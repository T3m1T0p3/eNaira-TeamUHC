﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using enairaUHC.AppDbContext;

namespace enairaUHC.Migrations
{
    [DbContext(typeof(EnairaDbContext))]
    [Migration("20220805190421_initUHCDbContext")]
    partial class initUHCDbContext
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.14")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("enairaUHC.src.Entity.Insurer", b =>
                {
                    b.Property<string>("InsurerId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("WalletAddress")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("InsurerId");

                    b.ToTable("Insurers");
                });

            modelBuilder.Entity("enairaUHC.src.Transaction", b =>
                {
                    b.Property<Guid>("TransactionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<double>("Amount")
                        .HasColumnType("float");

                    b.Property<string>("BVN")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DateTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("FromWallet")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ToWallet")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TransactionStatus")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("TransactionId");

                    b.ToTable("Transactions");
                });

            modelBuilder.Entity("enairaUHC.src.User", b =>
                {
                    b.Property<string>("BVN")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("InsureranceStatus")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MiddleName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("WalletAddress")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("BVN");

                    b.HasIndex("WalletAddress");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("enairaUHC.src.Wallet", b =>
                {
                    b.Property<Guid>("WalletAddress")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("BVN")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Balance")
                        .HasColumnType("float");

                    b.HasKey("WalletAddress");

                    b.ToTable("Wallet");
                });

            modelBuilder.Entity("enairaUHC.src.eNairaServices.EnairaUser", b =>
                {
                    b.Property<Guid>("EnairaUserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("AccountNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("BVN")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ChannelCode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CustomerTier")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Reference")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("EnairaUserId");

                    b.ToTable("ENairerUsers");
                });

            modelBuilder.Entity("enairaUHC.src.User", b =>
                {
                    b.HasOne("enairaUHC.src.Wallet", "Wallet")
                        .WithMany()
                        .HasForeignKey("WalletAddress");

                    b.Navigation("Wallet");
                });
#pragma warning restore 612, 618
        }
    }
}
