﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using StackSwapApplication.Data;

#nullable disable

namespace StackSwapApplication.Migrations
{
    [DbContext(typeof(TradeContext))]
    [Migration("20231118024013_CompletionToTrade")]
    partial class CompletionToTrade
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.11");

            modelBuilder.Entity("StackSwapApplication.Models.Card", b =>
                {
                    b.Property<uint>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<bool>("Available")
                        .HasColumnType("INTEGER");

                    b.Property<int>("CardTier")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Champion")
                        .HasColumnType("TEXT");

                    b.Property<double>("Damage")
                        .HasColumnType("REAL");

                    b.Property<double>("Health")
                        .HasColumnType("REAL");

                    b.Property<double>("Magic")
                        .HasColumnType("REAL");

                    b.Property<uint>("OwnerID")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("OwnerID");

                    b.ToTable("Cards", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1u,
                            Available = true,
                            CardTier = 1,
                            Champion = "Ashe",
                            Damage = 1250.0,
                            Health = 800.0,
                            Magic = 1500.0,
                            OwnerID = 1u
                        },
                        new
                        {
                            Id = 2u,
                            Available = true,
                            CardTier = 2,
                            Champion = "Ashe",
                            Damage = 1300.0,
                            Health = 850.0,
                            Magic = 1550.0,
                            OwnerID = 1u
                        },
                        new
                        {
                            Id = 3u,
                            Available = true,
                            CardTier = 1,
                            Champion = "Draven",
                            Damage = 3550.0,
                            Health = 2800.0,
                            Magic = 500.0,
                            OwnerID = 1u
                        },
                        new
                        {
                            Id = 4u,
                            Available = true,
                            CardTier = 5,
                            Champion = "Urgot",
                            Damage = 5250.0,
                            Health = 900.0,
                            Magic = 7500.0,
                            OwnerID = 1u
                        },
                        new
                        {
                            Id = 5u,
                            Available = true,
                            CardTier = 5,
                            Champion = "Draven",
                            Damage = 4025.0,
                            Health = 5800.0,
                            Magic = 2500.0,
                            OwnerID = 2u
                        },
                        new
                        {
                            Id = 6u,
                            Available = true,
                            CardTier = 2,
                            Champion = "Jarvan",
                            Damage = 3200.0,
                            Health = 2800.0,
                            Magic = 4500.0,
                            OwnerID = 2u
                        },
                        new
                        {
                            Id = 7u,
                            Available = true,
                            CardTier = 2,
                            Champion = "Ashe",
                            Damage = 1300.0,
                            Health = 850.0,
                            Magic = 1550.0,
                            OwnerID = 3u
                        },
                        new
                        {
                            Id = 8u,
                            Available = true,
                            CardTier = 5,
                            Champion = "Jax",
                            Damage = 1300.0,
                            Health = 1850.0,
                            Magic = 4550.0,
                            OwnerID = 4u
                        },
                        new
                        {
                            Id = 9u,
                            Available = true,
                            CardTier = 4,
                            Champion = "Olaf",
                            Damage = 6550.0,
                            Health = 3800.0,
                            Magic = 500.0,
                            OwnerID = 4u
                        },
                        new
                        {
                            Id = 10u,
                            Available = true,
                            CardTier = 4,
                            Champion = "Tarin",
                            Damage = 1250.0,
                            Health = 1900.0,
                            Magic = 7500.0,
                            OwnerID = 4u
                        },
                        new
                        {
                            Id = 11u,
                            Available = true,
                            CardTier = 5,
                            Champion = "Jax",
                            Damage = 1300.0,
                            Health = 1850.0,
                            Magic = 4550.0,
                            OwnerID = 5u
                        },
                        new
                        {
                            Id = 12u,
                            Available = true,
                            CardTier = 1,
                            Champion = "Draven",
                            Damage = 3550.0,
                            Health = 2800.0,
                            Magic = 500.0,
                            OwnerID = 5u
                        },
                        new
                        {
                            Id = 13u,
                            Available = true,
                            CardTier = 2,
                            Champion = "Jarvan",
                            Damage = 3200.0,
                            Health = 2800.0,
                            Magic = 4500.0,
                            OwnerID = 6u
                        },
                        new
                        {
                            Id = 14u,
                            Available = true,
                            CardTier = 2,
                            Champion = "Ashe",
                            Damage = 1300.0,
                            Health = 850.0,
                            Magic = 1550.0,
                            OwnerID = 6u
                        },
                        new
                        {
                            Id = 15u,
                            Available = true,
                            CardTier = 5,
                            Champion = "Jax",
                            Damage = 1300.0,
                            Health = 1850.0,
                            Magic = 4550.0,
                            OwnerID = 7u
                        },
                        new
                        {
                            Id = 16u,
                            Available = true,
                            CardTier = 4,
                            Champion = "Olaf",
                            Damage = 6550.0,
                            Health = 3800.0,
                            Magic = 500.0,
                            OwnerID = 7u
                        },
                        new
                        {
                            Id = 17u,
                            Available = true,
                            CardTier = 4,
                            Champion = "Tarin",
                            Damage = 1250.0,
                            Health = 1900.0,
                            Magic = 7500.0,
                            OwnerID = 7u
                        },
                        new
                        {
                            Id = 18u,
                            Available = true,
                            CardTier = 5,
                            Champion = "Jax",
                            Damage = 1300.0,
                            Health = 1850.0,
                            Magic = 4550.0,
                            OwnerID = 7u
                        },
                        new
                        {
                            Id = 19u,
                            Available = true,
                            CardTier = 1,
                            Champion = "Draven",
                            Damage = 3550.0,
                            Health = 2800.0,
                            Magic = 500.0,
                            OwnerID = 7u
                        },
                        new
                        {
                            Id = 20u,
                            Available = true,
                            CardTier = 5,
                            Champion = "Darius",
                            Damage = 7300.0,
                            Health = 2850.0,
                            Magic = 750.0,
                            OwnerID = 8u
                        },
                        new
                        {
                            Id = 21u,
                            Available = true,
                            CardTier = 4,
                            Champion = "A",
                            Damage = 550.0,
                            Health = 7800.0,
                            Magic = 3500.0,
                            OwnerID = 8u
                        },
                        new
                        {
                            Id = 22u,
                            Available = true,
                            CardTier = 4,
                            Champion = "Olaf",
                            Damage = 6550.0,
                            Health = 3800.0,
                            Magic = 500.0,
                            OwnerID = 9u
                        },
                        new
                        {
                            Id = 23u,
                            Available = true,
                            CardTier = 4,
                            Champion = "Tarin",
                            Damage = 1250.0,
                            Health = 1900.0,
                            Magic = 7500.0,
                            OwnerID = 9u
                        },
                        new
                        {
                            Id = 24u,
                            Available = true,
                            CardTier = 5,
                            Champion = "Jax",
                            Damage = 1300.0,
                            Health = 1850.0,
                            Magic = 4550.0,
                            OwnerID = 9u
                        });
                });

            modelBuilder.Entity("StackSwapApplication.Models.Purchase", b =>
                {
                    b.Property<uint>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<uint>("BuyerId")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime?>("PurchaseDate")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("BuyerId");

                    b.ToTable("Purchases", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1u,
                            BuyerId = 5u,
                            PurchaseDate = new DateTime(2020, 5, 1, 13, 30, 0, 0, DateTimeKind.Unspecified)
                        });
                });

            modelBuilder.Entity("StackSwapApplication.Models.PurchaseCard", b =>
                {
                    b.Property<uint>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<uint>("CardId")
                        .HasColumnType("INTEGER");

                    b.Property<uint>("PurchaseId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("PurchaseId");

                    b.ToTable("PurchaseCards");

                    b.HasData(
                        new
                        {
                            Id = 1u,
                            CardId = 11u,
                            PurchaseId = 1u
                        });
                });

            modelBuilder.Entity("StackSwapApplication.Models.Trade", b =>
                {
                    b.Property<uint>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<uint>("BuyerId")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime?>("CompletedDate")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("InitatedDate")
                        .HasColumnType("TEXT");

                    b.Property<bool>("IsAccepted")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("IsComplete")
                        .HasColumnType("INTEGER");

                    b.Property<uint>("SellerId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("BuyerId");

                    b.HasIndex("SellerId");

                    b.ToTable("Trades", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1u,
                            BuyerId = 7u,
                            CompletedDate = new DateTime(2023, 7, 15, 12, 30, 4, 0, DateTimeKind.Unspecified),
                            InitatedDate = new DateTime(2023, 7, 12, 22, 20, 4, 0, DateTimeKind.Unspecified),
                            IsAccepted = true,
                            IsComplete = true,
                            SellerId = 9u
                        });
                });

            modelBuilder.Entity("StackSwapApplication.Models.TradeBuyerCard", b =>
                {
                    b.Property<uint>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<uint>("BuyerId")
                        .HasColumnType("INTEGER");

                    b.Property<uint>("CardId")
                        .HasColumnType("INTEGER");

                    b.Property<uint>("TradeId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("TradeId");

                    b.ToTable("TradeBuyerCards", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1u,
                            BuyerId = 7u,
                            CardId = 24u,
                            TradeId = 1u
                        },
                        new
                        {
                            Id = 2u,
                            BuyerId = 7u,
                            CardId = 23u,
                            TradeId = 1u
                        });
                });

            modelBuilder.Entity("StackSwapApplication.Models.TradeSellerCard", b =>
                {
                    b.Property<uint>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<uint>("CardId")
                        .HasColumnType("INTEGER");

                    b.Property<uint>("SellerId")
                        .HasColumnType("INTEGER");

                    b.Property<uint>("TradeId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("TradeId");

                    b.ToTable("TradeSellerCards", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1u,
                            CardId = 15u,
                            SellerId = 9u,
                            TradeId = 1u
                        });
                });

            modelBuilder.Entity("StackSwapApplication.Models.TradeUser", b =>
                {
                    b.Property<uint>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<uint>("Credits")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Email")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.Property<string>("Password")
                        .HasColumnType("TEXT");

                    b.Property<string>("Username")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Users", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1u,
                            Credits = 2755u,
                            Email = "bgorthy@gmail.com",
                            Name = "Ben Gorthy",
                            Password = "beng1",
                            Username = "Dovaquila"
                        },
                        new
                        {
                            Id = 2u,
                            Credits = 1500u,
                            Email = "nKamal@gmail.com",
                            Name = "Nafee Kamal",
                            Password = "nKamal2",
                            Username = "Zangun"
                        },
                        new
                        {
                            Id = 3u,
                            Credits = 5500u,
                            Email = "jhunter@gmail.com",
                            Name = "Jennifer Hunter",
                            Password = "jHunter3",
                            Username = "VioletJen"
                        },
                        new
                        {
                            Id = 4u,
                            Credits = 500u,
                            Email = "jyang@gmail.com",
                            Name = "Joyce Yang",
                            Password = "jYang5",
                            Username = "JuicyJ"
                        },
                        new
                        {
                            Id = 5u,
                            Credits = 5500u,
                            Email = "jnguyen@gmail.com",
                            Name = "Jenny Nguyen",
                            Password = "jjNguy",
                            Username = "J-Wizzy"
                        },
                        new
                        {
                            Id = 6u,
                            Credits = 17500u,
                            Email = "jjohng@gmail.com",
                            Name = "Johnathan Graham",
                            Password = "jGraham2",
                            Username = "JonJonQ"
                        },
                        new
                        {
                            Id = 7u,
                            Credits = 175u,
                            Email = "shazadU@gmail.com",
                            Name = "Umair Shazad",
                            Password = "umRick22",
                            Username = "BigRick"
                        },
                        new
                        {
                            Id = 8u,
                            Credits = 350u,
                            Email = "sgangnon@gmail.com",
                            Name = "Shannon Gangnon",
                            Password = "sh559",
                            Username = "Shananigans"
                        },
                        new
                        {
                            Id = 9u,
                            Credits = 1255u,
                            Email = "miaCIA@gmail.com",
                            Name = "Mia Cia",
                            Password = "miaCy55",
                            Username = "CiayteMi"
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

            modelBuilder.Entity("StackSwapApplication.Models.Purchase", b =>
                {
                    b.HasOne("StackSwapApplication.Models.TradeUser", "Buyer")
                        .WithMany("Purchases")
                        .HasForeignKey("BuyerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Buyer");
                });

            modelBuilder.Entity("StackSwapApplication.Models.PurchaseCard", b =>
                {
                    b.HasOne("StackSwapApplication.Models.Purchase", "Purchase")
                        .WithMany("PurchaseCards")
                        .HasForeignKey("PurchaseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Purchase");
                });

            modelBuilder.Entity("StackSwapApplication.Models.Trade", b =>
                {
                    b.HasOne("StackSwapApplication.Models.TradeUser", "Buyer")
                        .WithMany("Trades")
                        .HasForeignKey("BuyerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("StackSwapApplication.Models.TradeUser", "Seller")
                        .WithMany()
                        .HasForeignKey("SellerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Buyer");

                    b.Navigation("Seller");
                });

            modelBuilder.Entity("StackSwapApplication.Models.TradeBuyerCard", b =>
                {
                    b.HasOne("StackSwapApplication.Models.Trade", "Trade")
                        .WithMany("buyerCardsInfo")
                        .HasForeignKey("TradeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Trade");
                });

            modelBuilder.Entity("StackSwapApplication.Models.TradeSellerCard", b =>
                {
                    b.HasOne("StackSwapApplication.Models.Trade", "Trade")
                        .WithMany("sellerCardsInfo")
                        .HasForeignKey("TradeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Trade");
                });

            modelBuilder.Entity("StackSwapApplication.Models.Purchase", b =>
                {
                    b.Navigation("PurchaseCards");
                });

            modelBuilder.Entity("StackSwapApplication.Models.Trade", b =>
                {
                    b.Navigation("buyerCardsInfo");

                    b.Navigation("sellerCardsInfo");
                });

            modelBuilder.Entity("StackSwapApplication.Models.TradeUser", b =>
                {
                    b.Navigation("Cards");

                    b.Navigation("Purchases");

                    b.Navigation("Trades");
                });
#pragma warning restore 612, 618
        }
    }
}
