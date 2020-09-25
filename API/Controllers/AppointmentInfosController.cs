using System.Collections.Generic;
using System.Threading.Tasks;
using API.ApplicationHandlers;
using API.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/appointmentinfos")]
    [ApiController]
    public class AppointmentInfosController : ControllerBase
    {
        private readonly IMediator _mediator;
        public AppointmentInfosController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<List<AppointmentInfo>>> List()
        {
            return await _mediator.Send(new AppointmentList.Query());
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<AppointmentInfo>> Details(int id)
        {
            return await _mediator.Send(new AppointmentDetails.Query{Id = id});
        }

        [HttpPost]
        public async Task<ActionResult<Unit>> Create(CreateAppointment.Appointment appointment)
        {
            return await _mediator.Send(appointment);
        }
        
        [HttpDelete("{id}")]
        public async Task<ActionResult<Unit>> CancelOrDelete(int id)
        {
            return await _mediator.Send(new CancelOrDeleteAppointment.Appointment{Id = id});
        }
    }
}