using System;

namespace ConsoleGame
{
    public class Globals
    {
        public static readonly World world = new World(22, 20);//22, 20
        public static readonly World debugWorld = new World(16, 16);
        public static readonly World jsonWorld = JsonDeserializer.DeserializeWorldJson("./res/jsonWorld.json");
        public static readonly Player player = new Player(0, 0, new SubTile(ConsoleColor.Red, ConsoleColor.DarkRed, 'O'));
    }
}
