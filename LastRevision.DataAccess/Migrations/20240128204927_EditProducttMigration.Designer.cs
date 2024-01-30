﻿// <auto-generated />
using LastRevision.DataAccess.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace LastRevision.DataAccess.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20240128204927_EditProducttMigration")]
    partial class EditProducttMigration
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("LastRevision.Models.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("DisPlayOrder")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(511)
                        .HasColumnType("nvarchar(511)");

                    b.HasKey("Id");

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            DisPlayOrder = 1,
                            Name = "Action"
                        },
                        new
                        {
                            Id = 2,
                            DisPlayOrder = 2,
                            Name = "Drama"
                        },
                        new
                        {
                            Id = 3,
                            DisPlayOrder = 3,
                            Name = "Comedy"
                        });
                });

            modelBuilder.Entity("LastRevision.Models.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Author")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ISBN")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.ToTable("Products");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Author = "MicelAnglo",
                            CategoryId = 1,
                            Description = "I try do inter any data",
                            ISBN = "8000Aa961211",
                            Price = 63.0,
                            Title = "Nemo"
                        },
                        new
                        {
                            Id = 2,
                            Author = "MicelAnglo",
                            CategoryId = 3,
                            Description = "I try do inter any data",
                            ISBN = "8000Aa961211",
                            Price = 62.0,
                            Title = "ToyStory"
                        },
                        new
                        {
                            Id = 3,
                            Author = "MicelAnglo",
                            CategoryId = 1,
                            Description = "I try do inter any data",
                            ISBN = "8000Aa961211",
                            Price = 87.0,
                            Title = "Tangle"
                        },
                        new
                        {
                            Id = 4,
                            Author = "MicelAnglo",
                            CategoryId = 2,
                            Description = "I try do inter any data",
                            ISBN = "8000Aa961211",
                            Price = 16.0,
                            Title = "Snowite"
                        },
                        new
                        {
                            Id = 5,
                            Author = "MicelAnglo",
                            CategoryId = 3,
                            Description = "I try do inter any data",
                            ISBN = "8000Aa961211",
                            Price = 80.0,
                            Title = "Fola"
                        },
                        new
                        {
                            Id = 6,
                            Author = "MicelAnglo",
                            CategoryId = 1,
                            Description = "I try do inter any data",
                            ISBN = "8000Aa961211",
                            Price = 40.0,
                            Title = "mongel"
                        },
                        new
                        {
                            Id = 7,
                            Author = "MicelAnglo",
                            CategoryId = 2,
                            Description = "I try do inter any data",
                            ISBN = "8000Aa961211",
                            Price = 78.0,
                            Title = "Trazan"
                        });
                });

            modelBuilder.Entity("LastRevision.Models.Product", b =>
                {
                    b.HasOne("LastRevision.Models.Category", "Category")
                        .WithMany()
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");
                });
#pragma warning restore 612, 618
        }
    }
}
