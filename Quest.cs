public class Quest
{
    public string Name { get; set; }
    public string Description { get; set; }
    public bool IsCompleted { get; set; }
    public string ObjectiveType { get; set; } // e.g., "Fetch", "Rescue", "Defeat"
    public int ObjectiveTarget { get; set; } // Target jumlah (item/musuh/NPC)
    public int Progress { get; set; } // Progres terkini
    public int RewardGold { get; set; }

    public Quest(string name, string description, string type, int target, int rewardGold)
    {
        Name = name;
        Description = description;
        ObjectiveType = type;
        ObjectiveTarget = target;
        Progress = 0;
        RewardGold = rewardGold;
        IsCompleted = false;
    }

    public void UpdateProgress(int amount)
    {
        Progress += amount;
        if (Progress >= ObjectiveTarget)
        {
            IsCompleted = true;
            Console.WriteLine($"Quest Completed: {Name}");
        }
    }
}
