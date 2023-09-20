using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;

long counter = 0;
_ = Task.Run(() =>
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

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.Run(_ =>
{
     Interlocked.Increment(ref counter);
     return Task.CompletedTask;
});

app.Run();
