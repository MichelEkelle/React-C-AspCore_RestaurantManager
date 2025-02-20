﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using RestaurantManagerAPI.Models;

namespace RestaurantManagerAPI.Migrations
{
    [DbContext(typeof(RestaurantDbContext))]
    partial class RestaurantDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.6")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("RestaurantManagerAPI.Models.Customers", b =>
                {
                    b.Property<int>("CustomerID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CustomerName")
                        .HasColumnType("nvarchar(100)");

                    b.Property<bool>("Isdeleted")
                        .HasColumnType("bit");

                    b.HasKey("CustomerID");

                    b.ToTable("Customers");

                    b.HasData(
                        new
                        {
                            CustomerID = 1,
                            CustomerName = "Michel Ekelle",
                            Isdeleted = false
                        },
                        new
                        {
                            CustomerID = 2,
                            CustomerName = "Aymen Zalila",
                            Isdeleted = false
                        },
                        new
                        {
                            CustomerID = 3,
                            CustomerName = "Jerome decary",
                            Isdeleted = false
                        },
                        new
                        {
                            CustomerID = 4,
                            CustomerName = "Sophie Goudreau",
                            Isdeleted = false
                        });
                });

            modelBuilder.Entity("RestaurantManagerAPI.Models.FoodItems", b =>
                {
                    b.Property<int>("FoodID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("FoodName")
                        .HasColumnType("nvarchar(100)");

                    b.Property<decimal>("FoodPrice")
                        .HasColumnType("decimal(18,2)");

                    b.Property<bool>("Isdeleted")
                        .HasColumnType("bit");

                    b.HasKey("FoodID");

                    b.ToTable("FoodItems");

                    b.HasData(
                        new
                        {
                            FoodID = 1,
                            FoodName = "Poutine-frites",
                            FoodPrice = 6.5m,
                            Isdeleted = false
                        },
                        new
                        {
                            FoodID = 2,
                            FoodName = "hot Dog",
                            FoodPrice = 5.5m,
                            Isdeleted = false
                        },
                        new
                        {
                            FoodID = 3,
                            FoodName = "Salade",
                            FoodPrice = 2.5m,
                            Isdeleted = false
                        },
                        new
                        {
                            FoodID = 4,
                            FoodName = "Poutine-Poulet-frites",
                            FoodPrice = 8m,
                            Isdeleted = false
                        },
                        new
                        {
                            FoodID = 5,
                            FoodName = "Hambuger",
                            FoodPrice = 6.5m,
                            Isdeleted = false
                        });
                });

            modelBuilder.Entity("RestaurantManagerAPI.Models.OrderMasters", b =>
                {
                    b.Property<int>("OrderMasterID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CustomerID")
                        .HasColumnType("int");

                    b.Property<bool>("Isdeleted")
                        .HasColumnType("bit");

                    b.Property<string>("OrderNote")
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("OrderNumber")
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("PaymentMethod")
                        .HasColumnType("nvarchar(20)");

                    b.Property<decimal>("TotalPrice")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("OrderMasterID");

                    b.HasIndex("CustomerID");

                    b.ToTable("OrderMasters");
                });

            modelBuilder.Entity("RestaurantManagerAPI.Models.OrdersItems", b =>
                {
                    b.Property<int>("OrderItemID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("FoodItemID")
                        .HasColumnType("int");

                    b.Property<decimal>("FoodItemPrice")
                        .HasColumnType("decimal(18,2)");

                    b.Property<bool>("Isdeleted")
                        .HasColumnType("bit");

                    b.Property<int>("OrderMasterID")
                        .HasColumnType("int");

                    b.Property<int?>("OrderMastersOrderMasterID")
                        .HasColumnType("int");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.HasKey("OrderItemID");

                    b.HasIndex("FoodItemID");

                    b.HasIndex("OrderMastersOrderMasterID");

                    b.ToTable("OrdersItems");
                });

            modelBuilder.Entity("RestaurantManagerAPI.Models.OrderMasters", b =>
                {
                    b.HasOne("RestaurantManagerAPI.Models.Customers", "Customer")
                        .WithMany()
                        .HasForeignKey("CustomerID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Customer");
                });

            modelBuilder.Entity("RestaurantManagerAPI.Models.OrdersItems", b =>
                {
                    b.HasOne("RestaurantManagerAPI.Models.FoodItems", "FoodItem")
                        .WithMany()
                        .HasForeignKey("FoodItemID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("RestaurantManagerAPI.Models.OrderMasters", null)
                        .WithMany("OrderItemList")
                        .HasForeignKey("OrderMastersOrderMasterID");

                    b.Navigation("FoodItem");
                });

            modelBuilder.Entity("RestaurantManagerAPI.Models.OrderMasters", b =>
                {
                    b.Navigation("OrderItemList");
                });
#pragma warning restore 612, 618
        }
    }
}
