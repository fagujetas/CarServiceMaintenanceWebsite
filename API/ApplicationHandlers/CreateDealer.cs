using System;
using System.Threading;
using System.Threading.Tasks;
using API.Data;
using API.Models;
using MediatR;

namespace API.ApplicationHandlers
{
    public class CreateDealer
    {
        public class Dealer : IRequest
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public string Address1 { get; set; }
            public string Address2 { get; set; }
            public string City { get; set; }
            public string PostCode { get; set; }
        }

        public class Handler : IRequestHandler<Dealer>
        {
            private readonly DealerDataContext _context;
            public Handler(DealerDataContext context)
            {
                this._context = context;
            }

            public async Task<Unit> Handle(Dealer request, CancellationToken cancellationToken)
            {
                var dealer = new DealerInfo
                {
                    Id = request.Id,
                    Name = request.Name,
                    Address1 = request.Address1,
                    Address2 = request.Address2,
                    City = request.City,
                    PostCode = request.PostCode
                };

                _context.DealerInfos.Add(dealer);

                var success = await _context.SaveChangesAsync() > 0;

                if(success) return Unit.Value;

                throw new Exception("Problem saving changes");
            }
        }
    }
}