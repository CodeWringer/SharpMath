using System;
using System.Drawing;
using System.Diagnostics;

namespace Tools.Maths.Vector2
{
    /// <summary>
    /// Represents a vector in two dimensional space. 
    /// </summary>
    [DebuggerDisplay("X: {X}, Y: {Y}")]
    public class csVector2
    {
        /*****************************************************************/
        // Declarations
        /*****************************************************************/
        #region Declarations

        /// <summary>
        /// X component of this vector. 
        /// </summary>
        public double X;

        /// <summary>
		/// Y component of this vector. 
        /// </summary>
        public double Y;

        #endregion Declarations
        /*****************************************************************/
        // Constructors
        /*****************************************************************/
        #region Constructors

        /// <summary>
        /// Creates a new vector, with the given x and y values. 
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public csVector2(double x, double y)
        {
            this.X = x;
            this.Y = y;
        }

        /// <summary>
        /// Creates a new vector with default values. 
        /// </summary>
        public csVector2()
            : this(0, 0)
        {
        }

        /// <summary>
        /// Creates a new vector, based on the translation (distance) from the first point to the second point. 
        /// </summary>
        /// <param name="pntA"></param>
        /// <param name="pntB"></param>
        public csVector2(Point pntA, Point pntB)
            : this(pntB.X - pntA.X, pntB.Y - pntA.Y)
        {
        }

        /// <summary>
        /// Creates a new vector, based on the translation (distance) from the first point to the second point. 
        /// </summary>
        /// <param name="pntA"></param>
        /// <param name="pntB"></param>
        public csVector2(PointF pntA, PointF pntB)
            : this(pntB.X - pntA.X, pntB.Y - pntA.Y)
        {
        }

        /// <summary>
        /// Creates a new vector, based on the given vector. 
        /// </summary>
        /// <param name="vect"></param>
        public csVector2(csVector2 vect)
            : this(vect.X, vect.Y)
        {

        }

        #endregion Constructors
        /*****************************************************************/
        // Methods
        /*****************************************************************/
        #region Methods

        /// <summary>
        /// Returns the scalar (dot) product of the given vectors. 
        /// </summary>
        /// <remarks>
        /// Is the sign of the returned value positive, are both vectors facing in the same direction. 
        /// Is the sign of the returned value negative, are both vectors facing opposite directions. 
        /// Is the returned value equal 0, are both vectors orthogonal to one another. 
        /// </remarks>
        /// <param name="vectA">A vector. </param>
        /// <param name="vect">A vector. </param>
        public double GetDotProduct(csVector2 vect)
        {
            // scalar = (a.x*b.x + a.y*b.y)
            // vectorA * vectorB = a * b cos(alpha)
            // vectorA * vectorB = (a.x * b.x) + (a.y * b.y)

            return ((this.X * vect.X) + (this.Y * vect.Y));
        }

        /// <summary>
        /// Returns the scalar product of the given vectors. 
        /// </summary>
        /// <remarks>
        /// Is the sign of the returned value positive, are both vectors facing in the same direction. 
        /// Is the sign of the returned value negative, are both vectors facing opposite directions. 
        /// Is the returned value equal 0, are both vectors orthogonal to one another. 
        /// </remarks>
        /// <param name="vectA">A vector. </param>
        /// <param name="vectB">A vector. </param>
        /// <returns></returns>
        public static double GetDotProduct(csVector2 vectA, csVector2 vectB)
        {
            return vectA.GetDotProduct(vectB);
        }
        
        /// <summary>
        /// Returns the magnitude (absolute length) of the vector. 
        /// </summary>
        public double GetMagnitude()
        {
            return (Math.Sqrt((this.X * this.X) + (this.Y * this.Y)));
        }

        /// <summary>
        /// Returns the magnitude (absolute length) of the given vector. 
        /// </summary>
        /// <param name="vect">A vector. </param>
        public static double GetMagnitude(csVector2 vect)
        {
            return vect.GetMagnitude();
        }

