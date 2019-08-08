using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Location
{
    class Point3D : IPoint
    {
        private double x, y, z;
        public double X { get => this.x; set => this.x = value; }
        public double Y { get => this.y; set => this.y = value; }
        public double Z { get => this.z; set => this.z = value; }

        public Point3D(double x = 0, double y = 0, double z = 0)
        {
            this.x = x;
            this.y = y;
            this.z = z;
        }

        public static double operator- (Point3D p1, Point3D p2)
        {
            double dx2 = Math.Pow(p2.x - p1.X, 2);
            double dy2 = Math.Pow(p2.Y - p1.Y, 2);
            double dz2 = Math.Pow(p2.Z - p1.Z, 2);

            return Math.Sqrt(dx2 + dy2 + dz2);
        }

        public static Point3D operator+ (Point3D p1, Point3D p2)
        {
            double x = p2.x + p1.X;
            double y = p2.Y + p1.Y;
            double z = p2.Z + p1.Z;

            return new Point3D(x, y, z);
        }

    }
}