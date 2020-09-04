using System.Collections.Generic;
using API.Models;

namespace API.Dtos
{
    public class DealerReadDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string City { get; set; }
        public string PostCode { get; set; }


        public ICollection<DealerContact> DealerContacts { get; set; }
        public ICollection<DealerOperatingHour> DealerOperatingHours { get; set; }
    }
}