using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using P3.Models;
using System.ComponentModel.DataAnnotations;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace P3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FlightsController : ControllerBase
    {

        private readonly MyDbContext context;
        public FlightsController(MyDbContext _context)
        {
            context = _context;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await context.FlightTable.ToListAsync());
        }

        [HttpDelete]
        [Route("{flight}")]
        public async Task<IActionResult> DeleteUser(string flight)
        {
            if (context.FlightTable == null)
            {
                return NoContent();
            }
            var a = await context.FlightTable.FindAsync(flight);
            if (a != null)
            {
                context.FlightTable.Remove(a);
                await context.SaveChangesAsync();
                return Ok("Flight removed");
            }
            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> AddFlight(Flights addUser)
        {
            var user = new Flights()
            {
                Flight_number = addUser.Flight_number,
                Airline = addUser.Airline,
                From = addUser.From,
                To = addUser.To,
                DepartureDate= addUser.DepartureDate,
                Fare=addUser.Fare
            };
            await context.FlightTable.AddAsync(user);
            await context.SaveChangesAsync();
            return Ok(user);
        }

        [HttpPut]
        [Route("{flightnumber}")]
        public async Task<IActionResult> UpdateFlight(string flightnumber, Flights flight)
        {
            var a = await context.FlightTable.FindAsync(flightnumber);
            if (a != null)
            {
                a.Airline = flight.Airline;
                a.From = flight.From;
                a.To = flight.To;
                a.DepartureDate = flight.DepartureDate;
                a.Fare = flight.Fare;
                await context.SaveChangesAsync();
                return Ok(a);
            }
            return NotFound();
        }

        //[HttpDelete("{id}")]
        //public async Task<IActionResult> CancelFLight(string id)
        //{
    //        if (context.FlightTable == null)
    //        {
    //            return NoContent();
    //          }
        //    var flight = await context.FlightTable.FindAsync(id);
    //    if (flight != null)
    //    {
    //        context.FlightTable.Remove(flight);
    //        await context.SaveChangesAsync();
    //    }
    //    return NotFound();
    //}

}
}
