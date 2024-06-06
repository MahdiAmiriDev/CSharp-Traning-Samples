using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleEfConfigurationSamples.Models
{
    [Index(nameof(Name),IsUnique =true,Name ="ix_Nme_using_ttr")]
    public class IndexUsingAttributes
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }

    public class IndexUsingFluent
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool Filtred { get; set; }
    }
}
