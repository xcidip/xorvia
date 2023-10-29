using xorvia.Scripts.Character.Player.Inventory;

namespace xorvia.Scripts.Misc;

public static class GlobalVariables
{
    public static int Columns { get; set; }

    private static int _invSize;
    public static int InvSize
    {
        get => _invSize;
        set
        {
            if (value > 100)
            {
                _invSize = 99;
            }
            _invSize = value;
            InvWarning = (int)Math.Round(_invSize * 0.90);
        }
    }
    public static int InvWarning { get; set; }


    public static CurrencyBag CurrencyBag;

}