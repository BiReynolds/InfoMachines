namespace Core1.BinaryMachines
{
    public class BinaryMachine : MachineBase<bool>
    {
        public BinaryMachine(int size) : base(new BinaryFrame(size)) { } 
    }
}