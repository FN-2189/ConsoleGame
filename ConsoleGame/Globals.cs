using System;

namespace ConsoleGame
{
    public class Globals
    {
        public static readonly World world = JsonDeserializer.DeserializeWorld("./res/world/world.json");//22, 20
        public static readonly World debugWorld = new World(16, 16);
        public static readonly Player player = new Player(0, 0, new SubTile(ConsoleColor.Red, ConsoleColor.DarkRed, 'O'));
        public static void PrintError(string message)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(message);
            Console.ForegroundColor = ConsoleColor.Gray;
        }
    }
}
