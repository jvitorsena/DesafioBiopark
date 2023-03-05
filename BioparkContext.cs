using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using DesafioBiopark.Model.Migrations;

namespace DesafioBiopark;

public partial class BioparkContext : DbContext
{
    public BioparkContext()
    {
    }

    public BioparkContext(DbContextOptions<BioparkContext> options)
        : base(options)
    {
    }
    
    public virtual DbSet<EdificiosMigration> Edificios { get; set; }
    public virtual DbSet<LocatariosMigration> Locatarios { get; set; }
    public virtual DbSet<ApartamentosMigration> Apartamentos { get; set; }
    public virtual DbSet<ContratoMigration> Contratos { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseMySql("server=localhost;user=root;password=root_pwd;database=Biopark", Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.31-mysql"));

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("utf8mb3_bin")
            .HasCharSet("utf8mb3");

        modelBuilder.Entity<EdificiosMigration>().HasData(EdificiosSeed.Edificios);
        modelBuilder.Entity<LocatariosMigration>().HasData(LocatariosSeed.Locatarios);
        modelBuilder.Entity<ApartamentosMigration>().HasData(ApartamentosSeed.Apartamentos);
        // modelBuilder.Entity<ContratoMigration>().HasData(ContratoSeed.Contratos);
        
        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
