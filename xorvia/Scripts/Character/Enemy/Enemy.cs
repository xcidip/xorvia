using xorvia.Scripts.Character.Attributes;
using xorvia.Scripts.Character.Player.CharacterCreation;
using xorvia.Scripts.Items;

namespace xorvia.Scripts.Character.Enemy;

public class Enemy : Character
    {
        public string Name { get; set; }
        public PlayerSetting Profession { get; set; }
        public PlayerSetting Race { get; set; }
        public string PreferredFightingStyle { get; set; } // Dice/Memory/Slider/Typing
        public List<Drop> DropTable { get; set; }
        public Enemy(string name, PlayerSetting profession, PlayerSetting race, Stats stats, string fightingStyle, List<Drop> dropTable) 
        {
            Name = name;
            Profession = profession;
            Race = race;
            PreferredFightingStyle = fightingStyle;
            Stats = stats;
            CombatStats = new CombatStatList(stats,Profession.MainStat);
            DropTable = dropTable;
        }

        public void DecreaseHp(int amount)
        {
            CombatStats.DecreaseHP(amount);
        }

    }

    public class Drop
    {
        public ItemStack ItemStack { get; set; }
        public int DropChance { get; set; }
        public Drop(int dropChance, ItemStack itemStack)
        {
            ItemStack = itemStack;
            DropChance = dropChance;
        }
    }

    public class EnemyList
    {
        List<Enemy?> List { get; }
        public EnemyList(ProfessionList professionList, EnemyRaceList enemyRaceList, FoodItemList foodItemList)
        {
            List = new List<Enemy?>
            {
                new Enemy("Rat",professionList.Lookup("Warrior"),enemyRaceList.Lookup("Rodent"),new Stats(10,2,1,1,1,2,1,1,1), "Dice", new List<Drop>
                {
                    new Drop(50, new ItemStack(1,foodItemList.Lookup("Cooked Shrimp"))),
                }),
                new Enemy("Skeleton mage",professionList.Lookup("Mage"),enemyRaceList.Lookup("Undead"),new Stats(10,2,1,1,1,2,5,1,1), "Slider", new List<Drop>
                {
                    new Drop(50, new ItemStack(1,foodItemList.Lookup("Cooked Shrimp"))),
                }),
                new Enemy("Small goblin",professionList.Lookup("Hunter"),enemyRaceList.Lookup("Goblin"),new Stats(10,10,1,1,1,2,1,4,1), "Typing", new List<Drop>
                {
                    new Drop(50, new ItemStack(1,foodItemList.Lookup("Cooked Shrimp"))),
                }),
            };

        }
        public Enemy? Lookup(string name)
        {
            return List.Find(a => a?.Name == name);
        }
    }