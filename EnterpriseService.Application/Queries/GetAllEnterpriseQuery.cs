using EnterpriseService.Application.Reponses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnterpriseService.Application.Queries
{
    public class GetAllEnterpriseQuery : IRequest<List<EnterpriseResponse>>
    {
        public GetAllEnterpriseQuery() { }
    }
}
