using System;

namespace ConsoleGame
{
    public static class Commands
    {
        private const string helpText = 
            "go [argument]: Go in a direction\n" +
            "cut: Cuts down the tree on the tile you are on\n" +
            "inventory: Displays your inventory\n" +
            "clear: clears the screen and redraws the map\n" +
            "debug: draws the debug map\n" +
            "help: displays a list of all commands\n" +
            "help [command]: displays more info (and valid arguments) about the command";

        private const string noGo = "Invalid Command! Cannot go there.";

        public static bool Go(string arg, Player player, World world)
        {
            switch (arg)
            {
                case "up":
                    if(player.PosY - 1 < 0 || TileTypes.nonWalkable.Contains(world.GetTile(player.PosX, player.PosY - 1)))
                    {
                        Console.WriteLine(noGo);
                        return false;// don't go up
                    }
                    Console.WriteLine("Going up");
                    player.PosY -= 1;
                    break;

                case "down":
                    if (player.PosY + 1 > world.SizeY - 1 || TileTypes.nonWalkable.Contains(world.GetTile(player.PosX, player.PosY + 1)))//wtf
                    {
                        Console.WriteLine(noGo);
                        return false;// don't go down
                    }
                    Console.WriteLine("Going down");
                    player.PosY += 1;
                    break;

                case "left":
                    if (player.PosX - 1 < 0 || TileTypes.nonWalkable.Contains(world.GetTile(player.PosX - 1, player.PosY)))
                    {
                        Console.WriteLine(noGo);
                        return false;// don't go left
                    }
                    Console.WriteLine("Going left");
                    player.PosX -= 1;
                    break;

                case "right":
                    if (player.PosX + 1 > world.SizeX - 1 || TileTypes.nonWalkable.Contains(world.GetTile(player.PosX + 1, player.PosY)))
                    {
                        Console.WriteLine(noGo);
                        return false;// don't go right
                    }
                    Console.WriteLine("Going right");
                    player.PosX += 1;
                    break;

                default:
                    Console.WriteLine("Invalid argument! Type 'help go' for a list of arguments.");
                    return false;
            }
            return true;
        }

        public static bool Cut(World world, Player player)
        {
            Tile current = world.GetTile(player.PosX, player.PosY);

            if(current == TileTypes.Tree)
            {
                if (player.inventory.AddItem(Items.Wood))
                {
                    world.SetTile(player.PosX, player.PosY, TileTypes.Grass);
                    Console.WriteLine("Cutting tree.");
                    Console.WriteLine($"You now have {player.inventory.GetTotal(Items.Wood)} Wood");
                    return true;//cut tree and add item
                }
                else return false;
            }
            else
            {
                Console.WriteLine("Not on a tile with a tree!");
                return false;
            }
        }

        public static void Inventory(Player player)
        {
            player.inventory.PrintInventory();
        }

        public static void Help()
        {
            Console.WriteLine(helpText);
        }

        public static void Help(string arg)
        {
            switch (arg)
            {
                case "go":
                    Console.WriteLine("go: up:    go up\n    down:  go down\n    left:  go left\n    right: go right");//formatted
                    break;
                case "cut":
                    Console.WriteLine("cut: Cuts down the tree on the tile you are on. Does not work if your inventory is full.");
                    break;
                case "inventory":
                    Console.WriteLine("inventory: Displays your current inventory and shows all your items.\nDoes not use up a turn.");
                    break;
                case "clear":
                    Console.WriteLine("clear: Clears the screen and redraws the map.\nDoes not use up a turn.");
                    break;
                case "debug":
                    Console.WriteLine("debug: Draws the debug map to the screen.\nDoes not use up a turn.");
                    break;
                case "help":
                    Console.WriteLine("help: Shows a list of all valid commands.\nDoes not use up a turn.");
                    break;
                default:
                    Console.WriteLine("Invalid argument!");
                    break;
            }
        }

        public static void Clear()
        {
            Console.Clear();
            Renderer.Draw(Globals.player, Globals.world);
        }

        public static void Debug()
        {
            Renderer.Draw(Globals.player, Globals.debugWorld);
        }
    }
}
