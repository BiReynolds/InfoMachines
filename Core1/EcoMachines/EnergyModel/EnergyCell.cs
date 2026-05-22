using Core1;

namespace EcoMachines.EnergyModel
{

    public class EnergyCell : ComponentBase<float>
    {
        public EnergyCell(int address, bool isLeftCap = false, bool isRightCap = false) : base([address - 1, address, address + 1], address)
        {
            if (isLeftCap)
            {
                ReadSet = [address, address + 1];
            }
            else if (isRightCap)
            {
                ReadSet = [address - 1, address];
            }
        }

        public override float GetWriteValueFromReadValues(float[] readValues)
        {
            return readValues.Average();
        }
    }
}