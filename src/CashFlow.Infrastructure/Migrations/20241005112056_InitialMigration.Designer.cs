﻿// <auto-generated />
using System;
using CashFlow.Infrastructure.DataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace CashFlow.Infrastructure.Migrations
{
    [DbContext(typeof(CashFlowDbContext))]
    [Migration("20241005112056_InitialMigration")]
    partial class InitialMigration
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            MySqlModelBuilderExtensions.AutoIncrementColumns(modelBuilder);

            modelBuilder.Entity("CashFlow.Domain.Entities.Expense", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<long>("Id"));

                    b.Property<decimal>("Amount")
                        .HasColumnType("DECIMAL(18,2)")
                        .HasColumnName("Amount");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime(6)")
                        .HasColumnName("Date");

                    b.Property<string>("Description")
                        .HasMaxLength(500)
                        .HasColumnType("varchar(500)")
                        .HasColumnName("Description");

                    b.Property<string>("PaymentType")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("PaymentType");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(80)
                        .HasColumnType("varchar(80)")
                        .HasColumnName("Title");

                    b.Property<long>("UserId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Expenses", (string)null);
                });

            modelBuilder.Entity("CashFlow.Domain.Entities.User", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<long>("Id"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Role")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<Guid>("UserIdentifier")
                        .HasColumnType("char(36)");

                    b.HasKey("Id");

                    b.ToTable("User");
                });

            modelBuilder.Entity("CashFlow.Domain.Entities.Expense", b =>
                {
                    b.HasOne("CashFlow.Domain.Entities.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });
#pragma warning restore 612, 618
        }
    }
}
