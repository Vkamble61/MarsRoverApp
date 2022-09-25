using MarsRover.Models;
using FluentAssertions;

namespace MarsRover.Test
{
    public class MarsRoverTests
    {
        private Rover rover;
        private Plateau plateau;

        [SetUp]
        public void Setup()
        {
            rover = new Rover();
            plateau = new Plateau();
        }

        [Test]
        // Grid coordinates should be more than 0()
        public void Check_Plateau_Grid_Coordinates()
        {
            plateau.SetPlateauGrid(5, 5).Should().Be(true);
            plateau.SetPlateauGrid(5, 0).Should().Be(false);
            plateau.SetPlateauGrid(0, 5).Should().Be(false);
            plateau.SetPlateauGrid(0, 0).Should().Be(false);            
        }

        [Test]
        public void Check_RoverPosition()
        {
            rover.SetRoverPosition("12N").Should().Be(true);
          //  rover.SetRoverPosition("12N3").Should().Be(false);
            rover.SetRoverPosition("1N").Should().Be(false);
            rover.SetRoverPosition("1E2").Should().Be(false);
        }
        [Test]
        public void Check_CommandInstructions()
        {
            rover.GiveRoverCommand("MMRRLL").Should().Be(true);
            rover.GiveRoverCommand("M56L").Should().Be(false);
            rover.GiveRoverCommand("").Should().Be(false);
        }
        [Test]
        public void Check_ProcessCommand()
        {
            rover.ProcessCommand("12N","LMLMLMLMM").Should().Be("13N");
            rover.ProcessCommand("33E","MMRMMRMRRM").Should().Be("51E");
            rover.ProcessCommand("43S", "LLMMRRMMM").Should().Be("42S");
            rover.ProcessCommand("23W", "LLRRLL").Should().Be("23E");            
        }
    }

}