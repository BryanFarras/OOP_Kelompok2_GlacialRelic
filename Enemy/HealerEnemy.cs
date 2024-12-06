public class HealerEnemy : Enemy
{
    public HealerEnemy() : base("Healer Enemy", 80, 10, 5)
    {
    }

    public override void AttackPlayer(Player player)
    {
        Console.WriteLine($"{Name} attacks you with a basic strike.");
        int damage = Attack;
        player.HP -= damage;
        Console.WriteLine($"You take {damage} damage!");
        Heal();
    }

    private void Heal()
    {
        int healAmount = 20;
        HP += healAmount;
        Console.WriteLine($"{Name} heals itself for {healAmount} HP.");
    }

    public override void ExecuteSpecialAction(Player player)
    {
        Heal();
        Console.WriteLine($"{Name} performs a special healing action.");
    }
}
