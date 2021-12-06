﻿// <auto-generated />
using System;
using L_DINER.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace L_DINER.Migrations
{
    [DbContext(typeof(LDINER_DBContext))]
    [Migration("20211206023453_DBChange4")]
    partial class DBChange4
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.12")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("L_DINER.Models.Burger", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("ID");

                    b.ToTable("Burgers");
                });

            modelBuilder.Entity("L_DINER.Models.Drink", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("ID");

                    b.ToTable("Drinks");
                });

            modelBuilder.Entity("L_DINER.Models.Ingredient", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.ToTable("Ingredient");
                });

            modelBuilder.Entity("L_DINER.Models.IngredientLine", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("BurgerID")
                        .HasColumnType("int");

                    b.Property<int?>("IngredientID")
                        .HasColumnType("int");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("BurgerID");

                    b.HasIndex("IngredientID");

                    b.ToTable("IngredientLine");
                });

            modelBuilder.Entity("L_DINER.Models.Order", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("OrderState")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.Property<int>("UserID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("L_DINER.Models.OrderObjectForBurger", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("BurgerID")
                        .HasColumnType("int");

                    b.Property<int?>("OrderID")
                        .HasColumnType("int");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("BurgerID");

                    b.HasIndex("OrderID");

                    b.ToTable("OrderObjectForBurger");
                });

            modelBuilder.Entity("L_DINER.Models.OrderObjectForDrink", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("DrinkID")
                        .HasColumnType("int");

                    b.Property<int?>("OrderID")
                        .HasColumnType("int");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("DrinkID");

                    b.HasIndex("OrderID");

                    b.ToTable("OrderObjectForDrink");
                });

            modelBuilder.Entity("L_DINER.Models.OrderObjectForSide", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("OrderID")
                        .HasColumnType("int");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<int?>("SideID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("OrderID");

                    b.HasIndex("SideID");

                    b.ToTable("OrderObjectForSide");
                });

            modelBuilder.Entity("L_DINER.Models.Side", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("ID");

                    b.ToTable("Sides");
                });

            modelBuilder.Entity("L_DINER.Models.IngredientLine", b =>
                {
                    b.HasOne("L_DINER.Models.Burger", null)
                        .WithMany("Ingredients")
                        .HasForeignKey("BurgerID");

                    b.HasOne("L_DINER.Models.Ingredient", "Ingredient")
                        .WithMany()
                        .HasForeignKey("IngredientID");

                    b.Navigation("Ingredient");
                });

            modelBuilder.Entity("L_DINER.Models.OrderObjectForBurger", b =>
                {
                    b.HasOne("L_DINER.Models.Burger", "Burger")
                        .WithMany()
                        .HasForeignKey("BurgerID");

                    b.HasOne("L_DINER.Models.Order", null)
                        .WithMany("Burgers")
                        .HasForeignKey("OrderID");

                    b.Navigation("Burger");
                });

            modelBuilder.Entity("L_DINER.Models.OrderObjectForDrink", b =>
                {
                    b.HasOne("L_DINER.Models.Drink", "Drink")
                        .WithMany()
                        .HasForeignKey("DrinkID");

                    b.HasOne("L_DINER.Models.Order", null)
                        .WithMany("Drinks")
                        .HasForeignKey("OrderID");

                    b.Navigation("Drink");
                });

            modelBuilder.Entity("L_DINER.Models.OrderObjectForSide", b =>
                {
                    b.HasOne("L_DINER.Models.Order", null)
                        .WithMany("Sides")
                        .HasForeignKey("OrderID");

                    b.HasOne("L_DINER.Models.Side", "Side")
                        .WithMany()
                        .HasForeignKey("SideID");

                    b.Navigation("Side");
                });

            modelBuilder.Entity("L_DINER.Models.Burger", b =>
                {
                    b.Navigation("Ingredients");
                });

            modelBuilder.Entity("L_DINER.Models.Order", b =>
                {
                    b.Navigation("Burgers");

                    b.Navigation("Drinks");

                    b.Navigation("Sides");
                });
#pragma warning restore 612, 618
        }
    }
}
