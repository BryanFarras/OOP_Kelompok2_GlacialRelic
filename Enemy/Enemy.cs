public abstract class Enemy
{
    public string Name { get; set; }
    public int HP { get; set; }
    public int Attack { get; set; }
    public int Defense { get; set; }
    public List<string> Debuffs { get; set; }

    public Enemy(string name, int hp, int attack, int defense)
    {
        Name = name;
        HP = hp;
        Attack = attack;
        Defense = defense;
        Debuffs = new List<string>();
    }

    public abstract void AttackPlayer(Player player);

    public void ApplyDebuffs(Player player)
    {
        if (Debuffs.Contains("Poisoned"))
        {
            player.HP -= 5;
            Console.WriteLine($"{Name} poisons you! You lose 5 HP.");
        }
        if (Debuffs.Contains("Weakened"))
        {
            Console.WriteLine($"{Name} weakens you! Your attacks will deal half damage.");
        }
    }

    public virtual void ExecuteSpecialAction(Player player)
    {
        // Default special action (can be overridden)
        Console.WriteLine($"{Name} does nothing special this turn.");
    }
}
