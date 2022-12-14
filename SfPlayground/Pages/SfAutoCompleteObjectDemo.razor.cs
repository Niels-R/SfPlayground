using Microsoft.AspNetCore.Components.Web;
using SfPlayground.Common.Models;

namespace SfPlayground.Pages;

public partial class SfAutoCompleteObjectDemo
{
    private Country? _value;

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
        _value = _countries.Find(x => x.Code == "BE");
    }
}