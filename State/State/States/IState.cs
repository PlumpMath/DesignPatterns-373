

namespace State.States
{
    public interface IState
    {
        void SetMoney(int count, PrintMachine machine);
        void SetDevice(DeviceTypes type, PrintMachine machine);
        void SetDocument(string filename, PrintMachine machine);
        void Print(PrintMachine machine);
        int GetChange(PrintMachine machine);
    }
}
