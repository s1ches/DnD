using DungeounsAndDragons.Domain.Models;
using DungeounsAndDragons.Domain.Results;

namespace DungeonsAndDragons.Battle.Services;

public class BattleRunner : IBattleRunner
{
    private static bool IsAlive(Player player) => player.HealthPoints > 0;

    private readonly Random _attackResultSolver = new ();
    
    public async Task<BattleResultDto> GetBattleResult(Hero hero, Monster monster)
    {
        var result = new BattleResultDto() {Hero = hero, Monster = monster};
        
        while (IsAlive(hero) && IsAlive(monster))
        {
            var round = await GetRoundResult(hero, monster);
            result.Rounds.Add(round);

            hero.HealthPoints = round.CurrentHeroHp;
            monster.HealthPoints = round.CurrentMonsterHp;
            
            result.CurrentHeroHp = round.CurrentHeroHp;
            result.CurrentMonsterHp = round.CurrentMonsterHp;
        }
        
        result.Winner = IsAlive(hero) ? hero : monster;
        result.Looser = IsAlive(hero) ? monster : hero;
        
        return result;
    }

    private async Task<RoundResultDto> GetRoundResult(Hero hero, Monster monster)
    {
        var roundResult = new RoundResultDto
            { CurrentHeroHp = hero.HealthPoints, CurrentMonsterHp = monster.HealthPoints };

        for (var i = 0; i < hero.AttackPerRound && IsAlive(monster); i++)
        {
            var attack = await GetAttackResult(hero, monster);

            roundResult.Attacks.Add(attack);
            roundResult.CurrentMonsterHp = attack.CurrentMonsterHp;
            monster.HealthPoints = attack.CurrentMonsterHp;
        }

        if (roundResult.CurrentMonsterHp > 0)
            for (int i = 0; i < monster.AttackPerRound && IsAlive(hero); i++)
            {
                var attack = await GetAttackResult(monster, hero);
                
                roundResult.Attacks.Add(attack);
                roundResult.CurrentHeroHp = attack.CurrentHeroHp;
                hero.HealthPoints = roundResult.CurrentHeroHp;
            }
        
        return roundResult;
    }

    private Task<AttackResultDto> GetAttackResult(Player attacking, Player raking)
    {
        var attackResult = new AttackResultDto
            { Attacking = attacking, Raking = raking, NotModifiedAttack = _attackResultSolver.Next(1, 21) };
        
        if (attackResult.NotModifiedAttack == 20) attackResult.HitType = HitType.CriticalHit;
        else if (attackResult.NotModifiedAttack == 1) attackResult.HitType = HitType.CriticalMiss;
        else if (attackResult.NotModifiedAttack >= raking.ArmorClass) attackResult.HitType = HitType.Hit;
        else attackResult.HitType = HitType.Miss;
        
        if(attackResult.HitType is HitType.Hit or HitType.CriticalHit)
            for (var i = 0; i < attacking.DamageCubesNumber; i++)
                attackResult.NotModifiedDamage += _attackResultSolver.Next(1, attacking.DamageCubeCost + 1);

        if (attackResult.HitType is HitType.CriticalHit)
            attackResult.NotModifiedDamage *= 2;

        var resultDamage = attackResult.NotModifiedDamage + attacking.DamageModifier*2;
        
        switch (attacking)
        {
            case Hero:
                attackResult.CurrentHeroHp = attacking.HealthPoints;
                attackResult.CurrentMonsterHp =
                    raking.HealthPoints - resultDamage;
                raking.HealthPoints = attackResult.CurrentMonsterHp;
                break;
            case Monster:
                attackResult.CurrentMonsterHp = attacking.HealthPoints;
                attackResult.CurrentHeroHp =
                    raking.HealthPoints - resultDamage;
                raking.HealthPoints = attackResult.CurrentHeroHp;
                break;
        }

        return Task.FromResult(attackResult);
    }
}