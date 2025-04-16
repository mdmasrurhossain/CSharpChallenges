using System;

public class MylaraAndSkorin : Character
{
    public override string Name => "MYLARA AND SKORIN";
    public override IAttack StandardAttack { get; } = new Punch();
    public MylaraAndSkorin() : base(10)
    {
        EquippedGear = new CanonOfConsolas();
        OffensiveModifier = new RockAndStones();
    }
}

public class CanonOfConsolas : IGear
{
    public String Name => "CANON OF CONSOLAS";

    public IAttack Attack { get; } = new Boom();

}
    
public class Boom : IAttack
{
    public string Name => "BOOM";

    public AttackData Create() 
    {
        int damage = DamageForRound(Battle.BattleRound);
        return new AttackData(damage);
    } 

    public int DamageForRound(int battleRound)
    {
        int round = battleRound + 1;
        if (round % 5 == 0 && round % 3 == 0) return 5;
        else if (round % 5 == 0) return 2;
        else if (round % 3 == 0) return 2;
        return 1;
    }

}

public class RockAndStones : IAttackModifier
{
    public string Name => "ROCK AND STONES";

    public AttackData Modify(AttackData input, Character target)
    {
        if(target.DefensiveModifier is not StoneArmor) return input;
        ColoredConsole.WriteLine($"{Name} doing double damage against Stone Armor of {target.Name}", ConsoleColor.Yellow);
        return input with { Damage = input.Damage * 2 };

    }

}
