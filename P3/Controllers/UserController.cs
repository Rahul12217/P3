using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using P3.Models;
using P3.Repositories;
using System;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace P2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        public static int otp { get; set; }
        Random random = new Random();

        private readonly MyDbContext context;
        private readonly IUsersRepo userRepo;

        public UsersController(MyDbContext _context, IUsersRepo _usersRepo)
        {
            this.userRepo = _usersRepo;
            context = _context;
        }

        [HttpGet]
        public async Task<IActionResult> GetUsers()
        {
            var users = await userRepo.GetUsers();
            return Ok(users);
        }

        [HttpPost]
        public async Task<IActionResult> AddUser(AddUser addUser)
        {
            var user = new UserDetails()
            {
                Name = addUser.Name,
                Email = addUser.Email,
                Password = addUser.Password,
                Phone = addUser.Phone
            };

            user = await userRepo.AddUser(user);

            if(user != null)
            {
                MailMessage message = new MailMessage();
                message.From = new MailAddress("aticket79@gmail.com");
                message.Subject = $"{user.Name},Welcome to AirTicket.com!";
                message.To.Add(new MailAddress(user.Email));
                message.Body = $"<html><body> <h3> {user.Name},Welcome to AirTicket.com!</h3> <p>There’s a lot of world out there to explore, and your new account will help you do just that.</p></body></html>";
                message.IsBodyHtml = true;

                var smtpClient = new SmtpClient("smtp.gmail.com")
                {
                    Port = 587,
                    Credentials = new NetworkCredential("aticket79@gmail.com", "qiwp turh muvt bkwi"),
                    EnableSsl = true,
                };
                smtpClient.Send(message);
            }

            if(user == null) { return NotFound(); }

            return Ok(user);
        }

        [HttpPut]
        [Route("{id:int}")]
        public async Task<IActionResult> UpdateUser(int id, UpdateUser updateUser)
        {
            var user = await context.UsersTable.FindAsync(id);
            if (user != null)
            {
                user.Name = updateUser.UserName;
                user.Email = updateUser.Email;
                user.Password = updateUser.Password;
                user.Phone = updateUser.Phone;

                await context.SaveChangesAsync();
                return Ok(user);
            }
            return NotFound();
        }

        //otp generation
        [HttpPut]
        [Route("{email}")]
        public async Task<IActionResult> ChangePassword(string email)
        {
            var user = await context.UsersTable.Where(m => m.Email == email).ToListAsync();
            if (user.Count() != 0)
            {
                otp = random.Next(1000, 99999);
                MailMessage message = new MailMessage();
                message.From = new MailAddress("aticket79@gmail.com");
                message.Subject = $"{otp}";
                message.To.Add(new MailAddress(email));
                message.Body = $"<html><body> <h3> ,Welcome to Booking.com!</h3> <p>There’s a lot of world out there to explore, and your new account will help you do just that.</p></body></html>";
                message.IsBodyHtml = true;

                var smtpClient = new SmtpClient("smtp.gmail.com")
                {
                    Port = 587,
                    Credentials = new NetworkCredential("aticket79@gmail.com", "qiwp turh muvt bkwi"),
                    EnableSsl = true,
                };

                smtpClient.Send(message);


                return Ok(user);
            }

            return NotFound();
        }


        //Forgot password 
        [HttpPut]
        [Route("{user_otp:int},{email},{changePassword}")]
        public async Task<IActionResult> ForgotPassword(int user_otp, string email,string changePassword)
        {

            if(user_otp==otp){ 
                var user = await context.UsersTable.Where(m => m.Email == email).ToListAsync();
                if (user.Count() != 0)
                {
                    MailMessage message = new MailMessage();
                    message.From = new MailAddress("aticket79@gmail.com");
                    message.Subject = $"Password Changed";
                    message.To.Add(new MailAddress(email));
                    message.Body = $"<html><body> <h3> {changePassword}";
                    message.IsBodyHtml = true;

                    var smtpClient = new SmtpClient("smtp.gmail.com")
                    {
                        Port = 587,
                        Credentials = new NetworkCredential("aticket79@gmail.com", "qiwp turh muvt bkwi"),
                        EnableSsl = true,
                    };

                    smtpClient.Send(message);
                    user[0].Password = changePassword;
                    await context.SaveChangesAsync();
                    return Ok(user);
                }
            }
            return NotFound();
        }


        [HttpGet]
        [Route("{password}")]
        public async Task<IActionResult> GetUserByPassword(string password)
        {

            var user = await context.UsersTable.Where(m => m.Password == password).ToListAsync();
            if (user != null)
            {
                return Ok(user[0]);
            }
            return NotFound("User Not Found");

        }
        [HttpDelete]
        [Route("{id:int}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            var user = await context.UsersTable.FindAsync(id);
            if (user != null)
            {
                context.Remove(user);
                await context.SaveChangesAsync();
                return Ok($"User {id} deleted");
            }
            return NotFound();
        }

        [HttpGet]
        [Route("{email},{password}")]
        public async Task<IActionResult> Login(string email,string password)
        {
            //var user = await context.Users.FindAsync(id);
            var user = await context.UsersTable.Where(m => m.Email == email).ToListAsync();
            var pw = await context.UsersTable.Where(m => m.Password == password).ToListAsync();
            if (user.Count() != 0 && pw.Count() != 0)
            {
                return Ok(user[0]);
            }
            return NotFound();


        }
    }
}
