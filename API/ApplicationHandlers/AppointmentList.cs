using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using API.Data;
using API.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace API.ApplicationHandlers
{
    public class AppointmentList
    {        
        public class Query : IRequest<List<AppointmentInfo>> { }

        public class Handler : IRequestHandler<Query, List<AppointmentInfo>>
        {
            private readonly AppDataContext _context;
            public Handler(AppDataContext context)
            {
                _context = context;

            }
            public async Task<List<AppointmentInfo>> Handle(Query request, CancellationToken cancellationToken)
            {
                var appointment = await _context.AppointmentInfos.ToListAsync();

                return appointment;
            }
        }
    }
}