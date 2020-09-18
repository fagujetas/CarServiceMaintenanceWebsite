using System.Collections.Generic;
using System.Threading.Tasks;
using API.ApplicationHandlers;
using API.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/dealerinfos")]
    [ApiController]
    public class DealerInfosController : ControllerBase
    {
        private readonly IMediator _mediator;
        public DealerInfosController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<List<DealerInfo>>> List()
        {
            return await _mediator.Send(new DealerList.Query());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<DealerInfo>> Details(int id)
        {
            return await _mediator.Send(new DealerDetails.Query{Id = id});
        }

        [HttpPost]
        public async Task<ActionResult<Unit>> Create(CreateDealer.Dealer dealer)
        {
            return await _mediator.Send(dealer);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Unit>> Edit(int id, EditDealer.Dealer dealer)
        {
            dealer.Id = id;
            return await _mediator.Send(dealer);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Unit>> Delete(int id)
        {
            return await _mediator.Send(new DeleteDealer.Dealer{Id = id});
        }

        //test
        [HttpGet("searchdealersbycity/{city}")]
        public async Task<ActionResult<List<DealerInfo>>> SearchDealersByCity(string city)
        {
            return await _mediator.Send(new SearchDealersByCity.Query{City = city});
        }

        [HttpGet("searchallcities")]
        public async Task<ActionResult<List<string>>> SearchAllCities()
        {
            return await _mediator.Send(new SearchAllCities.Query());
        }
    }
}