﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using OfferGen.Repository;

#nullable disable

namespace OfferGen.API.Migrations
{
    [DbContext(typeof(RepositoryContext))]
    partial class RepositoryContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("OfferGen.Entities.Models.Company", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("CompanyId")
                        .HasDefaultValueSql("NEWSEQUENTIALID()");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RegistrationNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TaxIdentifier")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Website")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Companies");
                });

            modelBuilder.Entity("OfferGen.Entities.Models.CompanyRelations.BankAccounts", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("BankAccountId")
                        .HasDefaultValueSql("NEWSEQUENTIALID()");

                    b.Property<Guid>("CompanyId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("CompanyId");

                    b.ToTable("BankAccounts");
                });

            modelBuilder.Entity("OfferGen.Entities.Models.CompanyRelations.OfferHeader", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("OfferHeaderId");

                    b.Property<Guid>("CompanyId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("CompanyLogo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("HeaderCaption")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CompanyId")
                        .IsUnique();

                    b.ToTable("OfferHeaders");
                });

            modelBuilder.Entity("OfferGen.Entities.Models.Company", b =>
                {
                    b.OwnsOne("OfferGen.Entities.Models.Address", "Address", b1 =>
                        {
                            b1.Property<Guid>("CompanyId")
                                .ValueGeneratedOnAdd()
                                .HasColumnType("uniqueidentifier");

                            b1.Property<string>("City")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)");

                            b1.Property<string>("Street")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)");

                            b1.Property<string>("ZIPCode")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)");

                            b1.HasKey("CompanyId");

                            b1.ToTable("Companies");

                            b1.WithOwner()
                                .HasForeignKey("CompanyId");
                        });

                    b.OwnsOne("OfferGen.Entities.Models.Email", "Email", b1 =>
                        {
                            b1.Property<Guid>("CompanyId")
                                .ValueGeneratedOnAdd()
                                .HasColumnType("uniqueidentifier");

                            b1.Property<string>("EmailAddress")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)");

                            b1.HasKey("CompanyId");

                            b1.ToTable("Companies");

                            b1.WithOwner()
                                .HasForeignKey("CompanyId");
                        });

                    b.Navigation("Address")
                        .IsRequired();

                    b.Navigation("Email")
                        .IsRequired();
                });

            modelBuilder.Entity("OfferGen.Entities.Models.CompanyRelations.BankAccounts", b =>
                {
                    b.HasOne("OfferGen.Entities.Models.Company", "Company")
                        .WithMany("Accounts")
                        .HasForeignKey("CompanyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.OwnsOne("OfferGen.Entities.Models.CompanyRelations.BankAccountDetails", "AccountDetails", b1 =>
                        {
                            b1.Property<Guid>("BankAccountsId")
                                .ValueGeneratedOnAdd()
                                .HasColumnType("uniqueidentifier");

                            b1.Property<string>("AccountNumber")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)");

                            b1.Property<string>("Description")
                                .IsRequired()
                                .HasMaxLength(50)
                                .HasColumnType("nvarchar(50)");

                            b1.Property<string>("Name")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)");

                            b1.HasKey("BankAccountsId");

                            b1.ToTable("BankAccounts");

                            b1.WithOwner()
                                .HasForeignKey("BankAccountsId");
                        });

                    b.Navigation("AccountDetails")
                        .IsRequired();

                    b.Navigation("Company");
                });

            modelBuilder.Entity("OfferGen.Entities.Models.CompanyRelations.OfferHeader", b =>
                {
                    b.HasOne("OfferGen.Entities.Models.Company", "Company")
                        .WithOne("OfferHeader")
                        .HasForeignKey("OfferGen.Entities.Models.CompanyRelations.OfferHeader", "CompanyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Company");
                });

            modelBuilder.Entity("OfferGen.Entities.Models.Company", b =>
                {
                    b.Navigation("Accounts");

                    b.Navigation("OfferHeader")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
