﻿// <auto-generated />
using System;
using ETicaretAPI.persistence.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace ETicaretAPI.persistence.Migrations
{
    [DbContext(typeof(ETicaretAPIProjectDbContext))]
    [Migration("20230628180941_lastChangeforcMessage")]
    partial class lastChangeforcMessage
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("ETicaretAPI.domain.Entites.Address", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Apartment")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DeletedTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("District")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsSuccess")
                        .HasColumnType("bit");

                    b.Property<string>("Neighborhood")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Street")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("UpdatedTime")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Addresses");
                });

            modelBuilder.Entity("ETicaretAPI.domain.Entites.Basket", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DeletedTime")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsSuccess")
                        .HasColumnType("bit");

                    b.Property<Guid?>("OrderId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("UpdatedTime")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("isBasketConfirm")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.HasIndex("OrderId")
                        .IsUnique()
                        .HasFilter("[OrderId] IS NOT NULL");

                    b.ToTable("Baskets");
                });

            modelBuilder.Entity("ETicaretAPI.domain.Entites.BasketItem", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("BasketId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DeletedTime")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsSuccess")
                        .HasColumnType("bit");

                    b.Property<Guid?>("ProductId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<DateTime?>("UpdatedTime")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("BasketId");

                    b.HasIndex("ProductId");

                    b.ToTable("BasketItems");
                });

            modelBuilder.Entity("ETicaretAPI.domain.Entites.Category", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DeletedTime")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsSuccess")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("UpdatedTime")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            Id = new Guid("c112704c-1192-42d5-b83f-8932cebb59c8"),
                            CreatedDate = new DateTime(2023, 6, 28, 21, 9, 41, 145, DateTimeKind.Local).AddTicks(3599),
                            IsSuccess = true,
                            Name = "Toys"
                        },
                        new
                        {
                            Id = new Guid("d2b26034-015e-4414-abd6-a83c6d1e593a"),
                            CreatedDate = new DateTime(2023, 6, 28, 21, 9, 41, 145, DateTimeKind.Local).AddTicks(3633),
                            IsSuccess = true,
                            Name = "Food"
                        },
                        new
                        {
                            Id = new Guid("c62e3d07-1f16-411e-be9e-a76c6ba445f0"),
                            CreatedDate = new DateTime(2023, 6, 28, 21, 9, 41, 145, DateTimeKind.Local).AddTicks(3636),
                            IsSuccess = true,
                            Name = "Shoe"
                        },
                        new
                        {
                            Id = new Guid("22da9127-f4e9-491f-8440-75765eb4db4a"),
                            CreatedDate = new DateTime(2023, 6, 28, 21, 9, 41, 145, DateTimeKind.Local).AddTicks(3637),
                            IsSuccess = true,
                            Name = "Phone"
                        },
                        new
                        {
                            Id = new Guid("d0c3d27e-1781-46c9-87e1-2b88f48d23f2"),
                            CreatedDate = new DateTime(2023, 6, 28, 21, 9, 41, 145, DateTimeKind.Local).AddTicks(3639),
                            IsSuccess = true,
                            Name = "Laptop"
                        },
                        new
                        {
                            Id = new Guid("ca13f73e-ee19-40ca-9905-678043be4aea"),
                            CreatedDate = new DateTime(2023, 6, 28, 21, 9, 41, 145, DateTimeKind.Local).AddTicks(3641),
                            IsSuccess = true,
                            Name = "Furniture"
                        });
                });

            modelBuilder.Entity("ETicaretAPI.domain.Entites.CommunicationCustomerPerson", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("AppUserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("CommunicationPersonId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DeletedTime")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsSuccess")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("UpdatedTime")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("AppUserId");

                    b.HasIndex("CommunicationPersonId");

                    b.ToTable("CommunicationCustomerPersons");
                });

            modelBuilder.Entity("ETicaretAPI.domain.Entites.CommunicationMessage", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CommunicationCustomerPersonId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DeletedTime")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsSuccess")
                        .HasColumnType("bit");

                    b.Property<bool?>("PersonMessage")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("UpdatedTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("message")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CommunicationCustomerPersonId");

                    b.ToTable("CommunicationMessages");
                });

            modelBuilder.Entity("ETicaretAPI.domain.Entites.CommunicationPerson", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("AppUserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DeletedTime")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsSuccess")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("UpdatedTime")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("AppUserId");

                    b.ToTable("CommunicationPersons");
                });

            modelBuilder.Entity("ETicaretAPI.domain.Entites.Customer", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("AppUserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DeletedTime")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsSuccess")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("UpdatedTime")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("AppUserId");

                    b.ToTable("Customers");
                });

            modelBuilder.Entity("ETicaretAPI.domain.Entites.Identity.AppRole", b =>
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
                });

            modelBuilder.Entity("ETicaretAPI.domain.Entites.Identity.AppRoleClaim", b =>
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

            modelBuilder.Entity("ETicaretAPI.domain.Entites.Identity.AppUser", b =>
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

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Gender")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("ImageId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("IsSuccess")
                        .HasColumnType("bit");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

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

                    b.HasIndex("ImageId")
                        .IsUnique()
                        .HasFilter("[ImageId] IS NOT NULL");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers", (string)null);
                });

            modelBuilder.Entity("ETicaretAPI.domain.Entites.Identity.AppUserClaim", b =>
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

            modelBuilder.Entity("ETicaretAPI.domain.Entites.Identity.AppUserLogin", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("ETicaretAPI.domain.Entites.Identity.AppUserRole", b =>
                {
                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("RoleId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("ETicaretAPI.domain.Entites.Identity.AppUserToken", b =>
                {
                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("ETicaretAPI.domain.Entites.Image", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DeletedTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("FileName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FolderName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsSuccess")
                        .HasColumnType("bit");

                    b.Property<string>("Path")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("UpdatedTime")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Images");
                });

            modelBuilder.Entity("ETicaretAPI.domain.Entites.ImageProduct", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DeletedTime")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("ImageId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("IsSuccess")
                        .HasColumnType("bit");

                    b.Property<Guid>("ProductId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("UpdatedTime")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("ImageId");

                    b.HasIndex("ProductId");

                    b.ToTable("ImageProducts");
                });

            modelBuilder.Entity("ETicaretAPI.domain.Entites.Order", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("AddressId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("CustomerId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("DeletedTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsSuccess")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("UpdatedTime")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("AddressId")
                        .IsUnique();

                    b.HasIndex("CustomerId");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("ETicaretAPI.domain.Entites.Product", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("CategoryId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DeletedTime")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsSuccess")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.Property<string>("ProductCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Stock")
                        .HasColumnType("int");

                    b.Property<DateTime?>("UpdatedTime")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("ETicaretAPI.domain.Entites.Basket", b =>
                {
                    b.HasOne("ETicaretAPI.domain.Entites.Order", "Order")
                        .WithOne("Basket")
                        .HasForeignKey("ETicaretAPI.domain.Entites.Basket", "OrderId");

                    b.Navigation("Order");
                });

            modelBuilder.Entity("ETicaretAPI.domain.Entites.BasketItem", b =>
                {
                    b.HasOne("ETicaretAPI.domain.Entites.Basket", "Basket")
                        .WithMany("BasketItems")
                        .HasForeignKey("BasketId");

                    b.HasOne("ETicaretAPI.domain.Entites.Product", "Product")
                        .WithMany("BasketItems")
                        .HasForeignKey("ProductId");

                    b.Navigation("Basket");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("ETicaretAPI.domain.Entites.CommunicationCustomerPerson", b =>
                {
                    b.HasOne("ETicaretAPI.domain.Entites.Identity.AppUser", "AppUser")
                        .WithMany("CommunicationCustomerPersons")
                        .HasForeignKey("AppUserId");

                    b.HasOne("ETicaretAPI.domain.Entites.CommunicationPerson", "CommunicationPerson")
                        .WithMany("communicationCustomerPersons")
                        .HasForeignKey("CommunicationPersonId");

                    b.Navigation("AppUser");

                    b.Navigation("CommunicationPerson");
                });

            modelBuilder.Entity("ETicaretAPI.domain.Entites.CommunicationMessage", b =>
                {
                    b.HasOne("ETicaretAPI.domain.Entites.CommunicationCustomerPerson", "CommunicationCustomerPerson")
                        .WithMany("CommunicationMessages")
                        .HasForeignKey("CommunicationCustomerPersonId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CommunicationCustomerPerson");
                });

            modelBuilder.Entity("ETicaretAPI.domain.Entites.CommunicationPerson", b =>
                {
                    b.HasOne("ETicaretAPI.domain.Entites.Identity.AppUser", "AppUser")
                        .WithMany("CommunicationPersons")
                        .HasForeignKey("AppUserId");

                    b.Navigation("AppUser");
                });

            modelBuilder.Entity("ETicaretAPI.domain.Entites.Customer", b =>
                {
                    b.HasOne("ETicaretAPI.domain.Entites.Identity.AppUser", "AppUser")
                        .WithMany("Customers")
                        .HasForeignKey("AppUserId");

                    b.Navigation("AppUser");
                });

            modelBuilder.Entity("ETicaretAPI.domain.Entites.Identity.AppRoleClaim", b =>
                {
                    b.HasOne("ETicaretAPI.domain.Entites.Identity.AppRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ETicaretAPI.domain.Entites.Identity.AppUser", b =>
                {
                    b.HasOne("ETicaretAPI.domain.Entites.Image", "Image")
                        .WithOne("AppUser")
                        .HasForeignKey("ETicaretAPI.domain.Entites.Identity.AppUser", "ImageId");

                    b.Navigation("Image");
                });

            modelBuilder.Entity("ETicaretAPI.domain.Entites.Identity.AppUserClaim", b =>
                {
                    b.HasOne("ETicaretAPI.domain.Entites.Identity.AppUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ETicaretAPI.domain.Entites.Identity.AppUserLogin", b =>
                {
                    b.HasOne("ETicaretAPI.domain.Entites.Identity.AppUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ETicaretAPI.domain.Entites.Identity.AppUserRole", b =>
                {
                    b.HasOne("ETicaretAPI.domain.Entites.Identity.AppRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ETicaretAPI.domain.Entites.Identity.AppUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ETicaretAPI.domain.Entites.Identity.AppUserToken", b =>
                {
                    b.HasOne("ETicaretAPI.domain.Entites.Identity.AppUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ETicaretAPI.domain.Entites.ImageProduct", b =>
                {
                    b.HasOne("ETicaretAPI.domain.Entites.Image", "Image")
                        .WithMany("ImageProducts")
                        .HasForeignKey("ImageId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ETicaretAPI.domain.Entites.Product", "Product")
                        .WithMany("ImageProducts")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Image");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("ETicaretAPI.domain.Entites.Order", b =>
                {
                    b.HasOne("ETicaretAPI.domain.Entites.Address", "Address")
                        .WithOne("Order")
                        .HasForeignKey("ETicaretAPI.domain.Entites.Order", "AddressId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ETicaretAPI.domain.Entites.Customer", "Customer")
                        .WithMany("Orders")
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Address");

                    b.Navigation("Customer");
                });

            modelBuilder.Entity("ETicaretAPI.domain.Entites.Product", b =>
                {
                    b.HasOne("ETicaretAPI.domain.Entites.Category", "Category")
                        .WithMany("Products")
                        .HasForeignKey("CategoryId");

                    b.Navigation("Category");
                });

            modelBuilder.Entity("ETicaretAPI.domain.Entites.Address", b =>
                {
                    b.Navigation("Order")
                        .IsRequired();
                });

            modelBuilder.Entity("ETicaretAPI.domain.Entites.Basket", b =>
                {
                    b.Navigation("BasketItems");
                });

            modelBuilder.Entity("ETicaretAPI.domain.Entites.Category", b =>
                {
                    b.Navigation("Products");
                });

            modelBuilder.Entity("ETicaretAPI.domain.Entites.CommunicationCustomerPerson", b =>
                {
                    b.Navigation("CommunicationMessages");
                });

            modelBuilder.Entity("ETicaretAPI.domain.Entites.CommunicationPerson", b =>
                {
                    b.Navigation("communicationCustomerPersons");
                });

            modelBuilder.Entity("ETicaretAPI.domain.Entites.Customer", b =>
                {
                    b.Navigation("Orders");
                });

            modelBuilder.Entity("ETicaretAPI.domain.Entites.Identity.AppUser", b =>
                {
                    b.Navigation("CommunicationCustomerPersons");

                    b.Navigation("CommunicationPersons");

                    b.Navigation("Customers");
                });

            modelBuilder.Entity("ETicaretAPI.domain.Entites.Image", b =>
                {
                    b.Navigation("AppUser")
                        .IsRequired();

                    b.Navigation("ImageProducts");
                });

            modelBuilder.Entity("ETicaretAPI.domain.Entites.Order", b =>
                {
                    b.Navigation("Basket")
                        .IsRequired();
                });

            modelBuilder.Entity("ETicaretAPI.domain.Entites.Product", b =>
                {
                    b.Navigation("BasketItems");

                    b.Navigation("ImageProducts");
                });
#pragma warning restore 612, 618
        }
    }
}
