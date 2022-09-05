﻿// <auto-generated />
using System;
using Bca_New.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Bca_New.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20220831071959_player")]
    partial class player
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Bca_New.Models.Players", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("id"));

                    b.Property<DateTime>("date")
                        .HasColumnType("timestamp without time zone");

                    b.Property<DateTime?>("end_time")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("name")
                        .HasColumnType("text");

                    b.Property<string>("sport_name")
                        .HasColumnType("text");

                    b.Property<DateTime?>("start_time")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("status")
                        .HasColumnType("text");

                    b.Property<string>("tournment_type")
                        .HasColumnType("text");

                    b.HasKey("id");

                    b.ToTable("Player");
                });
#pragma warning restore 612, 618
        }
    }
}
