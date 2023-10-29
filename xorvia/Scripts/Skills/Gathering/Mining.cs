using xorvia.Assets.Sprites;
using xorvia.Scripts.Character.Player.Inventory;
using xorvia.Scripts.Items;
using xorvia.Scripts.Misc;

namespace xorvia.Scripts.Skills.Gathering;

public static class Mining
{
    public static void Start(Vein vein, int chanceToMineOneIn, Inventory inventory, Character.Attributes.Skills skills)
    {
        while (true)
        {
            Console.Clear();
            var random = new Random();

            if (random.Next(0, chanceToMineOneIn) == 0) // chance to catch a fish
            {
                var minedOre = vein.List[random.Next(vein.List.Count)];
                Console.WriteLine($"Good job, you mined {minedOre.Name}");
                Console.WriteLine($"You gained {minedOre.XpGain}xp + bonus xp if you have a % bonus");
                skills.AddXp("Mining", minedOre.XpGain);
                inventory.AddItemStack(new ItemStack(1, minedOre));
            }
            else
            {
                Console.WriteLine("Failed attempt :(");
            }
            Console.Write("Again?: ");
            if (Choice.YesNoValidation() == 'n') return;

        }
    }
    public static void Print()
    {
        var sprite = new SkillSprites();
        Console.WriteLine(sprite.Pickaxe);
    }
        
}

public class Vein
{
    public int Level { get; set; }
    public List<Ore> List { get; set; }
    public Vein(int level, List<Ore> list) 
    {
        Level = level;
        List = list;
    }
}