using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace MarsRover.Models
{
    public enum Direction { N, W, S, E };
    public class Rover
    {
        private int _startingX = 0, _startingY = 0;

        private Direction _startingDir = Direction.N;

        private int roverCurrentPos_X = 0, roverCurrentPos_Y = 0;
        private Point roverCurrentPos { get; set; }
        private Direction roverCurrentDir { get; set; }

        public Plateau plateau = new();

        public Rover()
        {
            roverCurrentPos = new Point(_startingX, _startingY);
            roverCurrentDir = _startingDir;
        }
        public bool SetRoverPosition(string input)
        {
           
            if (input != null)
            {
                if (int.TryParse(input[0].ToString(), out int X)) 
                    roverCurrentPos_X = X;
                else 
                    return false;

                if (int.TryParse(input[1].ToString(), out int Y)) 
                    roverCurrentPos_Y = Y;
                else 
                    return false;

                roverCurrentPos = new Point(roverCurrentPos_X, roverCurrentPos_Y);

                if (input[2].ToString().ToUpper() == "N")
                    roverCurrentDir = Direction.N;
                if (input[2].ToString().ToUpper() == "W")
                    roverCurrentDir = Direction.W;
                if (input[2].ToString().ToUpper() == "S")
                    roverCurrentDir = Direction.S;
                if (input[2].ToString().ToUpper() == "E")
                    roverCurrentDir = Direction.E;

                displayRoverPosition(roverCurrentPos, roverCurrentDir);
                return true;
            }
            return false;
        }

        public bool GiveRoverCommand(string command)
        {
            if (!String.IsNullOrWhiteSpace(command))
            {
                foreach (char ch in command)
                    if (!Char.IsLetter(ch)) return false;
            }
            else
                return false;
            return true;
        }

        public string ProcessCommand(string roverPosition, string roverCommand)
        {
            
            Console.WriteLine("Rover Initial Position: " + roverPosition);
            Console.WriteLine("Rover Command: " + roverCommand);
            if (roverCommand != null && SetRoverPosition(roverPosition) && GiveRoverCommand(roverCommand))
            {
                bool lastMoveSuccess = true;

                foreach (char ch in roverCommand)
                {
                    
                    if (lastMoveSuccess == false)
                        break;

                    
                    switch (ch)
                    {
                        case 'M':
                            lastMoveSuccess = MoveRoverForward();
                            break;

                        case 'L':
                            SpinRoverLeft();
                            break;

                        case 'R':
                            SpinRoverRight();
                            break;
                    }
                }
            }
            
            return displayRoverPosition(roverCurrentPos, roverCurrentDir);
        }
       /* public void assignGrid(Plateau plateau)
        {
            this.plateau = plateau;

            if (plateau.obstacles.Contains(roverCurrentPos))
            {
                Console.Write("Grid has obstacle at rover starting position. Landed rover at ");
                
                while (plateau.obstacles.Contains(roverCurrentPos))
                    MoveRoverForward();

                Console.Write("(" + roverCurrentPos.X + ", " + roverCurrentPos.Y + ") instead\n");
            }
        }*/


        public bool MoveRoverForward()
        {
            switch (roverCurrentDir)
            {
                case Direction.N: incrementY(); break;

                case Direction.W: decrementX(); break;

                case Direction.S: decrementY(); break;

                case Direction.E: incrementX(); break;
            }

             
           /*if (plateau.obstacles.Contains(roverCurrentPos))
             {
                 Console.WriteLine("Cannot move forward. Obstacle present ahead at (" + roverCurrentPos.X + ", " + roverCurrentPos.Y + ")");
                
                 return false;
             }*/

            return true;
        }


        public void SpinRoverLeft()
        {
            switch (roverCurrentDir)
            {
                case Direction.N: roverCurrentDir = Direction.W; break;

                case Direction.W: roverCurrentDir = Direction.S; break;

                case Direction.S: roverCurrentDir = Direction.E; break;

                case Direction.E: roverCurrentDir = Direction.N; break;

            }
        }

        public void SpinRoverRight()
        {
            switch (roverCurrentDir)
            {
                case Direction.N: roverCurrentDir = Direction.E; break;

                case Direction.W: roverCurrentDir = Direction.N; break;

                case Direction.S: roverCurrentDir = Direction.W; break;

                case Direction.E: roverCurrentDir = Direction.S; break;

            }
        }

        private void incrementX() => roverCurrentPos = new Point(roverCurrentPos.X + 1, roverCurrentPos.Y);
        private void decrementX() => roverCurrentPos = new Point(roverCurrentPos.X - 1, roverCurrentPos.Y);
        private void incrementY() => roverCurrentPos = new Point(roverCurrentPos.X, roverCurrentPos.Y + 1);
        private void decrementY() => roverCurrentPos = new Point(roverCurrentPos.X, roverCurrentPos.Y - 1);

        public string displayRoverPosition(Point roverPosition, Direction roverDirection) => roverPosition.X.ToString() + roverPosition.Y + roverCurrentDir;

    }
}