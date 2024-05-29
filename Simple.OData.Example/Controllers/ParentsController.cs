using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Routing.Controllers;
using Simple.OData.Example.Data;
using Simple.OData.Example.Entities;

namespace Simple.OData.Example.Controllers;

[Route("api/odata/parents")]
[ApiController]
public class ParentsController(ApplicationDbContext context) : ODataController
{
    private readonly ApplicationDbContext _context = context;

    [HttpGet]
    [EnableQuery]
    public IActionResult GetAll()
    {
        return Ok(_context.Parents.AsQueryable());
    }

    [HttpGet("{key}")]
    [EnableQuery]
    public IActionResult GetSingle([FromRoute] string key)
    {
        return Ok(_context.Parents.FirstOrDefault(p => p.Key == key));
    }

    [HttpGet("{parentKey}/children")]
    [EnableQuery]
    public IActionResult GetChildren([FromRoute] string parentKey)
    {
        return Ok(_context.Children.Where(c => c.ParentKey == parentKey).AsQueryable());
    }
}
