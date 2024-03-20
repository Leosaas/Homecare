using EnterpriseService.Application.Reponses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnterpriseService.Application.Queries
{
    public class GetEnterpriseByIdQuery : IRequest<EnterpriseResponse>
    {
        public long Id { get; set; }
        public GetEnterpriseByIdQuery(long id) 
        {
            Id = id;
        }
    }
}
