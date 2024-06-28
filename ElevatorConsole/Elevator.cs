namespace ElevatorConsole;

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
        History.Add(CurrentFloor);
        DoorsOpen = true;
    }
    
    public List<Floor> Floors { get; set; }

    public List<Floor> History { get; set; } = new List<Floor>();

    public Floor CurrentFloor { get; set; }
    public bool DoorsOpen { get; set; }

    public void MoveTo(Floor floor)
    {
        if (floor != CurrentFloor)
        {
            CloseDoors();
        
            CurrentFloor = floor;
            History.Add(CurrentFloor);
        }

        OpenDoors();
    }

    public void CloseDoors()
    {
        if (DoorsOpen)
        {
            DoorsOpen = false;
        }
    }

    public void OpenDoors()
    {
        if (!DoorsOpen)
        {
            DoorsOpen = true;
        }
    }
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