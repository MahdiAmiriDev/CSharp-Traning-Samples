using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleEfConfigurationSamples.Models
{
    [Table("lambo_company",Schema ="ef2")]
    public class Car
    {
        public int CarId { get; set; }

        [Column("Lambo")]
        public string Name { get; set; }
    }

    public class TrainFluent
    {
        public int TrainId { get; set; }
        public string Name { get; set; }
    }
}
