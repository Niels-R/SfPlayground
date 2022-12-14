using SfPlayground.Common.Models;
using Syncfusion.Blazor.Grids;

namespace SfPlayground.Pages;

public partial class SfGridScrollDemo
{
    private SfGrid<Comment>? _grid;
    private bool _isInitialRender;

    private void CreatedEventHandler()
    {
        //_isInitialRender = true;
        Console.WriteLine("CreatedEventHandler");
    }

    private void OnActionBeginEventHandler(ActionEventArgs<Comment> obj)
    {
        
        Console.WriteLine($"OnActionBeginEventHandler - {obj.Action} - {obj.RequestType}");
    }

    private void OnBatchAddEventHandler(BeforeBatchAddArgs<Comment> obj)
    {
        Console.WriteLine("OnBatchAddEventHandler");
    }

    private void OnLoadEventHandler()
    {
        Console.WriteLine("OnLoadEventHandler");
    }

    private void DataBoundEventHandler()
    {
        Console.WriteLine("DataBoundEventHandler");
    }

    private void OnDataBoundEventHandler(BeforeDataBoundArgs<Comment> obj)
    {
        Console.WriteLine($"OnDataBoundEventHandler");
    }

    private void RowDataBoundEventHandler(RowDataBoundEventArgs<Comment> obj)
    {
        Console.WriteLine($"RowDataBoundEventHandler - {obj.Data}");
    }
}