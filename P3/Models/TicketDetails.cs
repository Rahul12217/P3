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
        public string From { get; set; }

        [Required]
        public string To { get; set; }

        [Required]
        public DateTime DepartureDate { get; set; }

        [Required]
        public string No_of_Passengers { get; set; }

        [Required]
        public string Class { get; set; }

        [Required]
        [ForeignKey("UserDetail")]
        public int UserId { get; set; }


        public virtual UserDetails UserDetail { get; set; }

    }
}
