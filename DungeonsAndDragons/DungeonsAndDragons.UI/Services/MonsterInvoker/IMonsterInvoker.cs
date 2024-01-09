using DungeounsAndDragons.Domain.Models;

namespace DungeonsAndDragons.UI.Services.MonsterInvoker;

public interface IMonsterInvoker
{
    public Task<Monster> InvokeAsync();
}