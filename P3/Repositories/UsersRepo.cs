using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using P3.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace P3.Repositories
{
    public class UsersRepo : IUsersRepo
    {
        private readonly MyDbContext dbcontext;

        public UsersRepo(MyDbContext _dbContext)
        {
            this.dbcontext = _dbContext;
        }

        public async Task<UserDetails> AddUser(UserDetails addUser)
        {
            if (dbcontext.UsersTable.Any(x => x.Email == addUser.Email)) { return null; }
            await dbcontext.UsersTable.AddAsync(addUser);
            await dbcontext.SaveChangesAsync();
            return addUser;

        }

        public  Task<List<UserDetails>> GetUsers()
        {
            return  dbcontext.UsersTable.ToListAsync();
        }
    }
}
