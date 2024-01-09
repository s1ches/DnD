using DungeounsAndDragons.Domain.Models;

namespace DungeonsAndDragons.Battle.Data.StartData;

public class StartMonsterData
{
    public static List<Monster> Data => new List<Monster>()
    {
        new()
        {
            Id = Guid.NewGuid(),
            Name = "Asharra",
            HealthPoints = 100,
            AttackModifier = 0,
            AttackPerRound = 10,
            DamageCubesNumber = 7,
            DamageCubeCost = 8,
            DamageModifier = 4,
            ArmorClass = 12
        },
        new()
        {
            Id = Guid.NewGuid(),
            Name = "Adult black dragon",
            HealthPoints = 200,
            AttackModifier = 6,
            AttackPerRound = 23,
            DamageCubesNumber = 17,
            DamageCubeCost = 12,
            DamageModifier = 85,
            ArmorClass = 19
        },
        new()
        {
            Id = Guid.NewGuid(),
            Name = "Lemure",
            HealthPoints = 40,
            AttackModifier = 2,
            AttackPerRound = 10,
            DamageCubesNumber = 3,
            DamageCubeCost = 8,
            DamageModifier = 0,
            ArmorClass = 7
        },
        new()
        {
            Id = Guid.NewGuid(),
            Name = "Badger",
            HealthPoints = 15,
            AttackModifier = -3,
            AttackPerRound = 4,
            DamageCubesNumber = 1,
            DamageCubeCost = 4,
            DamageModifier = 1,
            ArmorClass = 10
        },
        new()
        {
            Id = Guid.NewGuid(),
            Name = "Devil Dog",
            HealthPoints = 70,
            AttackModifier = 0,
            AttackPerRound = 10,
            DamageCubesNumber = 2,
            DamageCubeCost = 8,
            DamageModifier = 0,
            ArmorClass = 10
        }
    };
}