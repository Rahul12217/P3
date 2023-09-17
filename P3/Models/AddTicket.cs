using System;
using System.ComponentModel.DataAnnotations;

namespace P3.Models
{
    public class AddTicket
    {
        public int UserId { get; set; }

        [Required]
        public string PassengerName { get; set; }

        [Required]
        public string PassengerEmail { get; set;}

        [Required] public string PassengerPhone { get;set; }
        [Required] public int Age { get; set; }

        [Required] public string Gender { get; set; }
        public string From { get; set; }
        public string To { get; set; }

        public string Airline { get; set; }
        public DateTime DepartureDate { get; set; }

        [Required]
        public string DepartureTime { get; set; }

        [Required]
        public string ArrivalTime { get; set; }
        public int No_of_Passengers { get; set; }

        public string Flight_number { get; set; }

        public string Fare { get; set; }

        //public string Class { get; set; }
    }
}
