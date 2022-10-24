using Application.IServices;
using Application.Services;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using RectangleAnalyzerWebUI;

var builder = WebAssemblyHostBuilder.CreateDefault(args);

builder.Services.AddTransient<IRectAnalizer, RectAnalizer>();


builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

await builder.Build().RunAsync();
