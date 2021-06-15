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
            EmployeeDataAccessLayer.DAL.IEmployeeService employeeObj = new EmployeeRepository();
            List<Employee> employees = employeeObj.GetEmployees(Guid.Empty).Employees;
            Employee e = employees.Find(x => x.UserName == username);
            if (e != null && !string.IsNullOrEmpty(e.Role))
                return e.Role;
            return "";
        }

        public Dictionary<string, string> IsValidUserCredentials(LoginRequest request)
        {
            EmployeeDataAccessLayer.DAL.IEmployeeService employee = new EmployeeRepository();
            List<Employee> emp = employee.GetEmployees(Guid.Empty).Employees;
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
