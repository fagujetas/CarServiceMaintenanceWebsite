using System;
using System.Threading;
using System.Threading.Tasks;
using API.Data;
using MediatR;

namespace API.ApplicationHandlers
{
    public class CancelOrDeleteAppointment
    {
        public class Appointment : IRequest
        {   
            public int Id { get; set; }
        }

        public class Handler : IRequestHandler<Appointment>
        {            
            private readonly AppDataContext _context;
            public Handler(AppDataContext context)
            {
                _context = context;
            }
            public async Task<Unit> Handle(Appointment request, CancellationToken cancellationToken)
            {
                var appointment = await _context.AppointmentInfos.FindAsync(request.Id);

                if(appointment == null)
                    throw new Exception("Appointment info not found");

                _context.Remove(appointment);

                var success = await _context.SaveChangesAsync() > 0;

                if(success) return Unit.Value;

                throw new Exception("Problem saving changes");  
            }
        }
    }
}