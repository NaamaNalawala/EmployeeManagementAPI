using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using EmployeeDataAccessLayer.Models;

namespace EmployeeDataAccessLayer.DAL
{
    public class EmployeeDetails:IEmployeeDetails 
    {
        public UpdateEmployeeResult AddOrUpdateEmployee(Employee emp, bool isUpdate, bool isDelete)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(ConnectionString.Value))
                {
                    using (SqlCommand cmd = new SqlCommand(SP.SP_AddOrUpdate_EmployeeDetails.Value, connection))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@empId", emp.Id);

                        cmd.Parameters.AddWithValue("@JoiningDt", GetValueIfNull(emp.JoiningDt));
                        
                        cmd.Parameters.AddWithValue("@RelievingDt", GetValueIfNull(emp.RelievingDt));

                        cmd.Parameters.AddWithValue("@UserName", GetValueIfNull(emp.UserName));
                        cmd.Parameters.AddWithValue("@Password", GetValueIfNull(emp.Password));
	                    cmd.Parameters.AddWithValue("@IsDeleted", isDelete);
                        cmd.Parameters.AddWithValue("@FirstName", GetValueIfNull(emp.FirstName));
                        cmd.Parameters.AddWithValue("@MiddleName", GetValueIfNull(emp.MiddleName));
	                    cmd.Parameters.AddWithValue("@LastName", GetValueIfNull(emp.LastName));
	                    cmd.Parameters.AddWithValue("@EmailId", GetValueIfNull(emp.EmailId));
	                    cmd.Parameters.AddWithValue("@Contact", GetValueIfNull(emp.ContactNum));
                        cmd.Parameters.AddWithValue("@Gender", GetValueIfNull(emp.Gender));
	                    cmd.Parameters.AddWithValue("@Address", GetValueIfNull(emp.Address));
	                    cmd.Parameters.AddWithValue("@City", GetValueIfNull(emp.City));
                        cmd.Parameters.AddWithValue("@DateOfBirth", GetValueIfNull(emp.DateOfBirth));
                        cmd.Parameters.AddWithValue("@Education", GetValueIfNull(emp.Education));
	                    cmd.Parameters.AddWithValue("@CreatedBy", GetValueIfNull(emp.CreatedBy));
	                    cmd.Parameters.AddWithValue("@ModifiedBy", GetValueIfNull(emp.ModifiedBy));
	                    cmd.Parameters.AddWithValue("@UserImage", GetValueIfNull(emp.UserImage));
                        cmd.Parameters.AddWithValue("@IsUpdate", isUpdate);
                        cmd.Parameters.AddWithValue("@profId", emp.ProfileId);
                        cmd.Parameters.AddWithValue("@roleId", GetValueIfNull(emp.RoleId));
                        cmd.Parameters.AddWithValue("@designationId", GetValueIfNull(emp.DesignationId));
                        SqlParameter returnParameter = cmd.Parameters.Add("RetVal", SqlDbType.Int);
                        returnParameter.Direction = ParameterDirection.ReturnValue;
                        cmd.Connection.Open();
                        cmd.ExecuteNonQuery();
                        cmd.Connection.Close();
                        var result = (CommonTypes.SP_Result)returnParameter.Value;
                        return new UpdateEmployeeResult
                        {
                            Result = result.ToString(),
                            isSuccess = (int)returnParameter.Value == 0 || (int)returnParameter.Value == 1 || (int)returnParameter.Value == 2 ? true : false
                        };
                    }
                }
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

        public List<Employee> GetUserDetails()
        {
            try
            {
                DataTable employeeDetails = new DataTable();
                using (SqlConnection connection = new SqlConnection(ConnectionString.Value))
                {
                    connection.Open();

                    String sql = "Select Id, JoiningDt, RelievingDt, CreatedDt, ModifiedDt, CreatedBy, ModifiedBy, UserName, Password from dbo.Employee WHERE IsDeleted=0";

                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        SqlDataAdapter adapter = new SqlDataAdapter(command);
                        adapter.Fill(employeeDetails);
                    }
                }
                List<Employee> employees = new List<Employee>();
                employees = CommonClass.ConvertDataTable<Employee>(employeeDetails);
                return employees;
            }
            catch (SqlException e)
            {
                throw e;
            }

        }
        public List<Employee> GetUserProfileData(Guid empId)
        {
            try
            {
                DataTable employeeDetails = new DataTable();
                using (SqlConnection connection = new SqlConnection(ConnectionString.Value))
                {
                    using (SqlCommand cmd = new SqlCommand(SP.SP_Get_EmployeeDetails.Value, connection))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@id", empId);
                        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                        adapter.Fill(employeeDetails);
                    }
                }
                List<Employee> employees = new List<Employee>();
                employees = CommonClass.ConvertDataTable<Employee>(employeeDetails);
                return employees;
            }
            catch (SqlException e)
            {
                throw e;
            }

        }

        public Object GetValueIfNull(Object obj)
        {
            if (obj == null)
            {
                return DBNull.Value;
            }
            else
                return obj;
        }
        
    }
}
