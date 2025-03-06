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
    [Route("api/blogs")]
    [ApiController]
    public class BlogsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public BlogsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/blogs
        // Get all blog with approval true
        [AllowAnonymous]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BlogFormat>>> GetBlog()
        {
            var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            int? userId = string.IsNullOrEmpty(userIdClaim) ? null : int.Parse(userIdClaim);

            var blogs = await _context.Blog
                .Where(b => b.IsApproved)
                .Include(b => b.LikedUsers)
                .Select(b => new BlogFormat
                {
                    Id = b.Id,
                    Title = b.Title,
                    Content = b.Content,
                    Author = b.Author.Username,
                    IsLiked = userId.HasValue && b.LikedUsers.Any(ulb => ulb.UserId == userId),
                    Likes = b.LikedUsers.Count(),
                    CreatedAt = b.CreatedAt,
                    UpdatedAt = b.UpdatedAt
                })
                .ToListAsync();

            return Ok(blogs);
        }

        // GET: api/blogs/5
        // Get blog by id
        [HttpGet("{id}")]
        public async Task<ActionResult<Blog>> GetBlog(int id)
        {
            var blog = await _context.Blog
                .Where(b => b.Id == id)
                .Select(b => new BlogFormat
                {
                    Id = b.Id,
                    Title = b.Title,
                    Content = b.Content,
                    Author = b.Author.Username,
                    Likes = b.LikedUsers.Count(),
                    CreatedAt = b.CreatedAt,
                    UpdatedAt = b.UpdatedAt
                })
                .FirstOrDefaultAsync();

            if (blog == null)
            {
                return NotFound($"Blog with ID {id} not found.");
            }

            return Ok(blog);
        }

        // GET: api/my-blogs
        // Get writer's blogs
        [Authorize(Policy = "Writer")]
        [HttpGet("my-blogs")]
        public async Task<ActionResult<IEnumerable<BlogFormat>>> GetMyBlogs()
        {
            var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            int? userId = string.IsNullOrEmpty(userIdClaim) ? null : int.Parse(userIdClaim);

            var blogs = await _context.Blog
                .Where(b => b.AuthorId == userId)
                .Select(b => new BlogFormat
                {
                    Id = b.Id,
                    Title = b.Title,
                    Content = b.Content,
                    Author = b.Author.Username,
                    Likes = b.LikedUsers.Count(),
                    CreatedAt = b.CreatedAt,
                    UpdatedAt = b.UpdatedAt
                })
                .ToListAsync();

            return Ok(blogs);
        }

        // GET: api/my-favorite-blogs
        // Get writer's blogs
        [Authorize]
        [HttpGet("my-favorite-blogs")]
        public async Task<ActionResult<IEnumerable<BlogFormat>>> GetMyFavoriteBlogs()
        {
            var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            int? userId = string.IsNullOrEmpty(userIdClaim) ? null : int.Parse(userIdClaim);

            var blogs = await _context.Blog
                .Where(b => b.LikedUsers.Any(ulb => ulb.UserId == userId))
                .Select(b => new BlogFormat
                {
                    Id = b.Id,
                    Title = b.Title,
                    Content = b.Content,
                    Author = b.Author.Username,
                    Likes = b.LikedUsers.Count(),
                    CreatedAt = b.CreatedAt,
                    UpdatedAt = b.UpdatedAt
                })
                .ToListAsync();

            return Ok(blogs);
        }

        // POST: api/blogs
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [Authorize(Policy = "AdminOrWriter")]
        [HttpPost]
        public async Task<ActionResult<Blog>> PostBlog(BlogModel model)
        {
            var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier);

            if (userIdClaim == null) return Unauthorized("User id not found in token.");

            int userId = int.Parse(userIdClaim.Value);

            if (string.IsNullOrEmpty(model.Title) || string.IsNullOrEmpty(model.Content))
            {
                return BadRequest("Title and Content are required.");
            }

            var blog = new Blog
            {
                Title = model.Title,
                Content = model.Content,
                AuthorId = userId,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            };

            _context.Blog.Add(blog);

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {

                return StatusCode(500, $"Internal server error: {ex.Message}");
            }

            return CreatedAtAction("GetBlog", new { id = blog.Id }, blog);
        }

        // PUT: api/blogs/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [Authorize(Policy = "Writer")]
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBlog(int id, BlogModel blog)
        {
            // Check claim NameIdentifier in token
            var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier);

            if (userIdClaim == null) return Unauthorized("User id not found in token.");

            int userId = int.Parse(userIdClaim.Value);

            // Check existing user
            var existingUser = await _context.Users.FindAsync(userId);

            if (existingUser == null) return Unauthorized("User not found.");

            // Check existing blog
            var existingBlog = await _context.Blog.FindAsync(id);

            if (existingBlog == null) return NotFound($"Blog with ID {id} not found.");

            // Check the owner of the blog
            if (!checkOwner(existingBlog, userId)) return Unauthorized("You are not the owner of this blog.");

            // Check if blog is approved
            if (existingBlog.IsApproved) return BadRequest("Blog is already approved.");

            // update blog
            if (blog.Title != null) existingBlog.Title = blog.Title;

            if (blog.Content != null) existingBlog.Content = blog.Content;

            existingBlog.UpdatedAt = DateTime.UtcNow;

            // mark blog as modified
            _context.Entry(existingBlog).State = EntityState.Modified;

            // save changes
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BlogExists(id))
                {
                    return NotFound($"Blog with ID {id} not found.");
                }
                else
                {
                    throw;
                }
            }

            return Ok(existingBlog);
        }

        // PUT api/like/{id}
        // Like blog by user
        [Authorize]
        [HttpPut("like/{id}")]
        public async Task<IActionResult> LikeBlog(int id)
        {
            // check claim NameIdentifier in token
            var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier);

            if (userIdClaim == null) return Unauthorized("User id not found in token.");

            int userId = int.Parse(userIdClaim.Value);

            // check existing blog
            if (!BlogExists(id)) return NotFound($"Blog with ID {id} not found.");

            var existingBlog = await _context.Blog.FindAsync(id);

            // check if user already liked blog
            if (existingBlog.LikedUsers.Any(ulb => ulb.UserId == userId)) return BadRequest("You already liked this blog.");

            // like blog
            var userLikeBlog = new UserLikeBlog
            {
                UserId = userId,
                BlogId = id
            };

            _context.UserLikeBlog.Add(userLikeBlog);

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (!BlogExists(id))
                {
                    return NotFound($"Blog with ID {id} not found.");
                }
                else
                {
                    throw;
                }
            }

            return Ok(existingBlog);
        }

        // PUT api/approve/{id}
        // Get pemnding approve blogs by admin user
        [Authorize(Policy = "Admin")]
        [HttpGet("pending-approval")]
        public async Task<IActionResult> GetPendingApprovalBlogs()
        {
            var blogs = await _context.Blog
                .Where(b => b.IsApproved != true)
                .Select(b => new BlogFormat
                {
                    Id = b.Id,
                    Title = b.Title,
                    Content = b.Content,
                    Author = b.Author.Username,
                    Likes = b.LikedUsers.Count(ulb => ulb.BlogId == b.Id),
                    CreatedAt = b.CreatedAt,
                    UpdatedAt = b.UpdatedAt
                })
                .ToListAsync();

            return Ok(blogs);
        }

        // PUT api/approve/{id}
        // Approve blog by admin user
        [Authorize(Policy = "Admin")]
        [HttpPut("approve/{id}")]
        public async Task<IActionResult> ApproveBlog(int id)
        {
            // check admin role
            var isAdmin = User.Claims.Any(c => c.Type == ClaimTypes.Role && c.Value.Equals("admin", StringComparison.OrdinalIgnoreCase));
            if (!isAdmin) return Unauthorized("Only admins can approve blogs.");

            // check existing blog
            if (!BlogExists(id)) return NotFound($"Blog with ID {id} not found.");

            var existingBlog = await _context.Blog.FindAsync(id);

            // check if blog is already approved
            if (existingBlog.IsApproved) return BadRequest("Blog is already approved.");

            // approve blog
            existingBlog.IsApproved = true;

            //mark blog as modified
            _context.Entry(existingBlog).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BlogExists(id))
                {
                    return NotFound($"Blog with ID {id} not found.");
                }
                else
                {
                    throw;
                }
            }

            return Ok(existingBlog);
        }

        // DELETE: api/blogs/5
        [Authorize(Policy = "AdminOrWriter")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBlog(int id)
        {
            var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier);
            if (userIdClaim == null)
            {
                return Unauthorized("User id not found in token.");
            }

            int userId = int.Parse(userIdClaim.Value);
            var blog = await _context.Blog.FindAsync(id);
            if (blog == null)
            {
                return NotFound();
            }

            var isAdmin = User.Claims.Any(c => c.Type == ClaimTypes.Role && c.Value.Equals("admin", StringComparison.OrdinalIgnoreCase));

            if (!isAdmin && !checkOwner(blog, userId))
            {
                return Unauthorized("You are not the owner of this blog.");
            }

            _context.Blog.Remove(blog);
            await _context.SaveChangesAsync();
            return NoContent();
        }

        private bool BlogExists(int id)
        {
            return _context.Blog.Any(e => e.Id == id);
        }

        private bool checkOwner(Blog blog, int userId)
        {
            return blog.AuthorId == userId;
        }
    }

    public class BlogModel
    {
        public string Title { get; set; }
        public string Content { get; set; }
    }

    public class BlogFormat
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public string Author { get; set; }
        public int Likes { get; set; }
        public bool IsLiked { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
