using Microsoft.AspNetCore.Mvc;
using P3.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace P3.Repositories
{
    public interface IUsersRepo
    {
        Task<List<UserDetails>> GetUsers();
        Task<UserDetails> AddUser(UserDetails addUser);
    }
}
