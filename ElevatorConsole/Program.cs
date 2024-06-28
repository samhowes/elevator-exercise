using Spectre.Console;

namespace ElevatorConsole;

internal static class Program
{
    public static void Main(string[] args)
    {
        var elevator = Elevator.Default();
        var elevatorOperator = new ElevatorOperator(elevator);

        while (true)
        {
            AnsiConsole.WriteLine($"Elevator on floor: {elevator.CurrentFloor.FloorNumber}");
            var openState = elevator.DoorsOpen ? "Open" : "Closed";
            AnsiConsole.WriteLine($"Doors are: {openState}");
            AnsiConsole.WriteLine($"Ctrl-C to exit");
            AnsiConsole.WriteLine();
            
            var commands = elevatorOperator.GetCommands();
        
            var command = AnsiConsole.Prompt(
                new SelectionPrompt<ElevatorCommand>()
                    .Title("Choose a button:")
                    .AddChoices(commands)
            );

            elevatorOperator.ExecuteCommand(command);
        }
    }
}

