using Microsoft.AspNetCore.Components.Web;
using SfPlayground.Models;

namespace SfPlayground.Pages;

public partial class SfAutoCompleteStringDemo
{
    private string? _value;

    private readonly List<Country> _countries = new()
    {
        new() { Name = "Australia", Code = "AU" },
        new() { Name = "Belgium", Code = "BE" },
        new() { Name = "Bermuda", Code = "BM" },
        new() { Name = "Canada", Code = "CA" },
        new() { Name = "Cameroon", Code = "CM" },
        new() { Name = "Denmark", Code = "DK" }
    };

    private void OnClick(MouseEventArgs args)
    {
        _value = "BE";
    }
}