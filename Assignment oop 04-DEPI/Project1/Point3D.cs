
using System;

namespace Assignment04Project1
{
    public class Point3D : IComparable<Point3D>, ICloneable
    {
        public int X { get; set; }
        public int Y { get; set; }
        public int Z { get; set; }


        // Constructors

        public Point3D() : this(0, 0, 0)
        {
        }

        public Point3D(int x) : this(x, 0, 0)
        {
        }

        public Point3D(int x, int y) : this(x, y, 0)
        {
        }

        public Point3D(int x, int y, int z)
        {
            X = x;
            Y = y;
            Z = z;
        }


        // ToString

        public override string ToString()
        {
            return string.Format(
                "Point Coordinates: ({0}, {1}, {2})",
                X, Y, Z
            );
        }


        // Compare Points

        public int CompareTo(Point3D other)
        {
            if (other == null)
                return 1;

            if (X != other.X)
                return X.CompareTo(other.X);

            if (Y != other.Y)
                return Y.CompareTo(other.Y);

            return Z.CompareTo(other.Z);
        }


        // Clone

        public object Clone()
        {
            return new Point3D(X, Y, Z);
        }
    }
}