using Aiko.Dto;
using FluentResults;

namespace Aiko.Repository.Services.Interface
{
    public interface IInvoiceService
    {
        Task<Result> AdicionarInvoice(InvoiceDto model);
    }
}
