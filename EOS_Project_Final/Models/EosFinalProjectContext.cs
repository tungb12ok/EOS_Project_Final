using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace EOS_Project_Final.Models;

public partial class EosFinalProjectContext : DbContext
{
    public EosFinalProjectContext()
    {
    }

    public EosFinalProjectContext(DbContextOptions<EosFinalProjectContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Quiz> Quizzes { get; set; }

    public virtual DbSet<Result> Results { get; set; }

    public virtual DbSet<Type> Types { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Server=ADMIN;database=EOS_Final_Project;Trusted_Connection=SSPI;Encrypt=false;TrustServerCertificate=true");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Quiz>(entity =>
        {
            entity.ToTable("Quiz");

            entity.Property(e => e.Id)
                .HasMaxLength(10)
                .IsFixedLength();
            entity.Property(e => e.Anwser)
                .HasMaxLength(10)
                .IsFixedLength();
            entity.Property(e => e.TypeId).HasColumnName("Type_Id");

            entity.HasOne(d => d.Type).WithMany(p => p.Quizzes)
                .HasForeignKey(d => d.TypeId)
                .HasConstraintName("FK_Quiz_Type");
        });

        modelBuilder.Entity<Result>(entity =>
        {
            entity.HasNoKey();

            entity.Property(e => e.TypeId).HasColumnName("TypeID");
            entity.Property(e => e.UserId).HasColumnName("UserID");

            entity.HasOne(d => d.Type).WithMany()
                .HasForeignKey(d => d.TypeId)
                .HasConstraintName("FK_Results_Type");

            entity.HasOne(d => d.User).WithMany()
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK_Results_User");
        });

        modelBuilder.Entity<Type>(entity =>
        {
            entity.ToTable("Type");

            entity.Property(e => e.Code)
                .HasMaxLength(10)
                .IsFixedLength();
            entity.Property(e => e.Name).HasMaxLength(50);
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.ToTable("User");

            entity.Property(e => e.Password).HasMaxLength(50);
            entity.Property(e => e.RoldId).HasColumnName("Rold_ID");
            entity.Property(e => e.Username).HasMaxLength(50);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
