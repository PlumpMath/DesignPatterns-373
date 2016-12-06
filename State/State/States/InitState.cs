using System;

namespace State.States
{
    public class InitState : StateBase
    {
        public override void SetMoney(int count, PrintMachine machine)
        {
            machine.Deposit = count;
            machine.State = new DeviceSelectionState();
        }

        public override void SetDevice(DeviceTypes type, PrintMachine machine)
        {
            throw new Exception("PrintMachine wants money");
        }

        public override void SetDocument(string filename, PrintMachine machine)
        {
            throw new Exception("PrintMachine wants money");
        }

        public override void Print(PrintMachine machine)
        {
            throw new Exception("PrintMachine wants money");
        }

        public override int GetChange(PrintMachine machine)
        {
            throw new Exception("PrintMachine wants money");
        }
    }
}
