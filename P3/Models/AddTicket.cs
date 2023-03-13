using System;

namespace P3.Models
{
    public class AddTicket
    {
        public int UserId { get; set; }

        public string From { get; set; }
        public string To { get; set; }

        public DateTime DepartureDate { get; set; }

        public string No_of_Passengers { get; set; }

        public string Class { get; set; }
    }
}
