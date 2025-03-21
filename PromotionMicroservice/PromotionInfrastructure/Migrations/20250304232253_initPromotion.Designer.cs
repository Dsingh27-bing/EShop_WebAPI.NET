﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PromotionInfrastructure.Data;

#nullable disable

namespace PromotionInfrastructure.Migrations
{
    [DbContext(typeof(PromotionDbContext))]
    [Migration("20250304232253_initPromotion")]
    partial class initPromotion
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("PromotionApplicationCore.Entities.PromotionDetails", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("ProductCategoryId")
                        .HasColumnType("int");

                    b.Property<string>("ProductCategoryName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PromotionId")
                        .HasColumnType("int");

                    b.Property<int>("PromotionSaleId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("PromotionSaleId");

                    b.ToTable("PromotionDetails");
                });

            modelBuilder.Entity("PromotionApplicationCore.Entities.PromotionSale", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal?>("Discount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime?>("EndDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("StartDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Promotions");
                });

            modelBuilder.Entity("PromotionApplicationCore.Entities.PromotionDetails", b =>
                {
                    b.HasOne("PromotionApplicationCore.Entities.PromotionSale", "PromotionSale")
                        .WithMany("PromotionDetails")
                        .HasForeignKey("PromotionSaleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("PromotionSale");
                });

            modelBuilder.Entity("PromotionApplicationCore.Entities.PromotionSale", b =>
                {
                    b.Navigation("PromotionDetails");
                });
#pragma warning restore 612, 618
        }
    }
}
