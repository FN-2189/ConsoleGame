﻿using System;
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
        public static readonly Tile StoneBrick = JsonDeserializer.DeserializeTile("./res/tile/stone.json");

        public static readonly Tile Water = JsonDeserializer.DeserializeTile("./res/tile/water.json");

        public static readonly Tile Grass = JsonDeserializer.DeserializeTile("./res/tile/grass.json");

        public static readonly Tile Tree = JsonDeserializer.DeserializeTile("./res/tile/tree.json");

        public static readonly Tile Test = JsonDeserializer.DeserializeTile("./res/tile/test.json");

        public static readonly Tile JsonTile = JsonDeserializer.DeserializeTile("./res/tile/jsonTile.json");

        public static readonly Tile[] allTiles = new Tile[] { Grass, Water, Tree, StoneBrick, Test, JsonTile };
        public static readonly List<Tile> nonWalkable = new List<Tile> { Water };
    }

    public class Tile
    {
        public const int Width = 4, Height = 2;

        public readonly string Name;

        public readonly SubTile[,] SubTiles;

        public Tile(string name, SubTile[,] subTiles)
        {
            Name = name;
            SubTiles = subTiles;
        }
    }

    public class SubTile
    {
        public ConsoleColor BackgroundColor;
        public ConsoleColor ForegroundColor;
        public char Character;

        public SubTile(ConsoleColor backgroundColor, ConsoleColor foregroundColor, char character)
        {
            BackgroundColor = backgroundColor;
            ForegroundColor = foregroundColor;
            Character = character;
        }
    }
}
