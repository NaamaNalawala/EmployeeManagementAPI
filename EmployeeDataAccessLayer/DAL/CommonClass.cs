using System;
using System.Collections.Generic;
using System.Data;
using System.Reflection;
using System.Text;

namespace EmployeeDataAccessLayer.DAL
{
    class CommonClass
    {
        public static List<T> ConvertDataTable<T>(DataTable dt)
        {
            List<T> data = new List<T>();
            foreach (DataRow row in dt.Rows)
            {
                T item = GetItem<T>(row);
                data.Add(item);
            }
            return data;
        }
        public static T GetItem<T>(DataRow dr)
        {
            Type temp = typeof(T);
            T obj = Activator.CreateInstance<T>();

            foreach (DataColumn column in dr.Table.Columns)
            {
                foreach (PropertyInfo pro in temp.GetProperties())
                {
                    if (pro.Name == column.ColumnName)
                        pro.SetValue(obj, dr.IsNull(pro.Name) ? null : dr[pro.Name], null);
                    else
                        continue;
                }
            }
            return obj;
        }
    }
}
