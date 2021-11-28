using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone
{
    public class Gum : VendingMachineItem
    {
        //Constructor
        public Gum(string name, decimal price, string slotNumber, string itemType, int quantity) : base(name, price, slotNumber, itemType, quantity)
        {

        }

        //Abstracted Method
        public override string MakeSound()
        {
            return "Chew Chew, Yum!";
        }
    }
}
