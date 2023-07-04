using System;
using System.Collections.Generic;

namespace StoreBoxes
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split();
            List<Box> data = new List<Box>();
            while (input[0] != "end")
            {
                string serialNumber = input[0];
                string itemName = input[1];
                int itemQuantity = int.Parse(input[2]);
                double itemPrice = double.Parse(input[3]);
                Item item = new Item()
                {
                    Name = itemName,
                    Price = itemPrice
                };
                Box box = new Box()
                {
                    SerialNumber = serialNumber,
                    Item = item,
                    ItemQuantity = itemQuantity
                };
                data.Add(box);
                input = Console.ReadLine().Split();
            }
            for (int i = 0; i < data.Count - 1; i++)
            {
                for (int j = 0; j < data.Count - 1; j++)
                {
                    if (data[j].PriceForBox < data[j + 1].PriceForBox)
                    {
                        Box temp = data[j];
                        data[j] = data[j + 1];
                        data[j + 1] = temp;
                    }
                }
            }
            foreach (Box item in data)
            {
                Console.WriteLine(item.SerialNumber);
                Console.WriteLine($"-- {item.Item.Name} - ${item.Item.Price:f2}: {item.ItemQuantity}");
                Console.WriteLine($"-- ${item.PriceForBox:f2}");
            }
        }
    }
    class Item
    {
        public string Name { get; set; }
        public double Price { get; set; }
    }
    class Box
    {
        public Box()
        {
            Item = new Item();
        }

        public string SerialNumber { get; set; }
        public Item Item { get; set; }
        public int ItemQuantity { get; set; }
        public double PriceForBox
        {
            get
            {
                return this.ItemQuantity * this.Item.Price;
            }
        }
    }
}
