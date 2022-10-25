﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Shop.Data;

#nullable disable

namespace FurnitureShop.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20221006222832_changeData")]
    partial class changeData
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("FurnitureShop.Models.DataModels.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Chairs"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Beds"
                        });
                });

            modelBuilder.Entity("FurnitureShop.Models.DataModels.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int?>("CategoryId")
                        .HasColumnType("int");

                    b.Property<string>("Img")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal?>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.ToTable("Products");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CategoryId = 1,
                            Img = "img/bg-img/1.jpg",
                            Name = "Modern Chair",
                            Price = 180m
                        },
                        new
                        {
                            Id = 2,
                            CategoryId = 2,
                            Img = "img/bg-img/2.jpg",
                            Name = "Minimalistic Plant Pot",
                            Price = 180m
                        },
                        new
                        {
                            Id = 3,
                            CategoryId = 1,
                            Img = "img/bg-img/3.jpg",
                            Name = "Modern Chair",
                            Price = 180m
                        },
                        new
                        {
                            Id = 4,
                            CategoryId = 2,
                            Img = "img/bg-img/4.jpg",
                            Name = "Night Stand",
                            Price = 100m
                        },
                        new
                        {
                            Id = 5,
                            CategoryId = 1,
                            Img = "img/bg-img/5.jpg",
                            Name = "Plant Po",
                            Price = 18m
                        },
                        new
                        {
                            Id = 6,
                            CategoryId = 2,
                            Img = "img/bg-img/6.jpg",
                            Name = "Small Table",
                            Price = 320m
                        },
                        new
                        {
                            Id = 7,
                            CategoryId = 1,
                            Img = "img/bg-img/7.jpg",
                            Name = "Metallic Chair",
                            Price = 318m
                        },
                        new
                        {
                            Id = 8,
                            CategoryId = 2,
                            Img = "img/bg-img/8.jpg",
                            Name = "Modern Rocking Chair",
                            Price = 318m
                        },
                        new
                        {
                            Id = 9,
                            CategoryId = 1,
                            Img = "img/bg-img/9.jpg",
                            Name = "Home Deco",
                            Price = 318m
                        });
                });

            modelBuilder.Entity("FurnitureShop.Models.DataModels.Product", b =>
                {
                    b.HasOne("FurnitureShop.Models.DataModels.Category", "Category")
                        .WithMany("Products")
                        .HasForeignKey("CategoryId");

                    b.Navigation("Category");
                });

            modelBuilder.Entity("FurnitureShop.Models.DataModels.Category", b =>
                {
                    b.Navigation("Products");
                });
#pragma warning restore 612, 618
        }
    }
}
