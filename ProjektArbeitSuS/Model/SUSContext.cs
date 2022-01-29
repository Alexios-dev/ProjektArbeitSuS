using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace ProjektArbeitSuS.Model
{
    public partial class SUSContext : DbContext
    {
        public SUSContext()
        {
        }

        public SUSContext(DbContextOptions<SUSContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Daten> Datens { get; set; } = null!;
        public virtual DbSet<Fach> Faches { get; set; } = null!;
        public virtual DbSet<Fehlzeiten> Fehlzeitens { get; set; } = null!;
        public virtual DbSet<Lehrer> Lehrers { get; set; } = null!;
        public virtual DbSet<Rfidchip> Rfidchips { get; set; } = null!;
        public virtual DbSet<Rfidleser> Rfidlesers { get; set; } = null!;
        public virtual DbSet<Schueler> Schuelers { get; set; } = null!;
        public virtual DbSet<SchulKlassen> SchulKlassens { get; set; } = null!;
        public virtual DbSet<Stundenplan> Stundenplans { get; set; } = null!;
        public virtual DbSet<StundenplanStunden> StundenplanStundens { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=localhost;Initial Catalog=SUS;Integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Daten>(entity =>
            {
                entity.ToTable("Daten");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.DatumVon).HasColumnType("datetime");

                entity.Property(e => e.RfidchipUid).HasColumnName("RFIDChip_UID");

                entity.Property(e => e.RfidleserId).HasColumnName("RFIDLeser_ID");

                entity.HasOne(d => d.RfidchipU)
                    .WithMany(p => p.Datens)
                    .HasForeignKey(d => d.RfidchipUid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Daten_RFIDChip");

                entity.HasOne(d => d.Rfidleser)
                    .WithMany(p => p.Datens)
                    .HasForeignKey(d => d.RfidleserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Daten_RFIDLeser");
            });

            modelBuilder.Entity<Fach>(entity =>
            {
                entity.ToTable("Fach");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Kuerzel)
                    .HasMaxLength(3)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Fehlzeiten>(entity =>
            {
                entity.ToTable("Fehlzeiten");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.DatumBis).HasColumnType("datetime");

                entity.Property(e => e.DatumVon).HasColumnType("datetime");

                entity.Property(e => e.LehrerMatrikelnummer).HasColumnName("Lehrer_Matrikelnummer");

                entity.Property(e => e.SchuelerMatrikelnummer).HasColumnName("Schueler_Matrikelnummer");

                entity.Property(e => e.StundenplanStundenId).HasColumnName("StundenplanStunden_ID");

                entity.HasOne(d => d.LehrerMatrikelnummerNavigation)
                    .WithMany(p => p.Fehlzeitens)
                    .HasForeignKey(d => d.LehrerMatrikelnummer)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Fehlzeiten_Lehrer");

                entity.HasOne(d => d.SchuelerMatrikelnummerNavigation)
                    .WithMany(p => p.Fehlzeitens)
                    .HasForeignKey(d => d.SchuelerMatrikelnummer)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Fehlzeiten_Schueler");

                entity.HasOne(d => d.StundenplanStunden)
                    .WithMany(p => p.Fehlzeitens)
                    .HasForeignKey(d => d.StundenplanStundenId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Fehlzeiten_StundenplanStunden");
            });

            modelBuilder.Entity<Lehrer>(entity =>
            {
                entity.HasKey(e => e.Matrikelnummer)
                    .HasName("Lehrer_pk");

                entity.ToTable("Lehrer");

                entity.Property(e => e.Matrikelnummer).ValueGeneratedNever();

                entity.Property(e => e.Geburtsdatum).HasColumnType("date");

                entity.Property(e => e.Kuerzel)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Nachname)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Password)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.RfidchipUid).HasColumnName("RFIDChip_UID");

                entity.Property(e => e.Vorname)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.RfidchipU)
                    .WithMany(p => p.Lehrers)
                    .HasForeignKey(d => d.RfidchipUid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Lehrer_RFIDChip");
            });

            modelBuilder.Entity<Rfidchip>(entity =>
            {
                entity.HasKey(e => e.Uid)
                    .HasName("RFIDChip_pk");

                entity.ToTable("RFIDChip");

                entity.Property(e => e.Uid)
                    .ValueGeneratedNever()
                    .HasColumnName("UID");
            });

            modelBuilder.Entity<Rfidleser>(entity =>
            {
                entity.ToTable("RFIDLeser");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Schueler>(entity =>
            {
                entity.HasKey(e => e.Matrikelnummer)
                    .HasName("Schueler_pk");

                entity.ToTable("Schueler");

                entity.Property(e => e.Matrikelnummer).ValueGeneratedNever();

                entity.Property(e => e.Geburtsdatum).HasColumnType("date");

                entity.Property(e => e.Nachname)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Password)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.RfidchipUid).HasColumnName("RFIDChip_UID");

                entity.Property(e => e.SchulKlassenId).HasColumnName("SchulKlassen_ID");

                entity.Property(e => e.Vorname)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.RfidchipU)
                    .WithMany(p => p.Schuelers)
                    .HasForeignKey(d => d.RfidchipUid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Schueler_RFIDChip");

                entity.HasOne(d => d.SchulKlassen)
                    .WithMany(p => p.Schuelers)
                    .HasForeignKey(d => d.SchulKlassenId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Schueler_SchuhlKlassen");
            });

            modelBuilder.Entity<SchulKlassen>(entity =>
            {
                entity.ToTable("SchulKlassen");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.LehrerMatrikelnummer).HasColumnName("Lehrer_Matrikelnummer");

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.LehrerMatrikelnummerNavigation)
                    .WithMany(p => p.SchulKlassens)
                    .HasForeignKey(d => d.LehrerMatrikelnummer)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Klassen_Lehrer");
            });

            modelBuilder.Entity<Stundenplan>(entity =>
            {
                entity.ToTable("Stundenplan");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.SchulKlassenId).HasColumnName("SchulKlassen_ID");

                entity.HasOne(d => d.SchulKlassen)
                    .WithMany(p => p.Stundenplans)
                    .HasForeignKey(d => d.SchulKlassenId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Stundenplan_SchuhlKlassen");
            });

            modelBuilder.Entity<StundenplanStunden>(entity =>
            {
                entity.ToTable("StundenplanStunden");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Bemerkung).HasColumnType("text");

                entity.Property(e => e.DateTimeBis).HasColumnType("datetime");

                entity.Property(e => e.DateTimeVon).HasColumnType("datetime");

                entity.Property(e => e.FachId).HasColumnName("Fach_ID");

                entity.Property(e => e.StundenplanId).HasColumnName("Stundenplan_ID");

                entity.HasOne(d => d.Fach)
                    .WithMany(p => p.StundenplanStundens)
                    .HasForeignKey(d => d.FachId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("StundenplanStunden_Fach");

                entity.HasOne(d => d.Stundenplan)
                    .WithMany(p => p.StundenplanStundens)
                    .HasForeignKey(d => d.StundenplanId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("StundenplanStunden_Stundenplan");

                entity.HasMany(d => d.LehrerMatrikelnummers)
                    .WithMany(p => p.StundenplanStundens)
                    .UsingEntity<Dictionary<string, object>>(
                        "LehrerStundenplanStunden",
                        l => l.HasOne<Lehrer>().WithMany().HasForeignKey("LehrerMatrikelnummer").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("Lehrer_StundenplanStunden_Lehrer"),
                        r => r.HasOne<StundenplanStunden>().WithMany().HasForeignKey("StundenplanStundenId").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("Lehrer_StundenplanStunden_StundenplanStunden"),
                        j =>
                        {
                            j.HasKey("StundenplanStundenId", "LehrerMatrikelnummer").HasName("Lehrer_StundenplanStunden_pk");

                            j.ToTable("Lehrer_StundenplanStunden");

                            j.IndexerProperty<long>("StundenplanStundenId").HasColumnName("StundenplanStunden_ID");

                            j.IndexerProperty<long>("LehrerMatrikelnummer").HasColumnName("Lehrer_Matrikelnummer");
                        });
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
