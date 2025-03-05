using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using server.Data;
using server.Models;
using server.Services;
using System;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

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
    public async Task<IActionResult> Register([FromBody] RegisterModel model)
    {
      var existingUser = await _context.Users
          .FirstOrDefaultAsync(u => u.Username == model.Username);

      if (existingUser != null)
      {
        return Conflict(new { Message = "Tài khoản đã tồn tại" });
      }

      var readerRole = await _context.Roles.FirstOrDefaultAsync(r => r.Name == "reader");

      if (readerRole == null)
      {
        return Conflict(new { Message = "Không có vai trò reader nào được tạo trước" });
      }

      var passwordHasher = new PasswordHasher<User>();
      var newUser = new User
      {
        Username = model.Username,
        PasswordHash = passwordHasher.HashPassword(null, model.Password)
      };

      await using var transaction = await _context.Database.BeginTransactionAsync();
      try
      {
        await _context.Users.AddAsync(newUser);
        await _context.SaveChangesAsync();

        var userRole = new UserRole { UserId = newUser.Id, RoleId = readerRole.Id };
        await _context.UserRoles.AddAsync(userRole);
        await _context.SaveChangesAsync();

        await transaction.CommitAsync();
      }
      catch (Exception ex)
      {
        await transaction.RollbackAsync();
        return StatusCode(500, new { Message = "Lỗi đăng ký tài khoản", Error = ex.Message });
      }

      return Ok(new
      {
        User = newUser.Id,
        Roles = await _context.UserRoles
          .Where(ur => ur.UserId == newUser.Id)
          .Select(ur => ur.Role.Name)
          .ToListAsync()
      });
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginModel model)
    {
      var user = await _context.Users
          .FirstOrDefaultAsync(u => u.Username == model.Username);

      if (user == null)
        return Unauthorized(new { Message = "Tài khoản chưa tồn tại" });

      if (!user.VerifyPassword(model.Password))
        return Unauthorized(new { Message = "Mật khẩu hoặc tài khoản không chính xác" });

      var userRoles = await _context.UserRoles
          .Where(ur => ur.UserId == user.Id)
          .Select(ur => ur.Role.Name)
          .ToArrayAsync();

      var token = _authService.GenerateJwtToken(user, userRoles);

      // Response.Cookies.Append("token", token, new CookieOptions
      // {
      //   HttpOnly = false,
      //   Secure = true,
      //   SameSite = SameSiteMode.None,
      //   Expires = DateTime.UtcNow.AddDays(10)
      // });

      return Ok(new { token = token, user = user.Username, roles = userRoles });
    }

    [HttpDelete("logout")]
    public IActionResult Logout()
    {
      // Response.Cookies.Delete("token");
      return Ok(new { message = "Đăng xuất thành công" });
    }

  }
  public class LoginModel
  {
    public string Username { get; set; }
    public string Password { get; set; }
  }

  public class RegisterModel
  {
    public string Username { get; set; }
    public string Password { get; set; }
  }
}