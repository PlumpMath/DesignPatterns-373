using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChainOfResponsibility
{
    class Program
    {
        static void Main(string[] args)
        {
            var bankWithoutPrint = new ChainOfResponsibilityWithoutPrint.Bancomat();
            var banknoteWithoutPrint = new ChainOfResponsibilityWithoutPrint.Banknote(ChainOfResponsibilityWithoutPrint.CurrencyType.Dollar, 165);
            var isValidWithoutPrint = bankWithoutPrint.Validate(banknoteWithoutPrint);
            Console.WriteLine($"Result of withoutPrint: {isValidWithoutPrint}");

            Console.WriteLine("\nSome troubles with print...");
            Console.WriteLine("\nExample with norm count banknotes");
            var bankWithPrint = new ChainOfResponsibilityWithPrint.Bancomat();
            var banknoteWithPrint = new ChainOfResponsibilityWithPrint.Banknote(ChainOfResponsibilityWithPrint.CurrencyType.Dollar, 160);
            var isValidWithPrint = bankWithPrint.Validate(banknoteWithPrint, true);
            Console.WriteLine($"\n\nResult of withPrint: {isValidWithPrint}");

            Console.WriteLine("\nExample with not enough banknotes");
            banknoteWithPrint = new ChainOfResponsibilityWithPrint.Banknote(ChainOfResponsibilityWithPrint.CurrencyType.Dollar, 165);
            isValidWithPrint = bankWithPrint.Validate(banknoteWithPrint, true);
            Console.WriteLine($"\n\nResult of withPrint: {isValidWithPrint}");
            Console.ReadLine();
        }
    }
}
