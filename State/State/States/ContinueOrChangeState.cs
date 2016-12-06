using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace State.States
{
    public class ContinueOrChangeState : StateBase
    {
        public override void SetMoney(int count, PrintMachine machine) { }

        public override void SetDevice(DeviceTypes type, PrintMachine machine)
        {
            throw new Exception("The device was setted");
        }

        public override void SetDocument(string filename, PrintMachine machine)
        {
            var docSelectState = new DocumentSelectionState();
            docSelectState.SetDocument(filename, machine);
        }

        public override void Print(PrintMachine machine)
        {
            throw new Exception("PrintMachine wants document selection");
        }

        public override int GetChange(PrintMachine machine)
        {
            var getChangeState = new GetShortChangeState();
            return getChangeState.GetChange(machine);
        }
    }
}
