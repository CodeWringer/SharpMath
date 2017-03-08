using System;
using System.Drawing;
using Tools.Maths.Geometry;

namespace Tools.Maths
{
    /// <summary>
    /// Contains various methods for performing mathematical operations. 
    /// </summary>
    /// <remarks>
    /// Date: 06.03.2017
    /// </remarks>
    public static class CSharpMaths
    {
        /*****************************************************************/
        // Declarations
        /*****************************************************************/
        #region Declarations

        /// <summary>
        /// Random Number generator. 
        /// </summary>
        public static Random rnd = new Random((int)DateTime.Now.Ticks);

        /// <summary>
        /// One degree in radians. 
        /// </summary>
        public const double DEG_TO_RAD = 0.01745329252;

        /// <summary>
        /// One degree in radians. 
        /// Basis: (180 / Math.PI)
        /// </summary>
        public const double RAD_TO_DEG = 57.295779513082323D;

        /// <summary>
        /// Number of degrees of a full circle. 
        /// </summary>
        public const double DEG_CIRCLE = 360.0D; 

        #endregion Declarations
        /*****************************************************************/
        // Methods
        /*****************************************************************/
        #region Methods

        /// <summary>
        /// Returns a point on a circle, based ont the given angle and circle radius. 
        /// </summary>
        /// <param name="pntCircleOrigin">Origin point of the circle. </param>
        /// <param name="dRadius">Radius of the circle. </param>
        /// <param name="dAngleRadian">An angle, in radians. </param>
        /// <returns></returns>
        public static PointF GetPointOnCircle(PointF pntCircleOrigin, double dRadius, double dAngleRadian)
        {
            return new PointF(
                (float)(pntCircleOrigin.Y + dRadius * Math.Sin(dAngleRadian)),
                (float)(pntCircleOrigin.X + dRadius * Math.Cos(dAngleRadian))
            );
        }

        /// <summary>
        /// Returns a point on a circle, based ont the given target point and circle radius. 
        /// </summary>
        /// <remarks>
        /// The returned point is the intersection point of an imaginary line drawn from the circle origin to the target point 
        /// and the circle's circumference. 
        /// </remarks>
        /// <param name="pntCircleOrigin">Origin point of the circle. </param>
        /// <param name="dRadius">Radius of the circle. </param>
        /// <param name="dAngleRadian">An angle, in radians. </param>
        /// <param name="pntTarget"></param>
        /// <returns></returns>
        public static PointF GetPointOnCircle(PointF pntCircleOrigin, double dRadius, PointF pntTarget, double dAngleRadian)
        {
            Vector2D vectScaled = new Vector2D(pntCircleOrigin, pntTarget);
            vectScaled = vectScaled.GetNormalized();
            vectScaled = vectScaled.GetScaled(dRadius);

            return new PointF(
                (float)(pntCircleOrigin.X + vectScaled.X),
                (float)(pntCircleOrigin.Y + vectScaled.Y)
            );
        }

        /// <summary>
        /// Returns a random point in a circle with the given radius. 
        /// </summary>
        /// <param name="radius"></param>
        /// <returns></returns>
        public static PointF GetRandomPointInCircle(double radius)
        {
            double radian = CSharpMaths.GetRandomDouble(0, Math.PI * 2);
            double distance = CSharpMaths.GetRandomDouble(0, radius);

            return new PointF((float)(distance * Math.Cos(radian)), (float)(distance * Math.Sin(radian)));
        }

        /// <summary>
        /// Returns the given radians angle converted to degrees. 
        /// </summary>
        /// <param name="vect"></param>
        /// <returns></returns>
        public static double GetAngleDeg(double dAngleRadian)
        {
            return (dAngleRadian * CSharpMaths.RAD_TO_DEG);
        }

        /// <summary>
        /// Returns the given degrees angle converted to radians. 
        /// </summary>
        /// <param name="dAngleDegree"></param>
        /// <returns></returns>
        public static double GetAngleRad(double dAngleDegree)
        {
            return dAngleDegree * CSharpMaths.DEG_TO_RAD;
        }

        /// <summary>
        /// Returns the angle between the given points, in radians. 
        /// </summary>
        /// <param name="pntA"></param>
        /// <param name="pntB"></param>
        /// <returns></returns>
        public static double GetAngleAtan2(PointF pntA, PointF pntB)
        {
            // pointA = origin
            // pointB = target
            return (Math.Atan2((pntB.Y - pntA.Y), (pntB.X - pntA.X)));
        }

