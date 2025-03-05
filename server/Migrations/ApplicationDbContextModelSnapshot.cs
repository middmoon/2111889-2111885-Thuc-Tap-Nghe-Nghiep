﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using server.Data;

namespace server.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.17")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("server.Models.Blog", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("AuthorId")
                        .HasColumnType("int");

                    b.Property<string>("Content")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsApproved")
                        .HasColumnType("bit");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("AuthorId");

                    b.ToTable("Blog");
                });

            modelBuilder.Entity("server.Models.EditorApply", b =>
                {
                    b.Property<int?>("UserId")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsApproved")
                        .HasColumnType("bit");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("UserId");

                    b.ToTable("EditorApply");
                });

            modelBuilder.Entity("server.Models.Role", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Roles");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "admin"
                        },
                        new
                        {
                            Id = 2,
                            Name = "reader"
                        },
                        new
                        {
                            Id = 3,
                            Name = "writer"
                        });
                });

            modelBuilder.Entity("server.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Username")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            PasswordHash = "AQAAAAEAACcQAAAAEBZjiF/qADNO4Oxv48mmTEjOc1QDbqsBLmib0V/odXIqyrrOhOOxIyRCby5EhrtuZQ==",
                            Username = "admin"
                        },
                        new
                        {
                            Id = 4,
                            PasswordHash = "AQAAAAEAACcQAAAAEJOEyQ5bQO3lFi2K3EVXsKY9KrFg4tRziIx/o8NMBvi3lbcu1dtpNOhblUV15EILTw==",
                            Username = "user1"
                        },
                        new
                        {
                            Id = 2,
                            PasswordHash = "AQAAAAEAACcQAAAAEBFxnSYhwX/juSNek1mez+3gzHoraQZoIk+dni2cSMFXe7cl9r+KMpuKKb4/0HqIcw==",
                            Username = "editor1"
                        },
                        new
                        {
                            Id = 3,
                            PasswordHash = "AQAAAAEAACcQAAAAEIiDYumA8lxO/81CrXDZoz6Vi8R+hfS8WI0jhr8p7/+0iKVsbJJwXainuyQMHtfFYA==",
                            Username = "editor2"
                        },
                        new
                        {
                            Id = 5,
                            PasswordHash = "AQAAAAEAACcQAAAAEIs+RF96Libtia/WMgEJGVySZ9PoLlTrElpn1RRULQDv48ioOhuzB3N6okdxYdunjg==",
                            Username = "user2"
                        });
                });

            modelBuilder.Entity("server.Models.UserLikeBlog", b =>
                {
                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<int>("BlogId")
                        .HasColumnType("int");

                    b.HasKey("UserId", "BlogId");

                    b.HasIndex("BlogId");

                    b.ToTable("UserLikeBlog");
                });

            modelBuilder.Entity("server.Models.UserRole", b =>
                {
                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("UserRoles");

                    b.HasData(
                        new
                        {
                            UserId = 1,
                            RoleId = 1
                        },
                        new
                        {
                            UserId = 1,
                            RoleId = 2
                        },
                        new
                        {
                            UserId = 1,
                            RoleId = 3
                        },
                        new
                        {
                            UserId = 2,
                            RoleId = 2
                        },
                        new
                        {
                            UserId = 2,
                            RoleId = 3
                        },
                        new
                        {
                            UserId = 3,
                            RoleId = 2
                        },
                        new
                        {
                            UserId = 3,
                            RoleId = 3
                        },
                        new
                        {
                            UserId = 4,
                            RoleId = 2
                        },
                        new
                        {
                            UserId = 5,
                            RoleId = 2
                        });
                });

            modelBuilder.Entity("server.Models.Blog", b =>
                {
                    b.HasOne("server.Models.User", "Author")
                        .WithMany("Blogs")
                        .HasForeignKey("AuthorId")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.Navigation("Author");
                });

            modelBuilder.Entity("server.Models.EditorApply", b =>
                {
                    b.HasOne("server.Models.User", "User")
                        .WithMany("EditorApplication")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("server.Models.UserLikeBlog", b =>
                {
                    b.HasOne("server.Models.Blog", "Blog")
                        .WithMany("LikedUsers")
                        .HasForeignKey("BlogId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("server.Models.User", "User")
                        .WithMany("LikedBlogs")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Blog");

                    b.Navigation("User");
                });

            modelBuilder.Entity("server.Models.UserRole", b =>
                {
                    b.HasOne("server.Models.Role", "Role")
                        .WithMany("UserRoles")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("server.Models.User", "User")
                        .WithMany("UserRoles")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Role");

                    b.Navigation("User");
                });

            modelBuilder.Entity("server.Models.Blog", b =>
                {
                    b.Navigation("LikedUsers");
                });

            modelBuilder.Entity("server.Models.Role", b =>
                {
                    b.Navigation("UserRoles");
                });

            modelBuilder.Entity("server.Models.User", b =>
                {
                    b.Navigation("Blogs");

                    b.Navigation("EditorApplication");

                    b.Navigation("LikedBlogs");

                    b.Navigation("UserRoles");
                });
#pragma warning restore 612, 618
        }
    }
}
