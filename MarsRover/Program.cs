using MarsRover.Models;


Plateau plateau = new();
Rover rover = new();

Console.WriteLine("Welcome to Mars: ");

plateau.SetPlateauGrid(10, 10);
Console.WriteLine("Rover Current Position " + rover.ProcessCommand("12N", "LMLMLMLMM") +"\n");
Console.WriteLine("Rover Current Position " + rover.ProcessCommand("33E", "MMRMMRMRRM") + "\n");
Console.WriteLine("Rover Current Position "+rover.ProcessCommand("43S", "LLMMRRMMM") + "\n");
Console.WriteLine("Rover Current Position " + rover.ProcessCommand("81N", "LLMMRRMMM") + "\n");
Console.WriteLine("Rover Current Position "+rover.ProcessCommand("23W", "LLRRLL") + "\n");

