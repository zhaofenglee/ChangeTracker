﻿using System;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Volo.Abp;
using Volo.Abp.Threading;

namespace JS.Abp.ChangeTracker;

class Program
{
    async static Task Main(string[] args)
    {
        using (var application = await AbpApplicationFactory.CreateAsync<ChangeTrackerConsoleApiClientModule>(options =>
        {
            var builder = new ConfigurationBuilder();
            builder.AddJsonFile("appsettings.json", false);
            builder.AddJsonFile("appsettings.secrets.json", true);
            options.Services.ReplaceConfiguration(builder.Build());
            options.UseAutofac();
        }))
        {
            await application.InitializeAsync();

            var demo = application.ServiceProvider.GetRequiredService<ClientDemoService>();
            await demo.RunAsync();

            Console.WriteLine("Press ENTER to stop application...");
            Console.ReadLine();

            await application.ShutdownAsync();
        }
    }
}