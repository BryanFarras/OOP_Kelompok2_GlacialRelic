public class QuestRegion : Region
{
    private Quest quest;

    public QuestRegion()
    {
        quest = new Quest("Gather Herbs", 
                        "Collect 3 Healing Herbs for the Herbalist.",
                        "Fetch", 
                        3, 
                        50);
    }

    public override void Enter(Player player)
    {
        Console.WriteLine("\nYou have entered a region with a quest!");
        Console.WriteLine($"Quest Available: {quest.Name}");
        Console.WriteLine(quest.Description);
        
        // Allow player to accept quest
        Console.WriteLine("\nDo you want to accept this quest? (yes/no)");
        string choice = Console.ReadLine();
        if (choice.ToLower() == "yes")
        {
            player.ActiveQuests.Add(quest);
            Console.WriteLine($"You have accepted the quest: {quest.Name}");
        }

        // Simulate quest progress (e.g., finding items)
        Random rand = new Random();
        int herbsFound = rand.Next(1, 4); // Simulate finding herbs
        Console.WriteLine($"\nYou found {herbsFound} Healing Herbs!");
        quest.UpdateProgress(herbsFound);

        if (quest.IsCompleted)
        {
            player.Gold += quest.RewardGold;
            Console.WriteLine($"You completed the quest and earned {quest.RewardGold} gold!");
        }
    }
}
