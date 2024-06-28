namespace ElevatorConsole;

public class Floor
{
    public int FloorNumber { get; }
    public bool HasCallButton { get; }

    public Floor(int floorNumber, bool hasCallButton)
    {
        FloorNumber = floorNumber;
        HasCallButton = hasCallButton;
    }
}