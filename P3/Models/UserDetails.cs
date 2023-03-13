using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace P3.Models
{
    public class UserDetails
    {
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int UserId { get; set; }

        [Required]
        public string Name{ get; set; }

        [Required]
        public string Email { get; set; }
        [Required]
        [StringLength(20, MinimumLength = 8, ErrorMessage = " Password should be minimum 8 characters !")]
        public string Password { get; set; }
        [Required]
        public string Phone { get; set; }

       //public ICollection<TicketDetails> TicketDetails { get; set; }

    }
}
