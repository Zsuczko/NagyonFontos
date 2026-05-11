using System;
using System.Collections.Generic;
using System.IO;
using LibraryGUI.Models;
using Microsoft.EntityFrameworkCore;

namespace LibraryGUI;

public partial class LibraryContext : DbContext
{
    public LibraryContext()
    {
    }

    public LibraryContext(DbContextOptions<LibraryContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Kolcsonze> Kolcsonzes { get; set; }

    public virtual DbSet<Konyv> Konyvs { get; set; }

    public virtual DbSet<Szerzo> Szerzos { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        var dbPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "library.db");
        optionsBuilder.UseSqlite($"Data Source={dbPath}");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Kolcsonze>(entity =>
        {
            entity.ToTable("kolcsonzes");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Datum).HasColumnName("datum");
            entity.Property(e => e.KonyvId).HasColumnName("konyvId");
            entity.Property(e => e.OlvasoNev).HasColumnName("olvasoNev");
            entity.Property(e => e.Visszahozva).HasColumnName("visszahozva");

            entity.HasOne(d => d.Konyv).WithMany(p => p.Kolcsonzes)
                .HasForeignKey(d => d.KonyvId)
                .OnDelete(DeleteBehavior.ClientSetNull);
        });

        modelBuilder.Entity<Konyv>(entity =>
        {
            entity.ToTable("konyv");

            entity.HasIndex(e => e.Cim, "IX_konyv_cim").IsUnique();

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Cim).HasColumnName("cim");
            entity.Property(e => e.KiadasEve).HasColumnName("kiadas_eve");
            entity.Property(e => e.Mufaj).HasColumnName("mufaj");
            entity.Property(e => e.SzerzoId).HasColumnName("szerzoId");

            entity.HasOne(d => d.Szerzo).WithMany(p => p.Konyvs)
                .HasForeignKey(d => d.SzerzoId)
                .OnDelete(DeleteBehavior.ClientSetNull);
        });

        modelBuilder.Entity<Szerzo>(entity =>
        {
            entity.ToTable("szerzo");

            entity.HasIndex(e => e.Nev, "IX_szerzo_nev").IsUnique();

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Nemzetiseg).HasColumnName("nemzetiseg");
            entity.Property(e => e.Nev).HasColumnName("nev");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
