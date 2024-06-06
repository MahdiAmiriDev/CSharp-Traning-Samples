using AutoScanAttribute;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sample.Domain
{
    /// <summary>
    /// نمایش مربوط به یک مقدار در دیباگ
    /// نمایش کلاس پراکسی 
    /// غیرفعال کردن نمایش یک پروپرتی
    /// </summary>
    [DebuggerDisplay("name is {FirstName}")]
    [DebuggerTypeProxy(typeof(DebuggerProxyClass))]
    [CodeChangeHistory("mehdi amiri",isBug:false,Description ="test attr by mehdi")]
    public  class Person
    {
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        public string FirstName { get; set; } = "mahdi";
        [StringLength(100)]
        public string LastName { get; set; } = "amiri";
        public int Age { get; set; }

        public void Print()
        {
            Console.WriteLine($"{FirstName} {LastName}");
        }
    }

    [Serializable]
    public class Serializeable
    {

    }
}
