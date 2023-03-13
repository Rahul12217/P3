using System.ComponentModel.DataAnnotations;

namespace P3.Models
{
    public class UpdateUser
    {
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public string Phone { get; set; }
    }
}
