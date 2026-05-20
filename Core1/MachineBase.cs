namespace Core1
{
    public class MachineBase<SymbolType>
    {
        public int Size;
        public MachineFrame<SymbolType> Frame;
        public List<ComponentBase<SymbolType>> Components = new();
        public MachineBase(MachineFrame<SymbolType> frame)
        {
            Frame = frame;
            Size = Frame.Size;
        }
        
        public void Tick()
        {
            SymbolType[] newState = new SymbolType[Frame.Size];
            foreach (ComponentBase<SymbolType> component in Components)
            {
                component.Tick(Frame.CurrentState, newState);
            }
            Frame.CurrentState = newState;
        }

        public void AddComponent(ComponentBase<SymbolType> component)
        {
            if (Components.Find((x)=>{ return x.Target == component.Target; }) != null)
            {
                throw new Exception($"conflicting target: {component.Target}");
            }
            Components.Add(component);
        }

        public void SetState(SymbolType[] newState, int startAddress, int endAddress)
        {
            for (int i = 0; i < endAddress - startAddress; i++)
            {
                Frame.CurrentState[startAddress + i] = newState[i];
            }
        }

        public SymbolType[] GetState()
        {
            return Frame.CurrentState[..];
        }
    }
}