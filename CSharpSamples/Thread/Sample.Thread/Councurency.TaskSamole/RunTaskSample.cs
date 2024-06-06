namespace Councurency.TaskSamole
{
    public class RunTaskSample
    {
        public void Start()
        {
            Task result = Task.Run(() => PrintName());
            Console.WriteLine("finished");
            Console.WriteLine($"task status is {result.Status}");
            result.Wait();
            Console.WriteLine($"task status is {result.Status}");
            Console.WriteLine($"task status after wait {result.Status}");
        }

        public void PrintName()
        {
            Thread.Sleep(3000);
            Console.WriteLine("isBack: "+Thread.CurrentThread.IsBackground);
            Console.WriteLine("isPool: "+Thread.CurrentThread.IsThreadPoolThread);
            Console.WriteLine("mahdi amiri");
        }
        /// <summary>
        /// تسک فکتوری مناسب کار های طولانی
        /// </summary>
        public void FactoryTask()
        {
            Task Tfactory = Task.Factory.StartNew(() => PrintName(), TaskCreationOptions.LongRunning);
            Tfactory.Wait();
        }
        /// <summary>
        /// تسک کلد که به سرعت اجرا نمی شود تا استارت نکنیم و منتظر پایان هم می مانیم
        /// </summary>
        public void ColdTask()
        {
            Task coldTask = new Task(PrintName);
            coldTask.Start();
            coldTask.Wait();
        }
    }
}
