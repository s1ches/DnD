using System.Text.Json;
using DungeonsAndDragons.Battle.Services;
using DungeounsAndDragons.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace DungeonsAndDragons.Battle.Controllers;

[Route("[controller]")]
public class BattleController : ControllerBase
{
    private readonly IBattleRunner _battleRunner;
    
    public BattleController(IBattleRunner battleRunner) => _battleRunner = battleRunner;
    
    [HttpGet]
    public async Task<ActionResult<string>> GetBattleResult(string heroJson, string monsterJson)
    {
        var monster = JsonSerializer.Deserialize<Monster>(monsterJson);
        var hero = JsonSerializer.Deserialize<Hero>(heroJson);
        
        var battleResult = await _battleRunner.GetBattleResult(hero, monster);

        return Ok(JsonSerializer.Serialize(battleResult));
    }
}