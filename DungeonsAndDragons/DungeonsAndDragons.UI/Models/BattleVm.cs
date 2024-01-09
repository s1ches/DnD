using DungeounsAndDragons.Domain.Models;
using DungeounsAndDragons.Domain.Results;

namespace DungeonsAndDragons.UI.Models;

public class BattleVm
{
    public BattleResultDto? Battle { get; set; }

    public Hero Hero { get; set; } = new()
    {
        Name = "MyHero",
        AttackModifier = 2,
        AttackPerRound = 2,
        DamageCubesNumber = 7,
        DamageCubeCost = 8,
        DamageModifier = 5,
        HealthPoints = 200,
        ArmorClass = 15
    };
    
    public Monster? Monster { get; set; }
    
}