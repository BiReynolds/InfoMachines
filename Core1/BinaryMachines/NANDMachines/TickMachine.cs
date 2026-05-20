namespace Core1.BinaryMachines.NANDMachines
{
    public class TickMachine : BinaryMachine
    {
        static bool[] StartState = [true, false];
        public TickMachine() : base(2)
        {
            Frame.CurrentState = StartState[..];
            AddComponent(new NANDComponent(0, 1, 1));
        }
    }
}