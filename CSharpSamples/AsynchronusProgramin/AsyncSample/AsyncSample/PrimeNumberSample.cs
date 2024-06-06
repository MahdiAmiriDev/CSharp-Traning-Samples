using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsyncSample
{
    public class PrimeNumberSample
    {
        private int GetPrimeNumberCount(int startFrom, int count)
        {
            return Enumerable.Range(startFrom, count).Count(c =>
                Enumerable.Range(2, (int)(Math.Sqrt(c) - 1)).All(d => c % d != 0));
        }

        private Task<int> GetPrimeNumberCountAsync(int startFrom, int count)
        {
            return Task.Run(() => Enumerable.Range(startFrom, count).Count(c =>
                Enumerable.Range(2, (int)(Math.Sqrt(c) - 1)).All(d => c % d != 0)));
        }

        public void DisplayPrimeNumV1()
        {
            int count = 2_000_000;
            for (int i = 0; i < 10; i++)
            {
                int start = i * count + 2;
                int itemCount = count - 3;

                Console.WriteLine($"there are {GetPrimeNumberCount(start, count)} between {start} and {start + itemCount}");
            }
        }

        public void DisplayPrimeNumV2()
        {
            int count = 2_000_000;
            for (int i = 0; i < 10; i++)
            {
                int start = i * count + 2;
                int itemCount = count - 3;

                Console.WriteLine($"there are {GetPrimeNumberCountAsync(start, count)} between {start} and {start + itemCount}");
            }
        }

        public void DisplayPrimeNumV3()
        {
            int count = 1_000_000;
            for (int i = 0; i < 10; i++)
            {
                int start = i * count + 2;
                int itemCount = count - 3;
                var awaiter = GetPrimeNumberCountAsync(start, count).GetAwaiter();

                awaiter.OnCompleted(() =>
                {
                    Console.WriteLine($"there are {awaiter.GetResult()} between {start} and {start + itemCount}");
                });
            }
        }

        public async void DisplayPrimeNumV4()
        {
            int count = 1_000_000;
            for (int i = 0; i < 10; i++)
            {
                int start = i * count + 2;
                int itemCount = count - 3;
                Console.WriteLine($"there are {await GetPrimeNumberCountAsync(start, count)} between {start} and {start + itemCount}");
            }
        }
    }
}
