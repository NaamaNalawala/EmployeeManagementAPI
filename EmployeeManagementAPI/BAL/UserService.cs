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

        public Dictionary<string, string> IsValidUserCredentials(LoginRequest request)
        {
            IEmployeeDetails employee = new EmployeeDetails();
            List<Employee> emp = employee.GetUserProfileData(Guid.Empty);
            Employee e = emp.Find(x => x.UserName == request.UserName);
            Dictionary<string, string> result = new Dictionary<string, string>();
            if (e!=null && e.Password == request.Password)
            {
                result.Add("role", e.Role);
                result.Add("id", e.Id.ToString());
                result.Add("isValid", "true");
            }
            else
            {
                result.Add("role", null);
                result.Add("id", null);
                result.Add("isValid", "false");
            }
            return result;
        }
    }
}
