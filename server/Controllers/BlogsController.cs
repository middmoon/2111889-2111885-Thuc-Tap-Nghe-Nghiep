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

        // POST: api/blogs
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [Authorize(Policy = "AdminOrWriter")]
        [HttpPost]
        public async Task<ActionResult<Blog>> PostBlog(BlogPostModel model)
        {
            var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier);

            if (userIdClaim == null)
            {
                return Unauthorized("User id not found in token.");
            }

            int userId = int.Parse(userIdClaim.Value);

            var blog = new Blog
            {
                Title = model.Title,
                Content = model.Content,
                AuthorId = userId,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            };

            _context.Blog.Add(blog);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBlog", new { id = blog.Id }, blog);
        }

        // GET: api/blogs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BlogFormat>>> GetBlog()
        {
            var blogs = await _context.Blog
                .Select(b => new BlogFormat
                {
                    Id = b.Id,
                    Title = b.Title,
                    Content = b.Content,
                    Author = b.Author.Username,
                    CreatedAt = b.CreatedAt,
                    UpdatedAt = b.UpdatedAt
                })
                .ToListAsync();

            return Ok(blogs);
        }

        // GET: api/blogs/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Blog>> GetBlog(int id)
        {
            var blog = await _context.Blog.FindAsync(id);

            if (blog == null)
            {
                return NotFound();
            }

            return blog;
        }

        // PUT: api/blogs/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754

        [Authorize(Policy = "Writer")]
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBlog(int id, Blog blog)
        {
            if (id != blog.Id)
            {
                return BadRequest();
            }

            var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier);

            if (userIdClaim == null)
            {
                return Unauthorized("User id not found in token.");
            }

            int userId = int.Parse(userIdClaim.Value);

            if (!checkOwner(blog, userId))
            {
                return Unauthorized("You are not the owner of this blog.");
            }

            _context.Entry(blog).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BlogExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
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

        private Boolean checkOwner(Blog blog, int userId)
        {
            return blog.AuthorId == userId;
        }
    }

    public class BlogPostModel
    {
        public string Title { get; set; }
        public string Content { get; set; }
    }

    public class BlogPutModel
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
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
