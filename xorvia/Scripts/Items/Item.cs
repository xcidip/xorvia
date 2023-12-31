﻿using xorvia.Scripts.Character.Attributes;
using xorvia.Scripts.Character.Player;
using xorvia.Scripts.Character.Player.Inventory;
using xorvia.Scripts.Misc;
using xorvia.Scripts.UI;

namespace xorvia.Scripts.Items;

public abstract class Item
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int RequiredLevel { get; set; }
        public int Price { get; set; }
        public GearSlot GearSlot { get; set; } // mount, pickaxe, head slot...
        public List<AttBonus> AttributeBonusList { get; set; }
        public ConsoleColor ForeColor { get; }
        public ConsoleColor BackColor { get; }
        public int HealValue { get; set; }
        public string WeaponStyle { get; set; }  // Melee, Magic, Ranged
        public string ArmorType { get; set; } // Plate, Cloth, Leather

        // protected = cannot be called outside of this class
        protected Item(string name, string description, int price,
            (ConsoleColor Foreground, ConsoleColor Background) colors)
        {
            Description = description;
            Name = name;
            Price = price;
            ForeColor = colors.Foreground;
            BackColor = colors.Background;
        }

        // Abstract method for using an item (to be implemented by derived classes)
        public abstract void Use(Player player);

        public virtual void Examine()
        {
            Console.Write($"Name: {Name}\n" +
                          $"Description: {Description}\n" +
                          $"It sells for: {Price}gp\n");
            Console.WriteLine();
        }
    }

    // recipe consists of ingredients
    // ingredient is item + quantity of that item
    public class ItemStack
    {
        public Item Item { get; set; }
        public int Quantity { get; set; }
        public string Name { get; set; }


        public ItemStack(int quantity, Item item)
        {
            Name = item.Name;
            Quantity = quantity;
            Item = item;
        }
    }

    public abstract class ItemList
    {
        protected List<Item> List { get; set; } = new List<Item>();
        public ItemRarity Rarity { get; set; }

        protected ItemList()
        {
            Rarity = new ItemRarity();
        }

        public Item Lookup(string name)
        {
            if (name == null) throw new ArgumentNullException(nameof(name));
            return List.FirstOrDefault(a => a?.Name == name);
        }
    }

    public static class ItemInteraction
    {
        public static void ItemInteract(Item item, Player player, int index)
        {
            var gear = player.Gear;
            var inventory = player.Inventory;

            switch (item)
            {
                case Armor itemObj:
                {
                    Console.WriteLine("What do you want to do with this armor piece?");
                    Console.WriteLine("(1) Equip\n" +
                                      "(2) Examine\n" +
                                      "(3) Remove from inventory\n" +
                                      "(4) Leave this menu");
                    var whatToDo = Choice.NumberRangeValidation(1, 4);
                    switch (whatToDo)
                    {
                        case 1:
                            gear.Equip(itemObj, player);
                            break;
                        case 2:
                            InventoryUtils.ItemExamine(itemObj);
                            break;
                        case 3:
                            inventory.List.RemoveAt(index);
                            Console.WriteLine(itemObj.Name + "removed from inventory");
                            break;
                        case 4:
                            break;
                    }

                    break;
                }
                case Potion itemObj:
                {
                    Console.WriteLine("What do you want to do with this Potion?");
                    Console.WriteLine("(1) Use\n" +
                                      "(2) Examine\n" +
                                      "(3) Remove from inventory\n" +
                                      "(4) Leave this menu");
                    var whatToDo = Choice.NumberRangeValidation(1, 4);
                    switch (whatToDo)
                    {
                        case 1:
                            itemObj.Use(player);
                            break;
                        case 2:
                            InventoryUtils.ItemExamine(itemObj);
                            break;
                        case 3:
                            inventory.List.RemoveAt(index);
                            Console.WriteLine(itemObj.Name + "removed from inventory");
                            break;
                        case 4:
                            break;
                    }

                    break;
                }
                case Food itemObj:
                {
                    Console.WriteLine("What do you want to do with this Food?");
                    Console.WriteLine("(1) Use\n" +
                                      "(2) Examine\n" +
                                      "(3) Remove from inventory\n" +
                                      "(4) Leave this menu");
                    var whatToDo = Choice.NumberRangeValidation(1, 4);
                    switch (whatToDo)
                    {
                        case 1:
                            itemObj.Use(player);
                            break;
                        case 2:
                            InventoryUtils.ItemExamine(itemObj);
                            break;
                        case 3:
                            inventory.List.RemoveAt(index);
                            Console.WriteLine(itemObj.Name + "removed from inventory");
                            break;
                        case 4:
                            break;
                    }

                    break;
                }
                case Weapon itemObj:
                {
                    Console.WriteLine("What do you want to do with this weapon?");
                    Console.WriteLine("(1) Equip\n" +
                                      "(2) Examine\n" +
                                      "(3) Remove from inventory\n" +
                                      "(4) Leave this menu");
                    var whatToDo = Choice.NumberRangeValidation(1, 4);
                    switch (whatToDo)
                    {
                        case 1:
                            gear.Equip(itemObj, player);
                            break;
                        case 2:
                            InventoryUtils.ItemExamine(itemObj);
                            break;
                        case 3:
                            inventory.List.RemoveAt(index);
                            Console.WriteLine(itemObj.Name + "removed from inventory");
                            break;
                        case 4:
                            break;
                    }

                    break;
                }
                case Equipable itemObj:
                {
                    Console.WriteLine("What do you want to do with this item?");
                    Console.WriteLine("(1) Equip\n" +
                                      "(2) Examine\n" +
                                      "(3) Remove from inventory\n" +
                                      "(4) Leave this menu");
                    var whatToDo = Choice.NumberRangeValidation(1, 4);
                    switch (whatToDo)
                    {
                        case 1:
                            gear.Equip(itemObj, player);
                            break;
                        case 2:
                            InventoryUtils.ItemExamine(itemObj);
                            break;
                        case 3:
                            inventory.List.RemoveAt(index);
                            Console.WriteLine(itemObj.Name + "removed from inventory");
                            break;
                        case 4:
                            break;
                    }

                    break;
                }
                default:
                {
                    Console.WriteLine("What do you want to do with this item?");
                    Console.WriteLine("(1) Examine\n" +
                                      "(3) Remove from inventory\n" +
                                      "(4) Leave this menu");
                    var whatToDo = Choice.NumberRangeValidation(1, 4);
                    switch (whatToDo)
                    {
                        case 1:
                            InventoryUtils.ItemExamine(item);
                            break;
                        case 2:
                            inventory.List.RemoveAt(index);
                            Console.WriteLine(item.Name + "removed from inventory");
                            break;
                        case 3:
                            break;
                    }

                    break;
                }
            }
        }
    }