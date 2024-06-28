namespace ElevatorConsole;

public class ElevatorOperator
{
    public Elevator Elevator { get; }

    public ElevatorOperator(Elevator elevator)
    {
        Elevator = elevator;
    }

    public void GoingUp(Floor floor)
    {
        Elevator.Direction = Direction.Up;
        Elevator.MoveTo(floor);
    }

    public void GoingDown(Floor floor)
    {
        Elevator.Direction = Direction.Down;
        Elevator.MoveTo(floor);
    }

    public void SelectFloor(Floor floor)
    {
        Elevator.MoveTo(floor);
    }
    
    public List<Floor> GetFloorOptions()
    {
        return Elevator.Direction switch
        {
            Direction.Stationary => Elevator.Floors.Where(f => f != Elevator.CurrentFloor).ToList(),
            Direction.Up => Elevator.Floors.Where(f => f.FloorNumber > Elevator.CurrentFloor.FloorNumber).ToList(),
            Direction.Down => Elevator.Floors.Where(f => f.FloorNumber < Elevator.CurrentFloor.FloorNumber).ToList(),
            _ => throw new Exception($"Invalid direction set: {Elevator.Direction}")
        };
    }
}