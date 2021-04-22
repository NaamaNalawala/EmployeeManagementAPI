using EmployeeDataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeeDataAccessLayer.DAL
{
    public interface IEmployeeDetails
    {
        List<Employee> GetUserDetails();
        List<Employee> GetUserProfileData(Guid empId);
    }
}
