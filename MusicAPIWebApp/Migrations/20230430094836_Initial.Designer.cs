﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MusicAPIWebApp.Models;

#nullable disable

namespace MusicAPIWebApp.Migrations
{
    [DbContext(typeof(MusicAPIContext))]
    [Migration("20230430094836_Initial")]
    partial class Initial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("MusicAPIWebApp.Models.Artist", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Artists");
                });

            modelBuilder.Entity("MusicAPIWebApp.Models.Genre", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Genres");
                });

            modelBuilder.Entity("MusicAPIWebApp.Models.Playlist", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Playlists");
                });

            modelBuilder.Entity("MusicAPIWebApp.Models.Song", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("ArtistId")
                        .HasColumnType("int");

                    b.Property<int>("GenreId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ArtistId");

                    b.HasIndex("GenreId");

                    b.ToTable("Songs");
                });

            modelBuilder.Entity("PlaylistSong", b =>
                {
                    b.Property<int>("PlaylistsId")
                        .HasColumnType("int");

                    b.Property<int>("SongsId")
                        .HasColumnType("int");

                    b.HasKey("PlaylistsId", "SongsId");

                    b.HasIndex("SongsId");

                    b.ToTable("PlaylistSong");
                });

            modelBuilder.Entity("MusicAPIWebApp.Models.Song", b =>
                {
                    b.HasOne("MusicAPIWebApp.Models.Artist", "Artist")
                        .WithMany("Songs")
                        .HasForeignKey("ArtistId")
                        .OnDelete(DeleteBehavior.ClientCascade)
                        .IsRequired();

                    b.HasOne("MusicAPIWebApp.Models.Genre", "Genre")
                        .WithMany("Songs")
                        .HasForeignKey("GenreId")
                        .OnDelete(DeleteBehavior.ClientCascade)
                        .IsRequired();

                    b.Navigation("Artist");

                    b.Navigation("Genre");
                });

            modelBuilder.Entity("PlaylistSong", b =>
                {
                    b.HasOne("MusicAPIWebApp.Models.Playlist", null)
                        .WithMany()
                        .HasForeignKey("PlaylistsId")
                        .OnDelete(DeleteBehavior.ClientCascade)
                        .IsRequired();

                    b.HasOne("MusicAPIWebApp.Models.Song", null)
                        .WithMany()
                        .HasForeignKey("SongsId")
                        .OnDelete(DeleteBehavior.ClientCascade)
                        .IsRequired();
                });

            modelBuilder.Entity("MusicAPIWebApp.Models.Artist", b =>
                {
                    b.Navigation("Songs");
                });

            modelBuilder.Entity("MusicAPIWebApp.Models.Genre", b =>
                {
                    b.Navigation("Songs");
                });
#pragma warning restore 612, 618
        }
    }
}
