using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleGame
{
    public static class TileTypes
    {
        private static readonly SubTile stoneBrickSubTile = new SubTile(ConsoleColor.DarkGray, ConsoleColor.Black, '+');//Stone Brick
        private static readonly SubTile[,] stoneBrickSubTiles = new SubTile[Tile.Height, Tile.Width]
        {
            { stoneBrickSubTile, stoneBrickSubTile, stoneBrickSubTile, stoneBrickSubTile },
            { stoneBrickSubTile, stoneBrickSubTile, stoneBrickSubTile, stoneBrickSubTile }
        };
        public static readonly Tile StoneBrick = new Tile(stoneBrickSubTiles);

        private static readonly SubTile waterSubTile = new SubTile(ConsoleColor.DarkCyan, ConsoleColor.DarkBlue, '~');//Water
        private static readonly SubTile[,] waterSubTiles = new SubTile[Tile.Height, Tile.Width]
        {
            { waterSubTile, waterSubTile, waterSubTile, waterSubTile },
            { waterSubTile, waterSubTile, waterSubTile, waterSubTile }
        };
        public static readonly Tile Water = new Tile(waterSubTiles);

        private static readonly SubTile grassSubTile = new SubTile(ConsoleColor.Green, ConsoleColor.DarkGreen, '#');//Grass
        private static readonly SubTile[,] grassSubTiles = new SubTile[Tile.Height, Tile.Width]
        {
            { grassSubTile, grassSubTile, grassSubTile, grassSubTile },
            { grassSubTile, grassSubTile, grassSubTile, grassSubTile }
        };
        public static readonly Tile Grass = new Tile(grassSubTiles);

        public static readonly SubTile stemSubTile = new SubTile(ConsoleColor.DarkRed, ConsoleColor.DarkRed, ' ');
        public static readonly SubTile leafSubTile = new SubTile(ConsoleColor.DarkGreen, ConsoleColor.Green, 'M');
        private static readonly SubTile[,] treeSubTiles = new SubTile[Tile.Height, Tile.Width]
        {
            { grassSubTile, leafSubTile, leafSubTile, leafSubTile },
            { grassSubTile, grassSubTile, stemSubTile, grassSubTile }
        };
        public static readonly Tile Tree = new Tile(treeSubTiles);

        private static readonly SubTile[,] testSubTiles = new SubTile[Tile.Height, Tile.Width]
        {
            { new SubTile(ConsoleColor.White, ConsoleColor.Black, 'a'), new SubTile(ConsoleColor.DarkGray, ConsoleColor.Gray, 'b'), new SubTile(ConsoleColor.DarkBlue, ConsoleColor.Blue, 'c'), new SubTile(ConsoleColor.DarkRed, ConsoleColor.Red, 'd') },
            { new SubTile(ConsoleColor.DarkYellow, ConsoleColor.Yellow, 'e'), new SubTile(ConsoleColor.DarkGreen, ConsoleColor.Green, 'f'), new SubTile(ConsoleColor.DarkCyan, ConsoleColor.Cyan, 'g'), new SubTile(ConsoleColor.DarkMagenta, ConsoleColor.Magenta, 'h') }

        };// Test Tile
        public static readonly Tile Test = new Tile(testSubTiles);


        public static readonly Tile[] allTiles = new Tile[] { Grass, Water, Tree, StoneBrick, Test };
        public static readonly List<Tile> nonWalkable = new List<Tile> { Water };
    }

    public class Tile
    {
        public const int Width = 4, Height = 2;

        public readonly SubTile[,] SubTiles;

        public Tile(SubTile[,] subTiles)
        {
            SubTiles = subTiles;
        }
    }

    public class SubTile
    {
        public readonly ConsoleColor BackgroundColor;
        public readonly ConsoleColor ForegroundColor;
        public readonly char Character;

        public SubTile(ConsoleColor backgroundColor, ConsoleColor foregroundColor, char character)
        {
            BackgroundColor = backgroundColor;
            ForegroundColor = foregroundColor;
            Character = character;
        }
    }
}
