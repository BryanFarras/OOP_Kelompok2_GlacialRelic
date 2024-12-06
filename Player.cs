// using System;
// using System.Collections.Generic;

// // Singleton Pattern for Player
// public class Player
// {
//     private static Player instance; // Static instance for the singleton
//     private static readonly object padlock = new object();

//     public int HP { get; set; }
//     public int MP { get; set; }
//     public int Level { get; set; }
//     public int Gold { get; set; }
//     public List<string> Buffs { get; set; }
//     public List<string> Debuffs { get; set; }
//     public string Role { get; set; } // To track player's role
//     public int AttackPower { get; set; } // Normal attack power
//     public int MagicPower { get; set; }  // Magic attack power

//     public List<Quest> ActiveQuests { get; private set; } // To track active quests
//     // Private constructor to prevent instantiation
//     private Player()
//     {
//         // Initialize Player Stats
//         HP = 200; // Starting HP
//         MP = 100; // Starting MP
//         Level = 1;
//         Gold = 0;
//         Buffs = new List<string>();
//         Debuffs = new List<string>();

//         // Give the player a health potion at the start of the game
//         Buffs.Add("Health Potion");
//     }

//     // Singleton Instance Property
//     public static Player Instance
//     {
//         get
//         {
//             lock (padlock)
//             {
//                 if (instance == null)
//                 {
//                     instance = new Player();
//                 }
//                 return instance;
//             }
//         }
//     }

//     // Display Player Stats
//     public void DisplayStats()
//     {
//         Console.WriteLine("\n=== Player Stats ===");
//         Console.WriteLine($"HP: {HP}");
//         Console.WriteLine($"MP: {MP}");
//         Console.WriteLine($"Level: {Level}");
//         Console.WriteLine($"Gold: {Gold}");
//         Console.WriteLine("Active Buffs:");
//         foreach (var buff in Buffs)
//         {
//             Console.WriteLine($"- {buff}");
//         }
//         Console.WriteLine("Active Debuffs:");
//         foreach (var debuff in Debuffs)
//         {
//             Console.WriteLine($"- {debuff}");
//         }
//         Console.WriteLine("\n=== Active Quests ===");
//         if (ActiveQuests.Count == 0)
//         {
//             Console.WriteLine("No active quests.");
//         }
//         else
//         {
//             foreach (var quest in ActiveQuests)
//             {
//                 Console.WriteLine($"- {quest.Name} (Progress: {quest.CurrentProgress}/{quest.RequiredAmount})");
//             }
//         }
//     }

//     // Apply the debuff effects
//     public void ApplyDebuffEffects()
//     {
//         if (Debuffs.Contains("Poisoned"))
//         {
//             // Poison deals 5 damage each turn
//             HP -= 5;
//             Console.WriteLine("You are poisoned! You lose 5 HP due to poison.");
//         }
//         if (Debuffs.Contains("Weakened"))
//         {
//             // Weakened reduces the player's damage output by half
//             Console.WriteLine("You are weakened! Your attacks deal half the damage.");
//         }
//     }

//     public void UpdateQuestProgress(string questName, int progress)
//     {
//         var quest = ActiveQuests.Find(q => q.Name == questName);
//         if (quest != null)
//         {
//             quest.UpdateProgress(progress);
//             Console.WriteLine($"Updated progress for quest: {quest.Name}");

//             if (quest.IsCompleted)
//             {
//                 Console.WriteLine($"Quest completed: {quest.Name}");
//                 Gold += quest.RewardGold;
//                 Console.WriteLine($"You earned {quest.RewardGold} gold!");
//                 ActiveQuests.Remove(quest); // Remove completed quest from active quests
//             }
//         }
//         else
//         {
//             Console.WriteLine($"No active quest found with name: {questName}");
//         }
//     }

//     public void RemoveDebuff(string debuff)
//     {
//         Debuffs.Remove(debuff);
//         Console.WriteLine($"{debuff} has worn off.");
//     }

//     // Clear all debuffs after combat
//     public void ClearDebuffs()
//     {
//         Debuffs.Clear();
//         Console.WriteLine("All debuffs have been cleared after the battle.");
//     }
// }



using System;
using System.Collections.Generic;

public class Player
{
    private static Player instance;
    private static readonly object padlock = new object();

    public int HP { get; set; }
    public int MP { get; set; }
    public int Level { get; set; }
    public int Gold { get; set; }
    public string Role { get; set; }
    public int AttackPower { get; set; }
    public int MagicPower { get; set; }
    public List<string> Skills { get; private set; }
    public List<string> Buffs { get; private set; }
    public List<string> Debuffs { get; private set; }
    public List<Quest> ActiveQuests { get; private set; }

    private Player()
    {
        HP = 200;
        MP = 100;
        Level = 1;
        Gold = 0;
        Role = "Unassigned";
        AttackPower = 30;
        MagicPower = 30;
        Skills = new List<string>();
        Buffs = new List<string>();
        Debuffs = new List<string>();
        ActiveQuests = new List<Quest>();
    }

    public static Player Instance
    {
        get
        {
            lock (padlock)
            {
                if (instance == null)
                {
                    instance = new Player();
                }
                return instance;
            }
        }
    }

    public void DisplayStats()
    {
        Console.WriteLine("\n=== Player Stats ===");
        Console.WriteLine($"Role: {Role}");
        Console.WriteLine($"HP: {HP}");
        Console.WriteLine($"MP: {MP}");
        Console.WriteLine($"Level: {Level}");
        Console.WriteLine($"Gold: {Gold}");
        Console.WriteLine("Skills: " + (Skills.Count > 0 ? string.Join(", ", Skills) : "None"));
        Console.WriteLine("Buffs: " + (Buffs.Count > 0 ? string.Join(", ", Buffs) : "None"));
        Console.WriteLine("Debuffs: " + (Debuffs.Count > 0 ? string.Join(", ", Debuffs) : "None"));

        Console.WriteLine("\n=== Active Quests ===");
        if (ActiveQuests.Count == 0)
        {
            Console.WriteLine("No active quests.");
        }
        else
        {
            foreach (var quest in ActiveQuests)
            {
                Console.WriteLine($"- {quest.Name} (Progress: {quest.CurrentProgress}/{quest.RequiredAmount})");
            }
        }
    }

    public void UpdateQuestProgress(string questName, int progress)
    {
        var quest = ActiveQuests.Find(q => q.Name == questName);
        if (quest != null)
        {
            quest.UpdateProgress(progress);

            if (quest.IsCompleted)
            {
                Gold += quest.RewardGold;
                ActiveQuests.Remove(quest);
                Console.WriteLine($"Quest completed: {quest.Name}. Earned {quest.RewardGold} gold!");
            }
        }
        else
        {
            Console.WriteLine($"No active quest found with name: {questName}");
        }
    }
}
