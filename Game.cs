using System;
using System.Collections.Generic;

public class Game
{
    static void Main(string[] args)
    {
        ShowMainMenu();

        Player player = Player.Instance;

        for (int level = 1; level <= 5; level++)
        {
            Console.WriteLine($"\n=== Level {level} ===");

            if (level == 1)
            {
                ChoosePlayerRole(player);
            }

            if (level == 3)
            {
                Console.WriteLine("\nYou've unlocked access to the Skill Tree!");
                SkillTreeUpgrade(player);
            }

            if (level == 4)
            {
                Shop shop = new Shop();
                shop.OpenShop(player);
                continue;
            }

            if (level == 5)
            {
                Boss finalBoss = new Boss("Final Boss", 300, 30);
                finalBoss.Enter(player);
                break;
            }

            CombatRegion combatRegion = new CombatRegion();
            combatRegion.Enter(player);

            if (player.HP <= 0)
            {
                Console.WriteLine("\nGame Over. Better luck next time!");
                break;
            }
        }
    }

    private static void ShowMainMenu()
    {
        Console.WriteLine("  ________.__                .__       .__    __________       .__  .__        ");
        Console.WriteLine(" /  _____/|  | _____    ____ |__|____  |  |   \\______   \\ ____ |  | |__| ____  ");
        Console.WriteLine("/   \\  ___|  | \\__  \\ _/ ___\\|  \\__  \\ |  |    |       _// __ \\|  | |  |/ ___\\ ");
        Console.WriteLine("\\    \\_\\  \\  |__/ __ \\\\  \\___|  |/ __ \\|  |__  |    |   \\  ___/|  |_|  \\  \\___ ");
        Console.WriteLine(" \\______  /____(____  /\\___  >__(____  /____/  |____|_  /\\___  >____/__|\\___  >");
        Console.WriteLine("        \\/          \\/     \\/        \\/               \\/     \\/            \\/ ");
        Console.WriteLine("======================================= Main Menu =======================================");
        Console.WriteLine("1. Start Game");
        Console.WriteLine("2. Options");
        Console.WriteLine("3. Exit");
        Console.WriteLine("==========================================================================================");

        Console.Write("Choose one of the options: ");
        string choice = Console.ReadLine();

        switch (choice)
        {
            case "1":
                Console.WriteLine("Starting Game...");
                break;
            case "2":
                Console.WriteLine("No additional options available yet.");
                break;
            case "3":
                Console.WriteLine("Exiting Game.");
                Environment.Exit(0);
                break;
            default:
                Console.WriteLine("Invalid Option. Please try again.");
                ShowMainMenu();
                break;
        }
    }

    private static void ChoosePlayerRole(Player player)
    {
        Console.WriteLine("\n=== Choose Your Role ===");
        Console.WriteLine("1. Fighter - More HP, Less MP, Higher Normal Damage.");
        Console.WriteLine("2. Magician - Less HP, More MP, Higher Magic Damage.");
        Console.Write("Choose your role (1/2): ");

        string roleChoice = Console.ReadLine();

        switch (roleChoice)
        {
            case "1":
                player.Role = "Fighter";
                player.HP = 300;
                player.MP = 50;
                player.AttackPower = 50;
                player.MagicPower = 20;
                Console.WriteLine("You chose Fighter!");
                break;
            case "2":
                player.Role = "Magician";
                player.HP = 150;
                player.MP = 200;
                player.AttackPower = 20;
                player.MagicPower = 50;
                Console.WriteLine("You chose Magician!");
                break;
            default:
                Console.WriteLine("Invalid choice. Please choose again.");
                ChoosePlayerRole(player);
                break;
        }
    }

    private static void SkillTreeUpgrade(Player player)
    {
        Console.WriteLine("\n=== Skill Tree ===");
        Console.WriteLine("Choose an upgrade:");
        Console.WriteLine("1. Increase Max HP by 50");
        Console.WriteLine("2. Increase Max MP by 30");
        Console.WriteLine("3. Unlock Special Skill");
        Console.WriteLine("4. Exit Skill Tree");

        string choice = Console.ReadLine();

        switch (choice)
        {
            case "1":
                player.HP += 50;
                Console.WriteLine("Your Max HP has been increased by 50!");
                break;

            case "2":
                player.MP += 30;
                Console.WriteLine("Your Max MP has been increased by 30!");
                break;

            case "3":
                if (!player.Skills.Contains("Special Skill"))
                {
                    player.Skills.Add("Special Skill");
                    Console.WriteLine("You have unlocked a Special Skill!");
                }
                else
                {
                    Console.WriteLine("You already have the Special Skill!");
                }
                break;

            case "4":
                Console.WriteLine("Exiting Skill Tree...");
                break;

            default:
                Console.WriteLine("Invalid choice. Please try again.");
                SkillTreeUpgrade(player);
                break;
        }
    }
}
