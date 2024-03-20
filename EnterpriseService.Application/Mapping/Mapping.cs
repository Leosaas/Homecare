using AutoMapper;
using EnterpriseService.Application.Reponses;
using EnterpriseService.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnterpriseService.Application.Mapping
{
    public class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<Enterprise, EnterpriseResponse>().ReverseMap();
        }
    }
}
