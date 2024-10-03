﻿// <auto-generated />
using System;
using EfSample.Dal;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace EfSample.Dal.Migrations
{
    [DbContext(typeof(CourseStoreDbContext))]
    [Migration("20231110103401_isDelete")]
    partial class isDelete
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("CourseTag", b =>
                {
                    b.Property<int>("TagsTagId")
                        .HasColumnType("int");

                    b.Property<int>("coursesCourseId")
                        .HasColumnType("int");

                    b.HasKey("TagsTagId", "coursesCourseId");

                    b.HasIndex("coursesCourseId");

                    b.ToTable("CourseTag");
                });

            modelBuilder.Entity("EfSample.Entities.Comment", b =>
                {
                    b.Property<int>("CommentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CommentId"), 1L, 1);

                    b.Property<string>("CommentBy")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CommentText")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("CourseId")
                        .HasColumnType("int");

                    b.Property<bool>("IsApproved")
                        .HasColumnType("bit");

                    b.Property<int>("StartCount")
                        .HasColumnType("int");

                    b.HasKey("CommentId");

                    b.HasIndex("CourseId");

                    b.ToTable("Comments");
                });

            modelBuilder.Entity("EfSample.Entities.Course", b =>
                {
                    b.Property<int>("CourseId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CourseId"), 1L, 1);

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Price")
                        .HasColumnType("int");

                    b.Property<DateTime>("StartDateTime")
                        .HasColumnType("datetime2");

                    b.HasKey("CourseId");

                    b.ToTable("Courses");
                });

            modelBuilder.Entity("EfSample.Entities.CourseTeacher", b =>
                {
                    b.Property<int>("CourseTeacherId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CourseTeacherId"), 1L, 1);

                    b.Property<int>("CourseId")
                        .HasColumnType("int");

                    b.Property<int>("SortOrder")
                        .HasColumnType("int");

                    b.Property<int>("TeacherId")
                        .HasColumnType("int");

                    b.HasKey("CourseTeacherId");

                    b.HasIndex("CourseId");

                    b.HasIndex("TeacherId");

                    b.ToTable("CourseTeachers");
                });

            modelBuilder.Entity("EfSample.Entities.Discount", b =>
                {
                    b.Property<int>("DiscountId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("DiscountId"), 1L, 1);

                    b.Property<int>("CourseId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("NewPrice")
                        .HasColumnType("int");

                    b.HasKey("DiscountId");

                    b.HasIndex("CourseId")
                        .IsUnique();

                    b.ToTable("Discount");
                });

            modelBuilder.Entity("EfSample.Entities.Tag", b =>
                {
                    b.Property<int>("TagId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TagId"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("TagId");

                    b.ToTable("Tags");
                });

            modelBuilder.Entity("EfSample.Entities.Teacher", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Teachers");
                });

            modelBuilder.Entity("CourseTag", b =>
                {
                    b.HasOne("EfSample.Entities.Tag", null)
                        .WithMany()
                        .HasForeignKey("TagsTagId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EfSample.Entities.Course", null)
                        .WithMany()
                        .HasForeignKey("coursesCourseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("EfSample.Entities.Comment", b =>
                {
                    b.HasOne("EfSample.Entities.Course", "Course")
                        .WithMany("Comments")
                        .HasForeignKey("CourseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Course");
                });

            modelBuilder.Entity("EfSample.Entities.CourseTeacher", b =>
                {
                    b.HasOne("EfSample.Entities.Course", "Course")
                        .WithMany("CourseTeachers")
                        .HasForeignKey("CourseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EfSample.Entities.Teacher", "Teacher")
                        .WithMany("CourseTeachers")
                        .HasForeignKey("TeacherId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Course");

                    b.Navigation("Teacher");
                });

            modelBuilder.Entity("EfSample.Entities.Discount", b =>
                {
                    b.HasOne("EfSample.Entities.Course", "Course")
                        .WithOne("Discount")
                        .HasForeignKey("EfSample.Entities.Discount", "CourseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Course");
                });

            modelBuilder.Entity("EfSample.Entities.Course", b =>
                {
                    b.Navigation("Comments");

                    b.Navigation("CourseTeachers");

                    b.Navigation("Discount")
                        .IsRequired();
                });

            modelBuilder.Entity("EfSample.Entities.Teacher", b =>
                {
                    b.Navigation("CourseTeachers");
                });
#pragma warning restore 612, 618
        }
    }
}