using System;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using API.Data;
using MediatR;

namespace API.ApplicationHandlers
{
    public class EditDealer
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
            private readonly AppDataContext _context;
            public Handler(AppDataContext context)
            {
                _context = context;

            }

            public async Task<Unit> Handle(Dealer request, CancellationToken cancellationToken)
            {
                var dealer = await _context.DealerInfos.FindAsync(request.Id);

                if(dealer == null)
                    throw new Exception("Dealer info not found");

                dealer.Name =   request.Name ?? dealer.Name;
                dealer.Address1 =   request.Address1 ?? dealer.Address1;
                dealer.Address2 =   request.Address2 ?? dealer.Address2;
                dealer.City =   request.City ?? dealer.City;
                dealer.PostCode =   request.PostCode ?? dealer.PostCode;

                var success = await _context.SaveChangesAsync() > 0;

                if(success) return Unit.Value;

                throw new Exception("Problem saving changes");    
            }
        }
    }
}