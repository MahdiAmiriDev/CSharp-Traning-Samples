using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace classesType
{
    internal static class StaticClassEx
    {
        //اکستنشن متد برای تیچر ساخته شده
        public static string GetFullName(this Teacher ex)
        {
            return $"{ex.FirstName} -- {ex.LastName}";
        }
    }
}
