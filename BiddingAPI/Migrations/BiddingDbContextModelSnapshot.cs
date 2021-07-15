﻿// <auto-generated />
using BiddingAPI.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace BiddingAPI.Migrations
{
    [DbContext(typeof(BiddingDbContext))]
    partial class BiddingDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.0");

            modelBuilder.Entity("BiddingAPI.Models.CurrentValue", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<double>("CurrentPrice")
                        .HasColumnType("float");

                    b.Property<int>("ProdId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Currentvalue");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CurrentPrice = 1000.0,
                            ProdId = 1
                        },
                        new
                        {
                            Id = 2,
                            CurrentPrice = 2000.0,
                            ProdId = 2
                        },
                        new
                        {
                            Id = 3,
                            CurrentPrice = 150.0,
                            ProdId = 3
                        },
                        new
                        {
                            Id = 4,
                            CurrentPrice = 5000.0,
                            ProdId = 4
                        },
                        new
                        {
                            Id = 5,
                            CurrentPrice = 200.0,
                            ProdId = 5
                        });
                });
#pragma warning restore 612, 618
        }
    }
}