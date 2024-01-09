using DungeonsAndDragons.Battle.Data.EntityTypeConfiguration;
using DungeonsAndDragons.Battle.Data.StartData;
using DungeounsAndDragons.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace DungeonsAndDragons.Battle.Data;

public class MonstersDbContext : DbContext
{
    public DbSet<Monster> Monsters { get; set; } = null!;

    public MonstersDbContext(DbContextOptions options) : base(options)
    {
        Database.EnsureCreated();
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new MonsterConfiguration());
    
        modelBuilder.Entity<Monster>().HasData(StartMonsterData.Data);
        
        base.OnModelCreating(modelBuilder);
    }
}