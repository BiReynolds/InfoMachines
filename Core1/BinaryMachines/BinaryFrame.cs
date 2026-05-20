namespace Core1.BinaryMachines
{
    public class BinaryFrame : MachineFrame<bool>
    {
        public BinaryFrame(int size) : base(new bool[size]) { } 
    }
}