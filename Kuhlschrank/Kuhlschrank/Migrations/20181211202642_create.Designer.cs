﻿// <auto-generated />
using System;
using Kuhlschrank.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Kuhlschrank.Migrations
{
    [DbContext(typeof(KuhlschrankContext))]
    [Migration("20181211202642_create")]
    partial class create
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.4-rtm-31024")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Kuhlschrank.Models.Client", b =>
                {
                    b.Property<long>("id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("address")
                        .IsRequired();

                    b.Property<string>("code")
                        .IsRequired();

                    b.Property<DateTime>("dateOfBirth");

                    b.Property<string>("email")
                        .IsRequired();

                    b.Property<string>("firstName")
                        .IsRequired();

                    b.Property<string>("lastName")
                        .IsRequired();

                    b.Property<string>("login")
                        .IsRequired();

                    b.Property<string>("password")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("phoneNumber");

                    b.Property<string>("place")
                        .IsRequired();

                    b.HasKey("id");

                    b.ToTable("Client");
                });

            modelBuilder.Entity("Kuhlschrank.Models.ClientFridge", b =>
                {
                    b.Property<long>("id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<long>("clientid");

                    b.Property<long>("fridgeid");

                    b.HasKey("id");

                    b.HasIndex("clientid");

                    b.HasIndex("fridgeid");

                    b.ToTable("ClientFridge");
                });

            modelBuilder.Entity("Kuhlschrank.Models.Fridge", b =>
                {
                    b.Property<long>("id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("activated");

                    b.Property<string>("serialNumber")
                        .IsRequired()
                        .HasMaxLength(10);

                    b.Property<float>("temperature");

                    b.HasKey("id");

                    b.ToTable("Fridge");
                });

            modelBuilder.Entity("Kuhlschrank.Models.ClientFridge", b =>
                {
                    b.HasOne("Kuhlschrank.Models.Client", "client")
                        .WithMany("fridges")
                        .HasForeignKey("clientid")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Kuhlschrank.Models.Fridge", "fridge")
                        .WithMany("clients")
                        .HasForeignKey("fridgeid")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}