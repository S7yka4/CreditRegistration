﻿// <auto-generated />
using System;
using CreditRegistration.Postgre;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace CreditRegistration.Postgre.Migrations
{
    [DbContext(typeof(PostgreContext))]
    partial class PostgreContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.13")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("CreditRegistration.DbCommon.Models.LoanOrder", b =>
                {
                    b.Property<long?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long?>("Id"));

                    b.Property<double>("CreditRating")
                        .HasColumnType("double precision")
                        .HasColumnName("credit_rating");

                    b.Property<string>("OrderId")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("order_id");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("status");

                    b.Property<long>("TarrifId")
                        .HasColumnType("bigint")
                        .HasColumnName("tariff_id");

                    b.Property<DateTime>("TimeInsert")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("time_insert");

                    b.Property<DateTime>("TimeUpdate")
                        .HasColumnType("timestamp with time zone")
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

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long?>("Id"));

                    b.Property<string>("InterstRate")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("interest_rate");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("type");

                    b.HasKey("Id");

                    b.HasIndex("Id");

                    b.ToTable("tariff", "CreditRegistrationSchema");
                });
#pragma warning restore 612, 618
        }
    }
}