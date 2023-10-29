using xorvia.Scripts.Character.Attributes;
using xorvia.Scripts.Character.Player;
using xorvia.Scripts.Character.Player.Inventory;

namespace xorvia.Scripts.Items;

public class Equipable : Item
    {
        public Equipable(int requiredLevel, GearSlot gearSlot, string name, int price,
            string description, List<AttBonus> attributeBonusList, (ConsoleColor Foreground, ConsoleColor Background) colors)
            : base(name, description, price, colors)
        {
            RequiredLevel = requiredLevel;
            GearSlot = gearSlot;
            AttributeBonusList = attributeBonusList;
        }

        public override void Use(Player player)
        {

        }

        public override void Examine()
        {
            Console.Write($"Name: {Name}\n" +
                          $"Description: {Description}\n" +
                          $"Required level to equip: {RequiredLevel}\n" +
                          $"It goes in {GearSlot} slot\n" +
                          $"It sells for: {Price}gp\n" +
                          $"Bonuses: ");
            foreach (var attributeBonus in AttributeBonusList)
            {
                Console.Write($"{attributeBonus.Bonus()}, ");
            }

            Console.WriteLine();

        }
    }


    public class Armor : Equipable
    {

        public Armor(int requiredLevel, GearSlot gearSlot, string armorType, string name, int price, string description,
            List<AttBonus> attributeBonusList, (ConsoleColor Foreground, ConsoleColor Background) colors)
            : base(requiredLevel, gearSlot, name, price, description, attributeBonusList, colors)
        {
            ArmorType = armorType;
        }
    }

    public class Weapon : Equipable
    {
        // Melee,Ranged,Magic,Tool

        public Weapon(int requiredLevel, GearSlot gearSlot, string weaponStyle, string name, int price,
            string description, List<AttBonus> attributeBonusList, (ConsoleColor Foreground, ConsoleColor Background) colors)
            : base(requiredLevel, gearSlot, name, price, description, attributeBonusList, colors)
        {
            WeaponStyle = weaponStyle;

        }

        public override void Examine()
        {
            Console.Write($"Name: {Name}\n" +
                          $"Description: {Description}\n" +
                          $"Required level to equip: {RequiredLevel}\n" +
                          $"Weapon Type: {WeaponStyle}\n" +
                          $"It goes in {GearSlot} slot" +
                          $"Weapon Style: {WeaponStyle}\n" +
                          $"It sells for: {Price}gp\n" +
                          $"Bonuses: ");
            foreach (var attributeBonus in AttributeBonusList)
            {
                Console.Write($"{attributeBonus.Bonus()}, ");
            }

            Console.WriteLine();

        }
    }