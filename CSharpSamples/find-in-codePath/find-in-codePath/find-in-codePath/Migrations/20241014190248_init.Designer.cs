﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using find_in_codePath;

#nullable disable

namespace find_in_codePath.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20241014190248_init")]
    partial class init
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("find_in_codePath.Company", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("CodePath")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("MyProperty");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CodePath = ",120,121,122,123,"
                        },
                        new
                        {
                            Id = 2,
                            CodePath = ",1120,1121,1122,1123,"
                        },
                        new
                        {
                            Id = 3,
                            CodePath = ",2120,2121,2122,2123,"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
