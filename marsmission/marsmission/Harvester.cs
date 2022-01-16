using System;
using System.Threading;

namespace marsmission {
    
    public class Harvester
    {
        public static SemaphoreSlim harv = new SemaphoreSlim(0);
        public static SemaphoreSlim wait = new SemaphoreSlim(2);
        public void Run() {
            while (true)
            {
                harv.Wait();
                Acknowledge();
                Sentinel.cont.Release();
                Harvest();

                wait.Wait();
                Store();
                wait.Release();
            }
        }
        
        
        private void Acknowledge(){
            Console.WriteLine("Acknowledging signal");
            Thread.Sleep(100);
        }
        private void Harvest(){
            Console.WriteLine("Harvesting resources");
            Thread.Sleep(1000);
        }
        private void Store(){
            Console.WriteLine("Storing resources"); 
            Thread.Sleep(200);
        }

    }
}