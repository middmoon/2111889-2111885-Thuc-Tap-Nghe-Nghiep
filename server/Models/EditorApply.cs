using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace server.Models
{
  public class EditorApply
  {
    public bool IsApproved { get; set; } = false;
    public int? UserId { get; set; }
    [JsonIgnore]
    public User User { get; set; }
    [JsonIgnore]
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;

  }
}