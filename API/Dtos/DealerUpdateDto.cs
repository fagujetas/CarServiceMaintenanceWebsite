using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using API.Models;

namespace API.Dtos
{
    public class DealerUpdateDto
    {
        [Required]
        [MaxLength(250)]
        public string Name { get; set; }
        
        [Required]
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        
        [Required]
        public string City { get; set; }
        
        [Required]
        public string PostCode { get; set; }


        public ICollection<DealerContact> DealerContacts { get; set; }
        public ICollection<DealerOperatingHour> DealerOperatingHours { get; set; }
    }
}