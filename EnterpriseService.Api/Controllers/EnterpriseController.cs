using EnterpriseService.Application.Commands;
using EnterpriseService.Application.Common;
using EnterpriseService.Application.Interface;
using EnterpriseService.Application.MessageService.Publisher;
using EnterpriseService.Application.Queries;
using EnterpriseService.Application.Reponses;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net.WebSockets;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EnterpriseService.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EnterpriseController : ControllerBase
    {
        private readonly IMediator mediator;

        public EnterpriseController(IMediator mediator )
        {
            this.mediator = mediator;
        }
        // GET: api/<EnterpriseController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var query = new GetAllEnterpriseQuery();
            var data = await mediator.Send(query);
            return Ok(data);
        }

        // GET api/<EnterpriseController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<EnterpriseResponse>> Get(long id)
        {
            return await mediator.Send(new GetEnterpriseByIdQuery(id));
        }

        // POST api/<EnterpriseController>
        [HttpPost]
        public async Task<ActionResult<ServiceResponse>> Post([FromBody] AddEnterpriseCommand addEnterpriseCommand)
        {
            var response = await mediator.Send(addEnterpriseCommand);
          
            return Ok(response);
        }

        // PUT api/<EnterpriseController>/5
        [HttpPut]
        public async Task<ActionResult<ServiceResponse>> Put([FromBody] EditEnterpriseCommand editEnterpriseCommand)
        {
            var response = await mediator.Send(editEnterpriseCommand);
            return Ok(response);
        }

        // DELETE api/<EnterpriseController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<ServiceResponse>> Delete(long id)
        {
            var command = new DeleteEnterpriseCommand(id);
            var response = await mediator.Send(command);
            return Ok(response);
        }
    }
}
