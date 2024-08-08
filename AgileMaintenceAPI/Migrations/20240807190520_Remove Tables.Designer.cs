﻿// <auto-generated />
using System;
using AgileMaintenceAPI.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace AgileMaintenceAPI.Migrations
{
    [DbContext(typeof(AgileMaintenceAPIContext))]
    [Migration("20240807190520_Remove Tables")]
    partial class RemoveTables
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            MySqlModelBuilderExtensions.AutoIncrementColumns(modelBuilder);

            modelBuilder.Entity("AgileMaintenceAPI.Models.Client", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<string>("Cpf")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<bool>("IsActive")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Clients");
                });

            modelBuilder.Entity("AgileMaintenceAPI.Models.OrderService", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<Guid>("ClientId")
                        .HasColumnType("char(36)");

                    b.Property<DateTime>("DateEnd")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime>("DateInit")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Defect")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<bool>("IsActive")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("Plate")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Vehicle")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.HasIndex("ClientId");

                    b.ToTable("OrderServices");
                });

            modelBuilder.Entity("AgileMaintenceAPI.Models.OrderService", b =>
                {
                    b.HasOne("AgileMaintenceAPI.Models.Client", "Client")
                        .WithMany("OrderServices")
                        .HasForeignKey("ClientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Client");
                });

            modelBuilder.Entity("AgileMaintenceAPI.Models.Client", b =>
                {
                    b.Navigation("OrderServices");
                });
#pragma warning restore 612, 618
        }
    }
}
