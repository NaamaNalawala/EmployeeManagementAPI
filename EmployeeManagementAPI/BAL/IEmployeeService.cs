using EmployeeDataAccessLayer.Models;
using System;
using System.Collections.Generic;

namespace EmployeeManagementAPI.BAL
{
    public interface IEmployeeService
    {
        EmployeeWithFormDetails GetAllEmployeeDetails();
        Employee GetEmployeeDetails(Guid id);
        UpdateEmployeeResult AddOrUpdateEmployee(Employee emp, bool isUpdate, bool isDelete);
    }
}
