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
    public class InvoiceModelMapper : Profile
    {
        public InvoiceModelMapper()
        {
            CreateMap<Invoice, InvoiceDto>();
            CreateMap<InvoiceDto, Invoice>()
                .ForMember(dst => dst.Custumer, opt => opt.MapFrom((frm, dst) => frm.Custumer.ToUpper()));
        }
    }
}
