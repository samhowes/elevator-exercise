namespace ElevatorConsole;

public class ElevatorOperator
{
    public Elevator Elevator { get; }

    public ElevatorOperator(Elevator elevator)
    {
        Elevator = elevator;
    }

    public List<ElevatorCommand> GetCommands()
    {
        var commands = new List<ElevatorCommand>();
        
        // commands from outside the doors
        foreach (var callableFloor in Elevator.Floors.Where(f => f.HasCallButton))
        {
            commands.Add(new ElevatorCommand(
                callableFloor, ElevatorOperation.CallTo, $"Call to floor {callableFloor.FloorNumber}"));
        }
        
        // commands from inside the elevator
        foreach (var floor in Elevator.Floors)
        {
            commands.Add(new ElevatorCommand(
                floor, ElevatorOperation.MoveTo, $"Go to floor {floor.FloorNumber}"));
        }

        return commands;
    }

    public void ExecuteCommand(ElevatorCommand command)
    {
        switch (command.Operation)
        {
            case ElevatorOperation.CallTo:
                if (!command.Floor.HasCallButton)
                    throw new Exception(
                        $"Can't call to floor #{command.Floor.FloorNumber} that does not have a call button");
                
                Elevator.MoveTo(command.Floor);
                break;
            
            case ElevatorOperation.MoveTo:
                Elevator.MoveTo(command.Floor);
                break;
            
            default:
                throw new Exception($"Unknown {nameof(ElevatorOperation)} value {command.Operation}");
        }
    }
}