using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Aiko.Domain;
using Aiko.Dto;
using AutoMapper;

namespace Aiko.Repository.Helpers.Profiles
{
    public class PlayModelMapper : Profile
    {
        public PlayModelMapper()
        {
            CreateMap<Play, PlayDto>();
            CreateMap<PlayDto, Play>();
        }
    }
}
