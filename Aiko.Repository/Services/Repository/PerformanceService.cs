using Aiko.Domain;
using Aiko.Dto;
using Aiko.Repository.Context;
using Aiko.Repository.Services.Interface;
using AutoMapper;
using FluentResults;
using Microsoft.EntityFrameworkCore;

namespace Aiko.Repository.Services.Repository
{
    public class PerformanceService : IPerformanceService
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public PerformanceService(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<Result> Adicionar(PerformanceDto model)
        {
            try
            {
                if (model == null)
                {
                    return Result.Fail("Performance informado esta vazio!");
                }

                var performance = _mapper.Map<Performance>(model);
                await _context.Performances.AddAsync(performance);
                _context.SaveChanges();

                return Result.Ok();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<List<PerformanceDto>> GetAll()
        {
            try
            {
                var request = await _context.Performances.ToListAsync();
                return _mapper.Map<List<PerformanceDto>>(request);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
