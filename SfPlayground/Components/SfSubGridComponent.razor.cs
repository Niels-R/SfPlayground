using Microsoft.AspNetCore.Components;
using SfPlayground.Models;
using Syncfusion.Blazor.Grids;

namespace SfPlayground.Components;

public partial class SfSubGridComponent : ComponentBase
{
    [Parameter] public long ProjectPropertyAutoId { get; set; }
    [Parameter] public List<Property> Properties { get; set; } = new();


    private List<Property>? _projectProperties;
    private List<Property> ProjectProperties
    {
        get
        {
            if (_projectProperties == null)
            {
                _projectProperties = Properties.Where(p => p.ProjectPropertyAutoId == ProjectPropertyAutoId).ToList();
            }

            return _projectProperties ?? new();
        }
    }

    private void OnLoadEventHandler(object args)
    {
        Console.WriteLine($"OnLoadEventHandler {args}");
    }

    private void OnRowDataBound(RowDataBoundEventArgs<Property> args)
    {
        if (args.Data?.TypeId != 21 || !Properties.Any(p => p.ProjectPropertyAutoId == args.Data.PropertyAutoId))
        {
            args.Row.AddClass(new string[] { "e-detail-disable" });
        }
    }
}
