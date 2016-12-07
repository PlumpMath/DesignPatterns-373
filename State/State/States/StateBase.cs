
namespace State.States
{
    public abstract class StateBase : IState
    {
        public abstract void SetMoney(int count, PrintMachine machine);

        public abstract void SetDevice(DeviceTypes type, PrintMachine machine);

        public abstract void SetDocument(string filename, PrintMachine machine);

        public abstract void Print(PrintMachine machine);

        public abstract int GetChange(PrintMachine machine);
    }
}
