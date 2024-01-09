using DungeounsAndDragons.Domain.Models;

namespace DungeounsAndDragons.Domain.Results;

public class AttackResultDto
{
    public required Player Attacking { get; set; }

    public required Player Raking { get; set; }
    
    public int CurrentHeroHp { get; set; }
    
    public int CurrentMonsterHp { get; set; }
    
    public HitType HitType { get; set; }
    
    public int NotModifiedAttack { get; set; }

    public int NotModifiedDamage { get; set; }
}