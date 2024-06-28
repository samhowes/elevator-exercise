namespace ElevatorConsole;

public enum Direction
{
    Stationary,
    Up,
    Down,
}

public class Elevator
{
    public static Elevator Default()
    {
        return new Elevator(new List<Floor>()
        {
            new Floor(1, false, true),
            new Floor(2, true, true),
            new Floor(3, true, true),
            new Floor(4, true, true),
            new Floor(5, true, false),
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
    
    public Direction Direction { get; set; } = Direction.Stationary;

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