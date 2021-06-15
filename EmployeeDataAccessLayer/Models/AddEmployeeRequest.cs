using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace EmployeeDataAccessLayer.Models
{
    public class AddEmployeeRequest
    {
        public Guid Id { get; set; }
        [Required]
        public string UserName { get; set; }
        [Required]
        public string Password { get; set; }
        public DateTime? JoiningDt { get; set; } = DateTime.Now;
        public DateTime? RelievingDt { get; set; }
        [Required]
        public Guid RoleId { get; set; }
        public Guid DesignationId { get; set; }
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
        public List<File> Files { get; set; }
    }

}
