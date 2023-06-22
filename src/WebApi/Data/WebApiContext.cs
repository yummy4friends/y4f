using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using WebApi.Models;

namespace WebApi.Data;

public partial class WebApiContext : DbContext
{
    public WebApiContext(DbContextOptions<WebApiContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Allergie> Allergies { get; set; }

    public virtual DbSet<Bestellungsposition> Bestellungspositions { get; set; }

    public virtual DbSet<Kunde> Kundes { get; set; }

    public virtual DbSet<Menuitem> Menuitems { get; set; }

    public virtual DbSet<Menuitemkategorie> Menuitemkategories { get; set; }

    public virtual DbSet<Menuitemueberkategorie> Menuitemueberkategories { get; set; }

    public virtual DbSet<Rabatt> Rabatts { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("utf8_general_ci")
            .HasCharSet("utf8");

        modelBuilder.Entity<Allergie>(entity =>
        {
            entity.HasKey(e => e.Idallergie).HasName("PRIMARY");

            entity.ToTable("allergie");

            entity.Property(e => e.Idallergie)
                .ValueGeneratedNever()
                .HasColumnType("int(11)")
                .HasColumnName("IDAllergie");
            entity.Property(e => e.Beschreibung).HasMaxLength(45);
        });

        modelBuilder.Entity<Bestellungsposition>(entity =>
        {
            entity.HasKey(e => e.Idbestellung).HasName("PRIMARY");

            entity.ToTable("bestellungsposition");

            entity.HasIndex(e => e.KundeIdkunde, "fk_Bestellung_Kunde");

            entity.HasIndex(e => e.RabattIdrabatt, "fk_Bestellungsposition_Rabatt1");

            entity.Property(e => e.Idbestellung)
                .ValueGeneratedNever()
                .HasColumnType("int(11)")
                .HasColumnName("IDBestellung");
            entity.Property(e => e.Datum).HasColumnType("datetime");
            entity.Property(e => e.KundeIdkunde)
                .HasColumnType("int(11)")
                .HasColumnName("Kunde_IDKunde");
            entity.Property(e => e.Menge).HasColumnType("int(11)");
            entity.Property(e => e.RabattIdrabatt)
                .HasColumnType("int(11)")
                .HasColumnName("Rabatt_IDRabatt");

            entity.HasOne(d => d.KundeIdkundeNavigation).WithMany(p => p.Bestellungspositions)
                .HasForeignKey(d => d.KundeIdkunde)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_Bestellung_Kunde");

            entity.HasOne(d => d.RabattIdrabattNavigation).WithMany(p => p.Bestellungspositions)
                .HasForeignKey(d => d.RabattIdrabatt)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_Bestellungsposition_Rabatt1");

            entity.HasMany(d => d.MenuItemIdmenuItems).WithMany(p => p.BestellungspositionIdbestellungs)
                .UsingEntity<Dictionary<string, object>>(
                    "BestellungspositionHasMenuitem",
                    r => r.HasOne<Menuitem>().WithMany()
                        .HasForeignKey("MenuItemIdmenuItem")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("fk_Bestellungsposition_has_MenuItem_MenuItem1"),
                    l => l.HasOne<Bestellungsposition>().WithMany()
                        .HasForeignKey("BestellungspositionIdbestellung")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("fk_Bestellungsposition_has_MenuItem_Bestellungsposition1"),
                    j =>
                    {
                        j.HasKey("BestellungspositionIdbestellung", "MenuItemIdmenuItem")
                            .HasName("PRIMARY")
                            .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0 });
                        j.ToTable("bestellungsposition_has_menuitem");
                        j.HasIndex(new[] { "MenuItemIdmenuItem" }, "fk_Bestellungsposition_has_MenuItem_MenuItem1");
                        j.IndexerProperty<int>("BestellungspositionIdbestellung")
                            .HasColumnType("int(11)")
                            .HasColumnName("Bestellungsposition_IDBestellung");
                        j.IndexerProperty<int>("MenuItemIdmenuItem")
                            .HasColumnType("int(11)")
                            .HasColumnName("MenuItem_IDMenuItem");
                    });
        });

        modelBuilder.Entity<Kunde>(entity =>
        {
            entity.HasKey(e => e.Idkunde).HasName("PRIMARY");

            entity.ToTable("kunde");

            entity.Property(e => e.Idkunde)
                .ValueGeneratedNever()
                .HasColumnType("int(11)")
                .HasColumnName("IDKunde");
            entity.Property(e => e.Code)
                .HasMaxLength(45)
                .HasColumnName("code");
            entity.Property(e => e.Treuepunkte).HasColumnType("int(11)");
        });

