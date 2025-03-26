using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Aiko.Dto;
using FluentResults;

namespace Aiko.Repository.Services.Interface
{
    public interface IExtratoService
    {
        Task<Result> GerarExtrato(ExtratoRequest model);
    }
}
