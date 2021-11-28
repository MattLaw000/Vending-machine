using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace Capstone
{
    class InitialSalesReport
    {
        //Property
        Dictionary<string, int> SalesReport { get; set; }

        //Constructor
        public InitialSalesReport()
        {

        }

        //Method !!!NOT USED YET!!! STILL NEED TO ADD METHOD OR PROGRAMMIING THAT UPDATES IT AS INPUT.SCV IS STATIC
        public void GenerateInitialSalesReportMethod()
        {
            string directory = Environment.CurrentDirectory;
            string fileName = "vendingmachine.csv";
            string fullFilePath = Path.Combine(directory, fileName);
            using (StreamReader streamReader = new StreamReader(fullFilePath))
            {
                while (!streamReader.EndOfStream)
                {
                    string line = streamReader.ReadLine();
                    string[] array = line.Split("|");
                    SalesReport.Add(array[1], 0);

                }
            }
        }
    }
}
