using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace inheritance.Interface
{
    public interface IMyFitstInterface
    {
        public void Test();
        public void Temp();
    }

    public class Implement : IMyFitstInterface
    {
        public void Temp()
        {
            Console.WriteLine("hello");
        }

        public void Test()
        {
            throw new NotImplementedException();
        }
    }
    //-----------------------------------------------------

    public interface ILogger
    {
        void Log(string message);

        public void Info(string message) => Console.WriteLine(message);
    }

    public class ConsoleLogger : ILogger
    {
        public void Log(string message)
        {
            Console.WriteLine(message);
        }

        public void Info(string message)
        {
            Console.WriteLine("implement");
        }
    }

}
