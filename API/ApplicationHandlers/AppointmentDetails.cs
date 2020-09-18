using System.Threading;
using System.Threading.Tasks;
using API.Data;
using API.Models;
using MediatR;

namespace API.ApplicationHandlers
{
    public class AppointmentDetails
    {        
        public class Query : IRequest<AppointmentInfo>
        {
            public int Id { get; set; }
        }

        public class Handler : IRequestHandler<Query, AppointmentInfo>
        {
            private readonly AppDataContext _context;
            public Handler(AppDataContext context)
            {
                _context = context;
            }
            
            public async Task<AppointmentInfo> Handle(Query request, CancellationToken cancellationToken)
            {
                var dealer = await _context.AppointmentInfos.FindAsync(request.Id);

                return dealer;
            }
        }
    }
}