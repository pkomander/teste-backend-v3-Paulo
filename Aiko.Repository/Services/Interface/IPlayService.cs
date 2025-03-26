using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Aiko.Dto;
using FluentResults;

namespace Aiko.Repository.Services.Interface
{
    public interface IPlayService
    {
        Task<Result> Adicionar(PlayDto model);
        Task<List<PlayDto>> GetAll();
    }
}
