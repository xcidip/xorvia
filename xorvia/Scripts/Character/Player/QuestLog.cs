﻿using xorvia.Scripts.Character.Attributes;
using xorvia.Scripts.Items;
using xorvia.Scripts.Misc;
using xorvia.Scripts.UI;

namespace xorvia.Scripts.Character.Player;

public class Quest
{
    #region Variables
    public int Quest_ID { get; set; }
    public string Name { get; set; }
    public string Description { get; set; } // what is this quest about
    public int MinLevel { get; set; } // minimal level to start the quest
    public int RecommendedLevel { get; set; } // recommended level to complete the level
    public string State { get; set; } // undelivered, started, unstarted, hidden
    public string FromWho { get; set; } // who to find when wanting to deliver the quest
    public List<Objective> Objectives { get; set; } // list of things to do
    public string Type { get; set; } // fetch/kill/delivery/puzzle/hybrid/typing/...
    public Reward Reward { get; set; } // what you get from quest items/skills xp/stats
    public List<Requirement> Requirements { get; set; } // skills needed to start the quest
    #endregion
    
    public Quest(int quest_ID, string name, string description, string type, string fromWho, int minLevel,
        int recommendedLevel, List<Objective> objectives, Reward reward,List<Requirement> requirements)
    {
        Quest_ID = quest_ID;
        Name = name;
        Description = description;
        Type = type;
        FromWho = fromWho;
        MinLevel = minLevel;
        RecommendedLevel = recommendedLevel;
        State = "unstarted";
        Objectives = objectives; // list
        Reward = reward; // list
        Requirements = requirements;
    }
}
public class QuestLog
{
    #region Variables
    private List<Quest> List { get; }
    private FishItemList FishItemList { get; set; }
    private ArmorItemList ArmorItemList { get; set; }
    #endregion

    #region Quest Log
    public QuestLog()
    {
        FishItemList = new FishItemList();
        ArmorItemList = new ArmorItemList();
        List = new List<Quest>
        {
            new Quest(1,"Wolf Trouble in the Woods", "Kill 10 wolves around here", "kill",
                "Norwyn", 0, 1,
                new List<Objective>
                {
                    new KillObjective("wolf", 10),
                }, 
                new Reward
                {
                    AttBonuses = new List<AttBonus>
                    {
                        new AttBonus("Strength",2,"points")
                    }
                },
                new List<Requirement>()
                ),
            new Quest(2,"The Five Fish Frenzy", "Bring me 5 trouts", "fetch",  "Norwyn", 0, 2,
                new List<Objective>
                {
                    new GatherObjective(new ItemStack(5, FishItemList.Lookup("Trout"))),
                },
                new Reward
                {
                    Items = new List<ItemStack>
                    {
                        new ItemStack(1,ArmorItemList.Lookup("Wizard's Hat")),
                        new ItemStack(1,ArmorItemList.Lookup("Wizard's Skirt")),
                    }
                },
                new List<Requirement>()
                ),
            new Quest(3,"Third Quest", "Deliver these items to their owners", "delivery", "these people", 0,
                0,
                new List<Objective>
                {
                    new DeliveryObjective(new ItemStack(1, FishItemList.Lookup("Trout")), "Dubois"),
                    new DeliveryObjective(new ItemStack(1, FishItemList.Lookup("Trout")), "NorwynBrother"),
                },
                new Reward
                {
                    Items = new List<ItemStack>
                    {
                        new ItemStack(5, FishItemList.Lookup("Trout")),
                    }
                    
                },
                new List<Requirement>
                {
                    new Requirement("Fishing",5),
                }
                ),
            // quest ideas: 
            // receive a sword and kill a boss with it, remove sword after completing
        };
    }
    #endregion

    #region Methods

    #region Quest State
    public void StartQuestByName(string name,Player player)
    {
        StartQuest(LookupByName(name), player);
    }
    public void StartQuestByID(int quest_ID, Player player)
    {
        StartQuest(LookupByID(quest_ID), player);
    }
    public void StartQuest(Quest quest, Player player)
    {
        switch (quest.State)
        {
            case "started":
                Console.WriteLine("Quest already started!");
                Choice.PressEnter();
                return;
            case "finished":
                Console.WriteLine("Quest already finished!");
                Choice.PressEnter();
                return;
            default:
                if (!QuestRequirementCheck(quest.Name, player))
                {
                    Console.WriteLine("Not eligible for quest");
                    Choice.PressEnter();
                    return;
                }
                quest.State = "started";
                Console.WriteLine($"Quest started: \"{quest.Name}\" !");
                Choice.PressEnter();
                return;
        }
    }

    public void FinishQuest(string name) // completes the quest, but marks it as undelivered and waiting to deliver
    {
        LookupByName(name).State = "undelivered";
    }
    public bool IsQuestFinished(string name)
    {
        return LookupByName(name).State == "undelivered";
    }
    public void HideQuest(string name)
    {
        LookupByName(name).State = "hidden";
    }
    #endregion

    #region Quest Completion
    public void CheckQuestCompletion(string name, Player player) // check for completed objectives
    {
        // todo
    }
    public void GiveQuestReward(string name, Player player)
    {
        var quest = LookupByName(name);

        // xp/points to skill/stat
        if (quest.Reward.AttBonuses != null)
        {
            foreach (var AttBonus in quest.Reward.AttBonuses)
            {
                player.ChangeAttributeValue(AttBonus, true);
            }
        }

        // item 
        if (quest.Reward.Items != null)
        {
            foreach (var ItemStack in quest.Reward.Items)
            {
                player.Inventory.AddItemStack(ItemStack);
            }
        }
        // hide quest from quest log
        HideQuest(name);
    }

    #endregion

    public void NpcStartQuest(string questName, Player player)
    {
        if (player.QuestLog.IsQuestFinished(questName) && QuestRequirementCheck(questName,player))
        {
            // todo remove quest items from inventory
            player.QuestLog.GiveQuestReward(questName, player);
            return;
        }
        player.QuestLog.StartQuest(LookupByName(questName),player);
    }


    public bool QuestRequirementCheck(string questName, Player player)
    {
        var everythingOkay = true;
        foreach (var requirement in LookupByName(questName).Requirements)
        {
            var yourSkill = player.Skills.Lookup(requirement.Name);
            if (yourSkill.Level < requirement.RequiredValue)
            {
                Console.WriteLine($"{yourSkill.Value} {requirement.Name} is too low you need at least: {requirement.RequiredValue}");
                everythingOkay = false;
            }
            if (!everythingOkay) Choice.PressEnter();
        }
        return everythingOkay;
    }

    public Quest LookupByName(string name)
    {
        if (name == null) throw new ArgumentNullException(nameof(name));
        return List.Find(a => a?.Name == name);
    }
    public Quest LookupByID(int quest_ID)
    {
        if (quest_ID < 0) throw new ArgumentNullException(nameof(quest_ID));
        return List.Find(a => a?.Quest_ID == quest_ID);
    }
    public void Print()
    {
        Utility.PrintQuestLog(List);
    }
    #endregion
}