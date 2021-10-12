using System;
using System.Collections.Generic;

namespace ConsoleGame
{
    public class Inventory
    {
        public const int MaxInventorySize = 10;

        private readonly List<ItemStack> inventory = new List<ItemStack>();

        public bool AddItem(Item item)
        {
            foreach (ItemStack i in inventory)
            {
                if (i.Item == item && i.Count < ItemStack.MaxStackSize)
                {
                    i.Count += 1;
                    return true; //space free
                }
            }

            if (inventory.Count < MaxInventorySize)
            {
                ItemStack i = new ItemStack(item);// add new ItemStack
                i.Count += 1;
                inventory.Add(i);
                Console.WriteLine("Added new Stack"); //debug
                return true; //space free
            }

            Console.WriteLine("Inventory full!");
            return false; //inventory full
        }

        public void PrintInventory()
        {
            Console.WriteLine("|Inventory|");
            Console.WriteLine();

            foreach (ItemStack i in inventory)
            {
                Console.WriteLine("-> " + i.Item.Name + ": " + i.Count.ToString());
            }
        }
    }

    public class ItemStack
    {
        public Item Item;//what is it
        public int Count;//how many
        public const int MaxStackSize = 8;

        public ItemStack(Item item)// count will allways start at 0
        {
            Item = item;
        }
    }

    public class Item
    {
        public readonly string Name; //will add more later
        public Item(string name)
        {
            Name = name;
        }
    }

    public class Items
    {
        public static readonly Item Wood = new Item("Wood");
    }
}
