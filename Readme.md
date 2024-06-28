# Elevator Exercise

## Quickstart

> Note: this code was written with the dotnet 8 sdk.

1. Run the tests: `cd ElevatorTests && dotnet test`
2. Run the Blazor App: `cd ElevatorWeb && dotnet run` then open a browser on the port output to console

## Assignment

Write an application in C# that will control an elevator. This application should maintain
the state of the elevator position, movement, the doors, as well as respond to the
controls inside and out while simulating the elevator operation.

There are five floors. The first and fifth floors have a call button to bring the elevator to
that floor. The second, third and fourth floor have up/down buttons that call the
elevator to the floor.

Inside the elevator there are five buttons representing each of the floors. For simplicity
there are no other buttons. For example, there are no buttons for emergency stop,
open door, or close door. Furthermore we can omit any other mechanisms such as door
sensors.

This application should demonstrate the following.

1. Good object oriented design
2. Readable code
3. Automated Testing (you may choose Nunit, MStest/vstest, xunit, …)
   You may make any kind of application that you choose (Web, Console, and GUI) so long
   as internally it demonstrates the above requirements.

## Implementation

The assignment is implemented as a Blazor Web Application. The Web interface can be found in the `ElevatorWeb` folder,
the elevator logic can be found in the `ElevatorLib` folder, and the tests can be found in the `ElevatorTests` folder.
The state information of the Elevator is maintained on the `Elevator` class while the logic of the user interactions
with the buttons internal and external to the Elevator is maintained in the `ElevatorOperator` class.

The elevator initializes its position to the first floor with the doors open and a "Stationary" position. When an
elevator is called to a specific floor with the `Up` or `Down` buttons, only floors above or below the current floor 
respectively are available for selection in the interface. After a completed selection and movement of the elevator the 
options are reset to allow a user inside the elevator to select any floor other than the current floor.