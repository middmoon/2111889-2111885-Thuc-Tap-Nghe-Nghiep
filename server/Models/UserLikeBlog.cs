using System.Text.Json.Serialization;

namespace server.Models
{
  public class UserLikeBlog
  {
    public int UserId { get; set; }
    [JsonIgnore]
    public User User { get; set; }
    public int BlogId { get; set; }
    [JsonIgnore]
    public Blog Blog { get; set; }
  }
}