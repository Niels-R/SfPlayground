using SfPlayground.Services.Interfaces;

namespace SfPlayground.Services;

public class GridStateService : IGridStateService
{
    public event Action<string?>? OnParentGridStateChanged;

    public void ParentGridStateChanged(string? state)
    {
        OnParentGridStateChanged?.Invoke(state);
    }
}