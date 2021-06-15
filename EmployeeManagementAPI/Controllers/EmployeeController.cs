using EmployeeDataAccessLayer.Models;
using EmployeeManagementAPI.BAL;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Security.Claims;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EmployeeManagementAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;
        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }
        // GET: api/<EmployeeController>
        [HttpGet]
        public EmployeeWithFormDetails Get()
        {
            return _employeeService.GetAllEmployeeDetails();
        }

        // GET api/<EmployeeController>/5
        [HttpGet("{id}")]
        public Employee Get(Guid id)
        {
            return _employeeService.GetEmployeeDetails(id);
        }

        // POST api/<EmployeeController>
        [HttpPost]
        public IActionResult Post([FromBody] AddEmployeeRequest request)
        {
            try
            {
                if (User.IsInRole("admin") || User.IsInRole("superadmin"))
                {
                    Employee employee = new Employee
                    {
                        UserName = request.UserName,
                        Password = request.Password,
                        FirstName = request.FirstName,
                        LastName = request.LastName,
                        MiddleName = request.MiddleName,
                        City = request.City,
                        Address = request.Address,
                        ContactNum = request.ContactNum,
                        Gender = request.Gender,
                        DateOfBirth = request.DateOfBirth,
                        JoiningDt = request.JoiningDt,
                        RelievingDt = request.RelievingDt,
                        Education = request.Education,
                        UserImage = request.UserImage,
                        RoleId = request.RoleId,
                        DesignationId = request.DesignationId,
                        CreatedBy = User.FindFirst(ClaimTypes.NameIdentifier)?.Value,
                        ModifiedBy = User.FindFirst(ClaimTypes.NameIdentifier)?.Value,
                        EmailId = request.EmailId
                    };
                    return Ok(_employeeService.AddOrUpdateEmployee(employee, false, false));
                }
                return Forbid();
            }
            catch (Exception ex)
            {
                return StatusCode(500);
            }
        }

        // PUT api/<EmployeeController>
        [HttpPut]
        public IActionResult Put([FromBody] AddEmployeeRequest request)
        {
            try
            {
                if (User.IsInRole("admin") || User.IsInRole("superadmin"))
                {
                    if(request.Id == Guid.Empty || request.Id == null)
                    {
                        return BadRequest("Employee Id is necessary");
                    }
                    Employee employee = new Employee
                    {
                        Id = request.Id,
                        UserName = request.UserName,
                        Password = request.Password,
                        FirstName = request.FirstName,
                        LastName = request.LastName,
                        MiddleName = request.MiddleName,
                        City = request.City,
                        Address = request.Address,
                        ContactNum = request.ContactNum,
                        Gender = request.Gender,
                        DateOfBirth = request.DateOfBirth,
                        JoiningDt = request.JoiningDt,
                        RelievingDt = request.RelievingDt,
                        Education = request.Education,
                        UserImage = request.UserImage,
                        RoleId = request.RoleId,
                        DesignationId = request.DesignationId,
                        ModifiedBy = User.FindFirst(ClaimTypes.NameIdentifier)?.Value
                    };
                    return Ok(_employeeService.AddOrUpdateEmployee(employee, true, false));
                }
                return Forbid();
            }
            catch (Exception ex)
            {
                return StatusCode(500);
            }
        }

        // DELETE api/<EmployeeController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            try
            {
                if (User.IsInRole("admin") || User.IsInRole("superadmin"))
                {
                    Employee employee = new Employee
                    {
                        Id = id,
                        ModifiedBy = User.FindFirst(ClaimTypes.NameIdentifier)?.Value
                    };
                    return Ok(_employeeService.AddOrUpdateEmployee(employee, false, true));
                }
                return Forbid();
            }
            catch (Exception e)
            {
                return StatusCode(500);
            }
        }
    }
}
