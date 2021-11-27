using System;

// 571 lines!

namespace ConsoleGame
{
    public class Program
    {

        static void Main(string[] args)
        {
            Console.WriteLine("Type 'help' to see all commands.");
            Globals.debugWorld.Debug();
            Globals.world.AddChest(ChestTypes.SmallChest, 0, 1);

            Globals.player.inventory.AddItem(Items.Chest);
            Globals.player.inventory.AddItem(Items.Chest);

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

            if (splitCommands.Length > 3 || splitCommands[0] == "")
            {
                Console.WriteLine("Command too long or too short, try again! Type 'help' for a list of commands.");
                return false;
            }

            switch (splitCommands[0])
            {
                case "go":
                    if (splitCommands.Length < 2)
                    {
                        Console.WriteLine("Command invalid: 'go' requires an argument! Type 'help go' to see a list of arguments.");
                        return false;
                    }
                    return Commands.Go(splitCommands[1], Globals.player, Globals.world);

                case "cut":
                    return Commands.Cut(Globals.world, Globals.player);

                case "build":
                    if(splitCommands.Length < 3)
                    {
                        Console.WriteLine("Command invalid: 'build' requires 2 arguments! Type 'help build' to see a list of arguments.");
                        return false;
                    }

                    return Commands.Build(splitCommands[1], splitCommands[2], Globals.player, Globals.world);

                case "place":
                    if(splitCommands.Length < 2)
                    {
                        Console.WriteLine("Command invalid: 'place' requires an argument! Type 'help place' to see a list of arguments.");
                        return false;
                    }
                    return Commands.Place(splitCommands[1], Globals.player, Globals.world);

                case "break":
                    return Commands.Break(Globals.player, Globals.world);

                case "inventory":
                    Commands.Inventory(Globals.world, Globals.player);
                    return false;// don't advance

                case "put":
                    if(splitCommands.Length < 3)
                    {
                        Console.WriteLine("Command invalid: 'put' requires 2 arguments! Type 'help put' to see a list of arguments.");
                        return false;
                    }
                    Commands.Put(splitCommands[1], splitCommands[2], Globals.world, Globals.player);
                    return false;

                case "take":
                    if (splitCommands.Length < 3)
                    {
                        Console.WriteLine("Command invalid: 'take' requires 2 arguments! Type 'help take' to see a list of arguments.");
                        return false;
                    }
                    Commands.Take(splitCommands[1], splitCommands[2], Globals.world, Globals.player);
                    return false;

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
