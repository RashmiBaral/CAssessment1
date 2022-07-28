﻿// <auto-generated />
using System;
using Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Infrastructure.Migrations.CAssessment
{
    [DbContext(typeof(CAssessmentContext))]
    [Migration("20220721123128_version19")]
    partial class version19
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.26")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ModelsAndUtility.Model.AssessmentDetails", b =>
                {
                    b.Property<int>("AssessmentID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AssessmentName")
                        .HasColumnType("varchar(100)");

                    b.Property<DateTime>("AssmtDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasColumnType("varchar(100)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.HasKey("AssessmentID");

                    b.ToTable("AssessmentDetail");
                });

            modelBuilder.Entity("ModelsAndUtility.Model.CaseStudyDetails", b =>
                {
                    b.Property<int>("CSID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AssessmentID")
                        .HasColumnType("int");

                    b.Property<string>("CaseStudy")
                        .HasColumnType("varchar(100)");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("varchar(100)");

                    b.Property<bool>("ReviewStatus")
                        .HasColumnType("bit");

                    b.HasKey("CSID");

                    b.ToTable("CaseStudyDetails");
                });

            modelBuilder.Entity("ModelsAndUtility.Model.CaseStudySolutions", b =>
                {
                    b.Property<int>("CSSID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CSID")
                        .HasColumnType("int");

                    b.Property<int>("CompetencyID")
                        .HasColumnType("int");

                    b.Property<string>("Solution")
                        .HasColumnType("varchar(100)");

                    b.HasKey("CSSID");

                    b.HasIndex("CSID");

                    b.ToTable("CaseStudySolutions");
                });

            modelBuilder.Entity("ModelsAndUtility.Model.Competency", b =>
                {
                    b.Property<int>("CompId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("CaseStudyDetailsCSID")
                        .HasColumnType("int");

                    b.Property<string>("Compname")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CompId");

                    b.HasIndex("CaseStudyDetailsCSID");

                    b.ToTable("CompetencyInfo");
                });

            modelBuilder.Entity("ModelsAndUtility.Model.UserDetail", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CreatedDate")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("EmpID")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("ModifiedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ModifiedDate")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PasswordChangeDate")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("RoleID")
                        .HasColumnType("int");

                    b.Property<string>("UserID")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("selected")
                        .HasColumnType("bit");

                    b.HasKey("ID");

                    b.ToTable("UserDetails");
                });

            modelBuilder.Entity("ModelsAndUtility.Model.UserRole", b =>
                {
                    b.Property<int>("RoleID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CreatedDate")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("UserDetailID")
                        .HasColumnType("int");

                    b.HasKey("RoleID");

                    b.HasIndex("UserDetailID");

                    b.ToTable("UserRoles");
                });

            modelBuilder.Entity("ModelsAndUtility.Model.CaseStudySolutions", b =>
                {
                    b.HasOne("ModelsAndUtility.Model.CaseStudyDetails", null)
                        .WithMany("CaseStudySolution")
                        .HasForeignKey("CSID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ModelsAndUtility.Model.Competency", b =>
                {
                    b.HasOne("ModelsAndUtility.Model.CaseStudyDetails", null)
                        .WithMany("Competencies")
                        .HasForeignKey("CaseStudyDetailsCSID");
                });

            modelBuilder.Entity("ModelsAndUtility.Model.UserRole", b =>
                {
                    b.HasOne("ModelsAndUtility.Model.UserDetail", null)
                        .WithMany("UserRoles")
                        .HasForeignKey("UserDetailID");
                });
#pragma warning restore 612, 618
        }
    }
}
