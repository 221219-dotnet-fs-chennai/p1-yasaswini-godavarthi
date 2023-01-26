using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace FluentApi.Entities;

public partial class TrainerDbContext : DbContext
{
    string path = File.ReadAllText("../../../../Console/connectionString.txt");
    public TrainerDbContext()
    {
    }

    public TrainerDbContext(DbContextOptions<TrainerDbContext> options)
        : base(options)
    {
    }
    

    public virtual DbSet<Company> Companies { get; set; }

    public virtual DbSet<EducationDetail> EducationDetails { get; set; }

    public virtual DbSet<Skill> Skills { get; set; }

    public virtual DbSet<TrainerDetaile> TrainerDetailes { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer(path);

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Company>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("pk_company");

            entity.Property(e => e.UserId).ValueGeneratedOnAdd();

            entity.HasOne(d => d.User).WithOne(p => p.Company)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Fk_company");
        });

        modelBuilder.Entity<EducationDetail>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("pk_education");

            entity.Property(e => e.UserId).ValueGeneratedOnAdd();

            entity.HasOne(d => d.User).WithOne(p => p.EducationDetail)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Fk_education");
        });

        modelBuilder.Entity<Skill>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("Pk_skill");

            entity.Property(e => e.UserId).ValueGeneratedOnAdd();

            entity.HasOne(d => d.User).WithOne(p => p.Skill)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Fk_skill");
        });

        modelBuilder.Entity<TrainerDetaile>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("pk_Details");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
