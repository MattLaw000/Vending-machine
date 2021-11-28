using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace Capstone
{
    class UserInterface
    {
        public void DisplayInventory(Dictionary<string, VendingMachineItem> inventoryReference)
        {
            foreach (KeyValuePair<string, VendingMachineItem> item in inventoryReference)
            {
                Console.WriteLine($"{item.Key})  ${item.Value.Price}  {item.Value.Name} x{item.Value.Quantity}");
            }
        }
    }
}