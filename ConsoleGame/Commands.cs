using System;
using System.Collections.Generic;

namespace ConsoleGame
{
    public static class Commands
    {
        enum Directions { Up, Down, Left, Right}
        private const string helpText = 
            "go [direction]: Go in a direction\n" +
            "cut: Cut down the tree on the tile you are on\n" +
            "build [build] [direction]: Build something in a specified direction\n" +
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
                    if(TileTypes.nonWalkable.Contains(world.GetTile(player.PosX, player.PosY - 1)))
                    {
                        Console.WriteLine(noGo);
                        return false;// don't go up
                    }
                    Console.WriteLine("Going up");
                    player.PosY -= 1;
                    break;

                case "down":
                    if (TileTypes.nonWalkable.Contains(world.GetTile(player.PosX, player.PosY + 1)))//wtf
                    {
                        Console.WriteLine(noGo);
                        return false;// don't go down
                    }
                    Console.WriteLine("Going down");
                    player.PosY += 1;
                    break;

                case "left":
                    if (TileTypes.nonWalkable.Contains(world.GetTile(player.PosX - 1, player.PosY)))
                    {
                        Console.WriteLine(noGo);
                        return false;// don't go left
                    }
                    Console.WriteLine("Going left");
                    player.PosX -= 1;
                    break;

                case "right":
                    if (TileTypes.nonWalkable.Contains(world.GetTile(player.PosX + 1, player.PosY)))
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

        public static bool Build(string build, string direction, Player player, World world)
        {
            Directions dir;

            switch (direction)
            {
                case "up": dir = Directions.Up; break;
                case "down": dir = Directions.Down; break;
                case "left": dir = Directions.Left; break;
                case "right": dir = Directions.Right; break;
                default:
                    Console.WriteLine("Invalid direction!");
                    return false;
            }

            switch (build)
            {
                case "bridge":
                    if (IsFree(dir, new List<Tile>{ TileTypes.Water }, world, player))
                    {
                        if(player.inventory.GetTotal(Items.Wood) >= 2)
                        {
                            for(int i = 0; i < 2; i++) player.inventory.RemoveItem(Items.Wood);
                            ReplaceTile(dir, TileTypes.Bridge, world, player);
                            return true;
                        }
                        Console.WriteLine("You don't have all required items!");
                        return false;
                    }

                    Console.WriteLine("Cannot place bridge there!");
                    return false;
                default:
                    Console.WriteLine("Invalid build!");
                    return false;
            }
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
                case "build":
                    Console.WriteLine("build [build] [direction]:\n  [build]:\n   bridge: a bridge that can be used to cross water. Can only be placed on water.\n  [direction]:\n   up, down, left, right: specifies the direction in which the build should be built.");
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


        static bool IsFree(Directions direction, List<Tile> free, World world, Player player) 
        {
            switch (direction)
            {
                case Directions.Up:     return free.Contains(world.GetTile(player.PosX, player.PosY - 1));
                case Directions.Down:   return free.Contains(world.GetTile(player.PosX, player.PosY + 1));
                case Directions.Left:   return free.Contains(world.GetTile(player.PosX - 1, player.PosY));
                case Directions.Right:  return free.Contains(world.GetTile(player.PosX + 1, player.PosY));
            }

            return true; //make compiler happy
        }

        static void ReplaceTile(Directions direction, Tile tile, World world, Player player)
        {
            switch(direction)
            {
                case Directions.Up: world.SetTile(player.PosX, player.PosY - 1, tile); break;
                case Directions.Down: world.SetTile(player.PosX, player.PosY + 1, tile); break;
                case Directions.Left: world.SetTile(player.PosX - 1, player.PosY, tile); break;
                case Directions.Right: world.SetTile(player.PosX + 1, player.PosY, tile); break;
            }
        }
    }
}
