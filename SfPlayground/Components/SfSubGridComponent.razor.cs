using Microsoft.AspNetCore.Components;
using SfPlayground.Models;
using Syncfusion.Blazor.Grids;

namespace SfPlayground.Components;

public partial class SfSubGridComponent : ComponentBase
{
    [Parameter] public long ProjectPropertyAutoId { get; set; }
    [Parameter] public List<Property> Properties { get; set; } = new();
    [Parameter] public string? ParentGridState { get; set; }

    private SfGrid<Property>? _grid;
    private int _gridStateHashCode;

    private List<Property>? _projectProperties;
    private List<Property> ProjectProperties
    {
        get
        {
            _projectProperties ??= Properties.Where(p => p.ProjectPropertyAutoId == ProjectPropertyAutoId).ToList();

            return _projectProperties ?? new();
        }
    }

    protected override async Task OnParametersSetAsync()
    {
        if (ParentGridState?.GetHashCode() != _gridStateHashCode && _grid != null)
        {
            _gridStateHashCode = ParentGridState?.GetHashCode() ?? 0;
            await _grid.SetPersistDataAsync(ParentGridState);
            StateHasChanged();
        }

        await base.OnParametersSetAsync();
    }

    private async Task OnLoadEventHandlerAsync(object args)
    {
        if (!string.IsNullOrEmpty(ParentGridState))
        {
            await _grid!.SetPersistDataAsync(ParentGridState);
        }
    }

    private void OnRowDataBound(RowDataBoundEventArgs<Property> args)
    {
        if (args.Data?.TypeId != 21 || Properties.All(p => p.ProjectPropertyAutoId != args.Data.PropertyAutoId))
        {
            args.Row.AddClass(new[] { "e-detail-disable" });
        }
    }
}
