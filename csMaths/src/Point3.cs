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
    }
}
