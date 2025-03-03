using Microsoft.IdentityModel.Tokens;
using server.Models;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.IdentityModel.Tokens;
using Microsoft.IdentityModel;
using System.Collections.Generic;

namespace server.Services
{
  public interface IAuthService
  {
    string GenerateJwtToken(User user, string[] roles);
  }

  public class AuthService : IAuthService
  {
    private readonly string _jwtKey;
    private readonly string _jwtIssuer;
    private readonly string _jwtAudience;

    public AuthService()
    {
      _jwtKey = Environment.GetEnvironmentVariable("JWT_KEY");
      _jwtIssuer = Environment.GetEnvironmentVariable("JWT_ISSUER");
      _jwtAudience = Environment.GetEnvironmentVariable("JWT_AUDIENCE");
    }

    public string GenerateJwtToken(User user, string[] roles)
    {

      var claims = new List<Claim>
      {
        new Claim(ClaimTypes.NameIdentifier, user.Id.ToString())
      };

      foreach (var role in roles ?? Array.Empty<string>())
      {
        claims.Add(new Claim(ClaimTypes.Role, role));
      }

      var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtKey));
      var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

      var token = new JwtSecurityToken(
          issuer: _jwtIssuer,
          audience: _jwtAudience,
          claims: claims,
          expires: DateTime.Now.AddDays(10),
          signingCredentials: creds
      );

      return new JwtSecurityTokenHandler().WriteToken(token);
    }
  }
}