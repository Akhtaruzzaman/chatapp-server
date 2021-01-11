﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Repository.DBContext;

namespace Repository.Migrations
{
    [DbContext(typeof(DBContext_Sql))]
    [Migration("20210111052014_V.001")]
    partial class V001
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.1");

            modelBuilder.Entity("Domain.Master.Users", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("CreatedBy")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("CreatedFrom")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<bool>("IsArchived")
                        .HasColumnType("bit");

                    b.Property<string>("LoginId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Mobile")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("UpdatedBy")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("UpdatedFrom")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("LoginId")
                        .IsUnique()
                        .HasFilter("[LoginId] IS NOT NULL");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = new Guid("fadede5d-1c91-4d95-92e4-f447ea6edade"),
                            Address = "Dhaka, Banlgadesh",
                            CreatedAt = new DateTime(2021, 1, 11, 11, 20, 14, 580, DateTimeKind.Local).AddTicks(9776),
                            CreatedBy = new Guid("00000000-0000-0000-0000-000000000000"),
                            CreatedFrom = "",
                            IsActive = true,
                            IsArchived = false,
                            LoginId = "user1@gmail.com",
                            Mobile = "013xxxxxxxx",
                            Name = "User 1",
                            Password = "8cb2237d0679ca88db6464eac60da96345513964",
                            UpdatedBy = new Guid("00000000-0000-0000-0000-000000000000")
                        },
                        new
                        {
                            Id = new Guid("52315bc2-0192-43da-88ec-669076082158"),
                            Address = "Dhaka, Banlgadesh",
                            CreatedAt = new DateTime(2021, 1, 11, 11, 20, 14, 586, DateTimeKind.Local).AddTicks(9285),
                            CreatedBy = new Guid("00000000-0000-0000-0000-000000000000"),
                            CreatedFrom = "",
                            IsActive = true,
                            IsArchived = false,
                            LoginId = "user2@gmail.com",
                            Mobile = "013xxxxxxxx",
                            Name = "User 2",
                            Password = "8cb2237d0679ca88db6464eac60da96345513964",
                            UpdatedBy = new Guid("00000000-0000-0000-0000-000000000000")
                        });
                });

            modelBuilder.Entity("Domain.Messenger.Messages", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("CreatedBy")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("CreatedFrom")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("FromId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("IsArchived")
                        .HasColumnType("bit");

                    b.Property<string>("Message")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("SeenStatus")
                        .HasColumnType("int");

                    b.Property<Guid>("ToId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("UpdatedBy")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("UpdatedFrom")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("FromId");

                    b.HasIndex("ToId");

                    b.ToTable("Messages");
                });

            modelBuilder.Entity("Domain.Messenger.Messages", b =>
                {
                    b.HasOne("Domain.Master.Users", "From")
                        .WithMany()
                        .HasForeignKey("FromId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Master.Users", "To")
                        .WithMany()
                        .HasForeignKey("ToId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("From");

                    b.Navigation("To");
                });
#pragma warning restore 612, 618
        }
    }
}
