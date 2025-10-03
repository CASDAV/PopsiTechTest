using System;
using Microsoft.EntityFrameworkCore;
using Popsi.Domain.Entities;

namespace Popsi.Infrastructure.Persistance;

public class AppDbContext : DbContext
{

    public DbSet<User> Users { get; set; }
    public DbSet<Labour> Labours { get; set; }

    public AppDbContext(DbContextOptions options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<User>()
            .HasKey(u => u.Id);
        modelBuilder.Entity<User>()
            .Property(u => u.Name)
            .IsRequired();
        modelBuilder.Entity<User>()
            .Property(u => u.Email)
            .IsRequired()
            .HasMaxLength(255);

        modelBuilder.Entity<Labour>()
            .HasKey(l => l.Id);
        modelBuilder.Entity<Labour>()
            .Property(l => l.Title)
            .IsRequired()
            .HasMaxLength(100);
        modelBuilder.Entity<Labour>()
            .Property(l => l.CreationDate)
            .IsRequired();
        modelBuilder.Entity<Labour>()
            .Property(l => l.ExpirationDate)
            .IsRequired();
        modelBuilder.Entity<Labour>()
            .HasOne(l => l.User)
            .WithMany(u => u.Tasks)
            .HasForeignKey(l => l.Owner);
    }
}
