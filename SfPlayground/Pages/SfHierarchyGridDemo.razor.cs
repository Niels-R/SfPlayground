using System.Net.Http.Json;
using Microsoft.AspNetCore.Components;
using SfPlayground.Models;
using Syncfusion.Blazor.Grids;
using Action = Syncfusion.Blazor.Grids.Action;

namespace SfPlayground.Pages;

public partial class SfHierarchyGridDemo
{
    [Inject] private HttpClient Http { get; set; }

    private List<Property> _mainProperties = new();
    private List<Property> _properties = new();
    private SfGrid<Property>? _grid;
    private string? _gridState;

    protected override async Task OnInitializedAsync()
    {
        _properties = await Http!.GetFromJsonAsync<List<Property>>($"sample-data/properties.json?{Guid.NewGuid()}") ?? new List<Property>();
        _mainProperties = _properties.Where(p => p.ProjectPropertyAutoId == null).ToList();

        base.OnInitialized();
    }

    private async Task OnActionCompleted(ActionEventArgs<Property> args)
    {
        var actions = new List<Action> { Action.ColumnState, Action.Reorder };

        if (actions.Contains(args.RequestType))
        {
            _gridState = await _grid!.GetPersistDataAsync();
        }
    }

    private async Task OnResetClickedAsync()
    {
        if (_grid != null)
        {
            await _grid.ResetPersistDataAsync();
            _gridState = null;
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
}
