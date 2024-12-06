public class NormalEnemy : Enemy
{
    public NormalEnemy() : base("Normal Enemy", 100, 15, 10)
    {
    }

    public override void AttackPlayer(Player player)
    {
        Console.WriteLine($"{Name} strikes you!");
        int damage = Attack;
        player.HP -= damage;
        Console.WriteLine($"You take {damage} damage!");
    }

    public override void ExecuteSpecialAction(Player player)
    {
        Console.WriteLine($"{Name} attacks you with a special attack!");
        int specialDamage = 30;
        player.HP -= specialDamage;
        Console.WriteLine($"You take {specialDamage} special damage!");
    }
}
