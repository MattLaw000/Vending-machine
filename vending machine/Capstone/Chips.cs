using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone
{
    public class Chips : VendingMachineItem
    {
        //Constructor
        public Chips(string name, decimal price, string slotNumber, string itemType, int quantity) : base(name, price, slotNumber, itemType, quantity)
        {

        }

        //Abstracted Method
        public override string MakeSound()
        {
            return "Crunch Crunch, Yum!";
        }
    }
}
