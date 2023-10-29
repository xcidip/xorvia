using xorvia.Assets.Sprites;
using xorvia.Scripts.Character.Enemy;
using xorvia.Scripts.Character.NPC;
using xorvia.Scripts.Character.Player;
using xorvia.Scripts.Character.Player.CharacterCreation;
using xorvia.Scripts.Character.Player.Inventory;
using xorvia.Scripts.Fighting;
using xorvia.Scripts.Items;
using xorvia.Scripts.Skills;
using xorvia.Scripts.Skills.Crafting;
using xorvia.Scripts.Skills.Gathering;

namespace xorvia.Scripts.Misc;

public static class Tutorial
    {
        public static void Start(NpcList npcList, Player player)
        {
            Cutscenes.Intro();

            Console.WriteLine("Do you want a tutorial? (Recommended for first time players)");
            switch (Choice.YesNoValidation())
            {
                case 'y':
                    break;
                default:
                    return;
            }

            var norwyn = npcList.Lookup("Norwyn");

            // basic info WIP
            norwyn.Talk(player);

            Console.Clear();
            Console.WriteLine("First, you are gonna catch a fish and then cook it.\nAfter you caught one you can return.");
            Choice.PressEnter();

            // fishing
            var fishItemList = new FishItemList();
            var pond = new Pond(0, new List<Fish>
            {
                (Fish)fishItemList.Lookup("Shrimp"),
            });
            Fishing.Start(pond,1, player.Inventory, player.Skills);


            // cooking
            Console.Clear();
            Console.WriteLine("Now that you caught a fish, you have to cook it!");
            Choice.PressEnter();

            var cooking = new Cooking();
            while (true)
            {
                cooking.Print();
                player.Inventory.Print();
                cooking.WhatToCraft(player.Inventory, player.Skills);
                if (player.Inventory.Lookup("Cooked Shrimp") != null) break;
            }
            Console.WriteLine("Cool now you a got a cooked shrimp in your inventory, that you can eat to restore health when needed");
            player.Inventory.Print();
            Choice.PressEnter();

            // rat killing
            Console.WriteLine($"Now you are going to learn how to attack enemies.");
            var professionList = new ProfessionList();
            var enemyRaceList = new EnemyRaceList();
            
            var foodItemList = new FoodItemList();
            var enemyList = new EnemyList(professionList,enemyRaceList,foodItemList);
            Fight.Start(player,enemyList.Lookup("Rat"));

            // mining + smithing
            Console.WriteLine("Now that you have beaten a rat, you are going to get yourself a better weapon for your profession");
            var oreList = new OreItemList();
            var vein = new Vein(0, new List<Ore>
            {
                (Ore)oreList.Lookup("Copper ore")
            });
            while (player.Inventory.Lookup("Copper ore")  == null) Mining.Start(vein, 1, player.Inventory, player.Skills);

            // smithing
            Console.Clear();
            Console.WriteLine("Now that you mined some copper you can smelt it to get a Copper bar");
            Choice.PressEnter();

            var smithing = new Smithing();
            while (true)
            {
                smithing.Print();
                player.Inventory.Print();
                smithing.WhatToCraft(player.Inventory, player.Skills);
                if (player.Inventory.Lookup("Copper bar") != null) break;
            }
            Console.WriteLine("Cool now you a got a Copper bar in your inventory, that you can craft a weapon or armor from");
            player.Inventory.Print();
            Choice.PressEnter();

            Console.WriteLine("Now make a weapon for your class (warrior - melee, mage - magic, hunter - ranged");
            Choice.PressEnter();
            while (true)
            {
                smithing.Print();
                player.Inventory.Print();
                smithing.WhatToCraft(player.Inventory, player.Skills);
                
                if (player.CharacterInfo[1].WeaponStyle == "Melee" && player.Inventory.Lookup("Copper dagger") != null) break;
                if (player.CharacterInfo[1].WeaponStyle == "Magic" && player.Inventory.Lookup("Copper staff") != null) break;
                if (player.CharacterInfo[1].WeaponStyle == "Ranged" && player.Inventory.Lookup("Copper bow") != null) break;
            }

            // killing a rat
            Console.Clear();
            Console.WriteLine("Now that you have yourself a weapon, you can try killing a skeleton mage with it.\nBut first you have to equip the weapon");
            Choice.PressEnter();

            Console.WriteLine("Type the number of the weapon in the inventory, and then select equip, then exit when you are ready");
            player.Action();

            Fight.Start(player, enemyList.Lookup("Skeleton mage"));

            Console.Clear();
            Console.WriteLine("Now you are ready for the actual game.");
            Console.WriteLine("You will now be sent to the mainland with a boat");
            Choice.PressEnter();

            Traveling.Travel(10);
        }
    }