        /// <summary>
        /// Returns the angle between the given points, in degrees. 
        /// </summary>
        /// <param name="pntA"></param>
        /// <param name="pntB"></param>
        /// <returns></returns>
        public static double GetAngleAtan2Deg(PointF pntA, PointF pntB)
        {
            // pointA = origin
            // pointB = target
            return (Math.Atan2((pntB.Y - pntA.Y), (pntB.X - pntA.X)) * (180 / Math.PI));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pntA"></param>
        /// <param name="pntB"></param>
        /// <param name="pntC"></param>
        /// <returns></returns>
        /// <see cref="http://csharphelper.com/blog/2014/07/determine-whether-a-point-is-inside-a-polygon-in-c/"/>
        public static double GetAngle(Vector2D pntA, Vector2D pntB, Vector2D pntC)
        {
            // Get the dot product...
            // Get the vectors' coordinates.
            double BAx = pntA.X - pntB.X;
            double BAy = pntA.Y - pntB.Y;
            double BCx = pntC.X - pntB.X;
            double BCy = pntC.Y - pntB.Y;

            // Calculate the dot product.
            double dot_product = (BAx * BCx + BAy * BCy);

            // Get the cross product...
            // Get the vectors' coordinates.
            BAx = pntA.X - pntB.X;
            BAy = pntA.Y - pntB.Y;
            BCx = pntC.X - pntB.X;
            BCy = pntC.Y - pntB.Y;

            // Calculate the Z coordinate of the cross product.
            double cross_product = (BAx * BCy - BAy * BCx);

            // Calculate the angle.
            return Math.Atan2(cross_product, dot_product);
        }

        /// <summary>
        /// Returns a random int value between the given minimum and maximum values. 
        /// </summary>
        /// <param name="min"></param>
        /// <param name="max"></param>
        /// <returns></returns>
        public static int GetRandomInt(int min, int max)
        {
            return CSharpMaths.rnd.Next(min, max);
        }

        /// <summary>
        /// Returns a random double value between the given minimum and maximum values. 
        /// </summary>
        /// <param name="min"></param>
        /// <param name="max"></param>
        /// <returns></returns>
        public static double GetRandomDouble(double min, double max)
        {
            return CSharpMaths.rnd.NextDouble() * (max - min) + min;
        }

        /// <summary>
        /// Returns the distance between the given points. 
        /// </summary>
        /// <param name="pntA"></param>
        /// <param name="pntB"></param>
        /// <param name="bNaive">If true, only approximated distance will be returned. </param>
        /// <returns></returns>
        public static double GetDistance(PointF pntA, PointF pntB, bool bNaive = false)
        {
            if (bNaive == true)
            {
                return (pntA.X - pntB.X) + (pntA.Y - pntB.Y);
            }
            else
            {
                Vector2D vect = new Vector2D(pntA, pntB);
                return vect.GetMagnitude();
            }
        }

        /// <summary>
        /// Returns the given degrees angle clamped to the range 0-360. 
        /// </summary>
        /// <param name="dAngle"></param>
        /// <returns></returns>
        public static double GetAngleClamped(double dAngle)
        {
            if (dAngle > CSharpMaths.DEG_CIRCLE)
            {
                dAngle = dAngle % CSharpMaths.DEG_CIRCLE;
            }
            else if (dAngle < 0)
            {
                dAngle = CSharpMaths.DEG_CIRCLE + (dAngle % CSharpMaths.DEG_CIRCLE);
            }

            return dAngle;
        }

        #region GetLineIntersection

        /// <summary>
        /// Returns the point of intersection for lines spanning each given point pair. 
        /// </summary>
        /// <param name="pntA1">Start point of the first line. </param>
        /// <param name="pntB1">End point of the first line. </param>
        /// <param name="pntA2">Start point of the second line. </param>
        /// <param name="pntB2">End point of the second line. </param>
        /// <returns>The point of intersection or null, if there is no point of intersection. </returns>
        public static PointF? GetLineIntersection(PointF pntA1, PointF pntB1, PointF pntA2, PointF pntB2)
        {
            float A1 = pntB1.Y - pntA1.Y;
            float B1 = pntA1.X - pntB1.X;
            float C1 = A1 * pntA1.X + B1 * pntA1.Y;

            float A2 = pntB2.Y - pntA2.Y;
            float B2 = pntA2.X - pntB2.X;
            float C2 = A2 * pntA2.X + B2 * pntA2.Y;

            float delta = A1 * B2 - A2 * B1;
            if (delta == 0)
                return null; // Lines are parallel. 

            float x = (B2 * C1 - B1 * C2) / delta;
            float y = (A1 * C2 - A2 * C1) / delta;

            return new PointF(x, y);
        }

        /// <summary>
        /// Returns the point of intersection for lines spanning each given point pair. 
        /// </summary>
        /// <param name="pntA1">Start point of the first line. </param>
        /// <param name="pntB1">End point of the first line. </param>
        /// <param name="pntA2">Start point of the second line. </param>
        /// <param name="pntB2">End point of the second line. </param>
        /// <returns>The point of intersection or null, if there is no point of intersection. </returns>
        public static PointD? GetLineIntersection(PointD pntA1, PointD pntB1, PointD pntA2, PointD pntB2)
        {
            double A1 = pntB1.Y - pntA1.Y;
            double B1 = pntA1.X - pntB1.X;
            double C1 = A1 * pntA1.X + B1 * pntA1.Y;

            double A2 = pntB2.Y - pntA2.Y;
            double B2 = pntA2.X - pntB2.X;
            double C2 = A2 * pntA2.X + B2 * pntA2.Y;

            double delta = A1 * B2 - A2 * B1;
            if (delta == 0)
                return null; // Lines are parallel. 

            double x = (B2 * C1 - B1 * C2) / delta;
            double y = (A1 * C2 - A2 * C1) / delta;

            return new PointD(x, y);
        }

        #endregion GetLineIntersection

        #endregion Methods
    }
}
