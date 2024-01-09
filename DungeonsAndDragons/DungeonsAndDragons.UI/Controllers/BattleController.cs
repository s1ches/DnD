using DungeonsAndDragons.UI.Models;
using DungeonsAndDragons.UI.Services.BattleInvoker;
using DungeonsAndDragons.UI.Services.MonsterInvoker;
using DungeounsAndDragons.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace DungeonsAndDragons.UI.Controllers;

public class BattleController : Controller
{
    private readonly IMonsterInvoker _monsterInvoker;

    private readonly IBattleInvoker _battleInvoker;

    public BattleController(IMonsterInvoker monsterInvoker, IBattleInvoker battleInvoker) =>
        (_monsterInvoker, _battleInvoker) = (monsterInvoker, battleInvoker);
    
    [HttpGet]
    public IActionResult Battle()
    {
        return View(new BattleVm());
    }

    [HttpPost]
    public async Task<IActionResult> Battle(Hero hero)
    {
        var monster = await _monsterInvoker.InvokeAsync();
        var battleResult = await _battleInvoker.InvokeAsync(hero, monster);

        var battleVm = new BattleVm() { Hero = hero, Battle = battleResult, Monster = monster };

        return View(battleVm);
    }
}