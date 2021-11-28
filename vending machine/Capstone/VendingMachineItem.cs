using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone
{
    public abstract class VendingMachineItem //: IHasPrice
    {
        //Properties
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string SlotNumber { get; set; }
        public string ItemType { get; set; }
        public int Quantity { get; set; } = 5;

        //Constructor
        public VendingMachineItem(string name, decimal price, string slotNumber, string itemType, int quantity)
        {
            Name = name;
            Price = price;
            SlotNumber = slotNumber;
            ItemType = itemType;
            Quantity = quantity;
        }

        //Abstract Method
        public abstract string MakeSound();
    }
}