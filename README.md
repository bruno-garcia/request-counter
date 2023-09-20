A server that does nothing but increment a counter. Hit any key to see the current hit count.

I use this to test the throughput of the HTTP transport of different clients.

With .NET 8 installed, you can build and run (in release):
```
dotnet run -c release
```

Example test run with `wrk`:
```
wrk -t1 -c10 -d60s http://localhost:5000/
```

On my laptop, while using it normally:
```
Running 1m test @ http://localhost:5000/
  1 threads and 10 connections
  Thread Stats   Avg      Stdev     Max   +/- Stdev
    Latency   120.50us   57.07us   7.40ms   99.50%
    Req/Sec    77.57k     5.37k   90.05k    72.55%
  4638227 requests in 1.00m, 406.95MB read
Requests/sec:  77174.36
Transfer/sec:      6.77MB
```