using Core.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces
{
    public interface IAccountService
    {
        Task RegisterAsync(RegisterDTO userData);
        Task Login(string login, string password);
        Task Logout();
    }
}
