﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using StackSwapApplication.Data;

#nullable disable

namespace StackSwapApplication.Migrations
{
    [DbContext(typeof(TradeContext))]
    [Migration("20231108152927_SeededData")]
    partial class SeededData
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("StackSwapApplication.Models.Card", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<int>("CardTier")
                        .HasColumnType("int");

                    b.Property<string>("Champion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Damage")
                        .HasColumnType("float");

                    b.Property<double>("Health")
                        .HasColumnType("float");

                    b.Property<double>("Magic")
                        .HasColumnType("float");

                    b.Property<long>("OwnerID")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("OwnerID");

                    b.ToTable("Cards", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1L,
                            CardTier = 2,
                            Champion = "Ashe",
                            Damage = 900.0,
                            Health = 1200.0,
                            Magic = 320.0,
                            OwnerID = 1L
                        },
                        new
                        {
                            Id = 2L,
                            CardTier = 4,
                            Champion = "Jayce",
                            Damage = 1500.0,
                            Health = 900.0,
                            Magic = 150.0,
                            OwnerID = 1L
                        },
                        new
                        {
                            Id = 3L,
                            CardTier = 4,
                            Champion = "Ahri",
                            Damage = 1345.0,
                            Health = 900.0,
                            Magic = 1256.0,
                            OwnerID = 1L
                        },
                        new
                        {
                            Id = 4L,
                            CardTier = 1,
                            Champion = "Aatrox",
                            Damage = 250.0,
                            Health = 1250.0,
                            Magic = 825.0,
                            OwnerID = 1L
                        },
                        new
                        {
                            Id = 5L,
                            CardTier = 5,
                            Champion = "Jayce",
                            Damage = 1550.0,
                            Health = 950.0,
                            Magic = 200.0,
                            OwnerID = 1L
                        },
                        new
                        {
                            Id = 6L,
                            CardTier = 3,
                            Champion = "Draven",
                            Damage = 2250.0,
                            Health = 1250.0,
                            Magic = 200.0,
                            OwnerID = 2L
                        },
                        new
                        {
                            Id = 7L,
                            CardTier = 3,
                            Champion = "Darius",
                            Damage = 2575.0,
                            Health = 1750.0,
                            Magic = 300.0,
                            OwnerID = 2L
                        },
                        new
                        {
                            Id = 8L,
                            CardTier = 2,
                            Champion = "Jinx",
                            Damage = 1250.0,
                            Health = 900.0,
                            Magic = 550.0,
                            OwnerID = 2L
                        },
                        new
                        {
                            Id = 9L,
                            CardTier = 3,
                            Champion = "Draven",
                            Damage = 2250.0,
                            Health = 1250.0,
                            Magic = 200.0,
                            OwnerID = 3L
                        },
                        new
                        {
                            Id = 10L,
                            CardTier = 1,
                            Champion = "Pyke",
                            Damage = 895.0,
                            Health = 2500.0,
                            Magic = 560.0,
                            OwnerID = 3L
                        },
                        new
                        {
                            Id = 11L,
                            CardTier = 5,
                            Champion = "Sion",
                            Damage = 6250.0,
                            Health = 1200.0,
                            Magic = 550.0,
                            OwnerID = 3L
                        },
                        new
                        {
                            Id = 12L,
                            CardTier = 5,
                            Champion = "Talon",
                            Damage = 1255.0,
                            Health = 950.0,
                            Magic = 235.0,
                            OwnerID = 3L
                        },
                        new
                        {
                            Id = 13L,
                            CardTier = 2,
                            Champion = "Jinx",
                            Damage = 1250.0,
                            Health = 900.0,
                            Magic = 550.0,
                            OwnerID = 3L
                        },
                        new
                        {
                            Id = 14L,
                            CardTier = 3,
                            Champion = "Draven",
                            Damage = 2250.0,
                            Health = 1250.0,
                            Magic = 200.0,
                            OwnerID = 4L
                        },
                        new
                        {
                            Id = 15L,
                            CardTier = 1,
                            Champion = "Pyke",
                            Damage = 895.0,
                            Health = 2500.0,
                            Magic = 560.0,
                            OwnerID = 4L
                        },
                        new
                        {
                            Id = 16L,
                            CardTier = 5,
                            Champion = "Sion",
                            Damage = 6250.0,
                            Health = 1200.0,
                            Magic = 550.0,
                            OwnerID = 4L
                        },
                        new
                        {
                            Id = 17L,
                            CardTier = 5,
                            Champion = "Talon",
                            Damage = 1255.0,
                            Health = 950.0,
                            Magic = 235.0,
                            OwnerID = 4L
                        },
                        new
                        {
                            Id = 18L,
                            CardTier = 2,
                            Champion = "Jinx",
                            Damage = 1250.0,
                            Health = 900.0,
                            Magic = 550.0,
                            OwnerID = 4L
                        },
                        new
                        {
                            Id = 19L,
                            CardTier = 2,
                            Champion = "Ashe",
                            Damage = 900.0,
                            Health = 1200.0,
                            Magic = 320.0,
                            OwnerID = 5L
                        },
                        new
                        {
                            Id = 20L,
                            CardTier = 4,
                            Champion = "Jayce",
                            Damage = 1500.0,
                            Health = 900.0,
                            Magic = 150.0,
                            OwnerID = 5L
                        },
                        new
                        {
                            Id = 21L,
                            CardTier = 4,
                            Champion = "Ahri",
                            Damage = 1345.0,
                            Health = 900.0,
                            Magic = 1256.0,
                            OwnerID = 5L
                        },
                        new
                        {
                            Id = 22L,
                            CardTier = 5,
                            Champion = "Sion",
                            Damage = 6250.0,
                            Health = 1200.0,
                            Magic = 550.0,
                            OwnerID = 5L
                        },
                        new
                        {
                            Id = 23L,
                            CardTier = 5,
                            Champion = "Talon",
                            Damage = 1255.0,
                            Health = 950.0,
                            Magic = 235.0,
                            OwnerID = 5L
                        },
                        new
                        {
                            Id = 24L,
                            CardTier = 2,
                            Champion = "Jinx",
                            Damage = 1250.0,
                            Health = 900.0,
                            Magic = 550.0,
                            OwnerID = 5L
                        },
                        new
                        {
                            Id = 25L,
                            CardTier = 2,
                            Champion = "Jinx",
                            Damage = 1250.0,
                            Health = 900.0,
                            Magic = 550.0,
                            OwnerID = 6L
                        },
                        new
                        {
                            Id = 26L,
                            CardTier = 4,
                            Champion = "Jayce",
                            Damage = 1500.0,
                            Health = 900.0,
                            Magic = 150.0,
                            OwnerID = 6L
                        },
                        new
                        {
                            Id = 27L,
                            CardTier = 4,
                            Champion = "Ahri",
                            Damage = 1345.0,
                            Health = 900.0,
                            Magic = 1256.0,
                            OwnerID = 6L
                        });
                });

            modelBuilder.Entity("StackSwapApplication.Models.TradeUser", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<long>("Credits")
                        .HasColumnType("bigint");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Users", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1L,
                            Credits = 775L,
                            Email = "beng@hotmail.com",
                            Name = "Ben Gorthy",
                            Password = "beng1",
                            UserName = "DovAquila"
                        },
                        new
                        {
                            Id = 2L,
                            Credits = 650L,
                            Email = "joycey@hotmail.com",
                            Name = "Joyce Yang",
                            Password = "joycey2",
                            UserName = "JuicyJ"
                        },
                        new
                        {
                            Id = 3L,
                            Credits = 250L,
                            Email = "jennyn@hotmail.com",
                            Name = "Jenny Nguyen",
                            Password = "jennyn3",
                            UserName = "Jennay"
                        },
                        new
                        {
                            Id = 4L,
                            Credits = 550L,
                            Email = "jenh@hotmail.com",
                            Name = "Jennifer Hunter",
                            Password = "jenh4",
                            UserName = "ViolentJen"
                        },
                        new
                        {
                            Id = 5L,
                            Credits = 1250L,
                            Email = "nafeek@hotmail.com",
                            Name = "Nafee Kamal",
                            Password = "nafeek5",
                            UserName = "Zangun"
                        },
                        new
                        {
                            Id = 6L,
                            Credits = 700L,
                            Email = "jong@hotmail.com",
                            Name = "Johnathan Graham",
                            Password = "johng6",
                            UserName = "TimberWood"
                        });
                });

            modelBuilder.Entity("StackSwapApplication.Models.Card", b =>
                {
                    b.HasOne("StackSwapApplication.Models.TradeUser", "Owner")
                        .WithMany("Cards")
                        .HasForeignKey("OwnerID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Owner");
                });

            modelBuilder.Entity("StackSwapApplication.Models.TradeUser", b =>
                {
                    b.Navigation("Cards");
                });
#pragma warning restore 612, 618
        }
    }
}
