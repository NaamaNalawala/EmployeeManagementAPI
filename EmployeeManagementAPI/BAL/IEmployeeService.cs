using EmployeeDataAccessLayer.Models;
using System;
using System.Collections.Generic;

namespace EmployeeManagementAPI.BAL
{
    public interface IEmployeeService
    {
        List<Employee> GetAllEmployeeDetails();
        Employee GetEmployeeDetails(Guid id);
        UpdateEmployeeResult AddOrUpdateEmployee(Employee emp, bool isUpdate, bool isDelete);
    }
}
