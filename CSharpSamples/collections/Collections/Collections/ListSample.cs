using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Collections
{
    public class ListSample
    {
        List<string> vs = new(100);

        //مقدار حافظه اشغال شده
        public void PrintCapacity() =>
            Console.WriteLine(vs.Capacity);

        // تعداد موجود در لیست
        public void PrintCount () =>
            Console.WriteLine(vs.Count);

        // افزودن عضو به لیست
        public void AddMember(string input) => 
            vs.Add(input);

        //افزودن ظرفیت به لیست
        public void EnsureCapacity() =>
             vs.EnsureCapacity(30);

        // حذف ظرفیت استفاده نشده لیست
        public void Trim() =>
            vs.TrimExcess();

        /// <summary>
        /// انواع متد های حذف برای کار با لیست ها
        /// </summary>
        /// <param name="input"></param>
        public void RemoveMember(string input)
        {
            vs.Remove(input);
            vs.RemoveAll(list => list.Contains(input));
            vs.RemoveAt(4);
            vs.RemoveRange(2, 3);
            vs.Clear();
        }

        public void InsrtToList()
        {
            vs.Insert(3, "test");
            vs.Find(x => x.Contains("test"));
            vs.FindAll(x => x.Contains("test"));
            ///ادامه دارد
        }

        public void AddRange()
        {

            List<string> stringList = new()
            {
                "one",
                "two",
                "thre"
            };

            vs.AddRange(stringList);
        }

        public void start()
        {
            //List<(string key, int value)> dayOfWeek = new()
            //{
            //    ("shanbe", 1),
            //    ("yekShanbe", 2),
            //    ("doShanbe", 3),
            //    ("seShanbe", 4),
            //    ("charShanbe", 5),
            //    ("panjShanbe", 6),
            //    ("jomeh", 7)
            //};

            //dayOfWeek.ForEach(x =>
            //{
            //    global::System.Console.WriteLine($"{x.key} {x.value}");
            //});

            //-----------------------------------------------------------------

            //ListSample listSample = new();

            //listSample.AddMember("hello");
            //listSample.PrintCount();
            //listSample.PrintCapacity();
            //listSample.AddMember("55");
            //listSample.PrintCount();
            //listSample.PrintCapacity();
            //listSample.AddMember("22");
            //listSample.PrintCount();
            //listSample.PrintCapacity();
            //listSample.AddMember("11");
            //listSample.PrintCount();
            //listSample.PrintCapacity();
            //listSample.AddMember("11666");
            //listSample.AddMember("5555");
            //listSample.PrintCount();
            //listSample.PrintCapacity();

        }
    }
}
