using System;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;

namespace CookAsync
{
    class Program
    {
        static void Main(string[] args)
        {
            var sw = Stopwatch.StartNew();

            Console.WriteLine($"Cook operation started.! Thread Id : {Thread.CurrentThread.ManagedThreadId}");

            MakeOmeletAsync().Wait();
            //MakeOmeletAsync().ConfigureAwait(false);
            //Task.WaitAll(MakeOmeletAsync());
            

            sw.Stop();
            var elapsedTime = sw.ElapsedMilliseconds;

            Console.WriteLine($"Cook operation completed.! in {sw.ElapsedMilliseconds} seconds.  Thread Id : {Thread.CurrentThread.ManagedThreadId}");

        }

        private static async Task<bool> MakeOmeletAsync()
        {

            Console.WriteLine($"Cook operation steps. started ! Thread Id : {Thread.CurrentThread.ManagedThreadId}");


            Console.WriteLine("-------");
            var FirstStepGroup = await BreakEggsAsync().ContinueWith(async _ =>
            {
                await ScrambleEggsAsync();
                await AddSaltAsync();
            }).ConfigureAwait(false);



            //Console.WriteLine("-------");
            //var FirstStepGroupAlternative = await BreakEggsAsync().ContinueWith(async _ =>
            //{
            //    await ScrambleEggsAsync();
            //    await AddSaltAsync();
            //}, TaskScheduler.FromCurrentSynchronizationContext());


            Console.WriteLine("-------");
            var SecondStepGroup = await PrepareCookerAsync().ContinueWith(async _ =>
            {
                await PreparePanAsync();
                await AddOilAsync();
                await PutEggsToPanAsync();

            }).ConfigureAwait(false);

            Console.WriteLine("-------");

            await Task.WhenAll(FirstStepGroup, SecondStepGroup);

            Console.WriteLine("-------");

            await CookFoodAsync();
            await ServeFoodAsync();

            Console.WriteLine("-------");

            Console.WriteLine($"Cook operation steps completed.! Thread Id : {Thread.CurrentThread.ManagedThreadId}");

            return true;

        }

        private static async Task BreakEggsAsync()
        {
            await Task.Delay(500);
            Console.WriteLine($"Eggs were broken Thread Id : {Thread.CurrentThread.ManagedThreadId}");
        }

        private static async Task ScrambleEggsAsync()
        {
            await Task.Delay(500);
            Console.WriteLine($"Eggs were scrambled Thread Id : {Thread.CurrentThread.ManagedThreadId}");
        }


        private static async Task AddSaltAsync()
        {
            await Task.Delay(500);
            Console.WriteLine($"Salt was added Thread Id : {Thread.CurrentThread.ManagedThreadId}");
        }

        private static async Task PrepareCookerAsync()
        {
            await Task.Delay(500);
            Console.WriteLine($"Cooker was prepared Thread Id : {Thread.CurrentThread.ManagedThreadId}");
        }

        private static async Task PreparePanAsync()
        {
            await Task.Delay(500);
            Console.WriteLine($"Pan was prepared Thread Id : {Thread.CurrentThread.ManagedThreadId}");
        }

        private static async Task AddOilAsync()
        {
            await Task.Delay(500);
            Console.WriteLine($"Oil was added Thread Id : {Thread.CurrentThread.ManagedThreadId}");
        }

        private static async Task PutEggsToPanAsync()
        {
            await Task.Delay(500);
            Console.WriteLine($"Eggs were putted to pan Thread Id : {Thread.CurrentThread.ManagedThreadId}");
        }

        private static async Task CookFoodAsync()
        {
            await Task.Delay(500);
            Console.WriteLine($"Food was cooked Thread Id : {Thread.CurrentThread.ManagedThreadId}");
        }

        private static async Task ServeFoodAsync()
        {
            await Task.Delay(500);
            Console.WriteLine($"Food was served Thread Id : {Thread.CurrentThread.ManagedThreadId}");
        }

    }
}
