using Aiko.Domain;
using Aiko.Dto;
using Aiko.Repository.Context;
using Aiko.Repository.Services.Interface;
using AutoMapper;
using FluentResults;
using Microsoft.EntityFrameworkCore;

namespace Aiko.Repository.Services.Repository
{
    public class PlayService : IPlayService
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public PlayService(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<Result> Adicionar(PlayDto model)
        {
            try
            {
                if(model == null)
                {
                    return Result.Fail("Item informado esta vazio");
                }

                var play = _mapper.Map<Play>(model);
                await _context.Plays.AddAsync(play);
                _context.SaveChanges();
                
                return Result.Ok();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<List<PlayDto>> GetAll()
        {
            try
            {
                var request = await _context.Plays.ToListAsync();
                return _mapper.Map<List<PlayDto>>(request);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
