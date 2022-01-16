using System;
using System.Threading;

namespace marsmission {
    public class Sentinel
    {
        public static SemaphoreSlim cont = new SemaphoreSlim(0);
        public void Run() {
            while(true)
            {
                ScanningSurface();
                
                Signal();
                Harvester.harv.Release();
                
                cont.Wait();
                
            }
        }
        
        private void ScanningSurface(){
            Console.WriteLine("Scanning Surface");
            Thread.Sleep(500);
        }
        private void Signal(){
            Thread.Sleep(800);
            Console.WriteLine("Found raw material");
        }

    }
}