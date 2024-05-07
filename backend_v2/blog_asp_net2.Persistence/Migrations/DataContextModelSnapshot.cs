﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using blog_asp_net2.Persistence.Contextos;

namespace blog_asp_net2.Persistence.Migrations
{
    [DbContext(typeof(DataContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 64)
                .HasAnnotation("ProductVersion", "5.0.10");

            modelBuilder.Entity("blog_asp_net2.Domain.Comment", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("message")
                        .HasColumnType("longtext");

                    b.Property<int?>("postid")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.HasIndex("postid");

                    b.ToTable("Comments");
                });

            modelBuilder.Entity("blog_asp_net2.Domain.Post", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("message")
                        .HasColumnType("longtext");

                    b.HasKey("id");

                    b.ToTable("Posts");
                });

            modelBuilder.Entity("blog_asp_net2.Domain.Comment", b =>
                {
                    b.HasOne("blog_asp_net2.Domain.Post", "post")
                        .WithMany("comment")
                        .HasForeignKey("postid")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.Navigation("post");
                });

            modelBuilder.Entity("blog_asp_net2.Domain.Post", b =>
                {
                    b.Navigation("comment");
                });
#pragma warning restore 612, 618
        }
    }
}