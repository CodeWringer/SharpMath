using System;
using System.Drawing;
using System.Diagnostics;

namespace Tools.Math.Geometry
{
    /// <summary>
    /// Represents a vector in two dimensional space. 
    /// </summary>
    [DebuggerDisplay("X: {X}, Y: {Y}")]
    public class Vector2D
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
        public Vector2D(double x, double y)
        {
            this.X = x;
            this.Y = y;
        }

        /// <summary>
        /// Creates a new vector with default values. 
        /// </summary>
        public Vector2D()
            : this(0, 0)
        {
        }

        /// <summary>
        /// Creates a new vector, based on the translation (distance) from the first point to the second point. 
        /// </summary>
        /// <param name="pntA"></param>
        /// <param name="pntB"></param>
        public Vector2D(Point pntA, Point pntB)
            : this(pntB.X - pntA.X, pntB.Y - pntA.Y)
        {
        }

        /// <summary>
        /// Creates a new vector, based on the translation (distance) from the first point to the second point. 
        /// </summary>
        /// <param name="pntA"></param>
        /// <param name="pntB"></param>
        public Vector2D(PointF pntA, PointF pntB)
            : this(pntB.X - pntA.X, pntB.Y - pntA.Y)
        {
        }

        /// <summary>
        /// Creates a new vector, based on the given vector. 
        /// </summary>
        /// <param name="vect"></param>
        public Vector2D(Vector2D vect)
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
        public double GetDotProduct(Vector2D vect)
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
        public static double GetDotProduct(Vector2D vectA, Vector2D vectB)
        {
            return vectA.GetDotProduct(vectB);
        }
        
        /// <summary>
        /// Returns the magnitude (absolute length) of the vector. 
        /// </summary>
        public double GetMagnitude()
        {
            return (System.Math.Sqrt((this.X * this.X) + (this.Y * this.Y)));
        }

        /// <summary>
        /// Returns the magnitude (absolute length) of the given vector. 
        /// </summary>
        /// <param name="vect">A vector. </param>
        public static double GetMagnitude(Vector2D vect)
        {
            return vect.GetMagnitude();
        }

