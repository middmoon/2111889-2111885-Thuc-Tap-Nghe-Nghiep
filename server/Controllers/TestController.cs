using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace server.Controllers
{
  [ApiController]
  [Route("api/test")]
  public class TestController : ControllerBase
  {
    [HttpGet]
    public string Test()
    {
      return "Hello World";
    }

    [Authorize]
    [HttpGet("protected")]
    public string TestProtected()
    {
      return "Hello World TestProtected";
    }

    [Authorize(Policy = "Admin")]
    [HttpGet("protected/admin")]
    public string TestProtectedAdmin()
    {
      return "Hello World TestProtected -- only admin can access";
    }

    [Authorize(Policy = "Writer")]
    [HttpGet("protected/writer")]
    public string TestProtectedWriter()
    {
      return "Hello World TestProtected -- admin and writer can access";
    }

    [Authorize(Policy = "Reader")]
    [HttpGet("protected/reader")]
    public string TestProtectedReader()
    {
      return "Hello World TestProtected -- admin, writer and reader can access";
    }
  }
}
