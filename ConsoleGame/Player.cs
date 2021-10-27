using System;
using System.Collections.Generic;

namespace ConsoleGame
{
    public class Player
    {
        public int PosX, PosY;
        public SubTile SubTile;

        public Inventory inventory;

        public Player(int x, int y, SubTile subTile)
        {
            PosX = x;
            PosY = y;
            SubTile = subTile;
            inventory = new Inventory(10);
            
        }
    }
}
