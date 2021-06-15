using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeeDataAccessLayer.Models
{
     public class Employee
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string UserName { get; set; }
        public string Password { get; set; }
        public DateTime? JoiningDt { get; set; } = DateTime.Now;
        public DateTime? RelievingDt { get; set; }
        public DateTime? CreatedDt { get; set; }
        public DateTime? ModifiedDt { get; set; }
        public string CreatedBy { get; set; }
        public string ModifiedBy { get; set; }
        public string Role { get; set; }
        public Guid RoleId { get; set; }
        public string Designation { get; set; }
        public Guid DesignationId { get; set; }
        public Guid ProfileId { get; set; } = Guid.NewGuid();
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string EmailId { get; set; }
        public long ContactNum { get; set; }
        public string Gender { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string Education { get; set; }
        public string UserImage { get; set; }
        public EmployeeForm EmployeeForm { get; set; }

    }
    public class EmployeeWithFormDetails
    {
        public List<Employee> Employees { get; set; }
        public EmployeeForm EmployeeFormDetails { get; set; }
    }
}
