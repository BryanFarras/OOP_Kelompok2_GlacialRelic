public class CombatRegion : Region
{
    public override void Enter(Player player)
    {
        Random rand = new Random();
        
        // Create a random enemy
        Enemy enemy = CreateRandomEnemy();
        Console.WriteLine($"\nYou encounter a {enemy.Name}!");
        
        while (enemy.HP > 0 && player.HP > 0)
        {
            player.ApplyDebuffEffects(); // Apply debuff effects at the start of each turn
            Console.WriteLine($"\nEnemy HP: {enemy.HP}");
            player.DisplayStats();
            Console.WriteLine("\nYour Move:");
            Console.WriteLine("1. Normal Attack");
            Console.WriteLine("2. Elemental Attack (Cost: 10 MP)");
            Console.WriteLine("3. Defend (reduce incoming damage)");
            Console.WriteLine("4. Use Potion");
            Console.WriteLine("5. Attempt to Flee");

            string choice = Console.ReadLine();
            int damage;

            // Clear the console after each action
            Console.Clear();

            switch (choice)
            {
                case "1": // Normal Attack
                    damage = NormalAttack(player);
                    enemy.HP -= damage;
                    Console.WriteLine($"You performed a Normal Attack and dealt {damage} damage!");
                    break;

                case "2": // Elemental Attack
                    if (player.MP >= 10)
                    {
                        damage = ElementalAttack(player);
                        player.MP -= 10;  // Deduct MP for Elemental Attack
                        enemy.HP -= damage;
                        Console.WriteLine($"You performed an Elemental Attack and dealt {damage} damage!");
                    }
                    else
                    {
                        Console.WriteLine("Not enough MP to perform an Elemental Attack!");
                    }
                    break;

                case "3": // Defend
                    Console.WriteLine("You brace yourself to reduce incoming damage.");
                    player.Buffs.Add("Defend");
                    break;

                case "4": // Use Potion
                    UsePotion(player);
                    break;

                case "5": // Flee
                    if (rand.Next(0, 2) == 0) // 50% chance to flee
                    {
                        Console.WriteLine("You successfully fled!");
                        return;
                    }
                    else
                    {
                        Console.WriteLine("You failed to flee!");
                    }
                    break;

                default:
                    Console.WriteLine("Invalid choice.");
                    continue;
            }

            // Enemy performs action
            enemy.ExecuteSpecialAction(player);

            // Clear the console after enemy action
            Console.Clear();
        }

        if (player.HP > 0)
        {
            Console.WriteLine("\nYou defeated the enemy!");
            int goldReward = rand.Next(10, 30);
            player.Gold += goldReward;
            Console.WriteLine($"You received {goldReward} gold!");
            // Remove all debuffs after defeating the enemy
            player.ClearDebuffs();
        }
        else
        {
            Console.WriteLine("\nYou were defeated by the enemy!");
        }
    }

    private Enemy CreateRandomEnemy()
    {
        Random rand = new Random();
        int enemyType = rand.Next(1, 4); // Randomly choose an enemy type

        switch (enemyType)
        {
            case 1:
                return new NormalEnemy();
            case 2:
                return new HealerEnemy();
            case 3:
                return new TankEnemy();
            default:
                return new NormalEnemy(); // Default to NormalEnemy
        }
    }

    private int NormalAttack(Player player)
    {
        // Normal attack does fixed damage (e.g., 20), modified by debuff if weakened
        int damage = 20;
        if (player.Debuffs.Contains("Weakened"))
        {
            damage /= 2;
            Console.WriteLine("Your weakened state reduced the damage.");
        }
        return damage;
    }

    private int ElementalAttack(Player player)
    {
        Console.WriteLine("Choose your Elemental Attack:");
        Console.WriteLine("1. Fire Attack");
        Console.WriteLine("2. Ice Attack");
        Console.WriteLine("3. Lightning Attack");

        string attackChoice = Console.ReadLine();
        int damage = 0;
        switch (attackChoice)
        {
            case "1": // Fire
                damage = 25;
                Console.WriteLine("You cast a Fire Attack! The enemy is scorched by flames.");
                break;
            case "2": // Ice
                damage = 20;
                Console.WriteLine("You cast an Ice Attack! The enemy is frozen momentarily.");
                break;
            case "3": // Lightning
                damage = 30;
                Console.WriteLine("You cast a Lightning Attack! The enemy is struck by a bolt of lightning.");
                break;
            default:
                Console.WriteLine("Invalid choice.");
                break;
        }
        return damage;
    }

    private void UsePotion(Player player)
    {
        if (player.Buffs.Contains("Health Potion"))
        {
            player.HP += 50; // Larger healing potion for increased difficulty
            player.Buffs.Remove("Health Potion");
            Console.WriteLine("You used a Health Potion and regained 50 HP!");
        }
        else
        {
            Console.WriteLine("You don't have a Health Potion.");
        }
    }
}
