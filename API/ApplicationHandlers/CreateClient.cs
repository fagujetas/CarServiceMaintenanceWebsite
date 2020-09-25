using System;
using System.Threading;
using System.Threading.Tasks;
using API.Data;
using API.Models;
using MediatR;

namespace API.ApplicationHandlers
{
    public class CreateClient
    {
        public class Client : IRequest
        {
            public int Id { get; set; }
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public string Address { get; set; }
            public string ContactNumber { get; set; }
            public string Email { get; set; }
            public string CarMake { get; set; }
            public string CarModel { get; set; }
            public string CarYear { get; set; }
        }

        public class Handler : IRequestHandler<Client>
        {
            private readonly AppDataContext _context;
            public Handler(AppDataContext context)
            {
                this._context = context;
            }
            public async Task<Unit> Handle(Client request, CancellationToken cancellationToken)
            {
                var client = new ClientInfo
                {
                    Id = request.Id,
                    FirstName = request.FirstName,
                    LastName = request.LastName,
                    Address = request.Address,
                    ContactNumber = request.ContactNumber,
                    Email = request.Email,
                    CarMake = request.CarMake,
                    CarModel = request.CarModel,
                    CarYear = request.CarYear,
                };

                _context.ClientInfos.Add(client);

                var success = await _context.SaveChangesAsync() > 0;

                if (success) return Unit.Value;

                throw new Exception("Problem saving changes");
            }
        }
    }
}