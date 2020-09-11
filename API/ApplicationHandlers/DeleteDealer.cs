using System;
using System.Threading;
using System.Threading.Tasks;
using API.Data;
using MediatR;

namespace API.ApplicationHandlers
{
    public class DeleteDealer
    {
        public class Dealer : IRequest
        {   
            public int Id { get; set; }
        }

        public class Handler : IRequestHandler<Dealer>
        {
            private readonly DealerDataContext _context;
            public Handler(DealerDataContext context)
            {
                _context = context;
            }

            public async Task<Unit> Handle(Dealer request, CancellationToken cancellationToken)
            {
                var dealer = await _context.DealerInfos.FindAsync(request.Id);

                if(dealer == null)
                    throw new Exception("Dealer info not found");

                _context.Remove(dealer);

                var success = await _context.SaveChangesAsync() > 0;

                if(success) return Unit.Value;

                throw new Exception("Problem saving changes");        
            }
        }
    }
}