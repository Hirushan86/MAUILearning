using MAUILearning.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAUILearning.Services
{
    public class LoginService : ILoginRepository
    {
        public Task<UserInfo> Login(string username, string password)
        {
            // Implement your login logic here
            // For example, authenticate the user with the provided credentials
            if (username == "admin" && password == "password")
            {
                // Successful login logic
                Console.WriteLine("Login successful!");
                var user = new UserInfo() { UserId = 1, UserName = "Hirushan De Silva" };
                return Task.FromResult(user);
            }
            else
            {
                // Failed login logic
                Console.WriteLine("Login failed!");
                return Task.FromResult<UserInfo>(null);
            }
        }
    }
}
