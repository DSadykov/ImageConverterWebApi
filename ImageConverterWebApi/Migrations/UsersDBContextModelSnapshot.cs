﻿// <auto-generated />
using System;
using ImageConverterWebApi.Services.DB;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace ImageConverterWebApi.Migrations
{
    [DbContext(typeof(UsersDBContext))]
    partial class UsersDBContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "6.0.1");

            modelBuilder.Entity("ImageConverterWebApi.Models.ImageModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<byte[]>("ConvertedImage")
                        .IsRequired()
                        .HasColumnType("BLOB");

                    b.Property<string>("ConvertedImageName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("FromImageName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("UserId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("ImageModel");
                });

            modelBuilder.Entity("ImageConverterWebApi.Models.UserModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("TEXT");

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
