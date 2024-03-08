using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Agenda2.Agenda2DB;

public partial class ContactLongContext : DbContext
{
    public ContactLongContext()
    {
    }

    public ContactLongContext(DbContextOptions<ContactLongContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Contact> Contacts { get; set; }

    public virtual DbSet<Evenement> Evenements { get; set; }

    public virtual DbSet<Profil> Profils { get; set; }

    public virtual DbSet<R> Rs { get; set; }

    public virtual DbSet<Tache> Taches { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseMySql("server=127.0.0.1;port=3306;user=root;database=contact_long", Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.21-mysql"));

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("utf8mb4_0900_ai_ci")
            .HasCharSet("utf8mb4");

        modelBuilder.Entity<Contact>(entity =>
        {
            entity.HasKey(e => e.Idcontacts).HasName("PRIMARY");

            entity.ToTable("contact");

            entity.Property(e => e.Idcontacts).HasColumnName("idcontacts");
            entity.Property(e => e.AdresseContact)
                .HasMaxLength(45)
                .HasColumnName("adresse_contact");
            entity.Property(e => e.CodepostalContact)
                .HasMaxLength(45)
                .HasColumnName("codepostal_contact");
            entity.Property(e => e.EmailContact)
                .HasMaxLength(45)
                .HasColumnName("email_contact");
            entity.Property(e => e.NaissanceContact)
                .HasMaxLength(45)
                .HasColumnName("naissance_contact");
            entity.Property(e => e.NomContact)
                .HasMaxLength(45)
                .HasColumnName("nom_contact");
            entity.Property(e => e.PhoneContact)
                .HasMaxLength(45)
                .HasColumnName("phone_contact");
            entity.Property(e => e.PrenomContact)
                .HasMaxLength(45)
                .HasColumnName("prenom_contact");
            entity.Property(e => e.VilleContact)
                .HasMaxLength(45)
                .HasColumnName("ville_contact");

            entity.HasMany(d => d.RsIdrs).WithMany(p => p.ContactIdcontacts)
                .UsingEntity<Dictionary<string, object>>(
                    "ContactHasRs1",
                    r => r.HasOne<R>().WithMany()
                        .HasForeignKey("RsIdrs")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("fk_contact_has_rs1_rs1"),
                    l => l.HasOne<Contact>().WithMany()
                        .HasForeignKey("ContactIdcontacts")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("fk_contact_has_rs1_contact1"),
                    j =>
                    {
                        j.HasKey("ContactIdcontacts", "RsIdrs")
                            .HasName("PRIMARY")
                            .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0 });
                        j.ToTable("contact_has_rs1");
                        j.HasIndex(new[] { "ContactIdcontacts" }, "fk_contact_has_rs1_contact1_idx");
                        j.HasIndex(new[] { "RsIdrs" }, "fk_contact_has_rs1_rs1_idx");
                        j.IndexerProperty<int>("ContactIdcontacts").HasColumnName("contact_idcontacts");
                        j.IndexerProperty<int>("RsIdrs").HasColumnName("rs_idrs");
                    });
        });

        modelBuilder.Entity<Evenement>(entity =>
        {
            entity.HasKey(e => e.Idevenement).HasName("PRIMARY");

            entity.ToTable("evenement");

            entity.Property(e => e.Idevenement).HasColumnName("idevenement");
            entity.Property(e => e.NomEvenement)
                .HasMaxLength(55)
                .HasColumnName("nom_evenement");
        });

        modelBuilder.Entity<Profil>(entity =>
        {
            entity.HasKey(e => e.Idprofils).HasName("PRIMARY");

            entity.ToTable("profil");

            entity.HasIndex(e => e.ContactIdcontacts, "fk_profil_contact1_idx");

            entity.HasIndex(e => e.RsIdrs, "fk_profil_rs1_idx");

            entity.Property(e => e.Idprofils).HasColumnName("idprofils");
            entity.Property(e => e.ContactIdcontacts).HasColumnName("contact_idcontacts");
            entity.Property(e => e.PseudonymeProfils)
                .HasMaxLength(45)
                .HasColumnName("pseudonyme_profils");
            entity.Property(e => e.RsIdrs).HasColumnName("rs_idrs");
            entity.Property(e => e.UrlProfil)
                .HasMaxLength(45)
                .HasColumnName("url_profil");

            entity.HasOne(d => d.ContactIdcontactsNavigation).WithMany(p => p.Profils)
                .HasForeignKey(d => d.ContactIdcontacts)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_profil_contact1");

            entity.HasOne(d => d.RsIdrsNavigation).WithMany(p => p.Profils)
                .HasForeignKey(d => d.RsIdrs)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_profil_rs1");
        });

        modelBuilder.Entity<R>(entity =>
        {
            entity.HasKey(e => e.Idrs).HasName("PRIMARY");

            entity.ToTable("rs");

            entity.Property(e => e.Idrs).HasColumnName("idrs");
            entity.Property(e => e.IconRs)
                .HasMaxLength(200)
                .HasColumnName("icon_rs");
            entity.Property(e => e.NomRs)
                .HasMaxLength(45)
                .HasColumnName("nom_rs");
            entity.Property(e => e.UrlRs)
                .HasMaxLength(200)
                .HasColumnName("url_rs");
        });

        modelBuilder.Entity<Tache>(entity =>
        {
            entity.HasKey(e => e.IdTache).HasName("PRIMARY");

            entity.ToTable("tache");

            entity.HasIndex(e => e.EvenementIdevenement, "fk_tache_evenement1_idx");

            entity.Property(e => e.IdTache).HasColumnName("id_tache");
            entity.Property(e => e.DatelimTache)
                .HasMaxLength(55)
                .HasColumnName("datelim_tache");
            entity.Property(e => e.EvenementIdevenement).HasColumnName("evenement_idevenement");
            entity.Property(e => e.FaitTache).HasColumnName("fait_tache");
            entity.Property(e => e.NomTache)
                .HasMaxLength(75)
                .HasColumnName("nom_tache");

            entity.HasOne(d => d.EvenementIdevenementNavigation).WithMany(p => p.Taches)
                .HasForeignKey(d => d.EvenementIdevenement)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_tache_evenement1");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}