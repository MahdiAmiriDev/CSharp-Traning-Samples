using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sample.Thread
{
    public class ExceptionHandle
    {
        /// <summary>
        /// مدیریت صحیح خطا های ترد باید در متد فراخوانی شده باشد نه بر روی خود ترد
        /// </summary>
        public void StartBad()
        {
            try
            {
                System.Threading.Thread badHandle = new(BadMehtod);
                badHandle.Start();
            }
            catch (Exception)
            {

                Console.WriteLine("erroe in bad");
            }

        }

        public void StartGood()
        {
            System.Threading.Thread good = new(GoodMehtod);
            good.Start();
        }

        public void BadMehtod()
        {
            throw new Exception("error code 033942");
        }

        public void GoodMehtod()
        {
            try
            {
                BadMehtod();
            }
            catch (Exception e)
            {

                Console.WriteLine(e.Message);
            }
        }
    }
}
