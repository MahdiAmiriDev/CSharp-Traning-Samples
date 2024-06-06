namespace Sample.Thread
{
    public class CharPrinter
    {
        public void PrintStar()
        {
            for (int i = 0; i < 1000; i++)
            {
                Console.Write("$");

            }
        }

        public void PrintDash()
        {
            for (int i = 0; i < 1000; i++)
            {
                Console.Write("-");
                System.Threading.Thread.Sleep(TimeSpan.FromSeconds(5));
            }

            //Console.WriteLine($"thread name {System.Threading.Thread.CurrentThread.Name}" +
            //    $"is alive {System.Threading.Thread.CurrentThread.IsAlive}");
        }
    }
}
