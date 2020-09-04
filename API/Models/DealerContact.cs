using System.ComponentModel.DataAnnotations;

namespace API.Models
{
    public class DealerContact
    {
        [Key]
        public int DealerContactId { get; set; }
        
        [Required]
        [MaxLength(250)]
        public string Name { get; set; }
        
        [MaxLength(250)]
        public string Designation { get; set; }
        
        [Required]
        public string Email { get; set; }
        
        [Required]
        public string PhoneNumberStr { get; set; }
        
        public DealerInfo DealerInfo { get; set; }
    }
}