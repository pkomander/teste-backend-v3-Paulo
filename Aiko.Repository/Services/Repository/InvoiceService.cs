using Aiko.Domain;
using Aiko.Dto;
using Aiko.Repository.Context;
using Aiko.Repository.Services.Interface;
using AutoMapper;
using FluentResults;

namespace Aiko.Repository.Services.Repository
{
    public class InvoiceService : IInvoiceService
    {

        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public InvoiceService(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<Result> AdicionarInvoice(InvoiceDto model)
        {
			try
			{
				if (model == null)
				{
					return Result.Fail("Invoice informado esta vazio!");
				}

                foreach (var item in model.Performances)
                {
                    var performance = _mapper.Map<Performance>(item);

                    var invoice = _mapper.Map<Invoice>(model);
                    //invoice.PerformanceId = performance.PerformanceId;
                    await _context.Invoices.AddAsync(invoice);
                }

                _context.SaveChanges();

                return Result.Ok();
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}
        }
    }
}
