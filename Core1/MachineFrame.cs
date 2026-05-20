namespace Core1
{
    public class MachineFrame<SymbolType>
    {
        public readonly int Size;
        public readonly SymbolType[] StartState;
        public SymbolType[] CurrentState;
        public MachineFrame(SymbolType[] startState)
        {
            Size = startState.Length;
            StartState = startState[..];
            CurrentState = startState[..];
        }
    }
}