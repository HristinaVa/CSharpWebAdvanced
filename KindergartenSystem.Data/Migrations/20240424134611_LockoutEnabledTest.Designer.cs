﻿// <auto-generated />
using System;
using KindergartenSystem.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace KindergartenSystem.Data.Migrations
{
    [DbContext(typeof(KindergartenDbContext))]
    [Migration("20240424134611_LockoutEnabledTest")]
    partial class LockoutEnabledTest
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.28")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("KindergartenSystem.Data.Models.AgeGroup", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("KindergartenId")
                        .HasColumnType("int");

                    b.Property<int>("Number")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("KindergartenId");

                    b.ToTable("AgeGroups");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            KindergartenId = 1,
                            Number = 1
                        },
                        new
                        {
                            Id = 2,
                            KindergartenId = 1,
                            Number = 2
                        },
                        new
                        {
                            Id = 3,
                            KindergartenId = 1,
                            Number = 3
                        },
                        new
                        {
                            Id = 4,
                            KindergartenId = 1,
                            Number = 4
                        });
                });

            modelBuilder.Entity("KindergartenSystem.Data.Models.ApplicationUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

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

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(12)
                        .HasColumnType("nvarchar(12)")
                        .HasDefaultValue("...");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)")
                        .HasDefaultValue("...");

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
                            Id = "6d1f5e54-0d88-4c86-89b3-92b32c8070c3",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "50029594-a854-49d3-ac11-e725009b9323",
                            Email = "username@user.com",
                            EmailConfirmed = false,
                            FirstName = "Katya",
                            LastName = "Genova",
                            LockoutEnabled = false,
                            NormalizedEmail = "USERNAME@USER.COM",
                            NormalizedUserName = "USERNAME@USER.COM",
                            PasswordHash = "8D969EEF6ECAD3C29A3A629280E686CF0C3F5D5A86AFF3CA12020C923ADC6C92",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "C3CDC956-7B1E-4C75-BF5D-1A383F696FFC",
                            TwoFactorEnabled = false,
                            UserName = "username@user.com"
                        },
                        new
                        {
                            Id = "bcb4f072-ecca-43c9-ab26-c060c6f364e3",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "50029594-a854-49d3-ac11-e725009b9326",
                            Email = "userparent@user.com",
                            EmailConfirmed = false,
                            FirstName = "Iva",
                            LastName = "Ilieva",
                            LockoutEnabled = false,
                            NormalizedEmail = "USERPARENT@USER.COM",
                            NormalizedUserName = "USERPARENT@USER.COM",
                            PasswordHash = "E150A1EC81E8E93E1EAE2C3A77E66EC6DBD6A3B460F89C1D08AECF422EE401A0",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "C3CDC956-7B1E-4C75-BF5D-1A383F696FFA",
                            TwoFactorEnabled = false,
                            UserName = "userparent@user.com"
                        },
                        new
                        {
                            Id = "bcb4f072-ecca-43c9-ab26-c060c6f264e4",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "50029594-a854-49d3-ac11-e725009b9327",
                            Email = "admin@admin.bg",
                            EmailConfirmed = false,
                            FirstName = "Admin",
                            LastName = "Admin",
                            LockoutEnabled = true,
                            NormalizedEmail = "ADMIN@ADMIN.BG",
                            NormalizedUserName = "ADMIN@ADMIN.BG",
                            PasswordHash = "6F741B93409297B6B3BE618073B5F5899793CB18DDB45274FE6A636B1C62393A",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "C3CDC956-7B1E-4C75-BF5D-1A383F696FFB",
                            TwoFactorEnabled = false,
                            UserName = "admin@admin.bg"
                        });
                });

            modelBuilder.Entity("KindergartenSystem.Data.Models.Child", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("ClassGroupId")
                        .HasColumnType("int");

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnType("datetime2");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("ImageUrl")
                        .IsRequired()
                        .HasMaxLength(2048)
                        .HasColumnType("nvarchar(2048)");

                    b.Property<bool>("IsAttending")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(true);

                    b.Property<bool>("IsKindergartener")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(true);

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("MiddleName")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<Guid>("ParentId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("ClassGroupId");

                    b.HasIndex("ParentId");

                    b.ToTable("Children");

                    b.HasData(
                        new
                        {
                            Id = new Guid("71d5f2cc-76cc-4de1-8bf4-8b6d2bfa0c60"),
                            ClassGroupId = 2,
                            DateOfBirth = new DateTime(2019, 2, 2, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            FirstName = "Alex",
                            ImageUrl = "https://img.freepik.com/free-vector/cute-happy-smiling-child-isolated-white_1308-32243.jpg",
                            IsAttending = false,
                            IsKindergartener = false,
                            LastName = "Iliev",
                            MiddleName = "Hristov",
                            ParentId = new Guid("3cbc521e-07d7-40e5-9d16-655769d51dff")
                        });
                });

            modelBuilder.Entity("KindergartenSystem.Data.Models.ClassGroup", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("AgeGroupId")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.HasKey("Id");

                    b.HasIndex("AgeGroupId");

                    b.ToTable("ClassGroups");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            AgeGroupId = 1,
                            Title = "Zvezdichka"
                        },
                        new
                        {
                            Id = 2,
                            AgeGroupId = 2,
                            Title = "Mecho Puh"
                        },
                        new
                        {
                            Id = 3,
                            AgeGroupId = 3,
                            Title = "Pinokio"
                        },
                        new
                        {
                            Id = 4,
                            AgeGroupId = 4,
                            Title = "Rusalka"
                        },
                        new
                        {
                            Id = 5,
                            AgeGroupId = 4,
                            Title = "Chaika"
                        });
                });

            modelBuilder.Entity("KindergartenSystem.Data.Models.Image", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("KindergartenId")
                        .HasColumnType("int");

                    b.Property<string>("Url")
                        .IsRequired()
                        .HasMaxLength(2048)
                        .HasColumnType("nvarchar(2048)");

                    b.HasKey("Id");

                    b.HasIndex("KindergartenId");

                    b.ToTable("Image");

                    b.HasData(
                        new
                        {
                            Id = new Guid("91dd53ba-73b8-47b0-ba5b-4ead76778729"),
                            KindergartenId = 1,
                            Url = "https://as2.ftcdn.net/v2/jpg/05/95/07/45/1000_F_595074521_hpNDWQChd0dx3pKmFXoX6VNukn2PNOGz.jpg"
                        },
                        new
                        {
                            Id = new Guid("e066d3c3-73f1-4990-9e08-7994bd7a2c7e"),
                            KindergartenId = 1,
                            Url = "https://as1.ftcdn.net/v2/jpg/04/50/55/90/1000_F_450559026_CTK0vyFVr8d7ryOtZFrptDwT4mWP2IVf.jpg"
                        },
                        new
                        {
                            Id = new Guid("0909894a-7f7c-4f06-aff5-450c2f24dc09"),
                            KindergartenId = 1,
                            Url = "https://as2.ftcdn.net/v2/jpg/02/44/32/23/1000_F_244322317_eantlk9EzUZwcQ68xornkV4hxnGKz16T.jpg"
                        });
                });

            modelBuilder.Entity("KindergartenSystem.Data.Models.Kindergarten", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasMaxLength(120)
                        .HasColumnType("nvarchar(120)");

                    b.Property<string>("EmailAddress")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasMaxLength(13)
                        .HasColumnType("nvarchar(13)");

                    b.Property<string>("Principal")
                        .IsRequired()
                        .HasMaxLength(120)
                        .HasColumnType("nvarchar(120)");

                    b.HasKey("Id");

                    b.ToTable("Kindergartens");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Address = "Varna, ul.Morska 11",
                            EmailAddress = "zaiobaio@zaiobaio.com",
                            Name = "Zaio Baio",
                            PhoneNumber = "+359878888888",
                            Principal = "P.Petrova"
                        });
                });

            modelBuilder.Entity("KindergartenSystem.Data.Models.Parent", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasMaxLength(120)
                        .HasColumnType("nvarchar(120)");

                    b.Property<string>("EmailAddress")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(60)
                        .HasColumnType("nvarchar(60)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasMaxLength(13)
                        .HasColumnType("nvarchar(13)");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)")
                        .HasComment("User Identifier");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Parents");

                    b.HasData(
                        new
                        {
                            Id = new Guid("3cbc521e-07d7-40e5-9d16-655769d51dff"),
                            Address = "ul.Morska 12",
                            EmailAddress = "userparent@user.com",
                            Name = "Iva Ilieva",
                            PhoneNumber = "+359878888881",
                            Status = 1,
                            UserId = "bcb4f072-ecca-43c9-ab26-c060c6f364e3"
                        });
                });

            modelBuilder.Entity("KindergartenSystem.Data.Models.Teacher", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("ClassGroupId")
                        .HasColumnType("int");

                    b.Property<string>("EmailAddress")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImageUrl")
                        .IsRequired()
                        .HasMaxLength(2048)
                        .HasColumnType("nvarchar(2048)");

                    b.Property<bool>("IsWorking")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(true);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(60)
                        .HasColumnType("nvarchar(60)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasMaxLength(13)
                        .HasColumnType("nvarchar(13)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)")
                        .HasComment("User Identifier");

                    b.HasKey("Id");

                    b.HasIndex("ClassGroupId");

                    b.HasIndex("UserId");

                    b.ToTable("Teachers");

                    b.HasData(
                        new
                        {
                            Id = new Guid("43c50b97-9c66-4556-b703-7a0734ce389d"),
                            ClassGroupId = 1,
                            EmailAddress = "admin@admin.bg",
                            ImageUrl = "https://t4.ftcdn.net/jpg/04/75/00/99/360_F_475009987_zwsk4c77x3cTpcI3W1C1LU4pOSyPKaqi.jpg",
                            IsWorking = false,
                            Name = "Admin Admin",
                            PhoneNumber = "+359000000000",
                            UserId = "bcb4f072-ecca-43c9-ab26-c060c6f264e4"
                        });
                });

            modelBuilder.Entity("KindergartenSystem.Data.Models.Workshop", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ChildId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Url")
                        .IsRequired()
                        .HasMaxLength(2048)
                        .HasColumnType("nvarchar(2048)");

                    b.HasKey("Id");

                    b.HasIndex("ChildId");

                    b.ToTable("Workshops");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

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
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("ProviderKey")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

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

            modelBuilder.Entity("KindergartenSystem.Data.Models.AgeGroup", b =>
                {
                    b.HasOne("KindergartenSystem.Data.Models.Kindergarten", "Kindergarten")
                        .WithMany("AgeGroups")
                        .HasForeignKey("KindergartenId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Kindergarten");
                });

            modelBuilder.Entity("KindergartenSystem.Data.Models.Child", b =>
                {
                    b.HasOne("KindergartenSystem.Data.Models.ClassGroup", "ClassGroup")
                        .WithMany("Children")
                        .HasForeignKey("ClassGroupId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("KindergartenSystem.Data.Models.Parent", "Parent")
                        .WithMany("Children")
                        .HasForeignKey("ParentId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("ClassGroup");

                    b.Navigation("Parent");
                });

            modelBuilder.Entity("KindergartenSystem.Data.Models.ClassGroup", b =>
                {
                    b.HasOne("KindergartenSystem.Data.Models.AgeGroup", "AgeGroup")
                        .WithMany("ClassGroups")
                        .HasForeignKey("AgeGroupId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("AgeGroup");
                });

            modelBuilder.Entity("KindergartenSystem.Data.Models.Image", b =>
                {
                    b.HasOne("KindergartenSystem.Data.Models.Kindergarten", "Kindergarten")
                        .WithMany("Images")
                        .HasForeignKey("KindergartenId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Kindergarten");
                });

            modelBuilder.Entity("KindergartenSystem.Data.Models.Parent", b =>
                {
                    b.HasOne("KindergartenSystem.Data.Models.ApplicationUser", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("KindergartenSystem.Data.Models.Teacher", b =>
                {
                    b.HasOne("KindergartenSystem.Data.Models.ClassGroup", "ClassGroup")
                        .WithMany("Teachers")
                        .HasForeignKey("ClassGroupId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("KindergartenSystem.Data.Models.ApplicationUser", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ClassGroup");

                    b.Navigation("User");
                });

            modelBuilder.Entity("KindergartenSystem.Data.Models.Workshop", b =>
                {
                    b.HasOne("KindergartenSystem.Data.Models.Child", "Child")
                        .WithMany("workshops")
                        .HasForeignKey("ChildId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Child");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("KindergartenSystem.Data.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("KindergartenSystem.Data.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("KindergartenSystem.Data.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("KindergartenSystem.Data.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("KindergartenSystem.Data.Models.AgeGroup", b =>
                {
                    b.Navigation("ClassGroups");
                });

            modelBuilder.Entity("KindergartenSystem.Data.Models.Child", b =>
                {
                    b.Navigation("workshops");
                });

            modelBuilder.Entity("KindergartenSystem.Data.Models.ClassGroup", b =>
                {
                    b.Navigation("Children");

                    b.Navigation("Teachers");
                });

            modelBuilder.Entity("KindergartenSystem.Data.Models.Kindergarten", b =>
                {
                    b.Navigation("AgeGroups");

                    b.Navigation("Images");
                });

            modelBuilder.Entity("KindergartenSystem.Data.Models.Parent", b =>
                {
                    b.Navigation("Children");
                });
#pragma warning restore 612, 618
        }
    }
}
