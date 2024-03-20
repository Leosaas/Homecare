using EnterpriseService.Application.Reponses;
using EnterpriseService.Core.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnterpriseService.Application.Commands
{
    public class AddEnterpriseCommand : IRequest<ServiceResponse>
    {
        public long Id { get; set; }
        public AddEnterpriseCommand(long id) 
        {
            Id = id;
        }
    }
}
