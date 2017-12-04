﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using System;
using WebApplication1;

namespace WebApplication1.Migrations
{
    [DbContext(typeof(kindergartenContext))]
    [Migration("20171203213224_migration")]
    partial class migration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.0-rtm-26452")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("WebApplication1.Educators", b =>
                {
                    b.Property<int>("EducatorsId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("educators_id");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nchar(10)");

                    b.Property<string>("Awards")
                        .IsRequired()
                        .HasColumnType("nchar(10)");

                    b.Property<int>("Experience");

                    b.Property<string>("Fio")
                        .IsRequired()
                        .HasColumnName("FIO")
                        .HasColumnType("nchar(10)");

                    b.Property<int>("Phone");

                    b.HasKey("EducatorsId");

                    b.ToTable("educators");
                });

            modelBuilder.Entity("WebApplication1.Groups", b =>
                {
                    b.Property<int>("GroupsId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("groups_id");

                    b.Property<int>("EducatorsId")
                        .HasColumnName("educators_id");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnName("name")
                        .HasMaxLength(10);

                    b.Property<int>("NumberOfChildren")
                        .HasColumnName("number_of_children");

                    b.Property<int>("TypesOfGroupsId")
                        .HasColumnName("types_of_groups_id");

                    b.Property<DateTime>("YearOfCreation")
                        .HasColumnName("year_of_creation")
                        .HasColumnType("date");

                    b.HasKey("GroupsId");

                    b.HasIndex("EducatorsId");

                    b.HasIndex("TypesOfGroupsId");

                    b.ToTable("groups");
                });

            modelBuilder.Entity("WebApplication1.Pupils", b =>
                {
                    b.Property<int>("PupilsId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("pupils_id");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnName("address")
                        .HasMaxLength(25);

                    b.Property<string>("AttendanceGroup")
                        .IsRequired()
                        .HasColumnName("attendance_group")
                        .HasMaxLength(25);

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnName("date_of_birth")
                        .HasColumnType("date");

                    b.Property<string>("Fio")
                        .IsRequired()
                        .HasColumnName("FIO")
                        .HasMaxLength(25);

                    b.Property<string>("FioFather")
                        .IsRequired()
                        .HasColumnName("FIO_father")
                        .HasMaxLength(25);

                    b.Property<string>("FioMather")
                        .IsRequired()
                        .HasColumnName("FIO_mather")
                        .HasMaxLength(25);

                    b.Property<int>("GroupsId")
                        .HasColumnName("groups_id");

                    b.Property<string>("Info")
                        .IsRequired()
                        .HasColumnName("info")
                        .HasMaxLength(25);

                    b.HasKey("PupilsId");

                    b.HasIndex("GroupsId");

                    b.ToTable("pupils");
                });

            modelBuilder.Entity("WebApplication1.TypesOfGroups", b =>
                {
                    b.Property<int>("TypesOfGroupsId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("Types_of_groups_id");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.HasKey("TypesOfGroupsId");

                    b.ToTable("types_of_groups");
                });

            modelBuilder.Entity("WebApplication1.Groups", b =>
                {
                    b.HasOne("WebApplication1.Educators", "Educators")
                        .WithMany("Groups")
                        .HasForeignKey("EducatorsId")
                        .HasConstraintName("FK_groups_educators");

                    b.HasOne("WebApplication1.TypesOfGroups", "TypesOfGroups")
                        .WithMany("Groups")
                        .HasForeignKey("TypesOfGroupsId")
                        .HasConstraintName("FK_groups_types_of_groups");
                });

            modelBuilder.Entity("WebApplication1.Pupils", b =>
                {
                    b.HasOne("WebApplication1.Groups", "Groups")
                        .WithMany("Pupils")
                        .HasForeignKey("GroupsId")
                        .HasConstraintName("FK_pupils_groups");
                });
#pragma warning restore 612, 618
        }
    }
}