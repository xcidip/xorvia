using xorvia.Scripts.Character.Attributes;

namespace xorvia.Scripts.Character;

public abstract class Character
{
    public CombatStatList CombatStats { get; set; }
    
    public Stats Stats { get; set; }
}