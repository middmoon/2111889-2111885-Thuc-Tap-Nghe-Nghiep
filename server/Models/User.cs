using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Identity;

namespace server.Models
{
  public class User
  {
    [JsonIgnore]
    public int Id { get; set; }
    public string Username { get; set; }
    [JsonIgnore]
    public string PasswordHash { get; set; }
    [JsonIgnore]
    public virtual ICollection<UserRole> UserRoles { get; set; } = new List<UserRole>();
    [JsonIgnore]
    public virtual ICollection<Blog> Blogs { get; set; } = new List<Blog>();
    public void SetPassword(string password)
    {
      var hasher = new PasswordHasher<User>();
      PasswordHash = hasher.HashPassword(this, password);
    }
    public bool VerifyPassword(string password)
    {
      var hasher = new PasswordHasher<User>();
      return hasher.VerifyHashedPassword(this, PasswordHash, password) == PasswordVerificationResult.Success;
    }
  }
}