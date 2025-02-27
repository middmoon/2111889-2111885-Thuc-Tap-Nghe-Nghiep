using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using server.Data;
using server.Models;
using server.Services;
using System;
using System.Linq;

namespace server.Controllers
{
  [Route("api/auth")]
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

    [HttpPost("register")]
    public IActionResult Register([FromBody] RegisterModel model)
    {
      // Check if user already exists
      var existingUser = _context.Users
          .FirstOrDefault(u => u.Username == model.Username);

      if (existingUser != null)
      {
        return Conflict(new { Message = "Tài khoản đã tồn tại" });
      }

      var readerRole = _context.Roles.FirstOrDefault(r => r.Name == "reader");

      if (readerRole == null)
      {
        return Conflict(new { Message = "Không có vai trò reader nào được tạo trước" });
      }

      // Create new user
      var passwordHasher = new PasswordHasher<User>();
      var newUser = new User
      {
        Username = model.Username,
        PasswordHash = passwordHasher.HashPassword(null, model.Password)
      };

      // Start a transaction to add user and assign role to user
      using (var transaction = _context.Database.BeginTransaction())
      {
        try
        {
          _context.Users.Add(newUser);
          _context.SaveChanges();


          var userRole = new UserRole { UserId = newUser.Id, RoleId = readerRole.Id };
          _context.UserRoles.Add(userRole);
          _context.SaveChanges();


          transaction.Commit();
        }
        catch (Exception ex)
        {
          transaction.Rollback();
          return StatusCode(500, new { Message = "Lỗi đăng ký tài khoản", Error = ex.Message });
        }
      }

      return Ok(new { User = newUser.Id, Roles = newUser.UserRoles.Select(ur => ur.Role.Name) });
    }


    [HttpPost("login")]
    public IActionResult Login([FromBody] LoginModel model)
    {
      var user = _context.Users
          .FirstOrDefault(u => u.Username == model.Username);

      if (user == null)
        return Unauthorized(new { Message = "Tài khoản chưa tồn tại" });

      if (!user.VerifyPassword(model.Password))
        return Unauthorized(new { Message = "Mật khẩu hoặc tài khoản không chính xác" });

      var userRoles = _context.UserRoles
        .Where(ur => ur.UserId == user.Id)
        .Select(ur => ur.Role.Name)
        .ToArray();

      var token = _authService.GenerateJwtToken(user, userRoles);

      return Ok(new { token = token });
    }
  }

  public class RegisterModel
  {
    public string Username { get; set; }
    public string Password { get; set; }
  }

  public class LoginModel
  {
    public string Username { get; set; }
    public string Password { get; set; }
  }
}