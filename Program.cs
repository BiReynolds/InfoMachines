using Core1.BinaryMachines;
using Core1.BinaryMachines.NANDMachines;

public static class Program
{
    public static void Main()
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