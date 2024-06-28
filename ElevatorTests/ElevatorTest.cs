using ElevatorConsole;
using FluentAssertions;

namespace ElevatorTests;

public class ElevatorTest
{
    private readonly Elevator _elevator = Elevator.Default();

    [Fact]
    public void FloorHistory_IncludesInitialFloor()
    {
        _elevator.History.Count.Should().Be(1);
        _elevator.History[0].Should().Be(_elevator.CurrentFloor);
    }

    [Fact]
    public void ElevatorFloor_StartsAtOne_WithDoorOpen()
    {
        _elevator.CurrentFloor.FloorNumber.Should().Be(1);
        _elevator.DoorsOpen.Should().Be(true);
    }

    [Fact]
    public void MoveTo_SetsCurrentFloor()
    {
        _elevator.CurrentFloor.Should().Be(_elevator.Floors[0]);
        
        var floor = _elevator.Floors[4];
        _elevator.MoveTo(floor);

        _elevator.CurrentFloor.Should().Be(floor);
    }

    [Fact]
    public void MoveTo_AddsToHistory()
    {
        _elevator.History.Count.Should().Be(1);
        var floor = _elevator.Floors[4];
        
        _elevator.MoveTo(floor);

        _elevator.History.Count.Should().Be(2);
        _elevator.History[1].Should().Be(floor);
    }
    
    [Fact]
    public void MoveTo_OpensDoors_AfterMoving()
    {
        var floor = _elevator.Floors[4];
        
        _elevator.MoveTo(floor);

        _elevator.DoorsOpen.Should().Be(true);
    }

    [Fact]
    public void MoveTo_DoesNotMoveToFloor_ThatIsCurrentFloor()
    {
        var floor = _elevator.CurrentFloor;
        
        _elevator.MoveTo(floor);

        _elevator.History.Count.Should().Be(1);
    }
}