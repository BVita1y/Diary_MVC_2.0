﻿// <auto-generated />
using System;
using Diary_MVC_2._0.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Diary_MVC_2._0.Migrations
{
    [DbContext(typeof(DiaryDbContext))]
    [Migration("20210125005412_AddIsPerformed")]
    partial class AddIsPerformed
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.2");

            modelBuilder.Entity("Diary_MVC_2._0.Models.Plan", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsPerformed")
                        .HasColumnType("bit");

                    b.Property<DateTime>("StartDateTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("Subject")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Type")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Plan");

                    b.HasDiscriminator<string>("Discriminator").HasValue("Plan");
                });

            modelBuilder.Entity("Diary_MVC_2._0.Models.Reminder", b =>
                {
                    b.HasBaseType("Diary_MVC_2._0.Models.Plan");

                    b.HasDiscriminator().HasValue("Reminder");
                });

            modelBuilder.Entity("Diary_MVC_2._0.Models.Case", b =>
                {
                    b.HasBaseType("Diary_MVC_2._0.Models.Reminder");

                    b.Property<DateTime>("FinishDateTime")
                        .HasColumnType("datetime2");

                    b.HasDiscriminator().HasValue("Case");
                });

            modelBuilder.Entity("Diary_MVC_2._0.Models.Meeting", b =>
                {
                    b.HasBaseType("Diary_MVC_2._0.Models.Case");

                    b.Property<string>("Place")
                        .HasColumnType("nvarchar(max)");

                    b.HasDiscriminator().HasValue("Meeting");
                });
#pragma warning restore 612, 618
        }
    }
}