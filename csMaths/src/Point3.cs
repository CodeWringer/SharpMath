using System.Diagnostics;

namespace Tools.Maths.Geometry
{
    /// <summary>
    /// Represents a collection of three coordinates, for use in three dimensional space. 
    /// </summary>
    [DebuggerDisplay("\\{X = {X} Y = {Y} Z = {Z}\\}")]
    public struct Point3I
    {
        public int X;
        public int Y;
        public int Z;

        public Point3I(int x, int y, int z)
        {
            this.X = x;
            this.Y = y;
            this.Z = z;
        }

        #region Operators

        #region Unary

        public static Point3I operator +(Point3I left, Point3I right)
        {
            return new Point3I(left.X + right.X, left.Y + right.Y, left.Z + right.Z);
        }

        public static Point3I operator +(Point3I left, int number)
        {
            return new Point3I(left.X + number, left.Y + number, left.Z + number);
        }

        public static Point3I operator -(Point3I left, Point3I right)
        {
            return new Point3I(left.X - right.X, left.Y - right.Y, left.Z - right.Z);
        }

        public static Point3I operator -(Point3I left, int number)
        {
            return new Point3I(left.X - number, left.Y - number, left.Z - number);
        }

        public static Point3I operator *(Point3I left, int number)
        {
            return new Point3I(left.X * number, left.Y * number, left.Z * number);
        }

        public static Point3I operator /(Point3I left, int number)
        {
            return new Point3I(left.X / number, left.Y / number, left.Z / number);
        }

        #endregion Unary

        #region Comparison

        public static bool operator ==(Point3I left, Point3I right)
        {
            if (left.X != right.X || left.Y != right.Y || left.Z != right.Z)
                return false;
            else
                return true;
        }

        public static bool operator !=(Point3I left, Point3I right)
        {
            if (left.X == right.X && left.Y == right.Y && left.Z == right.Z)
                return false;
            else
                return true;
        }
        
        #endregion Comparison

        #endregion Operators

        public override string ToString()
        {
            return string.Format("{X = {0} Y = {1} Z = {2}}", X, Y, Z);
        }
    }

    /// <summary>
    /// Represents a collection of three coordinates, for use in three dimensional space. 
    /// </summary>
    [DebuggerDisplay("\\{X = {X} Y = {Y} Z = {Z}\\}")]
    public struct Point3F
    {
        public float X;
        public float Y;
        public float Z;

        public Point3F(float x, float y, float z)
        {
            this.X = x;
            this.Y = y;
            this.Z = z;
        }

        #region Operators

        #region Unary

        public static Point3F operator +(Point3F left, Point3F right)
        {
            return new Point3F(left.X + right.X, left.Y + right.Y, left.Z + right.Z);
        }

        public static Point3F operator +(Point3F left, int number)
        {
            return new Point3F(left.X + number, left.Y + number, left.Z + number);
        }

        public static Point3F operator -(Point3F left, Point3F right)
        {
            return new Point3F(left.X - right.X, left.Y - right.Y, left.Z - right.Z);
        }

        public static Point3F operator -(Point3F left, int number)
        {
            return new Point3F(left.X - number, left.Y - number, left.Z - number);
        }

        public static Point3F operator *(Point3F left, int number)
        {
            return new Point3F(left.X * number, left.Y * number, left.Z * number);
        }

        public static Point3F operator /(Point3F left, int number)
        {
            return new Point3F(left.X / number, left.Y / number, left.Z / number);
        }

        #endregion Unary

        #region Comparison

        public static bool operator ==(Point3F left, Point3F right)
        {
            if (left.X != right.X || left.Y != right.Y || left.Z != right.Z)
                return false;
            else
                return true;
        }

        public static bool operator !=(Point3F left, Point3F right)
        {
            if (left.X == right.X && left.Y == right.Y && left.Z == right.Z)
                return false;
            else
                return true;
        }

        #endregion Comparison

        #endregion Operators

        public override string ToString()
        {
            return string.Format("{X = {0} Y = {1} Z = {2}}", X, Y, Z);
        }
    }

    /// <summary>
    /// Represents a collection of three coordinates, for use in three dimensional space. 
    /// </summary>
    [DebuggerDisplay("\\{X = {X} Y = {Y} Z = {Z}\\}")]
    public struct Point3D
    {
        public double X;
        public double Y;
        public double Z;

        public Point3D(double x, double y, double z)
        {
            this.X = x;
            this.Y = y;
            this.Z = z;
        }

        #region Operators

        #region Unary

        public static Point3D operator +(Point3D left, Point3D right)
        {
            return new Point3D(left.X + right.X, left.Y + right.Y, left.Z + right.Z);
        }

        public static Point3D operator +(Point3D left, int number)
        {
            return new Point3D(left.X + number, left.Y + number, left.Z + number);
        }

        public static Point3D operator -(Point3D left, Point3D right)
        {
            return new Point3D(left.X - right.X, left.Y - right.Y, left.Z - right.Z);
        }

        public static Point3D operator -(Point3D left, int number)
        {
            return new Point3D(left.X - number, left.Y - number, left.Z - number);
        }

        public static Point3D operator *(Point3D left, int number)
        {
            return new Point3D(left.X * number, left.Y * number, left.Z * number);
        }

        public static Point3D operator /(Point3D left, int number)
        {
            return new Point3D(left.X / number, left.Y / number, left.Z / number);
        }

        #endregion Unary

        #region Comparison

        public static bool operator ==(Point3D left, Point3D right)
        {
            if (left.X != right.X || left.Y != right.Y || left.Z != right.Z)
                return false;
            else
                return true;
        }

        public static bool operator !=(Point3D left, Point3D right)
        {
            if (left.X == right.X && left.Y == right.Y && left.Z == right.Z)
                return false;
            else
                return true;
        }

        #endregion Comparison

        #endregion Operators

        public override string ToString()
        {
            return string.Format("{X = {0} Y = {1} Z = {2}}", X, Y, Z);
        }
    }
}
