using Microsoft.AspNetCore.Mvc;
using server.Data;
using server.Models;
using server.Services;
using System.Linq;

namespace server.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class AuthController : ControllerBase
  {
    private readonly ApplicationDbContext _context;
    private readonly IAuthService _authService;

    public AuthController(ApplicationDbContext context, IAuthService authService)
    {
      _context = context;
      _authService = authService;
    }

    [HttpPost("login")]
    public IActionResult Login([FromBody] LoginModel model)
    {
      var user = _context.Users
          .FirstOrDefault(u => u.Username == model.Username && u.PasswordHash == model.Password); // Cần hash password thực tế

      if (user == null)
        return Unauthorized();

      var token = _authService.GenerateJwtToken(user);
      return Ok(new { Token = token });
    }
  }

  public class LoginModel
  {
    public string Username { get; set; }
    public string Password { get; set; }
  }
}