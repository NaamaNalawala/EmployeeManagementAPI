using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeeDataAccessLayer.DAL
{
    class GenericTypeEqualityComparer : IEqualityComparer<Type>
    {
        public bool Equals(Type x, Type y)
        {
            var a = x.IsGenericType ? x.GetGenericTypeDefinition() : x;
            var b = y.IsGenericType ? y.GetGenericTypeDefinition() : y;
            return a == b;
        }

        public int GetHashCode(Type obj)
        {
            return obj.Name.GetHashCode();
        }
    }
}
