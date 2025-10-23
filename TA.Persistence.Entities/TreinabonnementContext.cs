using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Pomelo.EntityFrameworkCore.MySql.Scaffolding.Internal;

namespace TA.Persistence.Entities;

public partial class TreinabonnementContext : DbContext
{
    public TreinabonnementContext()
    {
    }

    public TreinabonnementContext(DbContextOptions<TreinabonnementContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Abonnement> Abonnements { get; set; }

    public virtual DbSet<Klant> Klants { get; set; }

    public virtual DbSet<Station> Stations { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseMySql("server=127.0.0.1;port=3306;database=treinabonnement;user=tauser;password=tauser", Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.4.6-mysql"));

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("utf8mb4_0900_ai_ci")
            .HasCharSet("utf8mb4");

        modelBuilder.Entity<Abonnement>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("abonnement");

            entity.HasIndex(e => e.AankomstStationId, "fk_abonnement_aankomststation");

            entity.HasIndex(e => e.KlantId, "fk_abonnement_klant");

            entity.HasIndex(e => e.VertrekStationId, "fk_abonnement_vertrekstation");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.AankomstStationId).HasColumnName("aankomst_station_id");
            entity.Property(e => e.Einddatum).HasColumnName("einddatum");
            entity.Property(e => e.KlantId).HasColumnName("klant_id");
            entity.Property(e => e.Klasse)
                .HasColumnType("enum('1','2')")
                .HasColumnName("klasse");
            entity.Property(e => e.Startdatum).HasColumnName("startdatum");
            entity.Property(e => e.VertrekStationId).HasColumnName("vertrek_station_id");

            entity.HasOne(d => d.AankomstStation).WithMany(p => p.AbonnementAankomstStations)
                .HasForeignKey(d => d.AankomstStationId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_abonnement_aankomststation");

            entity.HasOne(d => d.Klant).WithMany(p => p.Abonnements)
                .HasForeignKey(d => d.KlantId)
                .HasConstraintName("fk_abonnement_klant");

            entity.HasOne(d => d.VertrekStation).WithMany(p => p.AbonnementVertrekStations)
                .HasForeignKey(d => d.VertrekStationId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_abonnement_vertrekstation");
        });

        modelBuilder.Entity<Klant>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("klant");

            entity.HasIndex(e => e.Email, "email").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Email)
                .HasMaxLength(25)
                .HasColumnName("email");
            entity.Property(e => e.Naam)
                .HasMaxLength(25)
                .HasColumnName("naam");
            entity.Property(e => e.Voornaam)
                .HasMaxLength(25)
                .HasColumnName("voornaam");
        });

        modelBuilder.Entity<Station>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("station");

            entity.HasIndex(e => e.Naam, "naam").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Naam)
                .HasMaxLength(50)
                .HasColumnName("naam");
            entity.Property(e => e.VerwarmdeWachtruimte).HasColumnName("verwarmde_wachtruimte");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
