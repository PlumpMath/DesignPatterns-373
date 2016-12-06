using System;

namespace State.States
{
    public class GetShortChangeState : StateBase
    {
        public override void SetMoney(int count, PrintMachine machine) { }

        public override void SetDevice(DeviceTypes type, PrintMachine machine)
        {
            throw new Exception("The change must be taken");
        }

        public override void SetDocument(string filename, PrintMachine machine)
        {
            throw new Exception("The change must be taken");
        }

        public override void Print(PrintMachine machine)
        {
            throw new Exception("The change must be taken");
        }
    }
}
