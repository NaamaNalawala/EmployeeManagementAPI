using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeeDataAccessLayer.Models
{
     public class Employee
    {
        public Guid Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public DateTime? JoiningDt { get; set; }
        public DateTime? RelievingDt { get; set; }
        public DateTime? CreatedDt { get; set; }
        public DateTime? ModifiedDt { get; set; }
        public string CreatedBy { get; set; }
        public string ModifiedBy { get; set; }
        public EmployeeProfile EmployeeProfile { get; set; }
        public string Role { get; set; }
        public string Designation { get; set; }



    }
}
