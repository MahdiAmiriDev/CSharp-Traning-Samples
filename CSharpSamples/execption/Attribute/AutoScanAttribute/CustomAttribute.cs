using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoScanAttribute
{
    [AttributeUsage(AttributeTargets.All)]
    public class AutoScanDependencyAttribute : Attribute
    {

    }

    /// <summary>
    /// ایجاد یک اتریبیوت کاستوم که به عنوان یک متا دیتا برای ما کار می کند
    /// </summary>

    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct |
        AttributeTargets.Method,AllowMultiple =true , Inherited =false)]
    public class CodeChangeHistoryAttribute : Attribute
    {
        private readonly string author;
        

        public string Description { get; set; }
        public DateTime ChangeDateTime { get; set; }
        public bool IsBug { get; }

        public CodeChangeHistoryAttribute(string author , bool isBug = false)
        {
            this.author = author;
            IsBug = isBug;
        }
    }
}
