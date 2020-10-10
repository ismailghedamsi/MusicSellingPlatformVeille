using System;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Blazored.LocalStorage;
using BlazorStrap;
using Syncfusion.Blazor;
using Blazor.Fluxor;

namespace MusicSellingApp.Client
{
    public class Program
    {
        public static async Task Main(string[] args)
        {  
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.Services.AddBlazoredLocalStorage();
            builder.RootComponents.Add<App>("app");
           
            builder.Services.AddScoped(sp =>
             new HttpClient
             {
                 BaseAddress = new Uri(builder.HostEnvironment.BaseAddress)
             });

            builder.Services.AddTransient(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
            builder.Services.AddBootstrapCss();
            builder.Services.AddSyncfusionBlazor();
            builder.Services.AddFluxor(options => options.UseDependencyInjection(typeof(Program).Assembly));
            await builder.Build().RunAsync();
        }
    }
}
