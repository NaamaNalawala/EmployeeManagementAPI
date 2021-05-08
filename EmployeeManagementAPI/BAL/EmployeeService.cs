using EmployeeDataAccessLayer.DAL;
using EmployeeDataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagementAPI.BAL
{
    public class EmployeeService : IEmployeeService
    {
        IEmployeeDetails employee = new EmployeeDetails();

        public UpdateEmployeeResult AddOrUpdateEmployee(Employee emp, bool isUpdate, bool isDelete)
        {
            return employee.AddOrUpdateEmployee(emp, isUpdate, isDelete);
        }

        public List<Employee> GetAllEmployeeDetails()
        {
            return employee.GetUserProfileData(Guid.Empty);
        }

        public Employee GetEmployeeDetails(Guid id)
        {
            return employee.GetUserProfileData(id).First();
        }
    }
}
