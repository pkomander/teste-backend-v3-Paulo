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
    public class PerformanceModelMapper : Profile
    {
        public PerformanceModelMapper()
        {
            CreateMap<Performance, PerformanceDto>();
            CreateMap<PerformanceDto, Performance>()
                .ForMember(dst => dst.PlayId, opt => opt.MapFrom((frm, dst) => frm.PlayId))
                .ForMember(dst => dst.Play, opt => opt.Ignore());
        }
    }
}
