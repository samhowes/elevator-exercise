namespace ElevatorLib;

public class Floor
{
    public int FloorNumber { get; }
    public bool HasUpButton { get; }
    public bool HasDownButton { get; }

    public Floor(int floorNumber, bool hasDownButton, bool hasUpButton)
    {
        FloorNumber = floorNumber;
        HasUpButton = hasUpButton;
        HasDownButton = hasDownButton;
    }
}