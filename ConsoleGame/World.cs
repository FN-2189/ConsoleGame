using System.Collections.Generic;

namespace ConsoleGame
{
    public class World
    {
        public Tile[,] Tiles;
        public List<Chest> Chests;
        public readonly int SizeX, SizeY;

        public World(int sizeX, int sizeY)
        {
            SizeX = sizeX;
            SizeY = sizeY;
            Tiles = new Tile[SizeX, SizeY];
            Chests = new List<Chest>();

        }
        public void SetTile(int x, int y, Tile tile)
        {
            if (x < 0 || x > SizeX - 1 || y < 0 || y > SizeY - 1) return; //out of bounds
            Tiles[x, y] = tile;
        }
        public Tile GetTile(int x, int y)
        {
            if (x < 0 || x > SizeX - 1 || y < 0 || y > SizeY - 1) return null; //out of bounds
            return Tiles[x, y];
        }
        public void AddChest(Chest chest, int x, int y)
        {
            Chest toAdd = new Chest(chest);
            toAdd.SetPosition(x, y);
            Chests.Add(toAdd);
        }
        public void Debug()
        {
            for (int y = 0; y < SizeY; y++)//grid
            {
                for (int x = 0; x < SizeX; x++)//rows
                {
                    //Debug Pattern: displays all tiles
                    SetTile(x, y, TileTypes.allTiles[(x + y) % TileTypes.allTiles.Count]);//sick code bro

                }
            }
        }
    }

    
}
