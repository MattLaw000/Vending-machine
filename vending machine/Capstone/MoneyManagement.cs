using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone
{
    public class MoneyManagement
    {
        //Properties
        public decimal Cost { get; set; }
        public decimal TotalFeed { get; set; }
        //Default Constructor
        public MoneyManagement()
        {
        }
        //Methods
        public decimal AddToFeedMethod(decimal moneyProvided)
        {
            TotalFeed += moneyProvided;
            return TotalFeed;
        }
        //__________________________________________
        public void NewBalanceMethod(decimal price)
        {
            decimal balance = TotalFeed - price;
            TotalFeed -= price;
            Console.WriteLine($"Your balance is ${balance}");
        }

        //__________________________________________
        public string DespensechangeMethod()
        {
            decimal quarter = 0.25M;
            int quarterCounter = 0;
            decimal dime = 0.10M;
            int dimeCounter = 0;
            decimal nickel = 0.05M;
            int nickelCounter = 0;
            decimal change = TotalFeed;
            while (change > 0)
            {
                if (change >= quarter)
                {
                    quarterCounter++;
                    change -= quarter;
                }
                else if (change >= dime)
                {
                    dimeCounter++;
                    change -= dime;
                }
                else if (change >= nickel)
                {
                    nickelCounter++;
                    change -= nickel;
                }
            }
            TotalFeed = 0;
            Console.WriteLine($"Total change is: {quarterCounter} quarters, {dimeCounter} dimes, {nickelCounter} nickels.");
            return $"Total change is: {quarterCounter} quarters, {dimeCounter} dimes, {nickelCounter} nickels.";
        }
    }
}
