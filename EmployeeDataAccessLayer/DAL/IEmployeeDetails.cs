using EmployeeDataAccessLayer.Models;
using System;
using System.Collections.Generic;

namespace EmployeeDataAccessLayer.DAL
{
    public interface IEmployeeDetails
    {
        List<Employee> GetUserDetails();
        List<Employee> GetUserProfileData(Guid empId);
        UpdateEmployeeResult AddOrUpdateEmployee(Employee emp, bool isUpdate, bool isDelete);
    }
}
