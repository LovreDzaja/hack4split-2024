﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using hack4splitBORBAapi.Context;

#nullable disable

namespace hack4splitBORBAapi.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20240316153634_BORBAV1")]
    partial class BORBAV1
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.28")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("hack4splitBORBAapi.Model.EventModel", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"), 1L, 1);

                    b.Property<string>("contact")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("image_url")
                        .HasColumnType("nvarchar(max)");

                    b.Property<float>("latitude")
                        .HasColumnType("real");

                    b.Property<float>("longitude")
                        .HasColumnType("real");

                    b.Property<string>("working_hours")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("event", (string)null);
                });

            modelBuilder.Entity("hack4splitBORBAapi.Model.RatingModel", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"), 1L, 1);

                    b.Property<string>("Comment")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("EventId")
                        .HasColumnType("bigint");

                    b.Property<string>("Rating")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("UserId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("EventId");

                    b.HasIndex("UserId");

                    b.ToTable("rating", (string)null);
                });

            modelBuilder.Entity("hack4splitBORBAapi.Model.UserModel", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"), 1L, 1);

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Username")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("user", (string)null);
                });

            modelBuilder.Entity("hack4splitBORBAapi.Model.RatingModel", b =>
                {
                    b.HasOne("hack4splitBORBAapi.Model.EventModel", "Event")
                        .WithMany("Ratings")
                        .HasForeignKey("EventId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("hack4splitBORBAapi.Model.UserModel", "User")
                        .WithMany("Ratings")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Event");

                    b.Navigation("User");
                });

            modelBuilder.Entity("hack4splitBORBAapi.Model.EventModel", b =>
                {
                    b.Navigation("Ratings");
                });

            modelBuilder.Entity("hack4splitBORBAapi.Model.UserModel", b =>
                {
                    b.Navigation("Ratings");
                });
#pragma warning restore 612, 618
        }
    }
}
