using System.Collections.Generic;
namespace ConsoleGame
{
    public class Chest
    {
        public readonly string Name;
        public readonly Tile Tile;
        public readonly Inventory content;

        public Chest(string name,  int size, Tile tile)
        {
            Name = name;
            Tile = tile;
            content = new Inventory(size, "|Chest|");
        }

    }

    public class ChestTypes
    {
        public static readonly Chest SmallChest = new Chest("chest", 10, JsonDeserializer.DeserializeTile("./res/tile/small_chest.json"));
        public static readonly List<Chest> AllChests = new List<Chest> { SmallChest };
    }
}
