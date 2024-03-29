﻿// <auto-generated />
using System;
using EFDemo;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace EFDemo.Migrations
{
    [DbContext(typeof(Bank))]
    partial class BankModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("EFDemo.Account", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Account");

                    b.HasData(
                        new
                        {
                            Id = -1,
                            Name = "Nandini"
                        },
                        new
                        {
                            Id = -2,
                            Name = "Olha"
                        });
                });

            modelBuilder.Entity("EFDemo.Transaction", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<decimal>("Amount")
                        .HasColumnType("numeric");

                    b.Property<int>("RecipientAccountId")
                        .HasColumnType("integer");

                    b.Property<string>("Reference")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("SenderAccountId")
                        .HasColumnType("integer");

                    b.Property<DateTime>("Timestamp")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.HasIndex("RecipientAccountId");

                    b.HasIndex("SenderAccountId");

                    b.ToTable("Transaction");

                    b.HasData(
                        new
                        {
                            Id = -1,
                            Amount = 10m,
                            RecipientAccountId = -2,
                            Reference = "Mushroom burger",
                            SenderAccountId = -1,
                            Timestamp = new DateTime(2024, 3, 1, 16, 40, 46, 70, DateTimeKind.Utc).AddTicks(4211)
                        });
                });

            modelBuilder.Entity("EFDemo.Transaction", b =>
                {
                    b.HasOne("EFDemo.Account", "RecipientAccount")
                        .WithMany("InTransactions")
                        .HasForeignKey("RecipientAccountId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EFDemo.Account", "SenderAccount")
                        .WithMany("OutTransactions")
                        .HasForeignKey("SenderAccountId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("RecipientAccount");

                    b.Navigation("SenderAccount");
                });

            modelBuilder.Entity("EFDemo.Account", b =>
                {
                    b.Navigation("InTransactions");

                    b.Navigation("OutTransactions");
                });
#pragma warning restore 612, 618
        }
    }
}
