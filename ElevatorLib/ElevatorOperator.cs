namespace ElevatorLib;

public class ElevatorOperator
{
    public Elevator Elevator { get; }
    public List<Floor> FloorOptions { get; private set; }

    public ElevatorOperator(Elevator elevator)
    {
        Elevator = elevator;
        SetFloorOptions();
    }

    public void GoingUp(Floor floor)
    {
        Elevator.Direction = Direction.Up;
        Elevator.MoveTo(floor);
        SetFloorOptions();
    }

    public void GoingDown(Floor floor)
    {
        Elevator.Direction = Direction.Down;
        Elevator.MoveTo(floor);
        SetFloorOptions();
    }

    public void SelectFloor(Floor floor)
    {
        Elevator.MoveTo(floor);
        Elevator.Direction = Direction.Stationary;
        SetFloorOptions();
    }
    
    public void SetFloorOptions()
    {
        FloorOptions = Elevator.Direction switch
        {
            Direction.Stationary => Elevator.Floors.Where(f => f != Elevator.CurrentFloor).ToList(),
            Direction.Up => Elevator.Floors.Where(f => f.FloorNumber > Elevator.CurrentFloor.FloorNumber).ToList(),
            Direction.Down => Elevator.Floors.Where(f => f.FloorNumber < Elevator.CurrentFloor.FloorNumber).ToList(),
            _ => throw new Exception($"Invalid direction set: {Elevator.Direction}")
        };
    }
}