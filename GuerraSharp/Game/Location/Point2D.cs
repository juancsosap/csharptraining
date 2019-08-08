using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Location
{
    class Point2D
    {
        private double x, y;
        public double X { get => this.x; set => this.x = value; }
        public double Y { get => this.y; set => this.y = value; }

        public Point2D(double x = 0, double y = 0)
        {
            this.x = x;
            this.y = y;
        }

        public static double operator- (Point2D p1, Point2D p2)
        {
            double dx2 = Math.Pow(p2.x - p1.X, 2);
            double dy2 = Math.Pow(p2.Y - p1.Y, 2);
            
            return Math.Sqrt(dx2 + dy2);
        }

        public static Point2D operator+ (Point2D p1, Point2D p2)
        {
            double x = p2.x + p1.X;
            double y = p2.Y + p1.Y;
            
            return new Point2D(x, y);
        }

    }
}