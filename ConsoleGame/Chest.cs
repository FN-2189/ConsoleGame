using System.Collections.Generic;
namespace ConsoleGame
{
    public class Chest
    {
        public readonly string Name;
        public readonly Tile Tile;
        public readonly Inventory content;
        public int PosX, PosY;

        public Chest(string name,  int size, Tile tile)
        {
            Name = name;
            Tile = tile;
            content = new Inventory(size, "|Chest|");
        }

        public Chest(Chest chest)
        {
            Name = chest.Name;
            Tile = chest.Tile;
            content = new Inventory(chest.content.MaxInventorySize, "|Chest|");
        }

        public void SetPosition(int x, int y)
        {
            PosX = x;
            PosY = y;
        }

    }

    public class ChestTypes
    {
        public static readonly Chest SmallChest = new Chest("chest", 10, JsonDeserializer.DeserializeTile("./res/tile/small_chest.json"));
        public static readonly List<Chest> AllChests = new List<Chest> { SmallChest };
    }
}
