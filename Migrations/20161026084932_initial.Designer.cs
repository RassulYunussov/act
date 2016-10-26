﻿using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using act.Data;

namespace act.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20161026084932_initial")]
    partial class initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.0.1");

            modelBuilder.Entity("act.Models.Act", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClientBin");

                    b.Property<string>("ClientName");

                    b.Property<DateTime>("Date");

                    b.Property<int?>("DocumentNumber");

                    b.Property<string>("SupplierBin");

                    b.Property<string>("SupplierName");

                    b.HasKey("Id");

                    b.ToTable("Acts");
                });

            modelBuilder.Entity("act.Models.ActService", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("ActId");

                    b.Property<int>("Amount");

                    b.Property<string>("Name");

                    b.Property<decimal>("Price");

                    b.HasKey("Id");

                    b.HasIndex("ActId");

                    b.ToTable("ActService");
                });

            modelBuilder.Entity("act.Models.ActService", b =>
                {
                    b.HasOne("act.Models.Act")
                        .WithMany("Services")
                        .HasForeignKey("ActId");
                });
        }
    }
}