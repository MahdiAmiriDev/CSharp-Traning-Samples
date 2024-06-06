namespace Sample.Thread
{
    public class SharedAndLocalState
    {
        int j = 0;
        bool allowRight = true;
        private readonly static object _locker = new object();
        public void Start()
        {
            System.Threading.Thread t1 = new(SafeCheckSharedState);
            System.Threading.Thread t2 = new(SafeCheckSharedState);
            t1.Start();
            t2.Start();
        }

        public void Printer()
        {
            int counter = 10;
            for (int i = 0; j < counter; j++)
            {
                Console.Write("#");
            }
        }

        public void CheckShareState()
        {
            if (allowRight)
            {                
                Console.WriteLine("allow right");
                allowRight = false;
            }
        }
        /// <summary>
        /// استفاده از لاکر برای قفل کردن متد فقط برای انجام عملیات با یک ترد اجازه ورود ترد بعدی را نمی دهد
        /// </summary>
        public void SafeCheckSharedState()
        {
            lock (_locker)
            {
                if(allowRight)
                {                    
                    Console.WriteLine("my message");
                    allowRight = false;
                }
            }
        }
    }
}
