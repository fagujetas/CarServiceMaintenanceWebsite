using System;
using System.Threading;
using System.Threading.Tasks;
using API.Data;
using MediatR;

namespace API.ApplicationHandlers
{
    public class EditClient
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
                _context = context;

            }
            public async Task<Unit> Handle(Client request, CancellationToken cancellationToken)
            {
                var client = await _context.ClientInfos.FindAsync(request.Id);

                if(client == null)
                    throw new Exception("Client info not found");

                client.FirstName =   request.FirstName ?? client.FirstName;
                client.LastName =   request.LastName ?? client.LastName;
                client.Address =   request.Address ?? client.Address;
                client.ContactNumber =   request.ContactNumber ?? client.ContactNumber;
                client.Email =   request.Email ?? client.Email;
                client.CarMake =   request.CarMake ?? client.CarMake;
                client.CarModel =   request.CarModel ?? client.CarModel;
                client.CarYear =   request.FirstName ?? client.CarYear;

                var success = await _context.SaveChangesAsync() > 0;

                if(success) return Unit.Value;

                throw new Exception("Problem saving changes");    
            }
        }
    }
}