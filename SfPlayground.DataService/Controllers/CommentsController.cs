using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Routing.Controllers;
using SfPlayground.Common.Models;

namespace SfPlayground.DataService.Controllers;

public class CommentsController : ODataController
{
    private static List<Comment>? _comments;

    public CommentsController(HttpClient httpClient)
    {
        _comments ??= httpClient.GetFromJsonAsync<List<Comment>>("https://jsonplaceholder.typicode.com/comments").Result ?? new List<Comment>();
    }
    
    [EnableQuery]
    public ActionResult Get()
    {
        Thread.Sleep(5000);
        
        return Ok(_comments);
    }

    [EnableQuery]
    public ActionResult Get([FromRoute] int id)
    {
        var comment = _comments?.SingleOrDefault(x => x.Id == id);

        return comment == null 
            ? NotFound() 
            : Ok(comment);
    }
}