using System.Threading;
using System.Threading.Tasks;
using API.Data;
using API.Models;
using MediatR;

namespace API.ApplicationHandlers
{
    public class DealerDetails
    {
        public class Query : IRequest<DealerInfo>
        {
            public int Id { get; set; }
        }

        public class Handler : IRequestHandler<Query, DealerInfo>
        {
            private readonly DealerDataContext _context;
            public Handler(DealerDataContext context)
            {
                _context = context;
            }

            public async Task<DealerInfo> Handle(Query request, CancellationToken cancellationToken)
            {
                var dealer = await _context.DealerInfos.FindAsync(request.Id);

                return dealer;
            }
        }
    }
}