using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SimpleEfConfigurationSamples.DataAccessLayer
{
    //کلاس برای تبدیل دلخواه ورودی به بانک و خروجی از بانک
    public class MyIntToStringConvertor : ValueConverter<int, string>
    {
        public MyIntToStringConvertor(): base(x => x.ToString(),c => int.Parse(c))
        {

        }
    }
}
