using System.ComponentModel.DataAnnotations;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace P3.Models
{
    public class TicketDetails
    {
        [Key]
        public Guid TicketId { get; set; }

        [Required]
        public string PassengerName { get; set;}

        [Required]
        public string PassengerEmail { get;set;}

        [Required]
        public string PassengerPhone { get;set;}
        [Required] public int Age { get;set;}

        [Required] public string Gender { get;set;}

        [Required]
        public string From { get; set; }

        [Required]
        public string To { get; set; }

        public string Airline { get; set; }


        [Required]
        public DateTime DepartureDate { get; set; }

        [Required]
        public string DepartureTime { get; set;}

        [Required]
        public string ArrivalTime { get; set; }

        [Required]
        public int No_of_Passengers { get; set; }

        //[Required]
        //public string Class { get; set; }


        [Required]
        [ForeignKey("Flights")]
        public string Flight_number { get; set; }

        public Flights Flights { get; set; }

        [Required]
        public string Fare { get; set; }

        [Required]
        [ForeignKey("UserDetail")]
        public int UserId { get; set; }

        public virtual UserDetails UserDetail { get; set; }

    }
}
