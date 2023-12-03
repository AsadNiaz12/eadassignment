﻿// <auto-generated />
using DL.DbModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace MyWebApiStudentGPA.Migrations
{
    [DbContext(typeof(StudentDbContext))]
    partial class StudentDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.25")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("DL.DbModels.StudentDbDto", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RollNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("studentDbDto");
                });

            modelBuilder.Entity("DL.DbModels.StudentSubjectDbDto", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<double>("GPA")
                        .HasColumnType("float");

                    b.Property<int>("SID")
                        .HasColumnType("int");

                    b.Property<int>("SubjectId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("SID");

                    b.HasIndex("SubjectId");

                    b.ToTable("studentSubjectDbDto");
                });

            modelBuilder.Entity("DL.DbModels.StudentSubjectMarksDbDto", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<decimal>("Marks")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("StudentId")
                        .HasColumnType("int");

                    b.Property<int>("SubjectId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("StudentId");

                    b.HasIndex("SubjectId");

                    b.ToTable("studentSubjectMarksDbDto");
                });

            modelBuilder.Entity("DL.DbModels.SubjectDbDto", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.ToTable("subjectDbDto");
                });

            modelBuilder.Entity("DL.DbModels.StudentSubjectDbDto", b =>
                {
                    b.HasOne("DL.DbModels.StudentDbDto", "studentDbDto")
                        .WithMany()
                        .HasForeignKey("SID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DL.DbModels.SubjectDbDto", "SubjectDbDto")
                        .WithMany()
                        .HasForeignKey("SubjectId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("SubjectDbDto");

                    b.Navigation("studentDbDto");
                });

            modelBuilder.Entity("DL.DbModels.StudentSubjectMarksDbDto", b =>
                {
                    b.HasOne("DL.DbModels.StudentDbDto", "studentDbDto")
                        .WithMany("StudentSubjectMarks")
                        .HasForeignKey("StudentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DL.DbModels.SubjectDbDto", "SubjectDbDto")
                        .WithMany("StudentSubjectMarks")
                        .HasForeignKey("SubjectId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("SubjectDbDto");

                    b.Navigation("studentDbDto");
                });

            modelBuilder.Entity("DL.DbModels.StudentDbDto", b =>
                {
                    b.Navigation("StudentSubjectMarks");
                });

            modelBuilder.Entity("DL.DbModels.SubjectDbDto", b =>
                {
                    b.Navigation("StudentSubjectMarks");
                });
#pragma warning restore 612, 618
        }
    }
}