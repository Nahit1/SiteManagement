﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SiteManagement.Persistence;

namespace SiteManagement.Persistence.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20211231224114_apartmentpersonUpdate2")]
    partial class apartmentpersonUpdate2
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "5.0.1");

            modelBuilder.Entity("SiteManagement.Domain.Apartment", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<bool>("Active")
                        .HasColumnType("INTEGER");

                    b.Property<int>("ApartmentNo")
                        .HasColumnType("INTEGER");

                    b.Property<Guid>("ApartmentTypeId")
                        .HasColumnType("TEXT");

                    b.Property<Guid>("BlockId")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("Created")
                        .HasColumnType("TEXT");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("TEXT");

                    b.Property<bool>("Deleted")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("Direction")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Floor")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime?>("LastModified")
                        .HasColumnType("TEXT");

                    b.Property<string>("LastModifiedBy")
                        .HasColumnType("TEXT");

                    b.Property<int?>("ParkingPlaceCount")
                        .HasColumnType("INTEGER");

                    b.Property<Guid>("SiteId")
                        .HasColumnType("TEXT");

                    b.Property<bool>("UsingStatus")
                        .HasColumnType("INTEGER");

                    b.Property<int>("UsingType")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("ApartmentTypeId");

                    b.HasIndex("BlockId");

                    b.HasIndex("SiteId");

                    b.ToTable("Apartments");
                });

            modelBuilder.Entity("SiteManagement.Domain.ApartmentPerson", b =>
                {
                    b.Property<Guid>("ApartmentId")
                        .HasColumnType("TEXT");

                    b.Property<Guid>("PersonId")
                        .HasColumnType("TEXT");

                    b.Property<bool>("Active")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("Created")
                        .HasColumnType("TEXT");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("DateOfEntry")
                        .HasColumnType("TEXT");

                    b.Property<DateTime?>("DateOfExit")
                        .HasColumnType("TEXT");

                    b.Property<bool>("Deleted")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime?>("LastModified")
                        .HasColumnType("TEXT");

                    b.Property<string>("LastModifiedBy")
                        .HasColumnType("TEXT");

                    b.Property<int>("OwnerShipStatus")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("Share")
                        .HasColumnType("INTEGER");

                    b.HasKey("ApartmentId", "PersonId");

                    b.HasIndex("PersonId");

                    b.ToTable("ApartmentPerson");
                });

            modelBuilder.Entity("SiteManagement.Domain.ApartmentType", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<bool>("Active")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("Created")
                        .HasColumnType("TEXT");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("TEXT");

                    b.Property<bool>("Deleted")
                        .HasColumnType("INTEGER");

                    b.Property<decimal>("Dues")
                        .HasColumnType("TEXT");

                    b.Property<decimal?>("GrossArea")
                        .HasColumnType("TEXT");

                    b.Property<DateTime?>("LastModified")
                        .HasColumnType("TEXT");

                    b.Property<string>("LastModifiedBy")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.Property<decimal?>("NetArea")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("ApartmentTypes");
                });

            modelBuilder.Entity("SiteManagement.Domain.Block", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<bool>("Active")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Code")
                        .HasMaxLength(30)
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("Created")
                        .HasColumnType("TEXT");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("TEXT");

                    b.Property<bool>("Deleted")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime?>("LastModified")
                        .HasColumnType("TEXT");

                    b.Property<string>("LastModifiedBy")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .HasMaxLength(30)
                        .HasColumnType("TEXT");

                    b.Property<Guid>("SiteId")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("SiteId");

                    b.ToTable("Blocks");
                });

            modelBuilder.Entity("SiteManagement.Domain.Person", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<bool>("Active")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime?>("BirthDate")
                        .HasColumnType("TEXT");

                    b.Property<int?>("BloodType")
                        .HasColumnType("INTEGER");

                    b.Property<string>("ChronicDisease")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("Created")
                        .HasColumnType("TEXT");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("TEXT");

                    b.Property<bool>("Deleted")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("EducationStatus")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Email")
                        .HasMaxLength(50)
                        .HasColumnType("TEXT");

                    b.Property<int?>("Gender")
                        .HasColumnType("INTEGER");

                    b.Property<string>("GraduatedSchool")
                        .HasMaxLength(100)
                        .HasColumnType("TEXT");

                    b.Property<string>("IdentityNumber")
                        .HasMaxLength(20)
                        .HasColumnType("TEXT");

                    b.Property<string>("Job")
                        .HasMaxLength(50)
                        .HasColumnType("TEXT");

                    b.Property<DateTime?>("LastModified")
                        .HasColumnType("TEXT");

                    b.Property<string>("LastModifiedBy")
                        .HasColumnType("TEXT");

                    b.Property<string>("MobilePhone")
                        .HasMaxLength(20)
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .HasMaxLength(50)
                        .HasColumnType("TEXT");

                    b.Property<string>("Nationality")
                        .HasMaxLength(30)
                        .HasColumnType("TEXT");

                    b.Property<string>("OfficePhone")
                        .HasMaxLength(20)
                        .HasColumnType("TEXT");

                    b.Property<int?>("Pet")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Phone")
                        .HasMaxLength(20)
                        .HasColumnType("TEXT");

                    b.Property<string>("Photo")
                        .HasColumnType("TEXT");

                    b.Property<Guid>("SiteId")
                        .HasColumnType("TEXT");

                    b.Property<string>("TaxOffice")
                        .HasMaxLength(50)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("SiteId");

                    b.ToTable("Persons");
                });

            modelBuilder.Entity("SiteManagement.Domain.Site", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<bool>("Active")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Address")
                        .HasColumnType("TEXT");

                    b.Property<int?>("ApartmentCount")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("BlockCount")
                        .HasColumnType("INTEGER");

                    b.Property<string>("CellPhoneNumber")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("Created")
                        .HasColumnType("TEXT");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("TEXT");

                    b.Property<bool>("Deleted")
                        .HasColumnType("INTEGER");

                    b.Property<string>("District")
                        .HasColumnType("TEXT");

                    b.Property<DateTime?>("LastModified")
                        .HasColumnType("TEXT");

                    b.Property<string>("LastModifiedBy")
                        .HasColumnType("TEXT");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("TEXT");

                    b.Property<string>("Province")
                        .HasColumnType("TEXT");

                    b.Property<string>("SiteName")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Sites");
                });

            modelBuilder.Entity("SiteManagement.Domain.Apartment", b =>
                {
                    b.HasOne("SiteManagement.Domain.ApartmentType", "ApartmentType")
                        .WithMany()
                        .HasForeignKey("ApartmentTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SiteManagement.Domain.Block", "Block")
                        .WithMany()
                        .HasForeignKey("BlockId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SiteManagement.Domain.Site", "Site")
                        .WithMany("Apartments")
                        .HasForeignKey("SiteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ApartmentType");

                    b.Navigation("Block");

                    b.Navigation("Site");
                });

            modelBuilder.Entity("SiteManagement.Domain.ApartmentPerson", b =>
                {
                    b.HasOne("SiteManagement.Domain.Apartment", "Apartment")
                        .WithMany("Persons")
                        .HasForeignKey("ApartmentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SiteManagement.Domain.Person", "Person")
                        .WithMany("Apartments")
                        .HasForeignKey("PersonId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Apartment");

                    b.Navigation("Person");
                });

            modelBuilder.Entity("SiteManagement.Domain.Block", b =>
                {
                    b.HasOne("SiteManagement.Domain.Site", "Site")
                        .WithMany("Blocks")
                        .HasForeignKey("SiteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Site");
                });

            modelBuilder.Entity("SiteManagement.Domain.Person", b =>
                {
                    b.HasOne("SiteManagement.Domain.Site", "Site")
                        .WithMany("Persons")
                        .HasForeignKey("SiteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Site");
                });

            modelBuilder.Entity("SiteManagement.Domain.Apartment", b =>
                {
                    b.Navigation("Persons");
                });

            modelBuilder.Entity("SiteManagement.Domain.Person", b =>
                {
                    b.Navigation("Apartments");
                });

            modelBuilder.Entity("SiteManagement.Domain.Site", b =>
                {
                    b.Navigation("Apartments");

                    b.Navigation("Blocks");

                    b.Navigation("Persons");
                });
#pragma warning restore 612, 618
        }
    }
}
