namespace DungeounsAndDragons.Domain.Models;

public class Player
{
    public Guid Id { get; set; }
    
    public required string Name { get; set; }
    
    public int HealthPoints { get; set; }
    
    public int AttackModifier { get; set; }
    
    public int AttackPerRound { get; set; }
    
    public int DamageCubesNumber { get; set; }
    
    public int DamageCubeCost { get; set; }
    
    public int DamageModifier { get; set; }
    
    public int ArmorClass { get; set; }
}