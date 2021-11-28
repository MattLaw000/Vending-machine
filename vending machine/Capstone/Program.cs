using System;
using System.IO;
using System.Collections.Generic;

namespace Capstone
{
    class Program
    {
        static void Main(string[] args)
        {
            //Instantiates instances of classes
            VendingMachine vendingMachine = new VendingMachine();
            MoneyManagement moneyManagement = new MoneyManagement();
            Audit audit = new Audit();

            //Input file Stream Reader to dictionary and instantiates each item
            vendingMachine.GenerateInventoryMethod();

            // User Interface Programming, using properties and methods of existing classes
            try
            {
                bool mainMenuLoop = true;
                while (mainMenuLoop == true)
                {

                    //Main menu
                    Console.WriteLine("Please select one of these options: ");
                    Console.WriteLine("(1) Display Vending Machine Items");
                    Console.WriteLine("(2) Purchase");
                    Console.WriteLine("(3) Exit");
                    string userMainMenuInput = Console.ReadLine();
                    if (userMainMenuInput == "1")
                    {
                        vendingMachine.DisplayProductsMethod();
                    }
                    //Purchase menu
                    if (userMainMenuInput == "2")
                    {
                        bool purchaseMenuLoop = true;
                        while (purchaseMenuLoop == true)
                        {
                            Console.WriteLine($"(1) Feed Money");
                            Console.WriteLine($"(2) Select Product");
                            Console.WriteLine($"(3) Finish Transaction");
                            string PurchaseMenuInput = Console.ReadLine();

                            if (PurchaseMenuInput == "1")
                            {
                                try
                                {
                                    bool feedMoneyLoop = true;
                                    while (feedMoneyLoop == true)
                                    {
                                        Console.WriteLine("Please insert money in whole dollar amounts");
                                        string moneyInput = Console.ReadLine();
                                        //Feed input validation must be whole number
                                        if (decimal.Parse(moneyInput) % 1 != 0 || decimal.Parse(moneyInput) < 0)
                                        {
                                            Console.WriteLine("Number entered must be postive whole number!");
                                        }
                                        if (decimal.Parse(moneyInput) % 1 == 0 && decimal.Parse(moneyInput) > 0)
                                        {
                                            //Add to audit Log.txt
                                            audit.AddToAudit("Feed Money", moneyManagement.TotalFeed, (moneyManagement.TotalFeed + decimal.Parse(moneyInput)));
                                            moneyManagement.AddToFeedMethod(Decimal.Parse(moneyInput));
                                        }
                                        Console.WriteLine($"Total amount inserted ${moneyManagement.TotalFeed}");
                                        Console.WriteLine($"1) Add more money");
                                        Console.WriteLine($"2) Return to purchase menu");
                                        string moreMoneyMenuInput = Console.ReadLine();

                                        if (moreMoneyMenuInput == "2")
                                        {
                                            feedMoneyLoop = false;
                                        }
                                        //Feed Money Menu Input Validation ony l or 2
                                        if (moreMoneyMenuInput != "1" && moreMoneyMenuInput != "2")
                                        {
                                            Console.WriteLine("Number entered is not an option!");
                                            feedMoneyLoop = false;
                                        }
                                    }
                                }
                                catch (Exception)
                                { 
                                    Console.WriteLine("Input must be a whole positive number!");
                                }
                            }

                            if (PurchaseMenuInput == "2")
                            {
                                Console.WriteLine("Please enter slot number");
                                string slotNumberInput = Console.ReadLine().ToUpper();
                                if (vendingMachine.Inventory.ContainsKey(slotNumberInput) && vendingMachine.Inventory[slotNumberInput].Price <= moneyManagement.TotalFeed && vendingMachine.Inventory[slotNumberInput].Quantity > 0)
                                {
                                    //Add to audit log and get new feed amount
                                    audit.AddToAudit(vendingMachine.Inventory[slotNumberInput].Name, moneyManagement.TotalFeed, (moneyManagement.TotalFeed - vendingMachine.Inventory[slotNumberInput].Price));
                                    vendingMachine.DispenseProductMethod(slotNumberInput);
                                    moneyManagement.NewBalanceMethod(vendingMachine.Inventory[slotNumberInput].Price);
                                    moneyManagement.Cost = vendingMachine.Inventory[slotNumberInput].Price;
                                }
                                //Select Item Input Validation
                                else if (vendingMachine.Inventory.ContainsKey(slotNumberInput) && vendingMachine.Inventory[slotNumberInput].Price > moneyManagement.TotalFeed)
                                {
                                    Console.WriteLine("You don't have appropriate funds!");
                                }
                                else if (!vendingMachine.Inventory.ContainsKey(slotNumberInput))
                                {
                                    Console.WriteLine("Invalid slot number!");
                                }
                                else if (vendingMachine.Inventory[slotNumberInput].Quantity == 0)
                                {
                                    Console.WriteLine($"{vendingMachine.Inventory[slotNumberInput].Name} is sold out!");
                                }
                            }
                            if (PurchaseMenuInput == "3")
                            {
                                audit.AddToAudit("Give Change", moneyManagement.TotalFeed - moneyManagement.Cost, 0);
                                moneyManagement.DespensechangeMethod();
                                purchaseMenuLoop = false;
                            }
                            //Purchase menu Input validation
                            else if (PurchaseMenuInput != "1" && PurchaseMenuInput != "2" && PurchaseMenuInput != "3")
                            {
                                Console.WriteLine("Number entered is not an option!!");
                            }
                        }

                    }
                    if (userMainMenuInput == "3")
                    {
                        return;
                    }
                    if (userMainMenuInput == "4")
                    {
                        //Sales report - optional
                    }
                    //MainMenu input Validation
                    else if (userMainMenuInput != "1" && userMainMenuInput != "2" && userMainMenuInput != "3" && userMainMenuInput != "4")
                    {
                        Console.WriteLine("Number entered is not an option. Please enter a whole number 1 through 3!");
                    }
                }
            }
            catch (IOException message)
            {

                Console.WriteLine($"Could not find file. {message}");
            }
        }
    }
}
