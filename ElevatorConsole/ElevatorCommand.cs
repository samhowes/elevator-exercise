namespace ElevatorConsole;

public enum ElevatorOperation
{
    CallTo,
    MoveTo
}

public class ElevatorCommand
{
    public Floor Floor { get; }
    public ElevatorOperation Operation { get; }
    public string DisplayText { get; }

    public ElevatorCommand(Floor floor, ElevatorOperation operation, string displayText)
    {
        Floor = floor;
        Operation = operation;
        DisplayText = displayText;
    }
    public override string ToString()
    {
        return DisplayText;
    }
}