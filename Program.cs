using System;
using Microsoft.AspNetCore.Hosting;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore;

WebHost.CreateDefaultBuilder()
        .Configure(a =>
        {
            long counter = 0;
            Task.Run(() =>
            {
                while (true)
                {
                    var line = Console.ReadLine();
                    if (line == "clear")
                    {
                        Interlocked.Exchange(ref counter, 0);
                        GC.Collect();
                    }
                    Console.WriteLine("Counter at: " + counter);
                }
            });
            a.Use((_, _) =>
            {
                Interlocked.Increment(ref counter);
                return Task.CompletedTask;
            });
        }).Build().Run();
