namespace SfPlayground.Services.Interfaces;

public interface IGridStateService
{
    public event Action<string?>? OnParentGridStateChanged;

    public void ParentGridStateChanged(string? state);
}