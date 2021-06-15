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
    }
    public class EmployeeForm
    {
        public List<Role> Roles { get; set; }
        public List<Designation> Designations { get; set; }
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

    public class Country
    {
        public string Name { get; set; }
        public Guid Id { get; set; }
        public List<State> States { get; set; }
    }
    public class State
    {
        public string Name { get; set; }
        public Guid Id { get; set; }
        public List<City> Cities { get; set; }
    }
    public class City
    {
        public string Name { get; set; }
        public Guid Id { get; set; }
    }
}
