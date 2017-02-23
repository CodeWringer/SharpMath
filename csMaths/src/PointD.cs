using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime;

namespace Tools.Maths
{
    /// <summary>
    /// Represents an ordered pair of double x- and y-coordinates that defines a point in a two-dimensional plane.
    /// </summary>
    [TypeConverter(typeof(PointConverter))]
    [DebuggerDisplay("\\{ X = {X} Y = {Y} \\}")]
    public struct PointD
    {
        /*****************************************************************/
        // Declarations
        /*****************************************************************/
        #region Declarations

        /// <summary>
        /// Gets a value indicating whether this PointD is empty.
        /// </summary>
        [Browsable(false)]
        public bool IsEmpty { get; }

        /// <summary>
        /// Gets or sets the x-coordinate of this PointD.
        /// </summary>
        public double X { get; set; }

        /// <summary>
        /// Gets or sets the y-coordinate of this PointD.
        /// </summary>
        public double Y { get; set; }

        #endregion Declarations
        /*****************************************************************/
        // Constructors
        /*****************************************************************/
        #region Constructors

        /// <summary>
        /// Initializes a new instance of the PointD struct with the specified coordinates. 
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public PointD(double x, double y)
        {
            this.X = x;
            this.Y = y;
            this.IsEmpty = (x != 0 && y != 0) ? true : false;
        }

        #endregion Constructors
        /*****************************************************************/
        // Methods
        /*****************************************************************/
        #region Methods

        /// <summary>
        /// Converts the specified PointD to a Point by truncating the values of the given PointD. 
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static Point Truncate(PointD value)
        {
            return new Point((int)value.X, (int)value.Y);
        }

        /// <summary>
        /// Returns true, if the given object is a PointD and contains the same coordinates as this PointD. 
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
            if (obj is Point)
            {
                Point pnt = (Point)obj;
                if (pnt.X == this.X && pnt.Y == this.Y)
                    return true;
            }
            else if (obj is PointF)
            {
                PointF pnt = (PointF)obj;
                if (pnt.X == this.X && pnt.Y == this.Y)
                    return true;
            }
            else if (obj is PointD)
            {
                PointD pnt = (PointD)obj;
                if (pnt.X == this.X && pnt.Y == this.Y)
                    return true;
            }
            return false;
        }

        /// <summary>
        /// Returns a hash code for this PointD.
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            return this.X.GetHashCode() + this.Y.GetHashCode();
        }

        /// <summary>
        /// Translates this PointD by the specified PointD.
        /// </summary>
        /// <param name="p"></param>
        public void Offset(PointD p)
        {
            this.X += p.X;
            this.Y += p.Y;

        }

        /// <summary>
        /// Translates this PointD by the specified amount.
        /// </summary>
        /// <param name="dx"></param>
        /// <param name="dy"></param>
        [TargetedPatchingOptOut("Performance critical to inline across NGen image boundaries")]
        public void Offset(double dx, double dy)
        {
            this.X += dx;
            this.Y += dy;
        }

        /// <summary>
        /// Converts this PointD to a human-readable string.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return string.Format("\\{ X = {0} Y = {1} \\}", this.X, this.Y);
        }

        /// <summary>
        /// Compares the two PointD objects. The result specifies whether the values of the PointD.X or PointD.Y properties 
        /// of the two PointD are equal. 
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns>
        /// True if the PointD.X and PointD.Y values of left and right are equal; otherwise, false.
        /// </returns>
        [TargetedPatchingOptOut("Performance critical to inline across NGen image boundaries")]
        public static bool operator ==(PointD left, PointD right)
        {
            if (left.X == right.X && left.Y == right.Y)
                return true;
            else
                return false;
        }

        /// <summary>
        /// Compares the two PointD objects. The result specifies whether the values of the PointD.X or PointD.Y properties 
        /// of the two PointD are unequal. 
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns>
        /// True if the PointD.X and PointD.Y values of left and right are unequal; otherwise, false.
        /// </returns>
        [TargetedPatchingOptOut("Performance critical to inline across NGen image boundaries")]
        public static bool operator !=(PointD left, PointD right)
        {
            if (left.X == right.X && left.Y == right.Y)
                return false;
            else
                return true;
        }

        /// <summary>
        /// Converts the specified PointD structure to a System.Drawing.PointF structure.
        /// </summary>
        /// <param name="p"></param>
        public static implicit operator PointF(PointD p)
        {
            return new PointF((float)p.X, (float)p.Y);
        }

        /// <summary>
        /// Converts the specified PointD structure to a System.Drawing.PointF structure.
        /// </summary>
        /// <param name="p"></param>
        public static implicit operator Point(PointD p)
        {
            return new Point((int)p.X, (int)p.Y);
        }

        #endregion Methods
    }
}