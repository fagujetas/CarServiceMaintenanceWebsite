using System.Threading;
using System.Threading.Tasks;
using API.Data;
using API.Models;
using MediatR;

namespace API.ApplicationHandlers
{
    public class ClientDetails
    { 
        public class Query : IRequest<ClientInfo>
        {
            public int Id { get; set; }
        }

        public class Handler : IRequestHandler<Query, ClientInfo>
        {
            private readonly AppDataContext _context;
            public Handler(AppDataContext context)
            {
                _context = context;
            }            
            
            public async Task<ClientInfo> Handle(Query request, CancellationToken cancellationToken)
            {
                var client = await _context.ClientInfos.FindAsync(request.Id);

                return client;
            }
        }
    }
}