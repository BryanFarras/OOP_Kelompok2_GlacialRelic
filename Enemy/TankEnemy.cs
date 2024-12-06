public class TankEnemy : Enemy
{
    public TankEnemy() : base("Tank Enemy", 150, 20, 30)
    {
    }

    public override void AttackPlayer(Player player)
    {
        Console.WriteLine($"{Name} attacks you with a crushing blow.");
        int damage = Math.Max(Attack - player.AttackPower, 1); // Reducing damage by player defense
        player.HP -= damage;
        Console.WriteLine($"You take {damage} damage!");
    }

    public override void ExecuteSpecialAction(Player player)
    {
        Console.WriteLine($"{Name} braces itself, increasing its defense.");
        Defense += 10;
        Console.WriteLine($"{Name}'s defense increases by 10.");
    }
}
