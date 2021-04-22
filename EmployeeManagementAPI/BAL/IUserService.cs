using EmployeeManagementAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagementAPI.BAL
{
    public interface IUserService
    {
        string IsValidUserCredentials(LoginRequest request);
        string GetUserRole(string username);
    }
}