        modelBuilder.Entity<Menuitem>(entity =>
        {
            entity.HasKey(e => e.IdmenuItem).HasName("PRIMARY");

            entity.ToTable("menuitem");

            entity.HasIndex(e => e.MenuItemKategorieIdmenuItemKategorie, "fk_MenuItem_MenuItemKategorie1");

            entity.Property(e => e.IdmenuItem)
                .ValueGeneratedNever()
                .HasColumnType("int(11)")
                .HasColumnName("IDMenuItem");
            entity.Property(e => e.Bezeichnung).HasMaxLength(45);
            entity.Property(e => e.MenuItemKategorieIdmenuItemKategorie)
                .HasColumnType("int(11)")
                .HasColumnName("MenuItemKategorie_IDMenuItemKategorie");
            entity.Property(e => e.Preis).HasPrecision(8, 2);
            entity.Property(e => e.Zusatzinformation).HasMaxLength(45);

            entity.HasOne(d => d.MenuItemKategorieIdmenuItemKategorieNavigation).WithMany(p => p.Menuitems)
                .HasForeignKey(d => d.MenuItemKategorieIdmenuItemKategorie)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_MenuItem_MenuItemKategorie1");

            entity.HasMany(d => d.AllergieIdallergies).WithMany(p => p.MenuItemIdmenuItems)
                .UsingEntity<Dictionary<string, object>>(
                    "MenuitemHasAllergie",
                    r => r.HasOne<Allergie>().WithMany()
                        .HasForeignKey("AllergieIdallergie")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("fk_MenuItem_has_Allergie_Allergie1"),
                    l => l.HasOne<Menuitem>().WithMany()
                        .HasForeignKey("MenuItemIdmenuItem")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("fk_MenuItem_has_Allergie_MenuItem1"),
                    j =>
                    {
                        j.HasKey("MenuItemIdmenuItem", "AllergieIdallergie")
                            .HasName("PRIMARY")
                            .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0 });
                        j.ToTable("menuitem_has_allergie");
                        j.HasIndex(new[] { "AllergieIdallergie" }, "fk_MenuItem_has_Allergie_Allergie1");
                        j.IndexerProperty<int>("MenuItemIdmenuItem")
                            .HasColumnType("int(11)")
                            .HasColumnName("MenuItem_IDMenuItem");
                        j.IndexerProperty<int>("AllergieIdallergie")
                            .HasColumnType("int(11)")
                            .HasColumnName("Allergie_IDAllergie");
                    });
        });

        modelBuilder.Entity<Menuitemkategorie>(entity =>
        {
            entity.HasKey(e => e.IdmenuItemKategorie).HasName("PRIMARY");

            entity.ToTable("menuitemkategorie");

            entity.HasIndex(e => e.MenuItemUeberkategorieIdmenuItemUeberkategorie, "fk_MenuItemKategorie_MenuItemUeberkategorie1");

            entity.Property(e => e.IdmenuItemKategorie)
                .ValueGeneratedNever()
                .HasColumnType("int(11)")
                .HasColumnName("IDMenuItemKategorie");
            entity.Property(e => e.Bezeichnung).HasMaxLength(45);
            entity.Property(e => e.MenuItemUeberkategorieIdmenuItemUeberkategorie)
                .HasColumnType("int(11)")
                .HasColumnName("MenuItemUeberkategorie_IDMenuItemUeberkategorie");

            entity.HasOne(d => d.MenuItemUeberkategorieIdmenuItemUeberkategorieNavigation).WithMany(p => p.Menuitemkategories)
                .HasForeignKey(d => d.MenuItemUeberkategorieIdmenuItemUeberkategorie)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_MenuItemKategorie_MenuItemUeberkategorie1");
        });

        modelBuilder.Entity<Menuitemueberkategorie>(entity =>
        {
            entity.HasKey(e => e.IdmenuItemUeberkategorie).HasName("PRIMARY");

            entity.ToTable("menuitemueberkategorie");

            entity.Property(e => e.IdmenuItemUeberkategorie)
                .ValueGeneratedNever()
                .HasColumnType("int(11)")
                .HasColumnName("IDMenuItemUeberkategorie");
            entity.Property(e => e.Bezeichnung).HasMaxLength(45);
        });

        modelBuilder.Entity<Rabatt>(entity =>
        {
            entity.HasKey(e => e.Idrabatt).HasName("PRIMARY");

            entity.ToTable("rabatt");

            entity.Property(e => e.Idrabatt)
                .ValueGeneratedNever()
                .HasColumnType("int(11)")
                .HasColumnName("IDRabatt");
            entity.Property(e => e.GueltigkeitBis).HasColumnType("datetime");
            entity.Property(e => e.GueltigkeitVon).HasColumnType("datetime");
            entity.Property(e => e.Prozent).HasPrecision(8, 2);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
