using DungeounsAndDragons.Domain.Models;
using DungeounsAndDragons.Domain.Results;

namespace DungeonsAndDragons.UI.Services.BattleInvoker;

public interface IBattleInvoker
{
    public Task<BattleResultDto> InvokeAsync(Hero hero, Monster monster);
}