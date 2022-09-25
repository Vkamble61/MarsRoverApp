using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace MarsRover.Models
{
    public class Plateau
    {
        private int _minX { get; set; }
        public int maxX { get; private set; }
        private int _minY { get; set; }
        public int maxY { get; private set; }
        

        //public HashSet<Point> obstacles { get; private set; }  


        public Plateau()
        {
            this._minX = 0;            
            this._minY = 0;
                         
             /*int numObstacles = ((maxX - _minX) * (maxY - _minY)) / 10;
             obstacles = new HashSet<Point>();

             Random rand = new Random(); 
             int index = 1;
             while (index <= numObstacles)
             {
                 
                 Point p = new Point(rand.Next(_minX, maxX + 1), rand.Next(_minY, maxY + 1));
                 if (!obstacles.Contains(p))
                 {
                     obstacles.Add(p);
                     index++;
                 }
             }*/
        }
        public bool SetPlateauGrid(int X, int Y)
        {
            if (X <= _minX || Y <= _minY)  
                return false;            
            else
            {
                this.maxX = X;
                this.maxY = Y;
                return true;
            }
        }
        
        /*public void showObstacles()
        {
            foreach (Point p in obstacles)
                Console.WriteLine("(" + p.X + ", " + p.Y + ")");
        }*/
    }
}