using ElevatorLib;
using FluentAssertions;
using Xunit;

namespace ElevatorTests;

public class ElevatorOperatorTest
{
    private readonly Elevator _elevator;
    private readonly ElevatorOperator _operator;

    public ElevatorOperatorTest()
    {
        _elevator = Elevator.Default();
        _operator = new ElevatorOperator(_elevator);
    }

    [Fact]
    public void ElevatorDirection_IsSet()
    {
        var floor = _elevator.Floors[2];
        _operator.GoingUp(floor);
        _elevator.Direction.Should().Be(Direction.Up);
        
        _operator.GoingDown(floor);
        _elevator.Direction.Should().Be(Direction.Down);
        
        _operator.SelectFloor(floor);
        _elevator.Direction.Should().Be(Direction.Stationary);
    }

    [Fact]
    public void FloorOptions_AreInitialized()
    {
        _operator.FloorOptions.Count.Should().Be(4);

        _operator.FloorOptions[0].FloorNumber.Should().Be(2);
        _operator.FloorOptions[3].FloorNumber.Should().Be(5);
    }
    
    [Fact]
    public void DownFloorOptions_AreSet()
    {
        var floor = _elevator.Floors[2];
        _operator.GoingDown(floor);
        _operator.FloorOptions.Count.Should().Be(2);

        _operator.FloorOptions[0].FloorNumber.Should().Be(1);
        _operator.FloorOptions[1].FloorNumber.Should().Be(2);
    }
    
    
    [Fact]
    public void UpFloorOptions_AreSet()
    {
        var floor = _elevator.Floors[3];
        _operator.GoingUp(floor);
        _operator.FloorOptions.Count.Should().Be(1);

        _operator.FloorOptions[0].FloorNumber.Should().Be(5);
    }

    [Fact]
    public void FloorOptions_ShouldReset_AfterMoving()
    {
        var floor = _elevator.Floors[2];
        _operator.GoingUp(floor);
        _operator.FloorOptions.Count.Should().Be(2);
        
        _operator.SelectFloor(floor);
        _operator.FloorOptions.Count.Should().Be(4);

        _operator.FloorOptions.Where(f => f == floor).ToList().Count.Should().Be(0);
    }
    
}