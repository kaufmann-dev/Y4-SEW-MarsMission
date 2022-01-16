using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;

namespace marsmission {
    class Program {
        public static async Task Main(string[] args) {
            //RunAssignment1();
            await RunAssignment2();
        }

        public static void RunAssignment1()
        {
            var sent1 = new Thread(() => new Sentinel().Run());
            var sent2 = new Thread(() => new Sentinel().Run());
            var harv1 = new Thread(() => new Harvester().Run());
            var harv2 = new Thread(() => new Harvester().Run());
            var harv3 = new Thread(() => new Harvester().Run());
            var harv4 = new Thread(() => new Harvester().Run());
            
            sent1.Start();
            sent2.Start();
            harv1.Start();
            harv2.Start();
            harv3.Start();
            harv4.Start();
        }        
        
        public static async Task RunAssignment2() {
            // 1.Schritt: Starten Sie eine Zeitmessung.
            var stopwatch = Stopwatch.StartNew();
            
            // 2.Schritt: Instanzieren Sie einen Webclient
            var client = new WebClient();
                
            // 3.Schritt: Für folgedne URLs sollen die Daten heruntergeladen werden.
            // Das Laden der Daten soll parallel ausgeführt werden.
            
            var urls = new List<string>{
                "http://www.orf.at",
                "http://www.news.at"
            };

            var t1 = Task.Run(()=>client.DownloadHTML(urls[0]));
            var t2 = Task.Run(()=>client.DownloadHTML(urls[1]));
            var bruh = await Task.WhenAll(t1, t2);

            // 4.Schritt:Beenden Sie die Zeitmessung für den Download und geben
            // Sie die Daten in der Console aus.
            stopwatch.Stop();
            var time = stopwatch.ElapsedMilliseconds;
            Console.WriteLine($"Execution took {time} milliseconds");
            
            foreach (var x in bruh)
            {
                Console.WriteLine(x);
            }

        }
    }
}