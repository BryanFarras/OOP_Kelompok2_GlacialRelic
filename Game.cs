using System;

public class Game
{
        static void Main(string[] args)
        {
            Player player = new Player("Hero", 100, 30, 50, 0);  // Membuat karakter pemain
            CombatRegion combatRegion = new CombatRegion();


        for (int level = 1; level <= 5; level++)
        {
            Console.WriteLine($"\n=== Level {level} ===");
        
            if (level == 3) // Offer Skill Tree Upgrade after level 3
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
                break; // End game if player dies
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

        Console.Write("Choose one of the Options: ");
        string choice = Console.ReadLine();

        switch (choice)
        {
            case "1":
                Console.WriteLine("Starting Game...");
                break;
            case "2":
                Console.WriteLine("Belum ada opsi tambahan.");
                // TODO: Tambahkan pengaturan jika diperlukan
                break;
            case "3":
                Console.WriteLine("Exit Game.");
                Environment.Exit(0);
                break;
            default:
                Console.WriteLine("Option Invalid.");
                ShowMainMenu();
                break;
        }
    }

    private static void ChoosePlayerRole()
    {
        Console.WriteLine("\n=== Choose Role ===");
        Console.WriteLine("1. Fighter");
        Console.WriteLine("   - More HP, Less MP, Higher Normal Damage.");
        Console.WriteLine("2. Magician");
        Console.WriteLine("   - Less HP, More MP, Higher Magic Damage.");
        Console.WriteLine("=================");
        Console.Write("Choose role (1/2): ");

        string roleChoice = Console.ReadLine();
        Player player = Player.Instance;

        switch (roleChoice)
        {
            case "1":
                Console.WriteLine("You choose Fighter!");
                player.HP = 300;
                player.MP = 50;
                // Damage normal lebih tinggi
                break;
            case "2":
                Console.WriteLine("You choose Magician!");
                player.HP = 150;
                player.MP = 200;
                // Damage magic lebih tinggi
                break;
            default:
                Console.WriteLine("Pilihan tidak valid. Pilih ulang.");
                ChoosePlayerRole();
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
