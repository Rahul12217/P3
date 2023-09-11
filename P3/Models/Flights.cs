using System;
using System.ComponentModel.DataAnnotations;

namespace P3.Models
{
    public class Flights
    {
        [Key]
        [Required]
        public string Flight_number { get; set; }

        [Required]
        public string Airline { get; set; }

        [Required]
        public string From { get;set; }

        [Required]
        public string To { get;set; }

        [Required]
        public DateTime DepartureDate { get; set; }

        [Required]
        public string DepartureTime { get; set; }

        [Required]
        public string ArrivalTime { get; set; }


        [Required]
        public string Fare { get; set; }

    }
}
