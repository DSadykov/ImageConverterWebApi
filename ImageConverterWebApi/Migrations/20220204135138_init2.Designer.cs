// <auto-generated />
using System;
using ImageConverterWebApi.Services.DB;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace ImageConverterWebApi.Migrations
{
    [DbContext(typeof(UsersDBContext))]
    [Migration("20220204135138_init2")]
    partial class init2
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("ImageConverterWebApi.Models.ImageModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("ContentType")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<byte[]>("ConvertedImageBytes")
                        .IsRequired()
                        .HasColumnType("longblob");

                    b.Property<string>("ConvertedImageName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("FromImageName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("ImageModels");
                });

            modelBuilder.Entity("ImageConverterWebApi.Models.UserModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("ImageConverterWebApi.Models.ImageModel", b =>
                {
                    b.HasOne("ImageConverterWebApi.Models.UserModel", "User")
                        .WithMany("ConvertedImages")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("ImageConverterWebApi.Models.UserModel", b =>
                {
                    b.Navigation("ConvertedImages");
                });
#pragma warning restore 612, 618
        }
    }
}
