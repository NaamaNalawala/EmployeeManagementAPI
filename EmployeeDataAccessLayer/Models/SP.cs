using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeeDataAccessLayer.Models
{
    class SP
    {
        private SP(string value) { Value = value; }

        public string Value { get; set; }

        public static SP SP_Get_EmployeeDetails { get { return new SP("SP_Get_EmployeeDetails"); } }
        public static SP SP_AddOrUpdate_EmployeeDetails { get { return new SP("SP_AddOrUpdate_EmployeeDetails"); } }

    }
    class CommonTypes
    {
        public enum SP_Result
        {
            Inserted,
            Updated,
            Deleted,
            Username_Exists,
            Other_Exception
        }
    }
}
