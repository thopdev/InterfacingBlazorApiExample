using System;
using System.Net.Http;
using System.Threading.Tasks;
using BlazorAPI.Client.Services;
using BlazorAPI.Shared.Interfaces;
using ImpromptuInterface;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;

namespace BlazorAPI.Client
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("app");

            builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress + "api/") });
            builder.Services.AddScoped<IHttpClientService, HttpClientService>();
            builder.Services.AddScoped(typeof(IDogEndpoint), serviceProvider =>
            {
                var httpService = serviceProvider.GetService<IHttpClientService>();
                return new DynamicHttpEndpoint<IDogEndpoint>(httpService).ActLike<IDogEndpoint>();
            });

            await builder.Build().RunAsync();
        }
    }
}
