using System.Text.Json;
using Radzen;
using Radzen.Blazor;
using SfPlayground.Common.Models;

namespace RadzenPlayground.Pages;

public partial class RadzenDataGridODataDemo
{
    private readonly CommentsService _service = new();

    private DataGridSettings? _gridSettings;
    private ODataEnumerable<Comment>? _comments;
    private RadzenDataGrid<Comment>? _grid;
    private bool _isLoading;
    private int _count;

    private DataGridSettings? _deserializedGridSettings;
    private string? _serializedGridSettings;

    private IEnumerable<int> SelectedPostIds;
    private IEnumerable<int> PostIds = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

    private async Task LoadData(LoadDataArgs args)
    {
        _isLoading = true;

        var result = await _service.GetComments(args.Filter, args.Top, args.Skip, args.OrderBy, null, null, true);
        _comments = result.Value.AsODataEnumerable();
        _count = result.Count;

        _isLoading = false;
    }

    private void SerializeGridSettings()
    {
        _serializedGridSettings = JsonSerializer.Serialize(_grid!.Settings);
    }

    private void DeserializeGridSettings()
    {
        if (_serializedGridSettings == null)
        {
            return;
        }

        _deserializedGridSettings = JsonSerializer.Deserialize<DataGridSettings>(_serializedGridSettings);
        _gridSettings = _deserializedGridSettings;
    }
}

public class CommentsService
{
    private readonly Uri _baseUri = new("http://localhost:5126/odata/");
    private readonly HttpClient _httpClient = new();

    public async Task<ODataServiceResult<Comment>> GetComments(string? filter = default, int? top = default, int? skip = default, string? orderby = default, string? expand = default, string? select = default, bool? count = default)
    {
        var uri = new Uri(_baseUri, "comments");
        uri = uri.GetODataUri(filter:filter, top:top, skip:skip, orderby:orderby, expand:expand, select:select, count:count);

        Console.WriteLine(uri.ToString());

        var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, uri);

        var response = await _httpClient.SendAsync(httpRequestMessage);

        return await response.ReadAsync<ODataServiceResult<Comment>>();
    }
}