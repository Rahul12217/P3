using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using P3.Models;
using System.ComponentModel.DataAnnotations;
using System;
using System.Linq;
using System.Threading.Tasks;
using P3.Migrations;

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
                DepartureDate = addUser.DepartureDate.Date,
                DepartureTime=addUser.DepartureTime,
                ArrivalTime=addUser.ArrivalTime,
                Fare = addUser.Fare
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
                a.DepartureDate = flight.DepartureDate.Date;
                a.Fare = flight.Fare;
                await context.SaveChangesAsync();
                return Ok(a);
            }
            return NotFound();
        }


        [HttpGet]
        [Route("{flight_number}")]
        public async Task<IActionResult> GetFlightbyNumber(string flight_number)
        {
            var ticket = await context.FlightTable.FindAsync(flight_number);
            //var ticket = await context.FlightTable.Where(x => x.Flight_number==flight_number || x.To.ToLower()==flight_number.ToLower()).ToListAsync();

            if (ticket != null)
            {
                return Ok(ticket);
            }
            return NotFound();
        }

        [HttpGet]
        [Route("{from}/{to}/{date}")]
        //[Route("{from}")]
        public async Task<IActionResult> GetFlightBylocation(string from, string to,DateTime date)
        {
            var source = await context.FlightTable.Where(x => x.From.ToLower() == from.ToLower() && x.To.ToLower() == to.ToLower() && x.DepartureDate == date).ToListAsync();
            if (source.Count != 0 )
            {
                return Ok(source);
            }

            //if (source.Count != 0)
            //{
            //    var flight = await context.FlightTable.Where(x => x.To == to).ToListAsync();
            //    if (flight.Count != 0)
            //    {
            //        return Ok(flight);
            //    }
            //}
            return NotFound();
        }

        //[HttpGet]
        //[Route("{to}")]
        //public async Task<IActionResult> GetFlightByTo(string to)
        //{
        //    var source = await context.FlightTable.Where(x => x.To.ToLower() == to.ToLower()).ToListAsync();
        //    if (source.Count != 0)
        //    {
        //        return Ok(source);
        //    }
        //    return NotFound();
        //}



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
