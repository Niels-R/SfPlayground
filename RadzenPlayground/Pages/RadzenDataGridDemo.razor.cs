using System.Net.Http.Json;
using Microsoft.AspNetCore.Components;
using SfPlayground.Common.Models;

namespace RadzenPlayground.Pages;

public partial class RadzenDataGridDemo
{
    [Inject] private HttpClient? Http { get; set; }
    
    private List<WeatherForecast> _forecasts = new();
    
    protected override async Task OnInitializedAsync()
    {
        _forecasts = await Http!.GetFromJsonAsync<List<WeatherForecast>>("sample-data/weather.json") ?? new List<WeatherForecast>();

        await base.OnInitializedAsync();
    }
}