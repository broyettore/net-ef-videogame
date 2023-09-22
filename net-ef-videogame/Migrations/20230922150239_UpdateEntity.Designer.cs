﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using net_ef_videogame.Database;

#nullable disable

namespace net_ef_videogame.Migrations
{
    [DbContext(typeof(VideogameContext))]
    [Migration("20230922150239_UpdateEntity")]
    partial class UpdateEntity
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("net_ef_videogame.Classes.Softwarehouse", b =>
                {
                    b.Property<long>("SoftwareId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("SoftwareId"));

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Country")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Tax_id")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("SoftwareId");

                    b.ToTable("software_houses");
                });

            modelBuilder.Entity("net_ef_videogame.Classes.Videogame", b =>
                {
                    b.Property<long>("VideogameId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("VideogameId"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Overview")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Release_date")
                        .HasColumnType("datetime2");

                    b.Property<long>("SoftwareId")
                        .HasColumnType("bigint");

                    b.Property<long?>("SoftwarehouseSoftwareId")
                        .HasColumnType("bigint");

                    b.HasKey("VideogameId");

                    b.HasIndex("SoftwarehouseSoftwareId");

                    b.ToTable("videogame");
                });

            modelBuilder.Entity("net_ef_videogame.Classes.Videogame", b =>
                {
                    b.HasOne("net_ef_videogame.Classes.Softwarehouse", null)
                        .WithMany("Videogames")
                        .HasForeignKey("SoftwarehouseSoftwareId");
                });

            modelBuilder.Entity("net_ef_videogame.Classes.Softwarehouse", b =>
                {
                    b.Navigation("Videogames");
                });
#pragma warning restore 612, 618
        }
    }
}
