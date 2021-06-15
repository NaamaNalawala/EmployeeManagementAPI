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
        EmployeeDataAccessLayer.DAL.IEmployeeService employee = new EmployeeRepository();

        public UpdateEmployeeResult AddOrUpdateEmployee(Employee emp, bool isUpdate, bool isDelete)
        {
            return employee.AddOrUpdateEmployee(emp, isUpdate, isDelete);
        }

        public EmployeeWithFormDetails GetAllEmployeeDetails()
        {
            return employee.GetEmployees(Guid.Empty);
        }

        public Employee GetEmployeeDetails(Guid id)
        {
            return employee.GetEmployees(id).Employees.First();
        }
    }
}
