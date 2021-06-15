using EmployeeDataAccessLayer.Models;
using System;
using System.Collections.Generic;

namespace EmployeeDataAccessLayer.DAL
{
    public interface IEmployeeService
    {
        EmployeeForm GetEmployeeFormDetails();
        EmployeeWithFormDetails GetEmployees(Guid empId);
        UpdateEmployeeResult AddOrUpdateEmployee(Employee emp, bool isUpdate, bool isDelete);
    }
}
