using System.Text.Json;
using DungeounsAndDragons.ApiConfiguration;
using DungeounsAndDragons.Domain.Models;

namespace DungeonsAndDragons.UI.Services.MonsterInvoker;

public class MonsterInvoker : IMonsterInvoker
{
    private readonly HttpClient _client = new();

    public async Task<Monster> InvokeAsync()
    {
        var message = new HttpRequestMessage();
        message.Method = HttpMethod.Get;
        message.RequestUri = new Uri($"{BattleConfiguration.FullPath}{BattleConfiguration.MonsterController}");

        var response = await _client.SendAsync(message);
        var monsterJson = await response.Content.ReadAsStringAsync();

        return JsonSerializer.Deserialize<Monster>(monsterJson)!;

    }
}