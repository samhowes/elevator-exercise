namespace ElevatorConsole;

public enum ElevatorDoorState
{
    Open,
    Closed,
}

public class Elevator
{
    public static Elevator Default()
    {
        return new Elevator(new List<Floor>()
        {
            new Floor(1, true),
            new Floor(2, false),
            new Floor(3, false),
            new Floor(4, false),
            new Floor(5, true),
        });
    }
    
    public Elevator(List<Floor> floors)
    {
        Floors = floors;
        CurrentFloor = floors[0];
        DoorState = ElevatorDoorState.Closed;
    }
    
    public List<Floor> Floors { get; set; }

    public Floor CurrentFloor { get; set; }
    
    public ElevatorDoorState DoorState { get; set; }

}

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