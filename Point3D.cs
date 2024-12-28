using System;

namespace Project3C_
{
    public class Point3D : IComparable<Point3D>, ICloneable
    {
        public int x { get; set; } 
        public int y { get; set; } 
        public int z { get; set; }

        public Point3D() // Default constructor
        {
            x = 0;
            y = 0;
            z = 0;
        }
        public Point3D(int _x) // Parameterized constructor
        {  
            x = _x; 
        }
        public Point3D(int _x, int _y) : this(_x) // chaining
        {
            y = _y;
        }
        public Point3D(int _x, int _y, int _z) : this(_x, _y) // chaining
        {
            z = _z;
        }
        public Point3D(Point3D point) // Copy constructor
        {
            this.x = point.x;
            this.y = point.y;
            this.z = point.z;
        }


        public override string ToString() // Override ToString function
        {
            return $"({x}, {y}, {z})";
        }

        public override bool Equals(object? obj)
        {
            Point3D p = obj as Point3D ?? new Point3D();

            return (p.x == this.x && p.y == this.y && p.z == this.z); 
        }

        public int CompareTo(Point3D other)
        {
            if (this.x < other.x) return -1;
            if (this.x > other.x) return 1;

            if (this.y < other.y) return -1;
            if (this.y > other.y) return 1;

            return 0;
        }

        public object Clone()
        {
            return new Point3D(this.x, this.y, this.z);
        }
    }
}

