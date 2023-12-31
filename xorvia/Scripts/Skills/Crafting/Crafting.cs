﻿using xorvia.Assets.Sprites;
using xorvia.Scripts.Character.Player.Inventory;
using xorvia.Scripts.Items;
using xorvia.Scripts.Misc;

namespace xorvia.Scripts.Skills.Crafting;

public abstract class CraftingSkill
    {
        public RecipeList RecipeList { get; protected set; }

        public void Craft(Recipe recipe, Inventory inv, Character.Attributes.Skills skillList )
        {
            // Have enough resources in inventory for that recipe?
            foreach (var stack in recipe.List) // check each stack
            {
                // count how many of that item is in the inventory
                var itemNum = inv.List.Count(item => item.Name == stack.Name && item.Name != null);

                // if you don't have the required item in your inventory at all
                if (itemNum == 0)
                {
                    Console.WriteLine($"You don't have: {stack.Name}"); 
                    Choice.PressEnter();
                    return;
                }

                // if there is more in the recipe than in inventory
                if (stack.Quantity <= itemNum) continue;
                Console.WriteLine($"You need {stack.Quantity - itemNum} of {stack.Name}"); return;
            }

            // remove items from inv
            foreach (var stack in recipe.List)
            {
                for (var i= 0; i < stack.Quantity; i++) 
                {
                    inv.RemoveItem(inv.Lookup(stack.Item.Name));
                }
            }

            // 3s global crafting delay
            CraftingDelay();
            
                
            // add result
            inv.AddItemStack(new ItemStack(1, recipe.Result));

            // get xp
            skillList.AddXp(recipe.WhatSkill,recipe.Xp);

            Choice.PressEnter();
        }

        public void CraftingDelay()
        {
            // crafting animation
            var craftSprite = new SkillSprites().CraftingHammer;
            Console.WriteLine("\n" + craftSprite + "\n");
            Console.WriteLine("Crafting: 3s");
            for (var i = 1; i < 45; i++)
            {
                Console.Write(".");
                Thread.Sleep(66);
            }
            Console.Write("\n");
        }
        public void WhatToCraft(Inventory inv, Character.Attributes.Skills skillList)
        {
            Console.WriteLine("What do you want to craft 0 - EXIT");
            var choice = Choice.NumberRangeValidation(0, RecipeList.List.Count);
            if (choice == 0) { Console.Clear(); return;}
            Craft(RecipeList.List[choice - 1], inv,skillList);
        }

        public abstract void Print();
    }