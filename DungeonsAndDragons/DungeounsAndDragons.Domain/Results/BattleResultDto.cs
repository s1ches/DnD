using DungeounsAndDragons.Domain.Models;

namespace DungeounsAndDragons.Domain.Results;

public class BattleResultDto
{
    public List<RoundResultDto> Rounds { get; set; } = new();
    
    public required Hero Hero { get; set; }
    
    public required Monster Monster { get; set; }
    
    public Player? Winner { get; set; }
    
    public Player? Looser { get; set; }
    
    public int CurrentHeroHp { get; set; }
    
    public int CurrentMonsterHp { get; set; }
}