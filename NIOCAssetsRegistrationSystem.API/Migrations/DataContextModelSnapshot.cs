﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using NIOCAssetsRegistrationSystem.API.Data;

namespace NIOCAssetsRegistrationSystem.API.Migrations
{
    [DbContext(typeof(DataContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.7");

            modelBuilder.Entity("NIOCAssetsRegistrationSystem.API.Models.BuildingType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("BuildingTypes");
                });

            modelBuilder.Entity("NIOCAssetsRegistrationSystem.API.Models.City", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.Property<int>("ProvinceId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("ProvinceId");

                    b.ToTable("Cities");
                });

            modelBuilder.Entity("NIOCAssetsRegistrationSystem.API.Models.CompaniesPropertyInquiry", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<decimal?>("ArenaArea")
                        .HasColumnType("TEXT");

                    b.Property<decimal?>("BuildingArea")
                        .HasColumnType("TEXT");

                    b.Property<int?>("BuildingTypeId")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("CityId")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("CompanyId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Description")
                        .HasColumnType("TEXT");

                    b.Property<bool?>("ExistingBuilding")
                        .HasColumnType("INTEGER");

                    b.Property<bool?>("ExistingMap")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime?>("LatestChanges")
                        .HasColumnType("TEXT");

                    b.Property<decimal?>("Latitude")
                        .HasColumnType("TEXT");

                    b.Property<decimal?>("Longitude")
                        .HasColumnType("TEXT");

                    b.Property<int?>("MapCoordinatesAccuracyId")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("MapFormatId")
                        .HasColumnType("INTEGER");

                    b.Property<bool?>("OwnershipDocument")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("OwnershipDocumentTypeId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("PropertyTitle")
                        .HasColumnType("TEXT");

                    b.Property<int?>("ProvinceId")
                        .HasColumnType("INTEGER");

                    b.Property<byte[]>("UploadedFile")
                        .HasColumnType("BLOB");

                    b.Property<int?>("UserId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("BuildingTypeId");

                    b.HasIndex("CityId");

                    b.HasIndex("CompanyId");

                    b.HasIndex("MapCoordinatesAccuracyId");

                    b.HasIndex("MapFormatId");

                    b.HasIndex("OwnershipDocumentTypeId");

                    b.HasIndex("ProvinceId");

                    b.HasIndex("UserId");

                    b.ToTable("CompaniesPropertyInquiries");
                });

            modelBuilder.Entity("NIOCAssetsRegistrationSystem.API.Models.Company", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Companies");
                });

            modelBuilder.Entity("NIOCAssetsRegistrationSystem.API.Models.Confirmation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<bool?>("Active")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("CompanyId")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime?>("ConfirmDate")
                        .HasColumnType("TEXT");

                    b.Property<int?>("UserId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("CompanyId");

                    b.HasIndex("UserId");

                    b.ToTable("Confirmations");
                });

            modelBuilder.Entity("NIOCAssetsRegistrationSystem.API.Models.FileUpload", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int?>("CompanyId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Description")
                        .HasColumnType("TEXT");

                    b.Property<string>("FileName")
                        .HasColumnType("TEXT");

                    b.Property<DateTime?>("FileUploadDate")
                        .HasColumnType("TEXT");

                    b.Property<byte[]>("UploadedFile")
                        .HasColumnType("BLOB");

                    b.Property<int?>("UserId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("CompanyId");

                    b.HasIndex("UserId");

                    b.ToTable("FileUploads");
                });

            modelBuilder.Entity("NIOCAssetsRegistrationSystem.API.Models.MapCoordinatesAccuracy", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("MapCoordinatesAccuracies");
                });

            modelBuilder.Entity("NIOCAssetsRegistrationSystem.API.Models.MapFormat", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("MapFormats");
                });

