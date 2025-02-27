using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using server.Models;

namespace server.Controllers
{
  [ApiController]
  [Route("api/blog")]
  public class BlogController : ControllerBase
  {
    [HttpPost]
    public IActionResult Create([FromBody] Blog blog)
    {
      return Ok();
    }

    [HttpGet]
    public string Test()
    {
      return "Hello World";
    }
  }
}

public class Blog
{
  public int Id { get; set; }
  public string Title { get; set; }
  public string Content { get; set; }
  public User Author { get; set; }
  public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
  public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
}