        /// <summary>
        /// Projects this vector onto the given vector and returns the projection. 
        /// </summary>
        /// <param name="vect">A vector to be projected on. </param>
        public csVector2 Project(csVector2 vect)
        {
            // scalar = (a.x*b.x + a.y*b.y)
            // proj.x = ( scalar / (b.x*b.x + b.y*b.y) * b.x );
            // proj.y = ( scalar / (b.x*b.x + b.y*b.y) * b.y );

            // If b is a unit vector: 
            // proj.x = scalar*b.x;
            // proj.y = scalar*b.y;

            csVector2 vectProjected = new csVector2(0, 0);
            double dScalar = csVector2.GetDotProduct(this, vect);

            //if (bIsUnitVector)
            //{
            //    vectProjected.X = (dScalar * vectB.X);
            //    vectProjected.Y = (dScalar * vectB.Y);
            //    return vectProjected;
            //}
            //else
            //{
            vectProjected.X = (dScalar / (vect.X * vect.X + vect.Y * vect.Y)) * vect.X;
            vectProjected.Y = (dScalar / (vect.X * vect.X + vect.Y * vect.Y)) * vect.Y;

            return vectProjected;
            //}
        }

        /// <summary>
        /// Projects vector A onto vector B and returns the projection. 
        /// </summary>
        /// <param name="vectA">A vector to project. </param>
        /// <param name="vectB">A vector to be projected on. </param>
        public static csVector2 Project(csVector2 vectA, csVector2 vectB)
        {
            return vectA.Project(vectB);
        }

        /// <summary>
        /// Returns the cosine angle between this vector and the given vector. 
        /// </summary>
        /// <param name="vect"></param>
        /// <returns></returns>
        public double GetAngleCos(csVector2 vect)
        {
            // cos alpha = (vectorA*vectorB) / (|vectorA|*|vectorB|)
            // cos alpha = ((a.x*b.x) + (a.y*b.y)) / (Math.sqrt(a.x²+a.y²) * Math.sqrt(b.x²+b.y²))
            return (this.GetDotProduct(vect) / (this.GetMagnitude() * vect.GetMagnitude()));
        }

        /// <summary>
        /// Returns the cosine angle between this vector and the given vector. 
        /// </summary>
        /// <param name="vectA"></param>
        /// <param name="vectB"></param>
        /// <returns></returns>
        public static double GetAngleCos(csVector2 vectA, csVector2 vectB)
        {
            return vectA.GetAngleCos(vectB);
        }

        /// <summary>
        /// Returns the degrees angle between this vector and the given vector. 
        /// </summary>
        /// <param name="vect"></param>
        /// <returns></returns>
        public double GetAngleDeg(csVector2 vect)
        {
            return this.GetAngleCos(vect) / csMaths.DEG_TO_RAD;
        }

        /// <summary>
        /// Returns the degrees angle between the given vectors. 
        /// </summary>
        /// <param name="vectA"></param>
        /// <param name="vectB"></param>
        /// <returns></returns>
        public static double GetAngleDeg(csVector2 vectA, csVector2 vectB)
        {
            return vectA.GetAngleDeg(vectB);
        }

        /// <summary>
        /// Returns a normalized (unit length) vector, based on this vector. 
        /// </summary>
        /// <returns></returns>
        public csVector2 GetNormalized()
        {
            // 1. Get vector magnitude. 
            // 2. Divide each of its components (xy) or (xyz) by the magnitude. 
            double dMagnitude = this.GetMagnitude();

            return new csVector2(this.X / dMagnitude, this.Y / dMagnitude);
        }

        /// <summary>
        /// Returns a normalized (unit length) vector, based on the given vector. 
        /// </summary>
        /// <returns></returns>
        public static csVector2 GetNormalized(csVector2 vect)
        {
            return vect.GetNormalized();
        }

        /// <summary>
        /// Returns a scaled vector, based on this vector and the given factor. 
        /// </summary>
        /// <param name="dFactor"></param>
        /// <returns></returns>
        public csVector2 GetScaled(double dFactor)
        {
            return new csVector2(this.X * dFactor, this.Y * dFactor);
        }

