using EmployeeDataAccessLayer.DAL;
using EmployeeDataAccessLayer.Models;
using EmployeeManagementAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagementAPI.BAL
{
    public class UserService : IUserService
    {
        public string GetUserRole(string username)
        {
            IEmployeeDetails employeeObj = new EmployeeDetails();
            List<Employee> employees = employeeObj.GetUserProfileData(Guid.Empty);
            Employee e = employees.Find(x => x.UserName == username);
            if (e != null && !string.IsNullOrEmpty(e.Role))
                return e.Role;
            return "";
        }

        public string IsValidUserCredentials(LoginRequest request)
        {
            IEmployeeDetails employee = new EmployeeDetails();
            List<Employee> emp = employee.GetUserProfileData(Guid.Empty);
            Employee e = emp.Find(x => x.UserName == request.UserName);
            if (e!=null && e.Password == request.Password)
            {
                return e.Role;
            }
            else return "invalidUser";
        }
    }
}
