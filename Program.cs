using Core1.BinaryMachines;
using Core1.BinaryMachines.NANDMachines;
using EcoMachines.EnergyModel;

public static class Program
{
    public static void Main()
    {
        EnergyManager.RunSpikeTrial(11, 3, 100);
    }

    public static void RunTickMachine()
    {
        TickMachine machine = new();
        BinaryCLI cli = new(machine);
        Console.WriteLine("Starting CLI");
        string currInput = Console.ReadLine() ?? "";
        while (currInput != "exit")
        {
            cli.Respond(currInput);
            currInput = Console.ReadLine() ?? "";
        }
        Console.WriteLine("Exiting CLI");
    }
}