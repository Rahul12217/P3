using Microsoft.EntityFrameworkCore;

namespace P3.Models
{
    public class MyDbContext : DbContext
    {
        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options) { }


        public virtual DbSet<UserDetails> UsersTable { get; set; }
        public virtual DbSet<TicketDetails> TicketsTable { get; set; }

        public  DbSet<Flights> FlightTable { get; set; }
    }
}
