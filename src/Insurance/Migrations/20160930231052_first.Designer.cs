﻿using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Insurance.Data;

namespace Insurance.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20160930231052_first")]
    partial class first
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.0.0-rtm-21431")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Insurance.Models.ApplicationUser", b =>
                {
                    b.Property<string>("Id");

                    b.Property<int>("AccessFailedCount");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Email")
                        .HasAnnotation("MaxLength", 256);

                    b.Property<bool>("EmailConfirmed");

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("NormalizedEmail")
                        .HasAnnotation("MaxLength", 256);

                    b.Property<string>("NormalizedUserName")
                        .HasAnnotation("MaxLength", 256);

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<string>("SecurityStamp");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UserName")
                        .HasAnnotation("MaxLength", 256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("Insurance.Models.InsuranceViewModels.Customer", b =>
                {
                    b.Property<int>("Id");

                    b.Property<string>("Address")
                        .IsRequired();

                    b.Property<DateTime>("DateOfBirth");

                    b.Property<string>("Email")
                        .IsRequired();

                    b.Property<string>("FullName");

                    b.Property<string>("LastName")
                        .IsRequired();

                    b.Property<string>("MiddleName");

                    b.Property<string>("Name")
                        .IsRequired();

                    b.Property<string>("PhoneNumber")
                        .IsRequired();

                    b.Property<int?>("PlanTypeId");

                    b.Property<string>("SocialSecurity");

                    b.Property<string>("State");

                    b.Property<string>("StateOfBirth");

                    b.Property<string>("ZipCode");

                    b.HasKey("Id");

                    b.HasIndex("PlanTypeId");

                    b.ToTable("Customers");
                });

            modelBuilder.Entity("Insurance.Models.InsuranceViewModels.InsuranceCompany", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name")
                        .IsRequired();

                    b.HasKey("Id");

                    b.ToTable("InsuranceCompanies");
                });

            modelBuilder.Entity("Insurance.Models.InsuranceViewModels.PlanType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("CompanyId");

                    b.Property<string>("Metal");

                    b.Property<string>("Name")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("CompanyId");

                    b.ToTable("PlanTypes");
                });

            modelBuilder.Entity("Insurance.Models.InsuranceViewModels.Sale", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("CarrierId");

                    b.Property<int?>("CustomerId");

                    b.Property<string>("DirectAgent");

                    b.Property<DateTime>("EffectiveDate");

                    b.Property<string>("LeadAgent");

                    b.Property<int>("MemberQuantity");

                    b.Property<string>("Metal");

                    b.Property<double>("Premium");

                    b.Property<int?>("ProductNameId");

                    b.Property<string>("ReferringAgent");

                    b.Property<DateTime>("TerminationDate");

                    b.HasKey("ID");

                    b.HasIndex("CarrierId");

                    b.HasIndex("CustomerId");

                    b.HasIndex("ProductNameId");

                    b.ToTable("Sales");
                });

            modelBuilder.Entity("Insurance.Models.InsuranceViewModels.SalePayment", b =>
                {
                    b.Property<int>("SalePaymentId")
                        .ValueGeneratedOnAdd();

                    b.Property<double>("AmountPaid");

                    b.Property<int?>("CustomerId");

                    b.Property<DateTime>("DatePayment");

                    b.Property<int?>("InsuranceCompanyId");

                    b.HasKey("SalePaymentId");

                    b.HasIndex("CustomerId");

                    b.HasIndex("InsuranceCompanyId");

                    b.ToTable("Payments");
                });

            modelBuilder.Entity("Insurance.Models.InsuranceViewModels.Transaction", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("ClientId");

                    b.Property<int>("DepositedMoney");

                    b.Property<int?>("PlanTypeId");

                    b.Property<DateTime>("TransactionDate");

                    b.HasKey("Id");

                    b.HasIndex("ClientId");

                    b.HasIndex("PlanTypeId");

                    b.ToTable("Transactions");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRole", b =>
                {
                    b.Property<string>("Id");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Name")
                        .HasAnnotation("MaxLength", 256);

                    b.Property<string>("NormalizedName")
                        .HasAnnotation("MaxLength", 256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .HasName("RoleNameIndex");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("RoleId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider");

                    b.Property<string>("ProviderKey");

                    b.Property<string>("ProviderDisplayName");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("RoleId");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("LoginProvider");

                    b.Property<string>("Name");

                    b.Property<string>("Value");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("Insurance.Models.InsuranceViewModels.Customer", b =>
                {
                    b.HasOne("Insurance.Models.InsuranceViewModels.PlanType")
                        .WithMany("Customers")
                        .HasForeignKey("PlanTypeId");
                });

            modelBuilder.Entity("Insurance.Models.InsuranceViewModels.PlanType", b =>
                {
                    b.HasOne("Insurance.Models.InsuranceViewModels.InsuranceCompany", "Company")
                        .WithMany("PlanTypes")
                        .HasForeignKey("CompanyId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Insurance.Models.InsuranceViewModels.Sale", b =>
                {
                    b.HasOne("Insurance.Models.InsuranceViewModels.InsuranceCompany", "Carrier")
                        .WithMany()
                        .HasForeignKey("CarrierId");

                    b.HasOne("Insurance.Models.InsuranceViewModels.Customer", "Customer")
                        .WithMany()
                        .HasForeignKey("CustomerId");

                    b.HasOne("Insurance.Models.InsuranceViewModels.PlanType", "ProductName")
                        .WithMany()
                        .HasForeignKey("ProductNameId");
                });

            modelBuilder.Entity("Insurance.Models.InsuranceViewModels.SalePayment", b =>
                {
                    b.HasOne("Insurance.Models.InsuranceViewModels.Customer", "Customer")
                        .WithMany()
                        .HasForeignKey("CustomerId");

                    b.HasOne("Insurance.Models.InsuranceViewModels.InsuranceCompany", "InsuranceCompany")
                        .WithMany()
                        .HasForeignKey("InsuranceCompanyId");
                });

            modelBuilder.Entity("Insurance.Models.InsuranceViewModels.Transaction", b =>
                {
                    b.HasOne("Insurance.Models.InsuranceViewModels.Customer", "Client")
                        .WithMany()
                        .HasForeignKey("ClientId");

                    b.HasOne("Insurance.Models.InsuranceViewModels.PlanType", "PlanType")
                        .WithMany()
                        .HasForeignKey("PlanTypeId");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRole")
                        .WithMany("Claims")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Insurance.Models.ApplicationUser")
                        .WithMany("Claims")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Insurance.Models.ApplicationUser")
                        .WithMany("Logins")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRole")
                        .WithMany("Users")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Insurance.Models.ApplicationUser")
                        .WithMany("Roles")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
        }
    }
}
