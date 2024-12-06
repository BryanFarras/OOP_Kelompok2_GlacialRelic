using System;
using System.Collections.Generic;

public class SkillTree
{
    private Dictionary<string, int> skills;
    public int SkillPoints { get; set; }

    public SkillTree()
    {
        SkillPoints = 0; // Pemain mulai tanpa skill points
        skills = new Dictionary<string, int>
        {
            { "Health Boost", 0 },    // Tingkatkan HP maksimum
            { "Mana Boost", 0 },      // Tingkatkan MP maksimum
            { "Normal Attack Boost", 0 }, // Tingkatkan serangan normal
            { "Elemental Attack Boost", 0 }, // Tingkatkan serangan elemen
            { "AOE Attack", 0 },       // Skill area untuk Magician
            { "Counter Attack", 0 }    // Skill counter attack untuk Fighter
        };
    }

    public void DisplaySkillTree()
    {
        Console.WriteLine("\n=== Skill Tree ===");
        Console.WriteLine($"Skill Points: {SkillPoints}");
        foreach (var skill in skills)
        {
            Console.WriteLine($"{skill.Key}: Level {skill.Value}");
        }
    }

    public void UnlockOrUpgradeSkill(Player player)
    {
        if (SkillPoints <= 0)
        {
            Console.WriteLine("You don't have enough skill points!");
            return;
        }

        Console.WriteLine("\nChoose a skill to unlock or upgrade:");
        int index = 1;
        foreach (var skill in skills)
        {
            Console.WriteLine($"{index}. {skill.Key} (Current Level: {skill.Value})");
            index++;
        }
        Console.WriteLine("Enter the number of the skill to upgrade:");
        string input = Console.ReadLine();

        if (int.TryParse(input, out int skillChoice) && skillChoice > 0 && skillChoice <= skills.Count)
        {
            string selectedSkill = new List<string>(skills.Keys)[skillChoice - 1];

            // Upgrade or unlock the skill
            skills[selectedSkill]++;
            SkillPoints--;

            Console.WriteLine($"You upgraded {selectedSkill} to Level {skills[selectedSkill]}!");

            // Apply skill effects
            ApplySkillEffect(selectedSkill, player);
        }
        else
        {
            Console.WriteLine("Invalid choice.");
        }
    }

    private void ApplySkillEffect(string skillName, Player player)
    {
        switch (skillName)
        {
            case "Health Boost":
                player.HP += 20; // Tingkatkan HP
                Console.WriteLine("Your maximum HP increased by 20!");
                break;

            case "Mana Boost":
                player.MP += 10; // Tingkatkan MP
                Console.WriteLine("Your maximum MP increased by 10!");
                break;

            case "Normal Attack Boost":
                player.AttackPower += 5; // Tingkatkan serangan normal
                Console.WriteLine("Your Normal Attack damage increased by 5!");
                break;

            case "Elemental Attack Boost":
                player.ElementalPower += 10; // Tingkatkan serangan elemen
                Console.WriteLine("Your Elemental Attack damage increased by 10!");
                break;

            case "AOE Attack":
                if (player.Role == "Magician")
                {
                    Console.WriteLine("You unlocked the AOE Attack skill! You can now attack multiple enemies at once.");
                }
                else
                {
                    Console.WriteLine("AOE Attack is only available for Magician.");
                    skills[skillName]--; // Refund skill point
                    SkillPoints++;
                }
                break;

            case "Counter Attack":
                if (player.Role == "Fighter")
                {
                    Console.WriteLine("You unlocked the Counter Attack skill! You can now counter enemy attacks.");
                }
                else
                {
                    Console.WriteLine("Counter Attack is only available for Fighter.");
                    skills[skillName]--; // Refund skill point
                    SkillPoints++;
                }
                break;

            default:
                Console.WriteLine("Skill effect not implemented.");
                break;
        }
    }
}
