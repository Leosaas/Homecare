using AutoMapper;
using EnterpriseService.Application.Reponses;
using EnterpriseService.Infrastructure.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnterpriseService.Infrastructure.Mapper
{
    public class Mapping : Application.Mapping.Mapping
    {
        public Mapping() : base() 
        {
            //Application
      
            CreateMap<Core.Entities.Enterprise,Enterprise>().ReverseMap();
        }
    }
}
