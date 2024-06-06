using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace classesType
{
    internal class Anonymoustype
    {

       public string AnonymousType()
        {
            //ایجاد یک نوع ناشناس و استفاده از آن
            var student = new
            {
                name = "ali",
                lastName = "mohammadi"
            };

            return $"{student.name} + {student.lastName}";
        }

    }
}
