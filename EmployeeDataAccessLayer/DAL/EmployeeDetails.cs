using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using EmployeeDataAccessLayer.Models;

namespace EmployeeDataAccessLayer.DAL
{
    public class EmployeeDetails:IEmployeeDetails 
    {
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
    }
}
