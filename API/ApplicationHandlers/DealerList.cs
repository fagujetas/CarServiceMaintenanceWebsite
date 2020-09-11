using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using API.Data;
using API.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace API.ApplicationHandlers
{
    public class DealerList
    {
        public class Query : IRequest<List<DealerInfo>> { }

        public class Handler : IRequestHandler<Query, List<DealerInfo>>
        {
            private readonly DealerDataContext _context;
            public Handler(DealerDataContext context)
            {
                _context = context;

            }
            public async Task<List<DealerInfo>> Handle(Query request, CancellationToken cancellationToken)
            {
                var dealers = await _context.DealerInfos.ToListAsync();

                return dealers;
            }
        }
    }
}