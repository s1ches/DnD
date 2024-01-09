using DungeounsAndDragons.Domain.Models;
using DungeounsAndDragons.Domain.Results;

namespace DungeonsAndDragons.Battle.Services;

public interface IBattleRunner
{
    public Task<BattleResultDto> GetBattleResult(Hero hero, Monster monster);
}