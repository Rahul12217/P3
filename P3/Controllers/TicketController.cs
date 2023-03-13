using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using P3.Models;
using System;
using System.Linq;
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
                From = addTicket.From,
                To = addTicket.To,
                DepartureDate = addTicket.DepartureDate,
                No_of_Passengers = addTicket.No_of_Passengers,
                Class = addTicket.Class,
            };
            await context.TicketsTable.AddAsync(ticket);
            await context.SaveChangesAsync();
            return Ok(ticket);
        }

        [HttpDelete]
        [Route("{id:Guid}")]
        public async Task<IActionResult> DeleteTicket(Guid id)
        {
            var ticket = await context.TicketsTable.FindAsync(id);

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
                return Ok(ticket[0]);
            }
            return NotFound();
        }
    }
}
