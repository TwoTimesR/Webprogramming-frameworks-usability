﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ORM.Model;

namespace ORM.Migrations
{
    [DbContext(typeof(Database.OrganisationContext))]
    [Migration("20201121133304_OnConfiguring-modified-correctly")]
    partial class OnConfiguringmodifiedcorrectly
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "5.0.0");

            modelBuilder.Entity("CompanyCustomer", b =>
                {
                    b.Property<int>("CompaniesOrganisationId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("CustomersCustomerId")
                        .HasColumnType("INTEGER");

                    b.HasKey("CompaniesOrganisationId", "CustomersCustomerId");

                    b.HasIndex("CustomersCustomerId");

                    b.ToTable("CompanyCustomer");
                });

            modelBuilder.Entity("ORM.Model.Customer", b =>
                {
                    b.Property<int>("CustomerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER")
                        .HasColumnName("Customer_Id");

                    b.Property<double>("AvgSpending")
                        .HasColumnType("REAL");

                    b.Property<int>("PurchaseMade")
                        .HasColumnType("INTEGER");

                    b.HasKey("CustomerId");

                    b.ToTable("Customer");
                });

            modelBuilder.Entity("ORM.Model.Organisation", b =>
                {
                    b.Property<int>("OrganisationId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER")
                        .HasColumnName("Organisation_Id");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.Property<int>("NetWorth")
                        .HasColumnType("INTEGER");

                    b.HasKey("OrganisationId");

                    b.ToTable("Organisation");
                });

            modelBuilder.Entity("ORM.Model.Owner", b =>
                {
                    b.Property<int>("OwnerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER")
                        .HasColumnName("Owner_Id");

                    b.Property<int>("Age")
                        .HasColumnType("INTEGER");

                    b.Property<string>("FirstName")
                        .HasMaxLength(40)
                        .HasColumnType("TEXT");

                    b.Property<string>("LastName")
                        .HasMaxLength(40)
                        .HasColumnType("TEXT");

                    b.Property<int>("OrganisationId")
                        .HasColumnType("INTEGER");

                    b.HasKey("OwnerId");

                    b.HasIndex("OrganisationId")
                        .IsUnique();

                    b.ToTable("Owner");
                });

            modelBuilder.Entity("ORM.Model.Product", b =>
                {
                    b.Property<int>("OrganisationId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("SequenceNumber")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("CompanyOrganisationId")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("InStock")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.Property<double>("Price")
                        .HasColumnType("REAL");

                    b.HasKey("OrganisationId", "SequenceNumber");

                    b.HasIndex("CompanyOrganisationId");

                    b.ToTable("Product");
                });

            modelBuilder.Entity("ORM.Model.Company", b =>
                {
                    b.HasBaseType("ORM.Model.Organisation");

                    b.Property<double>("Solvability")
                        .HasColumnType("REAL");

                    b.Property<double>("StockPrice")
                        .HasColumnType("REAL");

                    b.ToTable("Company");
                });

            modelBuilder.Entity("ORM.Model.NonProfit", b =>
                {
                    b.HasBaseType("ORM.Model.Organisation");

                    b.Property<string>("Category")
                        .HasColumnType("TEXT");

                    b.Property<string>("Goal")
                        .HasColumnType("TEXT");

                    b.ToTable("NonProfit");
                });

            modelBuilder.Entity("CompanyCustomer", b =>
                {
                    b.HasOne("ORM.Model.Company", null)
                        .WithMany()
                        .HasForeignKey("CompaniesOrganisationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ORM.Model.Customer", null)
                        .WithMany()
                        .HasForeignKey("CustomersCustomerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ORM.Model.Owner", b =>
                {
                    b.HasOne("ORM.Model.Organisation", "Organisation")
                        .WithOne("Owner")
                        .HasForeignKey("ORM.Model.Owner", "OrganisationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Organisation");
                });

            modelBuilder.Entity("ORM.Model.Product", b =>
                {
                    b.HasOne("ORM.Model.Company", "Company")
                        .WithMany("Products")
                        .HasForeignKey("CompanyOrganisationId");

                    b.Navigation("Company");
                });

            modelBuilder.Entity("ORM.Model.Company", b =>
                {
                    b.HasOne("ORM.Model.Organisation", null)
                        .WithOne()
                        .HasForeignKey("ORM.Model.Company", "OrganisationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ORM.Model.NonProfit", b =>
                {
                    b.HasOne("ORM.Model.Organisation", null)
                        .WithOne()
                        .HasForeignKey("ORM.Model.NonProfit", "OrganisationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ORM.Model.Organisation", b =>
                {
                    b.Navigation("Owner");
                });

            modelBuilder.Entity("ORM.Model.Company", b =>
                {
                    b.Navigation("Products");
                });
#pragma warning restore 612, 618
        }
    }
}
