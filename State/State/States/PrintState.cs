using System;

namespace State.States
{
    public class PrintState : StateBase
    {
        public override void SetMoney(int count, PrintMachine machine) { }

        public override void SetDevice(DeviceTypes type, PrintMachine machine)
        {
            throw new Exception("The device was setted");
        }

        public override void SetDocument(string filename, PrintMachine machine)
        {
            throw new Exception("The document was setted");
        }

        public override void Print(PrintMachine machine)
        {
            if (machine.Deposit - machine.Cost < 0)
            {
                Console.WriteLine("Money not enough =(");
                machine.State = machine.Deposit > 0 ? (StateBase) new GetShortChangeState() : new InitState();
                return;
            }

            Console.WriteLine($"The document '{machine.Filename}' was printed");
            machine.Deposit -= machine.Cost;
            machine.State = new ContinueOrChangeState();
        }

        public override int GetChange(PrintMachine machine)
        {
            throw new Exception("PrintMachine wants document selection");
        }
    }
}
