using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleEfConfigurationSamples.Models
{
    public enum CustomerType
    {
        Gold,
        Silver
    }
    public class Customer
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public CustomerType CustomerType { get; set; }

        public int Age { get; set; }
    }
}
