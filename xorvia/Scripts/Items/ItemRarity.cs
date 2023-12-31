﻿namespace xorvia.Scripts.Items;

public class ItemRarity
{
    public (ConsoleColor Foreground, ConsoleColor Background) Common { get; } = (ConsoleColor.White, ConsoleColor.Black);
    public (ConsoleColor Foreground, ConsoleColor Background) Uncommon { get; } = (ConsoleColor.Green, ConsoleColor.Black);
    public (ConsoleColor Foreground, ConsoleColor Background) Rare { get; } = (ConsoleColor.Blue, ConsoleColor.Black);
    public (ConsoleColor Foreground, ConsoleColor Background) Epic { get; } = (ConsoleColor.Magenta, ConsoleColor.Black);
    public (ConsoleColor Foreground, ConsoleColor Background) Legendary { get; } = (ConsoleColor.Yellow, ConsoleColor.Black);
}