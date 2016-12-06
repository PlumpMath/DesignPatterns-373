using System;

namespace State.States
{
    public class DocumentSelectionState : StateBase
    {
        public override void SetMoney(int count, PrintMachine machine) { }

        public override void SetDevice(DeviceTypes type, PrintMachine machine)
        {
            throw new Exception("The device was setted");
        }

        public override void SetDocument(string filename, PrintMachine machine)
        {
            machine.Filename = filename;
            machine.State = new PrintState();
        }

        public override void Print(PrintMachine machine)
        {
            throw new Exception("PrintMachine wants document selection");
        }

        public override int GetChange(PrintMachine machine)
        {
            throw new Exception("PrintMachine wants document selection");
        }
    }
}
