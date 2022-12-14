using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using SfPlayground;
using SfPlayground.Services;
using SfPlayground.Services.Interfaces;
using Syncfusion.Blazor;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped<IGridStateService, GridStateService>();

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddSyncfusionBlazor();
Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("NjQyMjQ0QDMyMzAyZTMxMmUzMG94OXlNcEgxQ3BRY1ZaMndYaVpaVGZlVXlKTm5qZ3lKYkhKdDdCNHBwUEk9");

await builder.Build().RunAsync();