        /// <summary>
        /// Projects this vector onto the given vector and returns the projection. 
        /// </summary>
        /// <param name="vect">A vector to be projected on. </param>
        public Vector2D Project(Vector2D vect)
        {
            // scalar = (a.x*b.x + a.y*b.y)
            // proj.x = ( scalar / (b.x*b.x + b.y*b.y) * b.x );
            // proj.y = ( scalar / (b.x*b.x + b.y*b.y) * b.y );

            // If b is a unit vector: 
            // proj.x = scalar*b.x;
            // proj.y = scalar*b.y;

            Vector2D vectProjected = new Vector2D(0, 0);
            double dScalar = Vector2D.GetDotProduct(this, vect);

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
        public static Vector2D Project(Vector2D vectA, Vector2D vectB)
        {
            return vectA.Project(vectB);
        }

        /// <summary>
        /// Returns the cosine angle between this vector and the given vector. 
        /// </summary>
        /// <param name="vect"></param>
        /// <returns></returns>
        public double GetAngleCos(Vector2D vect)
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
        public static double GetAngleCos(Vector2D vectA, Vector2D vectB)
        {
            return vectA.GetAngleCos(vectB);
        }

        /// <summary>
        /// Returns the degrees angle between this vector and the given vector. 
        /// </summary>
        /// <param name="vect"></param>
        /// <returns></returns>
        public double GetAngleDeg(Vector2D vect)
        {
            return this.GetAngleCos(vect) / SharpMath.DEG_TO_RAD;
        }

        /// <summary>
        /// Returns the degrees angle between the given vectors. 
        /// </summary>
        /// <param name="vectA"></param>
        /// <param name="vectB"></param>
        /// <returns></returns>
        public static double GetAngleDeg(Vector2D vectA, Vector2D vectB)
        {
            return vectA.GetAngleDeg(vectB);
        }

        /// <summary>
        /// Returns a normalized (unit length) vector, based on this vector. 
        /// </summary>
        /// <returns></returns>
        public Vector2D GetNormalized()
        {
            // 1. Get vector magnitude. 
            // 2. Divide each of its components (xy) or (xyz) by the magnitude. 
            double dMagnitude = this.GetMagnitude();

            return new Vector2D(this.X / dMagnitude, this.Y / dMagnitude);
        }

        /// <summary>
        /// Returns a normalized (unit length) vector, based on the given vector. 
        /// </summary>
        /// <returns></returns>
        public static Vector2D GetNormalized(Vector2D vect)
        {
            return vect.GetNormalized();
        }

        /// <summary>
        /// Returns a scaled vector, based on this vector and the given factor. 
        /// </summary>
        /// <param name="dFactor"></param>
        /// <returns></returns>
        public Vector2D GetScaled(double dFactor)
        {
            return new Vector2D(this.X * dFactor, this.Y * dFactor);
        }

        /// <summary>
        /// Returns a scaled vector, based on the given vector and the given factor. 
        /// </summary>
        /// <param name="dFactor"></param>
        /// <returns></returns>
        public static Vector2D GetScaled(Vector2D vect, double dFactor)
        {
            return vect.GetScaled(dFactor);
        }

        /// <summary>
        /// Returns a rotated vector, based on this vector. 
        /// </summary>
        /// <param name="dAngle">An angle, in degrees. </param>
        /// <returns></returns>
        public Vector2D GetRotated(double dAngle)
        {
            //(x cos alpha + y sin alpha, -x sin alpha + y cos alpha)
            double dAngleRad = SharpMath.GetAngleRad(dAngle);
            double cos = System.Math.Cos(dAngleRad);
            double sin = System.Math.Sin(dAngleRad);

            return new Vector2D((this.X * cos) + (this.Y * sin), (-this.X * sin) + (this.Y * cos));
        }

        /// <summary>
        /// Returns a rotated vector, based on the given vector. 
        /// </summary>
        /// <param name="dAngle">An angle, in degrees. </param>
        /// <returns></returns>
        public static Vector2D GetRotated(Vector2D vect, double dAngle)
        {
            return vect.GetRotated(dAngle);
        }

        /// <summary>
        /// Returns a vector perependicular to this vector. 
        /// The returned vector can be considered rotated counter-clockwise by 90 degrees. 
        /// </summary>
        /// <returns></returns>
        public Vector2D GetPerpendicular()
        {
            return new Vector2D(-this.Y, this.X);
        }

        /// <summary>
        /// Returns a vector perependicular to the given vector. 
        /// The returned vector can be considered rotated counter-clockwise by 90 degrees. 
        /// </summary>
        /// <returns></returns>
        public static Vector2D GetPerpendicular(Vector2D vect)
        {
            return vect.GetPerpendicular();
        }

        #endregion Methods
        /*****************************************************************/
        // Operators
        /*****************************************************************/
        #region Operators

        public static Vector2D operator +(Vector2D vectA, Vector2D vectB)
        {
            return new Vector2D(vectA.X + vectB.X, vectA.Y + vectB.Y);
        }

        public static Vector2D operator +(Vector2D vect, Point pnt)
        {
            return new Vector2D(vect.X + pnt.X, vect.Y + pnt.Y);
        }

        public static Vector2D operator +(Vector2D vect, PointF pnt)
        {
            return new Vector2D(vect.X + pnt.X, vect.Y + pnt.Y);
        }

        public static Vector2D operator -(Vector2D vectA, Vector2D vectB)
        {
            return new Vector2D(vectA.X - vectB.X, vectA.Y - vectB.Y);
        }

        public static Vector2D operator -(Vector2D vect, Point pnt)
        {
            return new Vector2D(vect.X - pnt.X, vect.Y - pnt.Y);
        }

        public static Vector2D operator -(Vector2D vect, PointF pnt)
        {
            return new Vector2D(vect.X - pnt.X, vect.Y - pnt.Y);
        }

        public static Vector2D operator *(Vector2D vectA, Vector2D vectB)
        {
            return new Vector2D(vectA.X * vectB.X, vectA.Y * vectB.Y);
        }

        public static Vector2D operator *(Vector2D vect, Point pnt)
        {
            return new Vector2D(vect.X * pnt.X, vect.Y * pnt.Y);
        }

        public static Vector2D operator *(Vector2D vect, PointF pnt)
        {
            return new Vector2D(vect.X * pnt.X, vect.Y * pnt.Y);
        }

        public static Vector2D operator /(Vector2D vectA, Vector2D vectB)
        {
            return new Vector2D(vectA.X / vectB.X, vectA.Y / vectB.Y);
        }

        public static Vector2D operator /(Vector2D vect, Point pnt)
        {
            return new Vector2D(vect.X / pnt.X, vect.Y / pnt.Y);
        }

        public static Vector2D operator /(Vector2D vect, PointF pnt)
        {
            return new Vector2D(vect.X / pnt.X, vect.Y / pnt.Y);
        }

        #endregion Operators
        /*****************************************************************/
        // Events
        /*****************************************************************/
        #region Events

        #endregion Events
    }
}
