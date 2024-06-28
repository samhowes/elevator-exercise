using ElevatorConsole;
using FluentAssertions;

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
    public void GetCommands_ShouldHaveTwoCallTo()
    {
        var commands = _operator.GetCommands()
            .Where(c => c.Operation == ElevatorOperation.CallTo)
            .ToList();

        commands.Count.Should().Be(2);

        commands[0].Floor.FloorNumber.Should().Be(1);
        commands[1].Floor.FloorNumber.Should().Be(5);
    }

    [Fact]
    public void ExecuteCommand_ThrowsWhen_CallingToFloorWithoutCallButton()
    {
        var command = new ElevatorCommand(_elevator.Floors[1], ElevatorOperation.CallTo, "");

        var func = () => _operator.ExecuteCommand(command);
        func.Should().Throw<Exception>();
    }
}