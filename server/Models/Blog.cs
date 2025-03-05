using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace server.Models
{
  public class Blog
  {
    public int Id { get; set; }
    public string Title { get; set; }
    public string Content { get; set; }
    public int? AuthorId { get; set; }
    [JsonIgnore]
    public User Author { get; set; }
    [JsonIgnore]
    public bool IsApproved { get; set; } = false;
    public ICollection<UserLikeBlog> LikedUsers { get; set; } = new List<UserLikeBlog>();
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
  }
}