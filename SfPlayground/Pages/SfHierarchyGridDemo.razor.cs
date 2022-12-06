using System.Net.Http.Json;
using Microsoft.AspNetCore.Components;
using SfPlayground.Models;
using Syncfusion.Blazor.Grids;

namespace SfPlayground.Pages;

public partial class SfHierarchyGridDemo
{
    [Inject] private HttpClient? Http { get; set; }

    private List<Property> _mainProperties = new();
    private List<Property> _properties = new();
    private SfGrid<Property>? _grid;
    private string? _savedState;

    protected override async Task OnInitializedAsync()
    {
        _properties = await Http!.GetFromJsonAsync<List<Property>>("sample-data/properties.json") ?? new List<Property>();
        _mainProperties = _properties.Where(p => p.ProjectPropertyAutoId == null).ToList();

        base.OnInitialized();
    }

    private List<Property> GetProjectProperties(long projectPropertyAutoId)
    {
        return _properties.Where(p => p.ProjectPropertyAutoId == projectPropertyAutoId).ToList();
    }

    private void OnActionCompleted(ActionEventArgs<Property> args)
    {
        Console.WriteLine($"OnActionCompleted {args.RequestType}");
    }

    private void OnDetailDataBound(DetailDataBoundEventArgs<Property> args)
    {
        Console.WriteLine($"OnDetailDataBound {args.DetailElement?.ID}");
    }

    private void OnSubGridLoaded(object args)
    {
        Console.WriteLine($"OnSubGridLoaded {args}");
    }

    private void OnSubGridCreated(object args)
    {
        Console.WriteLine($"OnSubGridCreated {args}");
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
            var gridState = await Http!.GetStringAsync("sample-data/gridstate.json") ?? null;

            await _grid.SetPersistDataAsync(gridState);
            StateHasChanged();
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

    private void OnRowDataBound(RowDataBoundEventArgs<Property> args)
    {
        if (args.Data?.TypeId != 21 || !_properties.Any(p => p.ProjectPropertyAutoId == args.Data.PropertyAutoId))
        {
            args.Row.AddClass(new string[] { "e-detail-disable" });
        }
    }

    private async Task OnSaveStateClickedAsync()
    {
        if (_grid != null)
        {
            _savedState = await _grid.GetPersistDataAsync();
        }
    }
}
