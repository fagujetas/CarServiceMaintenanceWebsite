using API.Models;
using Microsoft.EntityFrameworkCore;

namespace API.Data
{
    public class DealerDataContext : DbContext
    {
        public DealerDataContext(DbContextOptions<DealerDataContext> opt) : base(opt)
        {
            
        }
        
        //create representation of the model in the database
        public DbSet<DealerContact> DealerContacts { get; set; }
        public DbSet<DealerInfo> DealerInfos { get; set; }
        public DbSet<DealerOperatingHour> DealerOperatingHours { get; set; }
    }
}