        /// <summary>
        /// Returns a scaled vector, based on the given vector and the given factor. 
        /// </summary>
        /// <param name="dFactor"></param>
        /// <returns></returns>
        public static csVector2 GetScaled(csVector2 vect, double dFactor)
        {
            return vect.GetScaled(dFactor);
        }

        /// <summary>
        /// Returns a rotated vector, based on this vector. 
        /// </summary>
        /// <param name="dAngle">An angle, in degrees. </param>
        /// <returns></returns>
        public csVector2 GetRotated(double dAngle)
        {
            //(x cos alpha + y sin alpha, -x sin alpha + y cos alpha)
            double dAngleRad = csMaths.GetAngleRad(dAngle);
            double cos = Math.Cos(dAngleRad);
            double sin = Math.Sin(dAngleRad);

            return new csVector2((this.X * cos) + (this.Y * sin), (-this.X * sin) + (this.Y * cos));
        }

        /// <summary>
        /// Returns a rotated vector, based on the given vector. 
        /// </summary>
        /// <param name="dAngle">An angle, in degrees. </param>
        /// <returns></returns>
        public static csVector2 GetRotated(csVector2 vect, double dAngle)
        {
            return vect.GetRotated(dAngle);
        }

        /// <summary>
        /// Returns a vector perependicular to this vector. 
        /// The returned vector can be considered rotated counter-clockwise by 90 degrees. 
        /// </summary>
        /// <returns></returns>
        public csVector2 GetPerpendicular()
        {
            return new csVector2(-this.Y, this.X);
        }

        /// <summary>
        /// Returns a vector perependicular to the given vector. 
        /// The returned vector can be considered rotated counter-clockwise by 90 degrees. 
        /// </summary>
        /// <returns></returns>
        public static csVector2 GetPerpendicular(csVector2 vect)
        {
            return vect.GetPerpendicular();
        }

        #endregion Methods
        /*****************************************************************/
        // Operators
        /*****************************************************************/
        #region Operators

        public static csVector2 operator +(csVector2 vectA, csVector2 vectB)
        {
            return new csVector2(vectA.X + vectB.X, vectA.Y + vectB.Y);
        }

        public static csVector2 operator +(csVector2 vect, Point pnt)
        {
            return new csVector2(vect.X + pnt.X, vect.Y + pnt.Y);
        }

        public static csVector2 operator +(csVector2 vect, PointF pnt)
        {
            return new csVector2(vect.X + pnt.X, vect.Y + pnt.Y);
        }

        public static csVector2 operator -(csVector2 vectA, csVector2 vectB)
        {
            return new csVector2(vectA.X - vectB.X, vectA.Y - vectB.Y);
        }

        public static csVector2 operator -(csVector2 vect, Point pnt)
        {
            return new csVector2(vect.X - pnt.X, vect.Y - pnt.Y);
        }

        public static csVector2 operator -(csVector2 vect, PointF pnt)
        {
            return new csVector2(vect.X - pnt.X, vect.Y - pnt.Y);
        }

        public static csVector2 operator *(csVector2 vectA, csVector2 vectB)
        {
            return new csVector2(vectA.X * vectB.X, vectA.Y * vectB.Y);
        }

        public static csVector2 operator *(csVector2 vect, Point pnt)
        {
            return new csVector2(vect.X * pnt.X, vect.Y * pnt.Y);
        }

        public static csVector2 operator *(csVector2 vect, PointF pnt)
        {
            return new csVector2(vect.X * pnt.X, vect.Y * pnt.Y);
        }

        public static csVector2 operator /(csVector2 vectA, csVector2 vectB)
        {
            return new csVector2(vectA.X / vectB.X, vectA.Y / vectB.Y);
        }

        public static csVector2 operator /(csVector2 vect, Point pnt)
        {
            return new csVector2(vect.X / pnt.X, vect.Y / pnt.Y);
        }

        public static csVector2 operator /(csVector2 vect, PointF pnt)
        {
            return new csVector2(vect.X / pnt.X, vect.Y / pnt.Y);
        }

        #endregion Operators
        /*****************************************************************/
        // Events
        /*****************************************************************/
        #region Events

        #endregion Events
    }
}
