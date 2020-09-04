using System;
using System.ComponentModel.DataAnnotations;

namespace API.Models
{
    public enum Day
    {
        Sunday, Monday, Tuesday, WEdnesday, Thursday, Friday, Saturday
    }
    public class DealerOperatingHour
    {
        [Key]
        public int DealerOperatingHourId { get; set; }
        
        [Required]
        public Day DayOfTheWeek { get; set; }
        
        [Required]
        public TimeSpan OpeningTime { get; set; }
        
        [Required]
        public TimeSpan ClosingTime { get; set; }

        public DealerInfo DealerInfo { get; set; }
    }
}