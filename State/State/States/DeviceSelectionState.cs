using System;

namespace State.States
{
    public class DeviceSelectionState : StateBase
    {
        public override void SetMoney(int count, PrintMachine machine) { }

        public override void SetDevice(DeviceTypes type, PrintMachine machine)
        {
            machine.Type = type;
            machine.State = new DocumentSelectionState();
        }

        public override void SetDocument(string filename, PrintMachine machine)
        {
            throw new Exception("PrintMachine wants device selection");
        }

        public override void Print(PrintMachine machine)
        {
            throw new Exception("PrintMachine wants device selection");
        }

        public override int GetChange(PrintMachine machine)
        {
            throw new Exception("PrintMachine wants device selection");
        }
    }
}
