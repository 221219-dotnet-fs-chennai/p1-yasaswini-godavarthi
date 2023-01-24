using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace EntityFrame.newEf;

public partial class TrainerDbContext : DbContext
{
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
        => optionsBuilder.UseSqlServer("Server=tcp:yashu-db-server.database.windows.net,1433;Initial Catalog=Trainer_db;Persist Security Info=False;User ID=yashu;Password=Yash@123;Encrypt=False;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Company>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("pk_company");

            entity.ToTable("Company");

            entity.Property(e => e.UserId)
                .ValueGeneratedOnAdd()
                .HasColumnName("user_id");
            entity.Property(e => e.CompanyDescription)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Company_Description");
            entity.Property(e => e.CompanyName)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("Company_name");
            entity.Property(e => e.CompanyType)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("Company_type");
            entity.Property(e => e.Experience)
                .HasMaxLength(20)
                .IsUnicode(false);

            entity.HasOne(d => d.User).WithOne(p => p.Company)
                .HasForeignKey<Company>(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Fk_company");
        });

        modelBuilder.Entity<EducationDetail>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("pk_education");

            entity.ToTable("Education_Details");

            entity.Property(e => e.UserId)
                .ValueGeneratedOnAdd()
                .HasColumnName("user_id");
            entity.Property(e => e.Department)
                .HasMaxLength(25)
                .IsUnicode(false);
            entity.Property(e => e.EndYear)
                .HasMaxLength(5)
                .IsUnicode(false)
                .HasColumnName("End_year");
            entity.Property(e => e.HighestGraduation)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("Highest_Graduation");
            entity.Property(e => e.Institute)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.StartYear)
                .HasMaxLength(5)
                .IsUnicode(false)
                .HasColumnName("Start_year");

            entity.HasOne(d => d.User).WithOne(p => p.EducationDetail)
                .HasForeignKey<EducationDetail>(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Fk_education");
        });

        modelBuilder.Entity<Skill>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("Pk_skill");

            entity.Property(e => e.UserId)
                .ValueGeneratedOnAdd()
                .HasColumnName("user_id");
            entity.Property(e => e.SkillLevel)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("Skill_Level");
            entity.Property(e => e.SkillName)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("Skill_name");
            entity.Property(e => e.SkillType)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("Skill_Type");

            entity.HasOne(d => d.User).WithOne(p => p.Skill)
                .HasForeignKey<Skill>(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Fk_skill");
        });

        modelBuilder.Entity<TrainerDetaile>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("pk_Details");

            entity.ToTable("Trainer_Detailes");

            entity.HasIndex(e => e.Email, "UQ__Trainer___A9D10534E3AAECE5").IsUnique();

            entity.Property(e => e.UserId).HasColumnName("user_id");
            entity.Property(e => e.Email)
                .HasMaxLength(25)
                .IsUnicode(false);
            entity.Property(e => e.FullName)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("Full_name");
            entity.Property(e => e.Gender)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.MobileNumber)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("Mobile_number");
            entity.Property(e => e.Password)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("PASSWORD");
            entity.Property(e => e.Website)
                .HasMaxLength(30)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
