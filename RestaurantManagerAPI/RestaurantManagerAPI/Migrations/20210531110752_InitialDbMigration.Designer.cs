﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using RestaurantManagerAPI.Models;

namespace RestaurantManagerAPI.Migrations
{
    [DbContext(typeof(RestaurantDbContext))]
    [Migration("20210531110752_InitialDbMigration")]
    partial class InitialDbMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
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

                    b.HasKey("CustomerID");

                    b.ToTable("Customers");
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

                    b.HasKey("FoodID");

                    b.ToTable("FoodItems");
                });

            modelBuilder.Entity("RestaurantManagerAPI.Models.OrderMasters", b =>
                {
                    b.Property<int>("OrderMasterID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CustomerID")
                        .HasColumnType("int");

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
