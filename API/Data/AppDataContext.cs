using API.Models;
using Microsoft.EntityFrameworkCore;

namespace API.Data
{
    public class AppDataContext : DbContext
    {
        public AppDataContext(DbContextOptions<AppDataContext> opt) : base(opt)
        {
            
        }
        
        //create representation of the model in the database
        public DbSet<DealerContact> DealerContacts { get; set; }
        public DbSet<DealerInfo> DealerInfos { get; set; }
        public DbSet<DealerOperatingHour> DealerOperatingHours { get; set; }

        //added 17 Sept 2020 for AppointmentInfo        
        public DbSet<AppointmentInfo> AppointmentInfos { get; set; }

        //added 25 Sept 2020 for ClientInfo        
        public DbSet<ClientInfo> ClientInfos { get; set; }
    }
}