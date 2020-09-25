using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using API.Data;
using API.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace API.ApplicationHandlers
{
    public class ClientList
    {
        public class Query : IRequest<List<ClientInfo>> { }

        public class Handler : IRequestHandler<Query, List<ClientInfo>>
        {
            private readonly AppDataContext _context;
            public Handler(AppDataContext context)
            {
                _context = context;
            }
            
            public async Task<List<ClientInfo>> Handle(Query request, CancellationToken cancellationToken)
            {
                var client = await _context.ClientInfos.ToListAsync();

                return client;
            }
        }
    }
}