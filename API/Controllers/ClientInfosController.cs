using System.Collections.Generic;
using System.Threading.Tasks;
using API.ApplicationHandlers;
using API.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/clientinfos")]
    [ApiController]
    public class ClientInfosController : ControllerBase
    {
        private readonly IMediator _mediator;
        public ClientInfosController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<List<ClientInfo>>> List()
        {
            return await _mediator.Send(new ClientList.Query());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ClientInfo>> Details(int id)
        {
            return await _mediator.Send(new ClientDetails.Query{Id = id});
        }

        [HttpPost]
        public async Task<ActionResult<Unit>> Create(CreateClient.Client client)
        {
            return await _mediator.Send(client);
        }
        
        [HttpDelete("{id}")]
        public async Task<ActionResult<Unit>> Delete(int id)
        {
            return await _mediator.Send(new DeleteClient.Client{Id = id});
        }
    }
}