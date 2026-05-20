namespace Core1.BinaryMachines.NANDMachines
{
    public class NANDComponent : ComponentBase<bool>
    {
        public NANDComponent(int arg1Address, int arg2Address, int targetAddress) : base([arg1Address, arg2Address], targetAddress) { }

        public override bool GetWriteValueFromReadValues(bool[] readValues)
        {
            if (readValues[0] && readValues[1])
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}