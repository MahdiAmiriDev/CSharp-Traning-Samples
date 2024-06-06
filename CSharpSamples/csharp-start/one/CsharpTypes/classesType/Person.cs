using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace classesType
{
    internal class Person
    {
        private int age;
        public string firstName;
        private readonly int _myAge;

        private string _myFeild;


        public string GetMyFeild()
        {
            return _myFeild;
        }

        public void SetMyFeild(string value)
        {
            _myFeild = value;
        }

        public string LastName { get; set; }

        private string mypropFull;

        public string MyProperty
        {
            get { return mypropFull; }
            set { mypropFull = value; }
        }

        private string _lastName;

        public string LastNamem  
        {
            get { return _lastName; }
        }

        /// <summary>
        /// فیلد و پروپرتی رید آنلی به صورت سینتکس جدید
        /// </summary>
        private string myFatherName;
        public string FatherName => myFatherName ?? "test";


        public Person(int age)
        {
            _myAge = age;
        }


        //کلمه کلیدی init 
        // فقط در زمان این ایت یا زمان ایجاد اینستنس مقدار می گیرد
        public string MyInitProperty { get; init;}

    }
}
