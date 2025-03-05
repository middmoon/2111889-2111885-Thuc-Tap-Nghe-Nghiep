using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using server.Data;
using server.Models;

namespace server.Controllers
{
  [Route("api/users")]
  [ApiController]
  public class UserController : ControllerBase
  {
    private readonly ApplicationDbContext _context;

    public UserController(ApplicationDbContext context)
    {
      _context = context;
    }
    // POST: api/users/approve-editor
    [Authorize(Policy = "Admin")]
    [HttpPost("approve-editor/{id}")]
    public async Task<IActionResult> ApproveEditor(int id)
    {
      // check token claim id
      var adminIdClaim = User.FindFirst(ClaimTypes.NameIdentifier);

      if (adminIdClaim == null) return Unauthorized("Invalid token.");

      // check existing user
      var existingUser = await _context.Users.FindAsync(id);

      if (existingUser == null) return NotFound($"User with ID {id} not found.");

      // find id of editor role
      var editorRole = await _context.Roles.FirstOrDefaultAsync(r => r.Name == "editor");

      if (editorRole == null) return NotFound("Editor role not found.");

      // check if user is already an editor
      if (existingUser.UserRoles.Any(ur => ur.RoleId == editorRole.Id)) return BadRequest("User is already an editor.");

      // add user as editor
      var userRole = new UserRole { UserId = existingUser.Id, RoleId = editorRole.Id };

      // add editor role to user
      _context.UserRoles.Add(userRole);

      try
      {
        await _context.SaveChangesAsync();
      }
      catch (DbUpdateException)
      {
        if (!UserExists(id))
        {
          return NotFound($"User with ID {id} not found.");
        }
        else
        {
          throw;
        }
      }

      return Ok(new { message = "User added as editor successfully.", user = existingUser });
    }

    [Authorize]
    [HttpGet("me")]
    public async Task<IActionResult> GetMe()
    {
      var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier);

      if (userIdClaim == null) return Unauthorized("Invalid token.");

      var userId = int.Parse(userIdClaim.Value);

      var user = await _context.Users.FindAsync(userId);

      if (user == null) return NotFound($"User with ID {userId} not found.");

      return Ok(new { user });
    }

    private bool UserExists(int id)
    {
      return _context.Users.Any(e => e.Id == id);
    }
  }
}