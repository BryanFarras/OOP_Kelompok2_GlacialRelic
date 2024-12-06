using System;

public class Quest
{
    public string Name { get; private set; }
    public string Description { get; private set; }
    public bool IsCompleted { get; private set; }
    public string ObjectiveType { get; private set; } // e.g., "Fetch", "Rescue", "Defeat"
    public int RequiredAmount { get; private set; } // Target amount (items/enemies/NPCs)
    public int CurrentProgress { get; private set; } // Current progress
    public int RewardGold { get; private set; }

    public Quest(string name, string description, string objectiveType, int requiredAmount, int rewardGold)
    {
        Name = name;
        Description = description;
        ObjectiveType = objectiveType;
        RequiredAmount = requiredAmount;
        CurrentProgress = 0;
        RewardGold = rewardGold;
        IsCompleted = false;
    }

    public void UpdateProgress(int amount)
    {
        if (IsCompleted)
        {
            Console.WriteLine($"Quest '{Name}' is already completed.");
            return;
        }

        CurrentProgress += amount;
        Console.WriteLine($"Progress updated for quest: {Name}. Current progress: {CurrentProgress}/{RequiredAmount}");

        if (CurrentProgress >= RequiredAmount)
        {
            CompleteQuest();
        }
    }

    private void CompleteQuest()
    {
        IsCompleted = true;
        CurrentProgress = RequiredAmount; // Ensure progress doesn't exceed the target
        Console.WriteLine($"Quest Completed: {Name}! Collect your reward of {RewardGold} gold.");
    }

    public override string ToString()
    {
        return $"{Name} - {Description} (Progress: {CurrentProgress}/{RequiredAmount}, Reward: {RewardGold} gold)";
    }
}
