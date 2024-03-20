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
    public class EditEnterpriseCommand : IRequest<ServiceResponse>
    {
        public long Id { get; set; }
        public EditEnterpriseCommand(long id) 
        {
            Id = id;
        }
    }
}
