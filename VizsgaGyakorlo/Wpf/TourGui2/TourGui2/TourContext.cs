using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.EntityFrameworkCore;
using TourGui2.Models;

namespace TourGui2;

public partial class TourContext : DbContext
{
    public TourContext()
    {
    }

    public TourContext(DbContextOptions<TourContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Csapat> Csapats { get; set; }

    public virtual DbSet<Eredmeny> Eredmenies { get; set; }

    public virtual DbSet<Versenyzo> Versenyzos { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        var dbPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "tour.db");
        optionsBuilder.UseSqlite($"Data Source={dbPath}");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Csapat>(entity =>
        {
            entity.ToTable("csapat");

            entity.HasIndex(e => e.CsapatNev, "IX_csapat_csapatNev").IsUnique();

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.CsapatNev)
                .HasColumnType("VARCHAR(200)")
                .HasColumnName("csapatNev");
        });

        modelBuilder.Entity<Eredmeny>(entity =>
        {
            entity.ToTable("eredmeny");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Ido)
                .HasColumnType("time")
                .HasColumnName("ido");
            entity.Property(e => e.Szakasz).HasColumnName("szakasz");
            entity.Property(e => e.VersenyzoId).HasColumnName("versenyzoId");

            entity.HasOne(d => d.Versenyzo).WithMany(p => p.Eredmenies)
                .HasForeignKey(d => d.VersenyzoId)
                .OnDelete(DeleteBehavior.ClientSetNull);
        });

        modelBuilder.Entity<Versenyzo>(entity =>
        {
            entity.ToTable("versenyzo");

            entity.HasIndex(e => e.Nev, "IX_versenyzo_nev").IsUnique();

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.CsapatId).HasColumnName("csapatId");
            entity.Property(e => e.Nemzetiseg)
                .HasColumnType("VARCHAR(200)")
                .HasColumnName("nemzetiseg");
            entity.Property(e => e.Nev)
                .HasColumnType("VARCHAR(200)")
                .HasColumnName("nev");

            entity.HasOne(d => d.Csapat).WithMany(p => p.Versenyzos)
                .HasForeignKey(d => d.CsapatId)
                .OnDelete(DeleteBehavior.ClientSetNull);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
