using System;

// 495 lines!

namespace ConsoleGame
{
    public class Program
    {

        static void Main(string[] args)
        {
            Console.WriteLine("Type 'help' to see all commands.");
            Globals.debugWorld.Debug();

            for(int i = 0; i < 25; i++) // debug
            {
                Globals.player.inventory.AddItem(Items.Wood);
                Globals.player.inventory.AddItem(Items.Stone);
            }
            while (true)
            {
                Renderer.Draw(Globals.player, Globals.world);

                string command;

                do
                {
                    command = Console.ReadLine();

                } while (!Evaluate(command));
            }
            
        }

        static bool Evaluate(string command)
        {
            command = command.ToLower();
            string[] splitCommands = command.Split(' ');
            /*
            //Test
            foreach (string s in splitCommands)
                Console.WriteLine(s);
            */

            if (splitCommands.Length > 2 || splitCommands[0] == "")
            {
                Console.WriteLine("Command too long or too short, try again! Type 'help' for a list of commands.");
                return false;
            }

            switch (splitCommands[0])
            {
                case "go":
                    if (splitCommands.Length == 1)
                    {
                        Console.WriteLine("Command invalid: 'go' requires an argument! Type 'help go' to see a list of arguments.");
                        return false;
                    }
                    return Commands.Go(splitCommands[1], Globals.player, Globals.world);

                case "inventory":
                    Commands.Inventory(Globals.player);
                    return false;// don't advance

                case "clear":
                    Commands.Clear();
                    return false;// don't advance the game if clear is triggered

                case "help":
                    if (splitCommands.Length == 1) Commands.Help();
                    else Commands.Help(splitCommands[1]);
                    return false;// don't advance the game if help is triggered

                case "debug":
                    Commands.Debug();
                    return false;

                default:
                    Console.WriteLine("Command invalid, try again! Type 'help' for a list of commands.");
                    return false;
            }
        }
    }
}
