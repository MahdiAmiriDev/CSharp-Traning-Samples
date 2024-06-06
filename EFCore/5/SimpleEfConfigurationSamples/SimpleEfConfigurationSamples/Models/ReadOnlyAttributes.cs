using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleEfConfigurationSamples.Models
{
    //این جدول بدون کلید اصلی است
    [Keyless]
    public class ReadOnlyAttributes
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }

    public class ReadOnlyFluent
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
