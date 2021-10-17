using System;
using System.Collections.Generic;

namespace ConsoleGame
{
    public class World
    {
        public Tile[,] tiles;
        public readonly int SizeX, SizeY;

        public World(int sizeX, int sizeY)
        {
            SizeX = sizeX;
            SizeY = sizeY;
            tiles = new Tile[SizeX, SizeY];

            int cX = SizeX / 2;
            int cY = SizeY / 2;
            /*
            for (int y = 0; y < SizeY; y++)//grid
            {
                for (int x = 0; x < SizeX; x++)//rows
                {
                    //Oval Lake With trees
                    
                    int d = (int)((y - cY) * (y - cY)/1.5f) + ((x - cX) * (x - cX));

                    if (d < 25)
                        SetTile(x, y, TileTypes.Water);
                    else if (d < 30)
                        SetTile(x, y, TileTypes.Tree);
                    else
                        SetTile(x, y, TileTypes.Grass);
                    
                }
            }
            */
        }

        public void SetTile(int x, int y, Tile tile)
        {
            tiles[x, y] = tile;
        }
        public Tile GetTile(int x, int y)
        {
            return tiles[x, y];
        }

        public void Debug()
        {
            for (int y = 0; y < SizeY; y++)//grid
            {
                for (int x = 0; x < SizeX; x++)//rows
                {
                    //Debug Pattern: displays all tiles
                    SetTile(x, y, TileTypes.allTiles[(x + y) % TileTypes.allTiles.Length]);//sick code bro

                }
            }
        }
    }

    
}
