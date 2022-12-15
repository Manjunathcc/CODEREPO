using System;
using System.Collections.Generic;
using Client.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Client.Infrastructure.Context;

public partial class HskeletonContext : DbContext
{
    public HskeletonContext()
    {
    }

    public HskeletonContext(DbContextOptions<HskeletonContext> options)
        : base(options)
    {

    }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<Login> Logins { get; set; }

    public virtual DbSet<Register> Registers { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=HSkeleton;Trusted_Connection=true");

      protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("PK__Users__1788CC4CA2BEC206");

            entity.Property(e => e.Email)
                .HasMaxLength(250)
                .IsUnicode(false);
            entity.Property(e => e.Password)
                .HasMaxLength(250)
                .IsUnicode(false);
            entity.Property(e => e.StreetName)
                .HasMaxLength(250)
                .IsUnicode(false);
            entity.Property(e => e.UserName)
                .HasMaxLength(250)
                .IsUnicode(false);
        });
         modelBuilder.Entity<Login>(entity =>
        {
            entity.HasKey(e => e.MailId).HasName("PK__Login__09A8749A1B70A6E0");

            entity.ToTable("Login");

            entity.Property(e => e.MailId)
                .HasMaxLength(250)
                .IsUnicode(false);
            entity.Property(e => e.Password)
                .HasMaxLength(250)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Register>(entity =>
        {
            entity.HasKey(e => e.MailId).HasName("PK__Register__09A8749A843E68FE");

            entity.ToTable("Register");

            entity.Property(e => e.MailId)
                .HasMaxLength(250)
                .IsUnicode(false);
            entity.Property(e => e.Password)
                .HasMaxLength(250)
                .IsUnicode(false);
            entity.Property(e => e.UserId)
                .HasMaxLength(250)
                .IsUnicode(false);
            entity.Property(e => e.UserName)
                .HasMaxLength(250)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
