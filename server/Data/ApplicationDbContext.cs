using Microsoft.EntityFrameworkCore;
using server.Models;
using DotNetEnv;
using System;
using System.IO;

namespace server.Data
{
  public class ApplicationDbContext : DbContext
  {
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

    public DbSet<User> Users { get; set; }
    public DbSet<Role> Roles { get; set; }
    public DbSet<UserRole> UserRoles { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
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
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
      if (!optionsBuilder.IsConfigured)
      {
        // Load .env khi chạy EF Core Tools
        Console.WriteLine($"Current Directory: {Directory.GetCurrentDirectory()}");
        Env.Load();
        string connectionString = Environment.GetEnvironmentVariable("DB_CONNECTION");
        Console.WriteLine($"DB_CONNECTION in OnConfiguring: {connectionString}");
        if (string.IsNullOrEmpty(connectionString))
        {
          throw new InvalidOperationException("DB_CONNECTION not found in .env file. Ensure .env is in the project root directory.");
        }
        optionsBuilder.UseSqlServer(connectionString);
      }
    }
  }
}