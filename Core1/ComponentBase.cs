namespace Core1
{
    public abstract class ComponentBase<SymbolType>
    {
        public int Complexity;
        public int[] ReadSet;
        public int Target;
        public ComponentBase(int[] readSet, int target)
        {
            Complexity = readSet.Length;
            ReadSet = readSet;
            Target = target;
        }

        public abstract SymbolType GetWriteValueFromReadValues(SymbolType[] readValues);

        public void Tick(SymbolType[] startState, SymbolType[] destination)
        {
            SymbolType[] readValues = GetReadValues(startState);
            SymbolType writeValue = GetWriteValueFromReadValues(readValues);
            SetTargetValue(destination, writeValue);
        }

        private SymbolType[] GetReadValues(SymbolType[] state)
        {
            SymbolType[] readValues = new SymbolType[ReadSet.Length];
            for (int i = 0; i < ReadSet.Length; i++)
            {
                readValues[i] = state[ReadSet[i]];
            }
            return readValues;
        }

        private void SetTargetValue(SymbolType[] state, SymbolType newValue)
        {
            state[Target] = newValue;
        }
    }
}