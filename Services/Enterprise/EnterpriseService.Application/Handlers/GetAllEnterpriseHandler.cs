using AutoMapper;
using EnterpriseService.Application.Commands;
using EnterpriseService.Application.Queries;
using EnterpriseService.Application.Reponses;
using EnterpriseService.Core.Entities;
using EnterpriseService.Core.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnterpriseService.Application.Handlers
{
    public class GetAllEnterpriseHandler : IRequestHandler<GetAllEnterpriseQuery, List<EnterpriseResponse>>
    {
        private readonly IEnterpriseRepository enterpriseRepository;
        private readonly IMapper mapper;

        public GetAllEnterpriseHandler(IEnterpriseRepository enterpriseRepository, IMapper mapper)
        {
            this.enterpriseRepository = enterpriseRepository;
            this.mapper = mapper;
        }
        public async Task<List<EnterpriseResponse>> Handle(GetAllEnterpriseQuery request, CancellationToken cancellationToken)
        {
            var data = await enterpriseRepository.GetAll();

            return mapper.Map<List<EnterpriseResponse>>(data);
        }
    }
}
