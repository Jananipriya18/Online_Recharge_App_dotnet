using dotnetapp.Models;
using System.Threading.Tasks;
using dotnetapp.Data;
using System.Collections.Generic;
using dotnetapp.Repositories;

namespace dotnetapp.Services
{
    public interface IUserService
    {
        Task<bool> RegisterAsync(User user);
        Task<string> LoginAsync(string username, string password);
    }
}   