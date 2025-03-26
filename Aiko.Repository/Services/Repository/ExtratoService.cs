using Aiko.Domain;
using Aiko.Dto;
using Aiko.Repository.Context;
using Aiko.Repository.Services.Interface;
using AutoMapper;
using FluentResults;
using Microsoft.EntityFrameworkCore;

namespace Aiko.Repository.Services.Repository
{
    public class ExtratoService : IExtratoService
    {

        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public ExtratoService(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<Result> GerarExtrato(ExtratoRequest model)
        {
            try
            {
                var query = _context.Invoices
                        .Include(i => i.Performances)
                        .ThenInclude(p => p.Play)
                        .OrderBy(o => o.Custumer).AsQueryable();

                if (!string.IsNullOrEmpty(model.Custumer))
                {
                    query = query.Where(w => w.Custumer.Contains(model.Custumer) || w.InvoiceId == model.InvoiceId);
                }
                else if (model.InvoiceId != null)
                {
                    query = query.Where(w => w.InvoiceId == model.InvoiceId);
                }
                else
                {
                    Result.Fail("Nao parametro de busca foi informado!");
                }

                var invoice = await query.FirstOrDefaultAsync();

                var processando = await ProcessandoInformacao(invoice);

                return Result.Ok().WithSuccess(new Success(processando.Successes.First().Message));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Result> ProcessandoInformacao(Invoice invoice)
        {
            try
            {
                double totalAmount = 0;
                var volumeCredits = 0;
                var result = string.Format("Statement for {0}\n", invoice.Custumer);

                foreach (var item in invoice.Performances)
                {
                    var play = item.Play;
                    var lines = play.Lines;

                    if (lines < 1000)
                        lines = 1000;

                    if (lines > 4000)
                        lines = 4000;

                    double thisAmount = lines * 10;

                    switch (play.Type)
                    {
                        case "tragedy":
                            if (item.Audience > 30)
                            {
                                thisAmount += 10.00 * (item.Audience - 30);
                            }
                            break;
                        case "comedy":
                            if (item.Audience > 20)
                            {
                                thisAmount += 100.00 + 5.00 * (item.Audience - 20);
                            }
                            thisAmount += 3.00 * item.Audience;
                            break;
                        case "histórico":
                            if (item.Audience > 30)
                            {
                                thisAmount += (10.00 * (item.Audience - 30)) + (100.00 + 5.00 * (item.Audience - 20));
                            }
                            thisAmount += 3.00 * item.Audience;
                            break;
                        default:
                            return Result.Fail("unknown type: " + play.Type);
                    }

                    volumeCredits += Math.Max(item.Audience - 30, 0);

                    if ("comedy" == play.Type)
                        volumeCredits += (int)Math.Floor((decimal)item.Audience / 5);

                    result += String.Format("  {0}: {1:C} ({2} seats)\n", play.Nome, Convert.ToDecimal(thisAmount / 100), item.Audience);
                    totalAmount += thisAmount;
                }

                result += String.Format("Amount owed is {0:C}\n", Convert.ToDecimal(totalAmount / 100));
                result += String.Format("You earned {0} credits\n", volumeCredits);

                return Result.Ok().WithSuccess(result);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
