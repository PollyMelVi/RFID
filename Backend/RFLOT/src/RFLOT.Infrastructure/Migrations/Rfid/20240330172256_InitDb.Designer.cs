﻿// <auto-generated />
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using RFLOT.Domain.Plane.ValueObjects;
using RFLOT.Infrastructure.Equip;

#nullable disable

namespace RFLOT.Infrastructure.Migrations.Rfid
{
    [DbContext(typeof(RfidDbContext))]
    [Migration("20240330172256_InitDb")]
    partial class InitDb
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("RFLOT.Domain.Equip.Equip", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text");

                    b.Property<DateTimeOffset?>("DateTimeEnd")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTimeOffset>("DateTimeStart")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("IdPlane")
                        .HasColumnType("text");

                    b.Property<int>("LastStatus")
                        .HasColumnType("integer");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Space")
                        .HasColumnType("text");

                    b.Property<int>("Type")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.ToTable("Equips");
                });

            modelBuilder.Entity("RFLOT.Domain.People.People", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("Role")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.ToTable("Peoples");
                });

            modelBuilder.Entity("RFLOT.Domain.Plane.Plane", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text");

                    b.Property<IEnumerable<Zone>>("Zones")
                        .IsRequired()
                        .HasColumnType("jsonb");

                    b.HasKey("Id");

                    b.ToTable("Planes");
                });
#pragma warning restore 612, 618
        }
    }
}