            modelBuilder.Entity("NIOCAssetsRegistrationSystem.API.Models.OwnershipDocumentType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("OwnershipDocumentTypes");
                });

            modelBuilder.Entity("NIOCAssetsRegistrationSystem.API.Models.Province", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Provinces");
                });

            modelBuilder.Entity("NIOCAssetsRegistrationSystem.API.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int?>("CompanyId")
                        .HasColumnType("INTEGER");

                    b.Property<byte[]>("PasswordHash")
                        .HasColumnType("BLOB");

                    b.Property<byte[]>("PasswordSalt")
                        .HasColumnType("BLOB");

                    b.Property<string>("UserName")
                        .HasColumnType("TEXT");

                    b.Property<int?>("UserTypeId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("CompanyId");

                    b.HasIndex("UserTypeId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("NIOCAssetsRegistrationSystem.API.Models.UserType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("UserTypes");
                });

            modelBuilder.Entity("NIOCAssetsRegistrationSystem.API.Models.City", b =>
                {
                    b.HasOne("NIOCAssetsRegistrationSystem.API.Models.Province", "Province")
                        .WithMany("Cities")
                        .HasForeignKey("ProvinceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("NIOCAssetsRegistrationSystem.API.Models.CompaniesPropertyInquiry", b =>
                {
                    b.HasOne("NIOCAssetsRegistrationSystem.API.Models.BuildingType", "BuildingType")
                        .WithMany("CompaniesPropertyInquiries")
                        .HasForeignKey("BuildingTypeId");

                    b.HasOne("NIOCAssetsRegistrationSystem.API.Models.City", "City")
                        .WithMany("CompaniesPropertyInquiries")
                        .HasForeignKey("CityId");

                    b.HasOne("NIOCAssetsRegistrationSystem.API.Models.Company", "Company")
                        .WithMany("CompaniesPropertyInquiries")
                        .HasForeignKey("CompanyId");

                    b.HasOne("NIOCAssetsRegistrationSystem.API.Models.MapCoordinatesAccuracy", "MapCoordinatesAccuracy")
                        .WithMany("CompaniesPropertyInquiries")
                        .HasForeignKey("MapCoordinatesAccuracyId");

                    b.HasOne("NIOCAssetsRegistrationSystem.API.Models.MapFormat", "MapFormat")
                        .WithMany("CompaniesPropertyInquiries")
                        .HasForeignKey("MapFormatId");

                    b.HasOne("NIOCAssetsRegistrationSystem.API.Models.OwnershipDocumentType", "OwnershipDocumentType")
                        .WithMany("CompaniesPropertyInquiries")
                        .HasForeignKey("OwnershipDocumentTypeId");

                    b.HasOne("NIOCAssetsRegistrationSystem.API.Models.Province", "Province")
                        .WithMany("CompaniesPropertyInquiries")
                        .HasForeignKey("ProvinceId");

                    b.HasOne("NIOCAssetsRegistrationSystem.API.Models.User", "User")
                        .WithMany("CompaniesPropertyInquiries")
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("NIOCAssetsRegistrationSystem.API.Models.Confirmation", b =>
                {
                    b.HasOne("NIOCAssetsRegistrationSystem.API.Models.Company", "Company")
                        .WithMany("Confirmations")
                        .HasForeignKey("CompanyId");

                    b.HasOne("NIOCAssetsRegistrationSystem.API.Models.User", "User")
                        .WithMany("Confirmations")
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("NIOCAssetsRegistrationSystem.API.Models.FileUpload", b =>
                {
                    b.HasOne("NIOCAssetsRegistrationSystem.API.Models.Company", "Company")
                        .WithMany()
                        .HasForeignKey("CompanyId");

                    b.HasOne("NIOCAssetsRegistrationSystem.API.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("NIOCAssetsRegistrationSystem.API.Models.User", b =>
                {
                    b.HasOne("NIOCAssetsRegistrationSystem.API.Models.Company", "Company")
                        .WithMany("Users")
                        .HasForeignKey("CompanyId");

                    b.HasOne("NIOCAssetsRegistrationSystem.API.Models.UserType", "UserType")
                        .WithMany("Users")
                        .HasForeignKey("UserTypeId");
                });
#pragma warning restore 612, 618
        }
    }
}
