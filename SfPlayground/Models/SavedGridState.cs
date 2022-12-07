using System.Text.Json.Serialization;

namespace SfPlayground.Models;

public class SavedGridState
{
    [JsonIgnore]
    public long AutoId { get; set; }
    public string? Name { get; set; }
    public bool IsDefault { get; set; }
    public string? State { get; set; }
}