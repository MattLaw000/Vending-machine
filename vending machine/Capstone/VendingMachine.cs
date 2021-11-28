using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace Capstone
{
    public class VendingMachine
    {
        //Property
        public Dictionary<string, VendingMachineItem> Inventory { get; set; } = new Dictionary<string, VendingMachineItem>();
        
        //Default Constructor
        public VendingMachine()
        {

        }

        //Methods
        public void DispenseProductMethod(string slotNumberInputParameter)
        {
            Inventory[slotNumberInputParameter].Quantity -= 1;
            Console.WriteLine($"You have selected {Inventory[slotNumberInputParameter].Name}");
            Console.WriteLine(Inventory[slotNumberInputParameter].MakeSound());
        }
        //__________________________________________________________________
        public void DisplayProductsMethod()
        {
            foreach (KeyValuePair<string, VendingMachineItem> item in Inventory)
            {
                Console.WriteLine($"{item.Key})  ${item.Value.Price}  {item.Value.Name} x{item.Value.Quantity}");
            };
        }
        //__________________________________________________________________
        public void GenerateInventoryMethod()
        {
            string directory = Environment.CurrentDirectory;
            string fileName = "vendingmachine.csv";
            string fullFilePath = Path.Combine(directory, fileName);
            using (StreamReader streamReader = new StreamReader(fullFilePath))
            {

                while (!streamReader.EndOfStream)
                {
                    // Creating new intances of each class to contain the name, price, quantity, type, slot number from input file and adds to Inventory dictionary
                    string line = streamReader.ReadLine();
                    string[] array = line.Split("|");
                    if (array[3] == "Drink")
                    {
                        Drinks drink = new Drinks(array[1], decimal.Parse(array[2]), array[0], array[3], 5);
                        Inventory.Add(array[0], drink);
                    }
                    if (array[3] == "Chip")
                    {
                        Chips chip = new Chips(array[1], decimal.Parse(array[2]), array[0], array[3], 5);
                        Inventory.Add(array[0], chip);
                    }
                    if (array[3] == "Gum")
                    {
                        Gum gum = new Gum(array[1], decimal.Parse(array[2]), array[0], array[3], 5);
                        Inventory.Add(array[0], gum);
                    }
                    if (array[3] == "Candy")
                    {
                        Candy candy = new Candy(array[1], decimal.Parse(array[2]), array[0], array[3], 5);
                        Inventory.Add(array[0], candy);
                    }
                }
            }
        }
    }
}