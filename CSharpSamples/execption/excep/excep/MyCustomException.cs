using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace excep
{
    public class MyCustomException:Exception
    {
        public int Id { get; set; }
        public string DefaultErrorMessage { get; set; } = "کاربر گرامی کمتر سوتی بده";

    }
}
