using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Hotel_Frontend.Services;
using Hotel_Frontend.Shared;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace Hotel_Frontend
{
    using HttpClientImpl;
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("#app");

            builder.Services
                .AddScoped(sp => new HttpClient {BaseAddress = new Uri(builder.HostEnvironment.BaseAddress)})
                .AddScoped<IHttpClientImpl, HttpClientImpl>()
                .AddScoped<IJsService, JsService>()
                .AddScoped<IAuthenticationService, AuthenticationService>()
                .AddScoped<IReservationService, ReservationService>()
                .AddScoped<AppState, AppState>();

            await builder.Build().RunAsync();
        }
    }
}
