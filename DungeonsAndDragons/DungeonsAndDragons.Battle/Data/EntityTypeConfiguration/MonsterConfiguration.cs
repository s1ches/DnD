using DungeounsAndDragons.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DungeonsAndDragons.Battle.Data.EntityTypeConfiguration;

public class MonsterConfiguration : IEntityTypeConfiguration<Monster>
{
    public void Configure(EntityTypeBuilder<Monster> builder)
    {
        builder.HasKey(monster => monster.Id);
        builder.HasIndex(monster => monster.Id).IsUnique();
        builder.Property(monster => monster.Name).IsRequired().HasMaxLength(100);
        builder.Property(monster => monster.HealthPoints).IsRequired();
        builder.Property(monster => monster.AttackModifier).IsRequired();
        builder.Property(monster => monster.AttackPerRound).IsRequired();
        builder.Property(monster => monster.DamageCubesNumber).IsRequired();
        builder.Property(monster => monster.DamageCubeCost).IsRequired();
        builder.Property(monster => monster.DamageModifier).IsRequired();
        builder.Property(monster => monster.ArmorClass).IsRequired();
    }
}