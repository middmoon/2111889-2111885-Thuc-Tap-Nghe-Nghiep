namespace server.Models
{
  public class UserLikeBlog
  {
    public int UserId { get; set; }
    public User User { get; set; }
    public int BlogId { get; set; }
    public Blog Blog { get; set; }
  }
}