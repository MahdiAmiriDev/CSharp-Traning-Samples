using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace operators
{

    /// <summary>
    /// اور راید کردن عملگر جمع برای کلاس مانی
    /// </summary>
    public class OperatorOverload
    {        
        public class Money
        {
            private int _value;
            public Money(int value)
            {
                _value = value;
            }

            public int Value { get { return _value; } }

            public static Money operator +(Money v1 , Money v2) =>
                new Money(v1.Value + v2.Value);

        }

    }
}
