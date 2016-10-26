using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using act.Data;

namespace act.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
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
