public class StoneAmarok : Character
{
    public override string Name => "STONE AMAROK";
    public override IAttack StandardAttack => new Bite();

    public StoneAmarok() : base(50)
    {
        DefensiveModifier = new StoneArmor();
    }

}

public class StoneArmor : IAttackModifier
{
    public string Name => "Stone Armor";
    public AttackData Modify(AttackData input, Character _)
    {
        if (input.Damage == 0) return input;
        ColoredConsole.WriteLine($"{Name} reduced the attack by 1 point", ConsoleColor.Yellow);
        return input with { Damage = input.Damage - 1 };
    }
}



public class Bite : IAttack
{
    public string Name => "BITE";
    public AttackData Create() => new AttackData(1);
}