// Program.cs

using Microsoft.Extensions.Hosting;
using RazorConsole.Core;
using RazorConsoleTest;

IHostBuilder hostBuilder = Host.CreateDefaultBuilder(args)
    .UseRazorConsole<Counter>();
IHost host = hostBuilder.Build();
await host.RunAsync();