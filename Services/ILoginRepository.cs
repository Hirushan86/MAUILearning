using MAUILearning.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAUILearning.Services
{
    public interface ILoginRepository
    {
        Task<UserInfo> Login(string username, string password);
    }
}
