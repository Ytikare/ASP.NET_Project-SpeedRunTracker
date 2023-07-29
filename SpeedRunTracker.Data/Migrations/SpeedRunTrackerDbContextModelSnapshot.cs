﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SpeedRunTracker.Data;

#nullable disable

namespace SpeedRunTracker.Data.Migrations
{
    [DbContext(typeof(SpeedRunTrackerDbContext))]
    partial class SpeedRunTrackerDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.20")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole<System.Guid>", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles", (string)null);

                    b.HasData(
                        new
                        {
                            Id = new Guid("b3cb43c8-0557-4f89-92ef-aab61426c85f"),
                            ConcurrencyStamp = "993da679-48b1-4005-8f79-db5576916202",
                            Name = "Admin",
                            NormalizedName = "ADMIN"
                        },
                        new
                        {
                            Id = new Guid("bd04980a-4718-47df-8a05-db07d6d91458"),
                            ConcurrencyStamp = "564200c4-f327-4867-a1dc-afa69435b948",
                            Name = "User",
                            NormalizedName = "USER"
                        },
                        new
                        {
                            Id = new Guid("3af205a4-079e-4464-8004-cfa98ffc3bb7"),
                            ConcurrencyStamp = "17490783-f81e-45b5-b6f1-8dd7b9275356",
                            Name = "Moderator",
                            NormalizedName = "Moderator"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<System.Guid>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("RoleId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<System.Guid>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<System.Guid>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("ProviderKey")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<System.Guid>", b =>
                {
                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("RoleId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);

                    b.HasData(
                        new
                        {
                            UserId = new Guid("de5697f9-1610-4c65-986d-998a20d207ec"),
                            RoleId = new Guid("b3cb43c8-0557-4f89-92ef-aab61426c85f")
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<System.Guid>", b =>
                {
                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Name")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("SpeedRunTracker.Data.Entities.AppUser", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers", (string)null);

                    b.HasData(
                        new
                        {
                            Id = new Guid("de5697f9-1610-4c65-986d-998a20d207ec"),
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "f3ab34e0-8e81-40f5-bc42-365a5cac76f1",
                            Email = "admin@admin.com",
                            EmailConfirmed = false,
                            LockoutEnabled = true,
                            NormalizedEmail = "ADMIN@ADMIN.COM",
                            NormalizedUserName = "ADMIN",
                            PasswordHash = "AQAAAAEAACcQAAAAEHAsiq3wRGnN1Iz5IWJgkYPD3ENZaHWSyQwp6Aw7uv4Yy8dPpgbsxMQDJIMn1Dl9sw==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "MPCRSFQ7OON7DFGOA2356FQUFLAR7AMK",
                            TwoFactorEnabled = false,
                            UserName = "Admin"
                        });
                });

            modelBuilder.Entity("SpeedRunTracker.Data.Entities.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("Id");

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Any%"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Any% Glitchless"
                        },
                        new
                        {
                            Id = 3,
                            Name = "100%"
                        },
                        new
                        {
                            Id = 4,
                            Name = "100% Glitchless "
                        });
                });

            modelBuilder.Entity("SpeedRunTracker.Data.Entities.Game", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ImgUrl")
                        .IsRequired()
                        .HasMaxLength(2000)
                        .HasColumnType("nvarchar(2000)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Games");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            ImgUrl = "https://cdn.akamai.steamstatic.com/steam/apps/391540/header.jpg",
                            Title = "Undertale"
                        },
                        new
                        {
                            Id = 2,
                            ImgUrl = "https://cdn.cloudflare.steamstatic.com/steam/apps/71113/header.jpg",
                            Title = "Sonic the Headghog"
                        },
                        new
                        {
                            Id = 3,
                            ImgUrl = "https://images.gog-statics.com/60741efd71f8d67d9ff221671c790782a82ac0bb5a73a7dc5d3f45801b3074da.jpg",
                            Title = "The binding of Isaac: Repentance"
                        },
                        new
                        {
                            Id = 4,
                            ImgUrl = "https://upload.wikimedia.org/wikipedia/en/c/c4/GTASABOX.jpg",
                            Title = "Grant Theft Auto: San Andreas"
                        },
                        new
                        {
                            Id = 5,
                            ImgUrl = "https://cdn.akamai.steamstatic.com/steam/apps/774361/header.jpg",
                            Title = "Blasphemous"
                        },
                        new
                        {
                            Id = 6,
                            ImgUrl = "https://cdn.akamai.steamstatic.com/steam/apps/1237970/header.jpg",
                            Title = "Titanfall 2"
                        });
                });

            modelBuilder.Entity("SpeedRunTracker.Data.Entities.GameCategories", b =>
                {
                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<int>("GameId")
                        .HasColumnType("int");

                    b.HasKey("CategoryId", "GameId");

                    b.HasIndex("GameId");

                    b.ToTable("GameCategories");

                    b.HasData(
                        new
                        {
                            CategoryId = 1,
                            GameId = 1
                        },
                        new
                        {
                            CategoryId = 3,
                            GameId = 1
                        },
                        new
                        {
                            CategoryId = 1,
                            GameId = 2
                        },
                        new
                        {
                            CategoryId = 2,
                            GameId = 2
                        },
                        new
                        {
                            CategoryId = 3,
                            GameId = 3
                        },
                        new
                        {
                            CategoryId = 4,
                            GameId = 3
                        },
                        new
                        {
                            CategoryId = 1,
                            GameId = 4
                        },
                        new
                        {
                            CategoryId = 2,
                            GameId = 4
                        },
                        new
                        {
                            CategoryId = 3,
                            GameId = 4
                        },
                        new
                        {
                            CategoryId = 4,
                            GameId = 4
                        },
                        new
                        {
                            CategoryId = 1,
                            GameId = 5
                        },
                        new
                        {
                            CategoryId = 3,
                            GameId = 5
                        },
                        new
                        {
                            CategoryId = 3,
                            GameId = 6
                        },
                        new
                        {
                            CategoryId = 4,
                            GameId = 6
                        });
                });

            modelBuilder.Entity("SpeedRunTracker.Data.Entities.GameGenres", b =>
                {
                    b.Property<int>("GenreId")
                        .HasColumnType("int");

                    b.Property<int>("GameId")
                        .HasColumnType("int");

                    b.HasKey("GenreId", "GameId");

                    b.HasIndex("GameId");

                    b.ToTable("GameGenres");

                    b.HasData(
                        new
                        {
                            GenreId = 7,
                            GameId = 2
                        },
                        new
                        {
                            GenreId = 5,
                            GameId = 3
                        },
                        new
                        {
                            GenreId = 4,
                            GameId = 1
                        },
                        new
                        {
                            GenreId = 6,
                            GameId = 1
                        },
                        new
                        {
                            GenreId = 7,
                            GameId = 5
                        },
                        new
                        {
                            GenreId = 2,
                            GameId = 5
                        },
                        new
                        {
                            GenreId = 2,
                            GameId = 4
                        },
                        new
                        {
                            GenreId = 1,
                            GameId = 6
                        });
                });

            modelBuilder.Entity("SpeedRunTracker.Data.Entities.Genre", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasMaxLength(25)
                        .HasColumnType("nvarchar(25)");

                    b.HasKey("Id");

                    b.ToTable("Genres");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Type = "Souls-like"
                        },
                        new
                        {
                            Id = 2,
                            Type = "Adventure"
                        },
                        new
                        {
                            Id = 3,
                            Type = "Strategy"
                        },
                        new
                        {
                            Id = 4,
                            Type = "Puzzle"
                        },
                        new
                        {
                            Id = 5,
                            Type = "Rouge-like"
                        },
                        new
                        {
                            Id = 6,
                            Type = "RPG"
                        },
                        new
                        {
                            Id = 7,
                            Type = "Side scroller"
                        });
                });

            modelBuilder.Entity("SpeedRunTracker.Data.Entities.SpeedRun", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<int>("GameId")
                        .HasColumnType("int");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<bool>("IsVerified")
                        .HasColumnType("bit");

                    b.Property<TimeSpan>("SpeedRunTime")
                        .HasColumnType("time");

                    b.Property<string>("SpeedRunVideoUrl")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<Guid>("SpeedRunerId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("SubmitionDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("VerificationDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("VerifierName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.HasIndex("GameId");

                    b.HasIndex("SpeedRunerId");

                    b.ToTable("SpeedRuns");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<System.Guid>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole<System.Guid>", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<System.Guid>", b =>
                {
                    b.HasOne("SpeedRunTracker.Data.Entities.AppUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<System.Guid>", b =>
                {
                    b.HasOne("SpeedRunTracker.Data.Entities.AppUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<System.Guid>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole<System.Guid>", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SpeedRunTracker.Data.Entities.AppUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<System.Guid>", b =>
                {
                    b.HasOne("SpeedRunTracker.Data.Entities.AppUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("SpeedRunTracker.Data.Entities.GameCategories", b =>
                {
                    b.HasOne("SpeedRunTracker.Data.Entities.Category", "Category")
                        .WithMany("Games")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SpeedRunTracker.Data.Entities.Game", "Game")
                        .WithMany("Categories")
                        .HasForeignKey("GameId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");

                    b.Navigation("Game");
                });

            modelBuilder.Entity("SpeedRunTracker.Data.Entities.GameGenres", b =>
                {
                    b.HasOne("SpeedRunTracker.Data.Entities.Game", "Game")
                        .WithMany("Genres")
                        .HasForeignKey("GameId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SpeedRunTracker.Data.Entities.Genre", "Genre")
                        .WithMany("Games")
                        .HasForeignKey("GenreId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Game");

                    b.Navigation("Genre");
                });

            modelBuilder.Entity("SpeedRunTracker.Data.Entities.SpeedRun", b =>
                {
                    b.HasOne("SpeedRunTracker.Data.Entities.Category", "Category")
                        .WithMany("SpeedRuns")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SpeedRunTracker.Data.Entities.Game", "Game")
                        .WithMany("SpeedRuns")
                        .HasForeignKey("GameId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SpeedRunTracker.Data.Entities.AppUser", "SpeedRuner")
                        .WithMany("SpeedRuns")
                        .HasForeignKey("SpeedRunerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");

                    b.Navigation("Game");

                    b.Navigation("SpeedRuner");
                });

            modelBuilder.Entity("SpeedRunTracker.Data.Entities.AppUser", b =>
                {
                    b.Navigation("SpeedRuns");
                });

            modelBuilder.Entity("SpeedRunTracker.Data.Entities.Category", b =>
                {
                    b.Navigation("Games");

                    b.Navigation("SpeedRuns");
                });

            modelBuilder.Entity("SpeedRunTracker.Data.Entities.Game", b =>
                {
                    b.Navigation("Categories");

                    b.Navigation("Genres");

                    b.Navigation("SpeedRuns");
                });

            modelBuilder.Entity("SpeedRunTracker.Data.Entities.Genre", b =>
                {
                    b.Navigation("Games");
                });
#pragma warning restore 612, 618
        }
    }
}
