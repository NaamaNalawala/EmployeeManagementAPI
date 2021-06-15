using System;
using System.Collections.Generic;

namespace EmployeeDataAccessLayer.Models
{
    internal class QueryResult
    {
        public Guid RoleId { get; set; }
        public string RoleName { get; set; }
        public Guid DesignationId { get; set; }
        public string DesignationName { get; set; }
        public Guid EducationId { get; set; }
        public string EducationName { get; set; }
        public string EducationOtherDetails { get; set; }
    }
    public class EmployeeForm
    {
        public List<Role> Roles { get; set; }
        public List<Designation> Designations { get; set; }
        public List<Education> Education { get; internal set; }
    }

    public class Role
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
    }

    public class Designation
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
    }
    public class Education
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string OtherDetails { get; internal set; }
    }


}
