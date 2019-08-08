using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Location
{
    class Point1D : IPoint
    {
        private double x;
        public double X { get => this.x; set => this.x = value; }
        
        public Point1D(double x = 0) => this.x = x;

        public static double operator -(Point1D p1, Point1D p2) => Math.Abs(p2.X - p1.X);

        public static Point1D operator+ (Point1D p1, Point1D p2) => new Point1D(p2.X + p1.X);

    }
}