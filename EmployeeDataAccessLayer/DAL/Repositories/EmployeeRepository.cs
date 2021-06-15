using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using EmployeeDataAccessLayer.Models;
using EmployeeDataAccessLayer.DAL.Services;
using EmployeeDataAccessLayer.DAL.Repositories;
using Dapper;
using System.Linq;
using static EmployeeDataAccessLayer.Models.CommonTypes;

namespace EmployeeDataAccessLayer.DAL
{
    public class EmployeeRepository:IEmployeeService 
    {
        readonly IDapper dapper = new Dapperr();
        public UpdateEmployeeResult AddOrUpdateEmployee(Employee emp, bool isUpdate, bool isDelete)
        {
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("@empId", emp.Id);
                parameters.Add("@JoiningDt", (emp.JoiningDt));
                parameters.Add("@RelievingDt", emp.RelievingDt);
                parameters.Add("@UserName", (emp.UserName));
                parameters.Add("@Password", (emp.Password));
                parameters.Add("@IsDeleted", isDelete);
                parameters.Add("@FirstName", emp.FirstName);
                parameters.Add("@MiddleName", (emp.MiddleName));
                parameters.Add("@LastName", (emp.LastName));
                parameters.Add("@EmailId", emp.EmailId);
                parameters.Add("@Contact", (emp.ContactNum));
                parameters.Add("@Gender", (emp.Gender));
                parameters.Add("@Address", (emp.Address));
                parameters.Add("@City", (emp.City));
                parameters.Add("@DateOfBirth", (emp.DateOfBirth));
                parameters.Add("@Education", (emp.Education));
                parameters.Add("@CreatedBy", (emp.CreatedBy));
                parameters.Add("@ModifiedBy", (emp.ModifiedBy));
                parameters.Add("@UserImage", (emp.UserImage));
                parameters.Add("@IsUpdate", isUpdate);
                parameters.Add("@profId", emp.ProfileId);
                parameters.Add("@roleId", (emp.RoleId));
                parameters.Add("@designationId", (emp.DesignationId));
                parameters.Add("@result", dbType: DbType.Int32, direction: ParameterDirection.ReturnValue);

                //var result = dapper.Get<int>(SP.SP_AddOrUpdate_EmployeeDetails.Value, parameters, CommandType.StoredProcedure);
                dapper.Execute<int>(SP.SP_AddOrUpdate_EmployeeDetails.Value, parameters,CommandType.StoredProcedure);
                var result = parameters.Get<int>("@result");
                return new UpdateEmployeeResult() {
                    Result = Enum.GetName(typeof(SP_Result), (SP_Result)Enum.ToObject(typeof(SP_Result),result)),
                    isSuccess = (int)result == 0 || (int)result == 1 || (int)result == 2 ? true : false
                };

            }
            catch (Exception ex)
            {
                return new UpdateEmployeeResult
                {
                    Result = null,
                    isSuccess = false
                };
            }
        }

        public EmployeeForm GetEmployeeFormDetails()
        {
            try
            {
                string sql = @"Select r.Id as RoleId, r.Name as RoleName, d.Id as DesignationId, d.Name as DesignationName, e.Id as EducationId, e.Name as EducationName, e.OtherDetails as EducationOtherDetails from  dbo.Roles r, dbo.Designation d, dbo.Education e; ";
                var result = dapper.GetAll<QueryResult>(sql, null, CommandType.Text);
                return new EmployeeForm() { 
                    Roles = result.GroupBy(x => new { x.RoleId, x.RoleName }).Select(x => new Role { Id = x.Key.RoleId, Name = x.Key.RoleName }).ToList(),
                    Designations = result.GroupBy(x => new { x.DesignationId, x.DesignationName }).Select(x => new Designation { Id = x.Key.DesignationId, Name = x.Key.DesignationName }).ToList(),
                    Education = result.GroupBy(x => new { x.EducationId, x.EducationName, x.EducationOtherDetails }).Select(x => new Education { Id = x.Key.EducationId, Name = x.Key.EducationName, OtherDetails = x.Key.EducationOtherDetails }).ToList()
                };
            }
            catch (SqlException e)
            {
                throw e;
            }

        }
        public EmployeeWithFormDetails GetEmployees(Guid empId)
        {
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("@id", empId);
                List<Employee> employees = dapper.GetAll<Employee>(SP.SP_Get_EmployeeDetails.Value, parameters, CommandType.StoredProcedure);
                EmployeeWithFormDetails details = new EmployeeWithFormDetails
                {
                    Employees = employees,
                    EmployeeFormDetails = GetEmployeeFormDetails()
                };
                return details;

            }
            catch (SqlException e)
            {
                throw e;
            }

        }
    }
}
