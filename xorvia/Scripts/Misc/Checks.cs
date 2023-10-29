using xorvia.Scripts.Character.Player;
using xorvia.Scripts.Items;

namespace xorvia.Scripts.Misc;

public static class Checks
{
    public static bool LevelCheck(int level, int requiredLevel)
    {
        if (requiredLevel <= level) return true;
        Console.WriteLine($"Player level too low. {requiredLevel} level required!");
        Choice.PressEnter();
        return false;
    }
    public static bool WeaponStyleCheck(string yourStyle, string weaponStyle)
    {
        if (weaponStyle == "all") return true;

        if (yourStyle == weaponStyle) return true;
            
        Console.WriteLine($"Wrong weapon - you can only equip {yourStyle} weapons");
        Choice.PressEnter();
        return false;
    }
    public static bool ArmorTypeCheck(string yourArmorType, string armorType)
    {
        if (armorType == "all") return true;

        if (yourArmorType == armorType) return true;

        Console.WriteLine($"Wrong armor - you can only equip {yourArmorType} armor");
        Choice.PressEnter();
        return false;
    }
}