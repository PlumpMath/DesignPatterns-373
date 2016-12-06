
namespace State.States
{
    public abstract class StateBase : IState
    {
        public abstract void SetMoney(int count, PrintMachine machine);

        public abstract void SetDevice(DeviceTypes type, PrintMachine machine);

        public abstract void SetDocument(string filename, PrintMachine machine);

        public abstract void Print(PrintMachine machine);

        public virtual int GetChange(PrintMachine machine)
        {
            var deposit = machine.Deposit;
            machine.State = new InitState();
            machine.Deposit = 0;
            machine.Type = DeviceTypes.None;
            return deposit;
        }
    }
}
