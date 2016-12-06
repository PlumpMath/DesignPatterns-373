using State.States;

namespace State
{
    public class PrintMachine
    {
        public int Deposit { get; set; }
        public DeviceTypes Type { get; set; }
        public string Filename { get; set; }

        public int Cost { get; private set; }
        public StateBase State { get; set; }

        public PrintMachine(int cost)
        {
            Cost = cost;
            State = new InitState();
        }

        public void SetMoney(int count)
        {
            State.SetMoney(count, this);
        }

        public void SetDevice(DeviceTypes type)
        {
            State.SetDevice(type, this);
        }

        public void SetDocument(string filename)
        {
            State.SetDocument(filename, this);
        }

        public void Print()
        {
            State.Print(this);
        }

        public int GetChange()
        {
            return State.GetChange(this);
        }
    }
}
