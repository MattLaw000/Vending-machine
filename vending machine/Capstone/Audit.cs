using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace Capstone
{
    public class Audit
    {
        public void AddToAudit(string auditType, decimal amountBefore, decimal amountAfter)
        {
            try
            {
                string currentDirectory = Directory.GetCurrentDirectory();
                string fileToWriteTo = "Log.txt";
                string fullPath = Path.Combine(currentDirectory, fileToWriteTo);
                StreamWriter streamWriter = new StreamWriter(fullPath, true);
                {
                    streamWriter.WriteLine($"{DateTime.Now} {auditType}: ${amountBefore} ${amountAfter}");
                    streamWriter.Close();
                }
            }
            catch (IOException message)
            {

                Console.WriteLine("File not found. " + message);
            }
        }
    }
}
