using System.Net.Http.Json;
using Microsoft.AspNetCore.Components;
using SfPlayground.Common.Models;
using Syncfusion.Blazor.Grids;

namespace SfPlayground.Pages;

public partial class SfGridDemo
{
    [Inject] private HttpClient? Http { get; set; }

    private List<WeatherForecast> _forecasts = new();
    private SfGrid<WeatherForecast>? _grid;
    private string? _savedState;

    protected override async Task OnInitializedAsync()
    {
        _forecasts = await Http!.GetFromJsonAsync<List<WeatherForecast>>("sample-data/weather.json") ?? new List<WeatherForecast>();

        await base.OnInitializedAsync();
    }

    private async Task OnLoadStateClicked()
    {
        if (_grid != null && !string.IsNullOrEmpty(_savedState))
        {
            await _grid.SetPersistDataAsync(_savedState);
            StateHasChanged();
        }
    }

    private async Task OnLoadStateFromJsonClicked()
    {
        if (_grid != null)
        {
            var gridState = await Http!.GetStringAsync("sample-data/gridstate.json");

            await _grid.SetPersistDataAsync(gridState);
            StateHasChanged();
        }
    }

    private async Task OnSaveStateClickedAsync()
    {
        if (_grid != null)
        {
            _savedState = await _grid.GetPersistDataAsync();
        }
    }

    private async Task OnResetClickedAsync()
    {
        if (_grid != null)
        {
            await _grid.ResetPersistDataAsync();
            StateHasChanged();
        }
    }
}