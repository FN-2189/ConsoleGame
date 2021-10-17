using System.Text.Json;
using System.IO;

namespace ConsoleGame
{
    class JsonDeserializer
    {
        public static World DeserializeWorld(string path)
        {
            WorldTiles worldTiles = JsonSerializer.Deserialize<WorldTiles>(File.ReadAllText(path));
            string[] tiles = worldTiles.Tiles;

            World world = new World(tiles[0].Length, tiles.Length);

            int x = 0;
            int y = 0;
            Tile tileToSet;
            foreach(string s in tiles)
            {
                foreach(char c in s)
                {
                    switch (c)
                    {
                        case '#'://grass
                            tileToSet = TileTypes.Grass;
                            break;
                        case 'T'://tree
                            tileToSet = TileTypes.Tree;
                            break;
                        case '~'://water
                            tileToSet = TileTypes.Water;
                            break;
                        default:
                            tileToSet = TileTypes.Grass;//set to grass if tile not mached
                            break;
                    }
                    world.SetTile(x, y, tileToSet);

                    x++;
                }
                x = 0;
                y++;
            }

            return world;
        }
    }

    class WorldTiles
    {
        public string[] Tiles { get; set; }
    }
}
