// See https://aka.ms/new-console-template for more information

namespace ElevatorConsole;

internal static class Program
{
    public static void Main(string[] args)
    {
        var elevator = Elevator.Default();
        var elevatorOperator = new ElevatorOperator(elevator);
    }
}