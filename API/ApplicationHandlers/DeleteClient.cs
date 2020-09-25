using System;
using System.Threading;
using System.Threading.Tasks;
using API.Data;
using MediatR;

namespace API.ApplicationHandlers
{
    public class DeleteClient
    {
        public class Client : IRequest
        {
            public int Id { get; set; }
        }

        public class Handler : IRequestHandler<Client>
        {
            private readonly AppDataContext _context;
            public Handler(AppDataContext context)
            {
                _context = context;
            }
            public async Task<Unit> Handle(Client request, CancellationToken cancellationToken)
            {
                var client = await _context.DealerInfos.FindAsync(request.Id);

                if(client == null)
                    throw new Exception("Dealer info not found");

                _context.Remove(client);

                var success = await _context.SaveChangesAsync() > 0;

                if(success) return Unit.Value;

                throw new Exception("Problem saving changes");  
            }
        }
    }
}