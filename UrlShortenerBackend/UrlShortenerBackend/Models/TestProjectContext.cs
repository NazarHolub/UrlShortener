using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace UrlShortenerBackend.Models;

public partial class TestProjectContext : DbContext
{
    public TestProjectContext()
    {
    }

    public TestProjectContext(DbContextOptions<TestProjectContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Url> Urls { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=(local); Database=TestProject;Integrated Security=true;TrustServerCertificate=true");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Url>(entity =>
        {
            entity.ToTable("URLs");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.NewUrl)
                .HasMaxLength(50)
                .IsFixedLength()
                .HasColumnName("NewURL");
            entity.Property(e => e.OldUrl)
                .HasMaxLength(100)
                .IsFixedLength()
                .HasColumnName("OldURL");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.Property(e => e.UserId).ValueGeneratedNever();
            entity.Property(e => e.Email)
                .HasMaxLength(20)
                .IsFixedLength();
            entity.Property(e => e.Password)
                .HasMaxLength(20)
                .IsFixedLength();
            entity.Property(e => e.Username)
                .HasMaxLength(15)
                .IsFixedLength();
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
