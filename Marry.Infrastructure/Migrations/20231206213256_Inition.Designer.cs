﻿// <auto-generated />
using Marry.Infrastructure.Persistance;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Marry.Infrastructure.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20231206213256_Inition")]
    partial class Inition
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Marry.Domain.Entities.Bride", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("PersonalInformationId")
                        .HasColumnType("int");

                    b.Property<int>("WitnessId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("PersonalInformationId");

                    b.HasIndex("WitnessId");

                    b.ToTable("Brides");
                });

            modelBuilder.Entity("Marry.Domain.Entities.Groom", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("PersonalInformationId")
                        .HasColumnType("int");

                    b.Property<int>("WitnessId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("PersonalInformationId");

                    b.HasIndex("WitnessId");

                    b.ToTable("Grooms");
                });

            modelBuilder.Entity("Marry.Domain.Entities.Marriage", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("BrideId")
                        .HasColumnType("int");

                    b.Property<string>("CreatedAt")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("GroomId")
                        .HasColumnType("int");

                    b.Property<string>("UpdatedAt")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("BrideId")
                        .IsUnique();

                    b.HasIndex("GroomId")
                        .IsUnique();

                    b.ToTable("Marriages");
                });

            modelBuilder.Entity("Marry.Domain.Entities.PersonalInformation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("BirthDate")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Gender")
                        .HasColumnType("int");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("MarriageStatus")
                        .HasColumnType("int");

                    b.Property<bool>("MedicalCertificate")
                        .HasColumnType("bit");

                    b.Property<string>("MiddleName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PassportNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("PersonalInformations");
                });

            modelBuilder.Entity("Marry.Domain.Entities.Witness", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Witnesses");
                });

            modelBuilder.Entity("Marry.Domain.Entities.Bride", b =>
                {
                    b.HasOne("Marry.Domain.Entities.PersonalInformation", "PersonalInformation")
                        .WithMany()
                        .HasForeignKey("PersonalInformationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Marry.Domain.Entities.Witness", "Witness")
                        .WithMany()
                        .HasForeignKey("WitnessId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("PersonalInformation");

                    b.Navigation("Witness");
                });

            modelBuilder.Entity("Marry.Domain.Entities.Groom", b =>
                {
                    b.HasOne("Marry.Domain.Entities.PersonalInformation", "PersonalInformation")
                        .WithMany()
                        .HasForeignKey("PersonalInformationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Marry.Domain.Entities.Witness", "Witness")
                        .WithMany()
                        .HasForeignKey("WitnessId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("PersonalInformation");

                    b.Navigation("Witness");
                });

            modelBuilder.Entity("Marry.Domain.Entities.Marriage", b =>
                {
                    b.HasOne("Marry.Domain.Entities.Bride", "Bride")
                        .WithOne("Marriage")
                        .HasForeignKey("Marry.Domain.Entities.Marriage", "BrideId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Marry.Domain.Entities.Groom", "Groom")
                        .WithOne("Marriage")
                        .HasForeignKey("Marry.Domain.Entities.Marriage", "GroomId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Bride");

                    b.Navigation("Groom");
                });

            modelBuilder.Entity("Marry.Domain.Entities.Bride", b =>
                {
                    b.Navigation("Marriage")
                        .IsRequired();
                });

            modelBuilder.Entity("Marry.Domain.Entities.Groom", b =>
                {
                    b.Navigation("Marriage")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
