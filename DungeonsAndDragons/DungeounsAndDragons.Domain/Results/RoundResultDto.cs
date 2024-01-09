namespace DungeounsAndDragons.Domain.Results;

public class RoundResultDto
{
    public List<AttackResultDto> Attacks { get; set; } = new();

    public int CurrentHeroHp { get; set; }
    
    public int CurrentMonsterHp { get; set; }
}