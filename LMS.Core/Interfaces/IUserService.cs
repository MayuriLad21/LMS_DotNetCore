using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LMS.Models;

namespace LMS.Core.Interfaces
{
    public interface IUserService
    {
        User Authenticate(string username, string password);
    }
}
