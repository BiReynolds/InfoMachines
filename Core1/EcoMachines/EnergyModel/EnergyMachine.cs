using Core1;

namespace EcoMachines.EnergyModel
{
    public class EnergyMachine : MachineBase<float>
    {
        public EnergyMachine(EnergyFrame frame) : base(frame)
        {
            for(int i = 0; i < Size; i++)
            {
                if (i == 0)
                {
                    Components.Add(new EnergyCell(0, isLeftCap: true));
                }
                else if (i == Size - 1)
                {
                    Components.Add(new EnergyCell(Size - 1, isRightCap: true));
                }
                else
                {
                    Components.Add(new EnergyCell(i));
                }
            }
        }
    }
}