using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using API.Data;
using API.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace API.ApplicationHandlers
{
    public class SearchDealersByCity
    {
        public class Query : IRequest<List<DealerInfo>>
        {
            public string City { get; set; }
        }

        public class Handler : IRequestHandler<Query, List<DealerInfo>>
        {
            private readonly AppDataContext _context;
            public Handler(AppDataContext context)
            {
                _context = context;

            }
            public async Task<List<DealerInfo>> Handle(Query request, CancellationToken cancellationToken)
            {
                /*12 Sept 2020 fagujetas
                    NB: 
                    refer to https://docs.microsoft.com/en-us/ef/core/miscellaneous/async
                    and
                    https://stackoverflow.com/questions/43277868/entity-framework-core-contains-is-case-sensitive-or-case-insensitive
                */
                return await _context.DealerInfos
                                        .Where(x => 
                                            EF.Functions.Like(x.City.ToUpper(), string.Format("%{0}%", request.City)))
                                        .ToListAsync();
            }
        }
    }
}