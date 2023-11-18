﻿// <auto-generated />
using System;
using CreditRegistration.MsSql;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace CreditRegistration.MsSql.Migrations
{
    [DbContext(typeof(MsSqlContext))]
    partial class MsSqlContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.13")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("CreditRegistration.DbCommon.Models.LoanOrder", b =>
                {
                    b.Property<long?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long?>("Id"));

                    b.Property<double>("CreditRating")
                        .HasColumnType("float")
                        .HasColumnName("credit_rating");

                    b.Property<string>("OrderId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)")
                        .HasColumnName("order_id");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("status");

                    b.Property<long>("TarrifId")
                        .HasColumnType("bigint")
                        .HasColumnName("tariff_id");

                    b.Property<DateTime>("TimeInsert")
                        .HasColumnType("datetime2")
                        .HasColumnName("time_insert");

                    b.Property<DateTime>("TimeUpdate")
                        .HasColumnType("datetime2")
                        .HasColumnName("time_update");

                    b.Property<long>("UserId")
                        .HasColumnType("bigint")
                        .HasColumnName("user_id");

                    b.HasKey("Id");

                    b.HasIndex("OrderId", "UserId");

                    b.ToTable("loan_order", "CreditRegistrationSchema");
                });

            modelBuilder.Entity("CreditRegistration.DbCommon.Models.Tarrif", b =>
                {
                    b.Property<long?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long?>("Id"));

                    b.Property<string>("InterstRate")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("interest_rate");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("type");

                    b.HasKey("Id");

                    b.HasIndex("Id");

                    b.ToTable("tariff", "CreditRegistrationSchema");
                });
#pragma warning restore 612, 618
        }
    }
}
