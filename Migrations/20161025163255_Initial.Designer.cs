using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using act.Data;

namespace act.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20161025163255_Initial")]
    partial class Initial
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

                    b.Property<int>("DocumentNumber");

                    b.Property<string>("SupplierBin");

                    b.Property<string>("SupplierName");

                    b.HasKey("Id");

                    b.ToTable("Acts");
                });
        }
    }
}
