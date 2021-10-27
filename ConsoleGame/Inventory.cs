using System;
using System.Collections.Generic;

namespace ConsoleGame
{
    public class Inventory
    {
        public int MaxInventorySize;

        public string Name;

        private readonly List<ItemStack> inventory = new List<ItemStack>();

        public Inventory(int size, string inventoryTitle)
        {
            Name = inventoryTitle;
            MaxInventorySize = size;
        }

        public bool AddItem(Item item)
        {
            ItemStack lastStack = inventory.FindLast(stack => stack.Item == item && stack.Count < ItemStack.MaxStackSize);

            if(lastStack != null)
            {
                lastStack.Count++;
                return true; //space free

            }

            if (inventory.Count < MaxInventorySize)
            {
                ItemStack stack = new ItemStack(item);// add new ItemStack
                stack.Count++;
                inventory.Add(stack);
                Console.WriteLine("Added new Stack"); //debug
                return true; //space free
            }

            Console.WriteLine("Inventory full!");
            return false; //inventory full
        }

        public bool RemoveItem(Item item)
        {
            ItemStack lastStack = inventory.FindLast(stack => stack.Item == item);

            if(lastStack == null)
            {
                Console.WriteLine("Item not present");
                return false;// no Item found
            }

            lastStack.Count--;

            if(lastStack.Count == 0)// if the stack is empty remove it
            {
                inventory.Remove(lastStack);
                Console.WriteLine("removed empty stack"); //debug
            }

            return true;// remove 1 item if stack found
        }

        public int GetTotal(Item item)
        {
            List<ItemStack> allOfType = inventory.FindAll(stack => stack.Item == item);
            int total = 0;

            foreach(ItemStack stack in allOfType)
            {
                total += stack.Count;
            }

            return total;
        }

        public void PrintInventory()
        {
            Console.WriteLine(Name);
            Console.WriteLine();

            foreach (ItemStack i in inventory)
            {
                Console.WriteLine($"-> {i.Item.Name}: {i.Count}");
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
        public static readonly Item Wood = new Item("wood");
        public static readonly Item Stone = new Item("stone");
        public static readonly List<Item> AllItems = new List<Item> { Wood, Stone };
    }
}
