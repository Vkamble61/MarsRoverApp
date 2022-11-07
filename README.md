# MarsRoverApp
MarsRoverApp is a C# Console App with NUnit Test project. It has two classes Rover.cs and Plateau.cs located in Models folder.
#  Plateau.cs
The constructor will set the Minimum X and Y co-ordinates.
SetPlateauGrid(int X, int Y) will set the grid with Maximum X & Y co-ordinates.
# Rover.cs
This class mainly take care of Rover Movements on grid.
Rover constructor will set by default position for rover.
SetRoverPosition()- It will set Rover position according to input coordinates.
GiveRoverCommand()- It will validate Rover input command.
ProcessCommand() - It will help rover to follow command by calling MoveRoverForward(), SpinRoverLeft(), SpinRoverRight() and display current position by calling displayRoverPosition().
