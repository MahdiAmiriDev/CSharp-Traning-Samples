using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Collections
{
    public class Queue
    {
        //ساخت صف جدید
        Queue<string> q = new();

        //افزودن به صف
        public void Enqueue(string input) 
            =>  q.Enqueue(input);

        //خارج کردن از صف
        public void Dequeue() =>
           Console.WriteLine(q.Dequeue()); 

        //حلقه بر روی صف
        public void ListDequeue()
        {
            foreach (var item in q)
            {
                Console.WriteLine(item);
            }
        }

        public void Start()
        {
            Enqueue("one");
            Enqueue("two");
            Enqueue("three");
            Enqueue("four");
            Dequeue();
            Dequeue();
            Dequeue();
            Dequeue();
            Enqueue("one");
            Enqueue("two");
            Enqueue("three");
            Enqueue("four");
            ListDequeue();
        }
    }
}
