﻿using xorvia.Scripts.Items;

namespace xorvia.Scripts.Skills.Crafting;

public class CookingRecipeList : RecipeList
    {
        public FishItemList FishItemList;
        public FoodItemList FoodItemList;
        public MaterialItemList MaterialItemList;
        public CookingRecipeList()
        {
            FishItemList = new FishItemList();
            FoodItemList = new FoodItemList();
            MaterialItemList = new MaterialItemList();

            List = new List<Recipe>
            {
                new Recipe("Cooking",
                    FoodItemList.Lookup("Cooked Shrimp"),
                    5,0,
                    new List<ItemStack>
                    {
                        new ItemStack(1, FishItemList.Lookup("Shrimp")),
                    }),
                new Recipe("Cooking",
                    FoodItemList.Lookup("Cooked Trout"),
                    10,10,
                    new List<ItemStack>
                    {
                        new ItemStack(1, FishItemList.Lookup("Trout")),
                    }),
                new Recipe("Cooking",
                    FoodItemList.Lookup("Cooked Salmon"),
                    15,20,
                    new List<ItemStack>
                    {
                        new ItemStack(1, FishItemList.Lookup("Salmon")),
                    }),
                new Recipe("Cooking",
                    FoodItemList.Lookup("Cooked Tuna"),
                    25,30,
                    new List<ItemStack>
                    {
                        new ItemStack(1, FishItemList.Lookup("Tuna")),
                    }),
                new Recipe("Cooking",
                    FoodItemList.Lookup("Cooked Crayfish"),
                    30,40,
                    new List<ItemStack>
                    {
                        new ItemStack(1, FishItemList.Lookup("Crayfish")),
                    }),
            };
        }
    }

    public class AlchemyRecipeList : RecipeList
    {
        public MaterialItemList MaterialItemList;
        public HerbItemList HerbItemList;
        public PotionItemList PotionItemList;
        public AlchemyRecipeList()
        {
            MaterialItemList = new MaterialItemList();
            HerbItemList = new HerbItemList();
            PotionItemList = new PotionItemList();

            List = new List<Recipe>
            {
                new Recipe("Alchemy",
                    PotionItemList.Lookup("Small HP potion"),
                    10,0,
                    new List<ItemStack>
                    {
                        new ItemStack(1,MaterialItemList.Lookup("Flask")),
                        new ItemStack(1,HerbItemList.Lookup("Peacebloom")),
                    }),

                new Recipe("Alchemy",
                    PotionItemList.Lookup("Medium HP potion"),
                    50,10,
                    new List<ItemStack>
                    {
                        new ItemStack(1,MaterialItemList.Lookup("Flask")),
                        new ItemStack(1,HerbItemList.Lookup("Goldthorn")),
                    }),

                new Recipe("Alchemy",
                    PotionItemList.Lookup("Large HP potion"),
                    100,0,
                    new List<ItemStack>
                    {
                        new ItemStack(1,MaterialItemList.Lookup("Flask")),
                        new ItemStack(1,HerbItemList.Lookup("Sungrass")),
                    }),
            };
        }
    }

    public class TailoringRecipeList : RecipeList
    {
        public MaterialItemList MaterialItemList;
        public ArmorItemList ArmorItemList;

        public TailoringRecipeList()
        {
            MaterialItemList = new MaterialItemList();
            ArmorItemList = new ArmorItemList();
            List = new List<Recipe>
            {
                new Recipe("Tailoring",
                    ArmorItemList.Lookup("Wizard's Coat"),
                    10,0,
                    new List<ItemStack>
                    {
                        new ItemStack(1,MaterialItemList.Lookup("Linen cloth")),
                    }),

                new Recipe("Tailoring",
                    ArmorItemList.Lookup("Wizard's Skirt"),
                    10,0,
                    new List<ItemStack>
                    {
                        new ItemStack(1,MaterialItemList.Lookup("Linen cloth")),
                    }),

                new Recipe("Tailoring",
                    ArmorItemList.Lookup("Wizard's Hat"),
                    10, 0,
                    new List<ItemStack>
                    {
                        new ItemStack(1,MaterialItemList.Lookup("Linen cloth")),
                    }),
            };
        }
    }

    public class SmithingRecipeList : RecipeList
    {
        public MaterialItemList MaterialItemList;
        public ArmorItemList ArmorItemList;
        public OreItemList OreItemList;
        public WeaponItemList WeaponItemList;

        public SmithingRecipeList()
        {
            MaterialItemList = new MaterialItemList();
            ArmorItemList = new ArmorItemList();
            OreItemList = new OreItemList();
            WeaponItemList = new WeaponItemList();
            List = new List<Recipe>
            {
                new Recipe("Smithing",
                    MaterialItemList.Lookup("Copper bar"),
                    5,0,
                    new List<ItemStack>
                    {
                        new ItemStack(1,OreItemList.Lookup("Copper ore")),
                    }),
                new Recipe("Smithing",
                    WeaponItemList.Lookup("Copper dagger"),
                    10,0,
                    new List<ItemStack>
                    {
                        new ItemStack(1,MaterialItemList.Lookup("Copper bar")),
                    }),
                new Recipe("Smithing",
                    WeaponItemList.Lookup("Copper staff"),
                    10,0,
                    new List<ItemStack>
                    {
                        new ItemStack(1,MaterialItemList.Lookup("Copper bar")),
                    }),
                new Recipe("Smithing",
                    WeaponItemList.Lookup("Copper bow"),
                    10,0,
                    new List<ItemStack>
                    {
                        new ItemStack(1,MaterialItemList.Lookup("Copper bar")),
                    }),

            };
        }
    }
    
    public class LthrworkingRecipeList : RecipeList
    {
        public MaterialItemList MaterialItemList;
        public ArmorItemList ArmorItemList;

        public LthrworkingRecipeList()
        {
            MaterialItemList = new MaterialItemList();
            ArmorItemList = new ArmorItemList();
            List = new List<Recipe>
            {
                new Recipe("Lthrworking",
                    ArmorItemList.Lookup("Wizard's Coat"),
                    10,0,
                    new List<ItemStack>
                    {
                        new ItemStack(1,MaterialItemList.Lookup("Linen cloth")),
                    }),

                new Recipe("Lthrworking",
                    ArmorItemList.Lookup("Wizard's Skirt"),
                    10,0,
                    new List<ItemStack>
                    {
                        new ItemStack(1,MaterialItemList.Lookup("Linen cloth")),
                    }),

                new Recipe("Lthrworking",
                    ArmorItemList.Lookup("Wizard's Hat"),
                    10, 0,
                    new List<ItemStack>
                    {
                        new ItemStack(1,MaterialItemList.Lookup("Linen cloth")),
                    }),
            };
        }
    }