using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using P3.Models;
using System;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Net.Sockets;
using System.Threading.Tasks;

namespace P3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TicketController : ControllerBase
    {
        private readonly MyDbContext context;
        public TicketController(MyDbContext _context)
        {
            context = _context;
        }

        [HttpGet]
        public async Task<IActionResult> GetTicketDetails()
        {
 //           var userId = 1;
 //           var products = await context.UsersTable.Join(context.TicketsTable,
 //               u => u.UserId,
 //           t => t.UserId,
 //       (u, t) => new
 //{
 //    UserId = u.UserId,
 //    Name = u.Name,
 //     }).Where(u=>u.UserId==userId)
 //.ToListAsync();

 //           return Ok(products);
            return Ok(await context.TicketsTable.ToListAsync());
        }
        [HttpPost]
        //[Route("{id:int}")]
        public async Task<IActionResult> Addnewticket(AddTicket addTicket/*,int id*/)
        {
            var ticket = new TicketDetails()
            {
                UserId = addTicket.UserId,
                PassengerName=addTicket.PassengerName,
                PassengerEmail=addTicket.PassengerEmail,
                PassengerPhone=addTicket.PassengerPhone,
                Airline=addTicket.Airline,
                Age= addTicket.Age,
                Gender=addTicket.Gender,
                From = addTicket.From,
                To = addTicket.To,
                DepartureDate = addTicket.DepartureDate,
                DepartureTime =addTicket.DepartureTime,
                ArrivalTime = addTicket.ArrivalTime,
                No_of_Passengers = addTicket.No_of_Passengers,
                //Class = addTicket.Class,
                Fare=addTicket.Fare,
                Flight_number=addTicket.Flight_number,
            };
            MailMessage message = new MailMessage();
            message.From = new MailAddress("aticket79@gmail.com");
            message.Subject = $"Your Ticket's Booked";
            message.To.Add(new MailAddress(ticket.PassengerEmail));
            message.Body = $"<html><body> <h3> {ticket.PassengerName},Welcome to AirTicket.com!</h3> <p>Your ticket from {ticket.From} to {ticket.To} is Booked succesfully.</p></body></html>";
            message.IsBodyHtml = true;

            var smtpClient = new SmtpClient("smtp.gmail.com")
            {
                Port = 587,
                Credentials = new NetworkCredential("aticket79@gmail.com", "qiwp turh muvt bkwi"),
                EnableSsl = true,
            };

            smtpClient.Send(message);

            await context.TicketsTable.AddAsync(ticket);
            await context.SaveChangesAsync();
            return Ok(ticket);
        }

        [HttpDelete]
        [Route("{id:Guid}")]
        public async Task<IActionResult> DeleteTicket(Guid id)
        {
            var ticket = await context.TicketsTable.FindAsync(id);

            MailMessage message = new MailMessage();
            message.From = new MailAddress("aticket79@gmail.com");
            message.Subject = $"Your Ticket's Cancelled";
            message.To.Add(new MailAddress(ticket.PassengerEmail));
            message.Body = $"<html><body> <h3> {ticket.PassengerName},Welcome to AirTicket.com!</h3> <p> TicketId : {ticket.TicketId}</p> <p>We regret to inform you that your ticket from {ticket.From} to {ticket.To} is cancelled.</p></body></html>";
            message.IsBodyHtml = true;

            var smtpClient = new SmtpClient("smtp.gmail.com")
            {
                Port = 587,
                Credentials = new NetworkCredential("aticket79@gmail.com", "qiwp turh muvt bkwi"),
                EnableSsl = true,
            };

            smtpClient.Send(message);

            if (ticket != null)
            {
                context.TicketsTable.Remove(ticket);
                await context.SaveChangesAsync();
                return Ok($"Tikcet {id} cancelled");
            }
            return NotFound();
        }

        [HttpGet]
        [Route("{id:int}")]
        public async Task<IActionResult> GetTicketByUSerId(int id)
        {
            var ticket = await context.TicketsTable.Where(x => x.UserId == id).ToListAsync();

            if (ticket.Count != 0)
            {
                return Ok(ticket);
            }
            return NotFound();
        }

        [HttpGet]
        [Route("{TicketId}")]
        public async Task<IActionResult> GetTicketByUSerId(Guid TicketId)
        {
            var ticket = await context.TicketsTable.FindAsync(TicketId);

            if (ticket != null)
            {
                return Ok(ticket);
            }
            return NotFound();
        }



    }
}
