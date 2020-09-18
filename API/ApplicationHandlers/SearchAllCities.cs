using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using API.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace API.ApplicationHandlers
{
    public class SearchAllCities
    {

        public class Query : IRequest<List<string>>
        {
            public string City { get; set; }
        }

        public class Handler : IRequestHandler<Query, List<string>>
        {
            private readonly AppDataContext _context;
            public Handler(AppDataContext context)
            {
                _context = context;

            }
            public async Task<List<string>> Handle(Query request, CancellationToken cancellationToken)
            {
                return await _context.DealerInfos.Select(p => p.City).Distinct().ToListAsync();
            }
        }
    }
}