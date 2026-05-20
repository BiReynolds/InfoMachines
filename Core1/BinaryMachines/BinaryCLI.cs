using Core1;

namespace Core1.BinaryMachines
{
    public class BinaryCLI
    {
        BinaryMachine Machine;
        MachineObserver<bool> Observer;
        MachineController<bool> Controller;
        public BinaryCLI(BinaryMachine machine)
        {
            Machine = machine;
            Observer = new MachineObserver<bool>(machine);
            Controller = new MachineController<bool>(machine);
        }

        public void Respond(string rawInput)
        {
            bool[]? parsedInput = GetParsedInput(rawInput);
            if (parsedInput != null)
            {
                Controller.SetData(parsedInput);
            }
            Machine.Tick();
            bool[] displayState = Observer.GetData();
            RenderState(displayState);
        }

        public static bool[]? GetParsedInput(string rawInput)
        {
            if (rawInput.Length == 0)
            {
                return null;
            }
            else
            {
                return GetBitListFromString(rawInput).ToArray();
            }
        }

        public static List<bool> GetBitListFromString(string bitString)
        {
            List<bool> result = new();
            foreach (char character in bitString)
            {
                if (char.IsWhiteSpace(character))
                {
                    continue;
                }
                else if (character == '0')
                {
                    result.Add(false);
                }
                else if (character == '1')
                {
                    result.Add(true);
                }
                else
                {
                    throw new Exception($"got unexpected character in bit-string: {character}");
                }
            }
            return result;
        }

        public static void RenderState(bool[] state)
        {
            foreach (bool value in state)
            {
                if (value)
                {
                    Console.Write("1 ");
                }
                else
                {
                    Console.Write("0 ");
                }
            }
            Console.WriteLine();
        }
    }
}