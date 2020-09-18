using System;
using System.ComponentModel.DataAnnotations;

namespace API.Models
{
    public class AppointmentInfo
    {
        [Key]
        public int AppointmentDataId { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        public string Address { get; set; }

        [Required]
        public string ContactNumber { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string CarMake { get; set; }

        [Required]
        public string CarModel { get; set; }

        [Required]
        public string CarYear { get; set; }

        [Required]
        public bool IsMaintenance { get; set; }
        
        [Required]
        public DateTime DateTimeOfAppointment { get; set; }
    }
}