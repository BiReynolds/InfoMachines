namespace EcoMachines.EnergyModel
{
    public static class EnergyManager
    {
        public static void RunSpikeTrial(int numCells, int spikeLocation, float spikeValue, int numSteps = 100)
        {
            Console.WriteLine("initializing start state");
            float[] startState = GetSpikeState(numCells, spikeLocation, spikeValue);
            Console.WriteLine("creating machine frame");
            EnergyFrame frame = new(startState);
            Console.WriteLine("creating machine");
            EnergyMachine machine = new(frame);
            Console.WriteLine("starting trial");
            for (int step = 0; step < numSteps; step++)
            {
                RenderState(machine.GetState());
                machine.Tick();
            }
            RenderState(machine.GetState());
        }
        
        public static float[] GetSpikeState(int numCells, int spikeLocation, float spikeValue)
        {
            if (numCells <= spikeLocation)
            {
                throw new Exception($"Cannot get spike state at {spikeLocation} with only {numCells} cells");
            }
            float[] result = new float[numCells];
            result[spikeLocation] = spikeValue;
            return result;
        }

        public static void RenderState(float[] state)
        {
            foreach (float val in state)
            {
                Console.Write($"{val.ToString("G3")} ");
            }
            Console.WriteLine();
        }
    }
}