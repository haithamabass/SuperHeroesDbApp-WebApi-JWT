﻿// <auto-generated />
using JWTSuperHeroesDb.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace JWTSuperHeroesDb.Migrations.SuperAppDb
{
    [DbContext(typeof(SuperAppDbContext))]
    [Migration("20220226173227_content2")]
    partial class content2
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("JWTSuperHeroesDb.Models.Power", b =>
                {
                    b.Property<int>("PowerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PowerId"), 1L, 1);

                    b.Property<string>("PowerName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("PowerId");

                    b.ToTable("Powers", "Data");
                });

            modelBuilder.Entity("JWTSuperHeroesDb.Models.SuperHero", b =>
                {
                    b.Property<int>("SuperId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("SuperId"), 1L, 1);

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PowerId")
                        .HasColumnType("int");

                    b.Property<double>("Rate")
                        .HasColumnType("float");

                    b.HasKey("SuperId");

                    b.HasIndex("PowerId");

                    b.ToTable("SuperHeroes", "Data");
                });

            modelBuilder.Entity("JWTSuperHeroesDb.Models.SuperHero", b =>
                {
                    b.HasOne("JWTSuperHeroesDb.Models.Power", "Power")
                        .WithMany()
                        .HasForeignKey("PowerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Power");
                });
#pragma warning restore 612, 618
        }
    }
}
