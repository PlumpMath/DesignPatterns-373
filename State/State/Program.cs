using System;

namespace State
{
    class Program
    {
        static void Main(string[] args)
        {
            var machine = new PrintMachine(2);
            machine.SetMoney(3);
            // machine.SetMoney(4); - хватит на две печати
            machine.SetDevice(DeviceTypes.FlashDisk);
            machine.SetDocument("in.txt");
            machine.Print();
            machine.SetDocument("out.txt");
            machine.Print();
            Console.WriteLine($"Short change: {machine.GetChange()}");
            Console.ReadLine();
        }
    }
}
