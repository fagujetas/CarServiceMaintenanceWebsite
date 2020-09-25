using System;
using System.Threading;
using System.Threading.Tasks;
using API.Data;
using API.Models;
using MediatR;

namespace API.ApplicationHandlers
{
    public class CreateAppointment
    {
        public class Appointment : IRequest
        {
            public int AppointmentDataId { get; set; }
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public string Address { get; set; }
            public string ContactNumber { get; set; }
            public string Email { get; set; }
            public string CarMake { get; set; }
            public string CarModel { get; set; }
            public string CarYear { get; set; }
            public bool IsMaintenance { get; set; }
            public DateTime DateTimeOfAppointment { get; set; }
        }

        public class Handler : IRequestHandler<Appointment>
        {
            private readonly AppDataContext _context;
            public Handler(AppDataContext context)
            {
                this._context = context;
            }

            public async Task<Unit> Handle(Appointment request, CancellationToken cancellationToken)
            {
                if (request.DateTimeOfAppointment < DateTime.Now)
                {
                    throw new Exception("Date and time of appointment should be later than today's date and time");
                }
                else
                {
                    var appointment = new AppointmentInfo
                    {
                        FirstName = request.FirstName,
                        LastName = request.LastName,
                        Address = request.Address,
                        ContactNumber = request.ContactNumber,
                        Email = request.Email,
                        CarMake = request.CarMake,
                        CarModel = request.CarModel,
                        CarYear = request.CarYear,
                        IsMaintenance = request.IsMaintenance,
                        DateTimeOfAppointment = request.DateTimeOfAppointment
                    };

                    _context.AppointmentInfos.Add(appointment);

                    var success = await _context.SaveChangesAsync() > 0;

                    if (success) return Unit.Value;

                    throw new Exception("Problem saving changes");
                }
            }
        }
    }
}