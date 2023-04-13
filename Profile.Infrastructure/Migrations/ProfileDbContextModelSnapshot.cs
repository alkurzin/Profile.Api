﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Profile.Infrastructure;

namespace Profile.Infrastructure.Migrations
{
    [DbContext(typeof(ProfileDbContext))]
    partial class ProfileDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.9")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Profile.Domain.FileModels.FileModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Path")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("FileModel");
                });

            modelBuilder.Entity("Profile.Domain.Profile.BankDetail", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("BankName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Bik")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CorrespondentAccount")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PaymentAccount")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long?>("ProfileId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("ProfileId");

                    b.ToTable("BankDetail");
                });

            modelBuilder.Entity("Profile.Domain.Profile.Profile", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("ContractRentScanId")
                        .HasColumnType("int");

                    b.Property<int?>("EgripScanId")
                        .HasColumnType("int");

                    b.Property<string>("FullName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Inn")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("InnScanId")
                        .HasColumnType("int");

                    b.Property<bool>("IsNoContract")
                        .HasColumnType("bit");

                    b.Property<string>("Ogrn")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("OgrnScanId")
                        .HasColumnType("int");

                    b.Property<string>("RegistrationDate")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ShortName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ContractRentScanId");

                    b.HasIndex("EgripScanId");

                    b.HasIndex("InnScanId");

                    b.HasIndex("OgrnScanId");

                    b.ToTable("Profiles");
                });

            modelBuilder.Entity("Profile.Domain.Profile.BankDetail", b =>
                {
                    b.HasOne("Profile.Domain.Profile.Profile", null)
                        .WithMany("BankDetails")
                        .HasForeignKey("ProfileId");
                });

            modelBuilder.Entity("Profile.Domain.Profile.Profile", b =>
                {
                    b.HasOne("Profile.Domain.FileModels.FileModel", "ContractRentScan")
                        .WithMany()
                        .HasForeignKey("ContractRentScanId");

                    b.HasOne("Profile.Domain.FileModels.FileModel", "EgripScan")
                        .WithMany()
                        .HasForeignKey("EgripScanId");

                    b.HasOne("Profile.Domain.FileModels.FileModel", "InnScan")
                        .WithMany()
                        .HasForeignKey("InnScanId");

                    b.HasOne("Profile.Domain.FileModels.FileModel", "OgrnScan")
                        .WithMany()
                        .HasForeignKey("OgrnScanId");

                    b.Navigation("ContractRentScan");

                    b.Navigation("EgripScan");

                    b.Navigation("InnScan");

                    b.Navigation("OgrnScan");
                });

            modelBuilder.Entity("Profile.Domain.Profile.Profile", b =>
                {
                    b.Navigation("BankDetails");
                });
#pragma warning restore 612, 618
        }
    }
}
