using System.Text.Json;
using DungeounsAndDragons.ApiConfiguration;
using DungeounsAndDragons.Domain.Models;
using DungeounsAndDragons.Domain.Results;

namespace DungeonsAndDragons.UI.Services.BattleInvoker;

public class BattleInvoker : IBattleInvoker
{
    private readonly HttpClient _client = new();
    
    public async Task<BattleResultDto> InvokeAsync(Hero hero, Monster monster)
    {
        var message = new HttpRequestMessage();
        message.Method = HttpMethod.Get;
        
        var heroJson = JsonSerializer.Serialize(hero);
        var monsterJson = JsonSerializer.Serialize(monster);

        var queryString = $"?heroJson={heroJson}&monsterJson={monsterJson}";

        message.RequestUri =
            new Uri($"{BattleConfiguration.FullPath}{BattleConfiguration.BattleController}{queryString}");

        var response = await _client.SendAsync(message);

        var battleResultJson = await response.Content.ReadAsStringAsync();

        return JsonSerializer.Deserialize<BattleResultDto>(battleResultJson)!;
    }
}