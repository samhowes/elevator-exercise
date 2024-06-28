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
    
}