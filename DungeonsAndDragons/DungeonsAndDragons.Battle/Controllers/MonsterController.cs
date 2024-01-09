using System.Text.Json;
using DungeonsAndDragons.Battle.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DungeonsAndDragons.Battle.Controllers;

[Route("[controller]")]
public class MonsterController : ControllerBase
{
    private readonly MonstersDbContext _dbContext;
    
    private readonly Random _random = new();

    public MonsterController(MonstersDbContext dbContext) => _dbContext = dbContext;

    [HttpGet]
    public async Task<ActionResult<string>> GetRandomMonster()
    {
        var countMonsters = await _dbContext.Monsters.CountAsync();
        var monster = await _dbContext.Monsters.Skip(_random.Next(0, countMonsters)).FirstOrDefaultAsync();

        return Ok(JsonSerializer.Serialize(monster));
    }
}