using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json.Serialization;
namespace RestApiSample
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int BrandId { get; set; }

        //وقتی که نال است مقدار را به جی سون سریالایز نکن کاربرد در ای پی ای های که مقدار 
        // را به صورت جی سون به کاربر بر میگردانند
        [JsonIgnore(Condition =JsonIgnoreCondition.WhenWritingNull)]
        public Brand Brand { get; set; }
    }
}
