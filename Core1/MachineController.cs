namespace Core1
{
    public class MachineController<SymbolType>
    {
        readonly int StartAddress, EndAddress;
        MachineBase<SymbolType> Machine;
        public MachineController(MachineBase<SymbolType> machine, int startAddress = 0, int endAddress = -1)
        {
            Machine = machine;
            int? testStartAddress = GetLiteralIndex(machine.Size, startAddress);
            int? testEndAddress = GetLiteralIndex(machine.Size, endAddress);
            if (CompatibilityCheck(testStartAddress, testEndAddress))
            {
                StartAddress = testStartAddress ?? 0;
                EndAddress = testEndAddress ?? Machine.Size;
            }
            else
            {
                throw new Exception("Controller and machine are incompatible");
            }
        }

        public static bool CompatibilityCheck(int? literalStartAddress, int? literalEndAddress)
        {
            if (literalStartAddress == null || literalEndAddress == null)
            {
                return false;
            }
            else if (literalStartAddress >= literalEndAddress)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public static int? GetLiteralIndex(int arrayLength, int index)
        {
            if (index < -arrayLength || index >= arrayLength)
            {
                return null;
            }
            else if (index < 0)
            {
                return index + arrayLength + 1;
            }
            else
            {
                return index;
            }
        }

        public void SetData(SymbolType[] input)
        {
            Machine.SetState(input, StartAddress, EndAddress);
        }
    }
}