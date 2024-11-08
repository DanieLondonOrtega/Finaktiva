﻿// <auto-generated />
using System;
using Finaktiva.Infrastructur.DataAccess.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Finaktiva.Infrastructur.Migrations
{
    [DbContext(typeof(EntityDbContext))]
    partial class EntityDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Finaktiva.Domain.Entities.EventLogs", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2")
                        .HasColumnName("Date");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("Description");

                    b.Property<int>("IdType")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("IdType");

                    b.ToTable("EventLogs", (string)null);
                });

            modelBuilder.Entity("Finaktiva.Domain.Entities.TypeEventLogs", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Type")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("TypeEventLogs");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Type = "Api"
                        },
                        new
                        {
                            Id = 2,
                            Type = "Formulario"
                        });
                });

            modelBuilder.Entity("Finaktiva.Domain.Entities.EventLogs", b =>
                {
                    b.HasOne("Finaktiva.Domain.Entities.TypeEventLogs", "TypeEventLogs")
                        .WithMany("EventsLogs")
                        .HasForeignKey("IdType")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("TypeEventLogs");
                });

            modelBuilder.Entity("Finaktiva.Domain.Entities.TypeEventLogs", b =>
                {
                    b.Navigation("EventsLogs");
                });
#pragma warning restore 612, 618
        }
    }
}
