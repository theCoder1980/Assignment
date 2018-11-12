﻿// <auto-generated />
using Assignment2.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using System;

namespace Assignment2.Migrations.PhotoDb
{
    [DbContext(typeof(PhotoDbContext))]
    [Migration("20181112084028_photosMigration")]
    partial class photosMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.3-rtm-10026")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Assignment2.Entities.Photo", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Url")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<int>("albumId")
                        .HasMaxLength(30);

                    b.Property<string>("thumbnailUrl")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("title")
                        .IsRequired()
                        .HasMaxLength(30);

                    b.HasKey("id");

                    b.ToTable("Photos");
                });
#pragma warning restore 612, 618
        }
    }
}