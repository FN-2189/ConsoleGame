
namespace ConsoleGame
{
    public class Chest
    {
        public readonly Tile Tile;
        public readonly Inventory content;

        public Chest(int size, Tile tile)
        {
            Tile = tile;
            content = new Inventory(size, "|Chest|");
        }

    }

    public class ChestTypes
    {
        public static readonly Chest SmallChest = new Chest(8, JsonDeserializer.DeserializeTile("./res/tile/small_chest.json"));
    }
}
