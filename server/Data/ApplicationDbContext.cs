using Microsoft.EntityFrameworkCore;
using server.Models;
using DotNetEnv;
using System;
using System.IO;
using Microsoft.AspNetCore.Identity;

namespace server.Data
{
  public class ApplicationDbContext : DbContext
  {
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

    public DbSet<User> Users { get; set; }
    public DbSet<Role> Roles { get; set; }
    public DbSet<UserRole> UserRoles { get; set; }

    public DbSet<UserLikeBlog> UserLikeBlogs { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      base.OnModelCreating(modelBuilder);

      // Define association between User and Role through UserRole
      modelBuilder.Entity<UserRole>()
        .HasKey(ur => new { ur.UserId, ur.RoleId });

      modelBuilder.Entity<UserRole>()
        .HasOne(ur => ur.User)
        .WithMany(u => u.UserRoles)
        .HasForeignKey(ur => ur.UserId);

      modelBuilder.Entity<UserRole>()
        .HasOne(ur => ur.Role)
        .WithMany(r => r.UserRoles)
        .HasForeignKey(ur => ur.RoleId);

      modelBuilder.Entity<User>()
        .HasMany(u => u.Blogs)
        .WithOne(b => b.Author)
        .OnDelete(DeleteBehavior.SetNull);

      modelBuilder.Entity<Blog>()
        .HasOne(b => b.Author)
        .WithMany(u => u.Blogs)
        .HasForeignKey(b => b.AuthorId)
        .OnDelete(DeleteBehavior.SetNull);

      modelBuilder.Entity<UserLikeBlog>()
        .HasKey(ulb => new { ulb.UserId, ulb.BlogId });

      modelBuilder.Entity<UserLikeBlog>()
          .HasOne(ulb => ulb.User)
          .WithMany(u => u.LikedBlogs)
          .HasForeignKey(ulb => ulb.UserId)
          .OnDelete(DeleteBehavior.Cascade);

      modelBuilder.Entity<UserLikeBlog>()
          .HasOne(ulb => ulb.Blog)
          .WithMany(b => b.LikedUsers)
          .HasForeignKey(ulb => ulb.BlogId)
          .OnDelete(DeleteBehavior.Cascade);

      // Seed roles
      var adminRole = new Role { Id = 1, Name = "admin" };
      var readerRole = new Role { Id = 2, Name = "reader" };
      var writerRole = new Role { Id = 3, Name = "writer" };

      modelBuilder.Entity<Role>().HasData(adminRole, readerRole, writerRole);

      // Hash password before save to database
      var passwordHasher = new PasswordHasher<User>();

      var adminUser = new User { Id = 1, Username = "admin" };
      adminUser.PasswordHash = passwordHasher.HashPassword(adminUser, "admin");

      var editorUser1 = new User { Id = 2, Username = "editor1" };
      editorUser1.PasswordHash = passwordHasher.HashPassword(editorUser1, "123");

      var editorUser2 = new User { Id = 3, Username = "editor2" };
      editorUser2.PasswordHash = passwordHasher.HashPassword(editorUser2, "123");

      var userReader1 = new User { Id = 4, Username = "user1" };
      userReader1.PasswordHash = passwordHasher.HashPassword(userReader1, "123");

      var userReader2 = new User { Id = 5, Username = "user2" };
      userReader2.PasswordHash = passwordHasher.HashPassword(userReader2, "123");

      modelBuilder.Entity<User>().HasData(adminUser, userReader1, editorUser1, editorUser2, userReader2);

      // Assign roles
      modelBuilder.Entity<UserRole>().HasData(
          new UserRole { UserId = 1, RoleId = 1 }, // Admin -> Admin role -> Admin have all permissions
          new UserRole { UserId = 1, RoleId = 2 }, // Admin has role reader
          new UserRole { UserId = 1, RoleId = 3 }, // Admin has role writer

          new UserRole { UserId = 2, RoleId = 2 }, // Editor1 -> Writer -> Editor1 can write
          new UserRole { UserId = 2, RoleId = 3 },
          new UserRole { UserId = 3, RoleId = 2 }, // Editor2 -> Writer
          new UserRole { UserId = 3, RoleId = 3 },

          new UserRole { UserId = 4, RoleId = 2 }, // User1 -> Reader -> Reader only can read
          new UserRole { UserId = 5, RoleId = 2 }  // User2 -> Reader
      );
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
      if (!optionsBuilder.IsConfigured)
      {
        // Load environment variables correctly
        Console.WriteLine($"Current Directory: {Directory.GetCurrentDirectory()}");

        var envFilePath = Path.Combine(Directory.GetCurrentDirectory(), ".env");
        if (File.Exists(envFilePath))
        {
          Env.Load();
        }

        string connectionString = Environment.GetEnvironmentVariable("DB_CONNECTION");

        if (string.IsNullOrEmpty(connectionString))
        {
          throw new InvalidOperationException("❌ DB_CONNECTION not found in .env file. Ensure .env is in the project root directory.");
        }

        optionsBuilder.UseSqlServer(connectionString);
      }
    }

    public DbSet<server.Models.Blog> Blog { get; set; }
  }
}
