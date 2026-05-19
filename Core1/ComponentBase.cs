namespace Core1
{
    public abstract class ComponentBase<SymbolType>
    {
        public int ReadComplexity, WriteComplexity;
        public int[] ReadSet, WriteSet;
        public ComponentBase(int[] readSet, int[] writeSet)
        {
            ReadComplexity = readSet.Length;
            WriteComplexity = writeSet.Length;
            ReadSet = readSet;
            WriteSet = writeSet;
        }

        public abstract SymbolType[] GetWriteValuesFromReadValues(SymbolType[] readValues);

        public void Tick(SymbolType[] state)
        {
            SymbolType[] readValues = GetReadValues(state);
            SymbolType[] writeValues = GetWriteValuesFromReadValues(readValues);
            SetWriteValues(state, writeValues);
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

        public void SetWriteValues(SymbolType[] state, SymbolType[] writeValues)
        {
            for (int i = 0; i < WriteSet.Length; i++)
            {
                state[WriteSet[i]] = writeValues.ElementAt(i);
            }
        }
    }
}