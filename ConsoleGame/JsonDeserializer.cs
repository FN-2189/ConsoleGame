using System;
using System.Text.Json;
using System.IO;

namespace ConsoleGame
{
    public class JsonDeserializer
    {
        public static World DeserializeWorld(string path)
        {
            WorldJson worldJson = JsonSerializer.Deserialize<WorldJson>(File.ReadAllText(path));
            string[] tiles = worldJson.Tiles;

            World world = new World(tiles[0].Length, tiles.Length);

            int x = 0;
            int y = 0;
            Tile tileToSet;
            foreach(string s in tiles)
            {
                foreach(char c in s)
                {
                    tileToSet = c switch
                    {
                        '#' => TileTypes.Grass,
                        '~' => TileTypes.Water,
                        'T' => TileTypes.Tree,
                        _ => TileTypes.Test
                    };
                    
                    world.SetTile(x, y, tileToSet);

                    x++;
                }
                x = 0;
                y++;
            }

            return world;
        }

        public static Tile DeserializeTile(string path)
        {
            TileJson tileJson = JsonSerializer.Deserialize<TileJson>(File.ReadAllText(path));

            int width = tileJson.ForeColors.Length / tileJson.Characters.Length;
            int height = tileJson.Characters.Length;

            SubTile[,] outSubTiles = new SubTile[height, width];
            for(int i = 0; i < height; i++)
            {
                for(int j = 0; j < width; j++)
                {
                    outSubTiles[i, j] = new SubTile(ConsoleColor.Black, ConsoleColor.White, ' ');
                }
            }

            int x = 0;
            int y = 0;

            foreach(string s in tileJson.Characters)//setup characters
            {
                foreach(char c in s)
                {
                    outSubTiles[y, x].Character = c;
                    x++;
                }
                x = 0;
                y++;
            }
            y = 0;

            foreach (int i in tileJson.ForeColors)//setup foreground color
            {
                outSubTiles[y, x].ForegroundColor = (ConsoleColor)i;
                x++;

                if(x == tileJson.ForeColors.Length / tileJson.Characters.Length)
                {
                    x = 0;
                    y++;
                }
            }
            y = 0;

            foreach (int i in tileJson.BackColors)//setup foreground color
            {
                outSubTiles[y, x].BackgroundColor = (ConsoleColor)i;
                x++;

                if (x == tileJson.BackColors.Length / tileJson.Characters.Length)
                {
                    x = 0;
                    y++;
                }
            }

            return new Tile(tileJson.Name, outSubTiles);
        }
    }

    class WorldJson
    {
        public string[] Tiles { get; set; }
    }

    class TileJson
    {
        public string Name { get; set; }
        public string[] Characters { get; set; }
        public int[] ForeColors { get; set; }
        public int[] BackColors { get; set; }
    }
}
