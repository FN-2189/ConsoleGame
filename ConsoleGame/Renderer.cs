using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleGame
{
    public static class Renderer
    {
        public static void Draw(Player player, World world)
        {

            int sizeX = world.SizeX;
            int sizeY = world.SizeY;
            Console.ForegroundColor = ConsoleColor.White;

            DrawHorizontalLine(sizeX);

            for (int y = 0; y < sizeY * Tile.Height; y++)//lines
            {
                Console.Write("|");

                for (int x = 0; x < sizeX * Tile.Width; x++)//vertical lines
                {
                    SubTile current;
                    if (x == player.PosX * Tile.Width + (int)(Tile.Width / 2) - 1 && y == player.PosY * Tile.Height + Tile.Height - 1)
                        current = player.SubTile;
                    else
                        current = world.GetTile(x / Tile.Width, y / Tile.Height).SubTiles[y % Tile.Height, x % Tile.Width];//getting tile to draw

                    Console.BackgroundColor = current.BackgroundColor;
                    Console.ForegroundColor = current.ForegroundColor;
                    Console.Write(current.Character);
                }

                Console.BackgroundColor = ConsoleColor.Black;
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write("|\n");
            }

            DrawHorizontalLine(sizeX);
        }

        private static void DrawHorizontalLine(int width)
        {
            Console.Write("+");
            for (int i = 0; i < width * Tile.Width; i++) Console.Write("-");
            Console.WriteLine("+");
        }
    }
}
