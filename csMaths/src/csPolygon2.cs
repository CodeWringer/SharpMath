using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

using Tools.Maths.Vector2;

namespace Tools.Maths.Polygon2
{
    /// <summary>
    /// Represents a polygon in two dimensional space. 
    /// </summary>
    /// <remarks>
    /// Version: 1.0.0.0
    /// Date: 28.12.2016
    /// </remarks>
    public class csPolygon2
    {
        /*****************************************************************/
        // Declarations
        /*****************************************************************/
        #region Declarations

        private List<Vector2.csVector2> _points;
        /// <summary>
        /// Getter for the list of points. 
        /// </summary>
        public List<Vector2.csVector2> Points
        {
            get { return this._points; }
            private set { this._points = value; }
        }

        /// <summary>
        /// A vector representing the center point of the polygon. 
        /// </summary>
        public csVector2 vectCenter
        {
            get
            {
                double totalX = 0;
                double totalY = 0;

                for (int i = 0; i < this._points.Count; i++)
                {
                    totalX += this._points[i].X;
                    totalY += this._points[i].Y;
                }

                return new Vector2.csVector2(totalX / (float)this._points.Count, totalY / (float)this._points.Count);
            }
        }

        #endregion Declarations
        /*****************************************************************/
        // Constructors
        /*****************************************************************/
        #region Constructors

        public csPolygon2()
        {
            this._points = new List<Vector2.csVector2>();
        }

        public csPolygon2(IEnumerable<Vector2.csVector2> points)
        {
            this._points = new List<Vector2.csVector2>(points);
        }

        #endregion Constructors
        /*****************************************************************/
        // Methods
        /*****************************************************************/
        #region Methods

        /// <summary>
        /// Returns the interval of this polygon projected onto the given axis. 
        /// </summary>
        /// <param name="vectAxis">The axis to project the polygon onto. </param>
        public Interval Project(Vector2.csVector2 vectAxis)
        {
            // Initialize with the first point in the list of points. 
            float d = (float)vectAxis.GetDotProduct(this.Points[0]); // To project a point on an axis use the dot product. 
            Interval interval = new Interval(d, d);
            
            // Check for min and max extents of the points along the axis. 
            for (int i = 0; i < this.Points.Count; i++)
            {
                d = (float)this.Points[i].GetDotProduct(vectAxis);

                if (d < interval.min) // New min extent found. 
                {
                    interval.min = d;
                }
                else if (d > interval.max) // New max extent found. 
                {
                    interval.max = d;
                }
            }

            return interval;
        }

        /// <summary>
        /// Returns the result of a collision check of the given polygons. 
        /// </summary>
        /// <param name="polygonA">A polygon to check. </param>
        /// <param name="polygonB">A polygon to check against. </param>
        /// <returns></returns>
        public static PolygonCollisionResult PolygonCollision(csPolygon2 polygonA, csPolygon2 polygonB)
        {
            return polygonA.PolygonCollision(polygonB);
        }

        /// <summary>
        /// Returns the result of a collision check of this polygon with the given polygon. 
        /// </summary>
        /// <param name="polygon">A polygon to check against. </param>
        /// <returns></returns>
        public PolygonCollisionResult PolygonCollision(csPolygon2 polygon)
        {
            PolygonCollisionResult result = new PolygonCollisionResult();

            if (polygon == null) // No collsion checking possible. 
                return result;
            else // Initialization. 
                result.Intersect = true;

            int edgeCountA = this.Points.Count;
            int edgeCountB = polygon.Points.Count;

            //float minIntervalDistance = float.PositiveInfinity;

            Vector2.csVector2 vectAxisTranslation = new Vector2.csVector2();
            Vector2.csVector2 vectEdge;

            // Loop through all the edges of both polygons
            for (int edgeIndex = 0; edgeIndex < edgeCountA + edgeCountB; edgeIndex++)
            {
                if (edgeIndex < edgeCountA) // Iterating over the edges of polygon A. 
                {
                    if (edgeIndex == edgeCountA - 1)
                    {
                        vectEdge = this.Points[0] - this.Points[edgeIndex];
                    }
                    else
                    {
                        vectEdge = this.Points[edgeIndex + 1] - this.Points[edgeIndex];
                    }
                }
                else // Iterating over the edges of polygon B. 
                {
                    if (edgeIndex == edgeCountA + edgeCountB - 1)
                    {
                        vectEdge = polygon.Points[0] - polygon.Points[edgeIndex - edgeCountA];
                    }
                    else
                    {
                        vectEdge = polygon.Points[edgeIndex - edgeCountA + 1] - polygon.Points[edgeIndex - edgeCountA];
                    }
                }

                // ===== 1. Find if the polygons are currently intersecting =====

                // Find the axis perpendicular to the current edge
                Vector2.csVector2 vectAxis = new Vector2.csVector2(-vectEdge.Y, vectEdge.X);
                vectAxis = vectAxis.GetNormalized();

                // Find the projection of the polygon on the current axis
                Interval intervalA = this.Project(vectAxis);
                Interval intervalB = polygon.Project(vectAxis);
                
                // Check if the polygon projections are currentlty intersecting
                if (intervalA.GetIntervalDistance(intervalB) > 0)
                    result.Intersect = false;

                //// ===== 2. Now find if the polygons *will* intersect =====

                //// Project the velocity on the current axis
                //float velocityProjection = (float)vectAxis.GetDotProduct(velocity);

                //// Get the projection of polygon A during the movement
                //if (velocityProjection < 0)
                //{
                //    intervalA.min += velocityProjection;
                //}
                //else
                //{
                //    intervalA.max += velocityProjection;
                //}

                //// Do the same test as above for the new projection
                //float intervalDistance = intervalA.GetIntervalDistance(intervalB);

                //if (intervalDistance > 0)
                //    result.WillIntersect = false;

                //// If the polygons are not intersecting and won't intersect, exit the loop
                //if (!result.Intersect && !result.WillIntersect)
                //    break;

                //// Check if the current interval distance is the minimum one. If so store
                //// the interval distance and the current distance.
                //// This will be used to calculate the minimum translation vector
                //intervalDistance = Math.Abs(intervalDistance);

                //if (intervalDistance < minIntervalDistance)
                //{
                //    minIntervalDistance = intervalDistance;
                //    vectAxisTranslation = vectAxis;

                //    csVector2D d = this.vectCenter - polygon.vectCenter;

                //    if (d.GetDotProduct(vectAxisTranslation) < 0)
                //        vectAxisTranslation = -vectAxisTranslation;
                //}
            }

            //// The minimum translation vector
            //// can be used to push the polygons appart.
            //result.MinimumTranslationVector = vectAxisTranslation * minIntervalDistance;

            return result;
        }

        /// <summary>
        /// Applies a translation to every point of the polygon, based on the given vector. 
        /// </summary>
        /// <param name="vect"></param>
        public void Translate(Vector2.csVector2 vect)
        {
            Translate(vect.X, vect.Y);
        }

        /// <summary>
        /// Applies a translation to every point of the polygon, based on the given coordinates. 
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public void Translate(double x, double y)
        {
            for (int i = 0; i < this._points.Count; i++)
            {
                Vector2.csVector2 p = this._points[i];
                this._points[i] = new Vector2.csVector2(p.X + x, p.Y + y);
            }
        }

        /// <summary>
        /// Returns a polygon, based on this polygon, that is scaled around the given point, by the given factor. 
        /// </summary>
        /// <param name="pointScale">The point to scale around. </param>
        /// <param name="dFactor">The factor to scale by. </param>
        /// <returns></returns>
        public csPolygon2 GetScaled(Vector2.csVector2 pointScale, double dFactor)
        {
            csPolygon2 polygonResult = new csPolygon2();

            foreach (Vector2.csVector2 point in this.Points)
            {
                Vector2.csVector2 vectDistance = pointScale - point;
                polygonResult.Points.Add(new Vector2.csVector2(point + vectDistance.GetScaled(dFactor)));
            }

            return polygonResult;
        }

        /// <summary>
        /// Returns a polygon, based on this polygon, that is reflected along the given axes. 
        /// </summary>
        /// <param name="reflectX">If true, the polygon will be reflected along the x-axis. </param>
        /// <param name="reflectY">If true, the polygon will be reflected along the y-axis. </param>
        /// <returns></returns>
        public csPolygon2 GetReflected(bool reflectX, bool reflectY)
        {
            csPolygon2 polygonResult = new csPolygon2();

            foreach (Vector2.csVector2 point in this.Points)
            {
                double resultX = point.X;
                double resultY = point.Y;

                if (reflectX)
                    resultX = -resultX;
                if (reflectY)
                    resultY = -resultY;

                polygonResult.Points.Add(new Vector2.csVector2(resultX, resultY));
            }

            return polygonResult;
        }

        /// <summary>
        /// Returns true, if the polygon contains the given point. 
        /// </summary>
        /// <param name="point">A point in local coordinates. </param>
        /// <param name="polygon">A polygon, in the form of an array of points. </param>
        /// <returns></returns>
        /// <see cref="http://csharphelper.com/blog/2014/07/determine-whether-a-point-is-inside-a-polygon-in-c/"/>
        public bool Contains(Vector2.csVector2 point)
        {
            // Get the angle between the point and the
            // first and last vertices.
            int max_point = this._points.Count - 1;
            double total_angle = csMaths.GetAngle(this._points[max_point], point, this._points[0]);

            // Add the angles from the point
            // to each other pair of vertices.
            for (int i = 0; i < max_point; i++)
            {
                total_angle += csMaths.GetAngle(this._points[i], point, this._points[i + 1]);
            }

            // The total angle should be 2 * PI or -2 * PI if
            // the point is in the polygon and close to zero
            // if the point is outside the polygon.
            return (Math.Abs(total_angle) > 0.000001);
        }

        #endregion Methods
        /*****************************************************************/
        // Events
        /*****************************************************************/
        #region Events

        #endregion Events
    }

    /// <summary>
    /// Structure that stores the results of the PolygonCollision function. 
    /// </summary>
    public struct PolygonCollisionResult
    {
        // Are the polygons currently intersecting?
        public bool Intersect;

        // The translation to apply to the first polygon to push the polygons apart.
        public Vector2.csVector2 MinimumTranslationVector;
    }

    /// <summary>
    /// Represents the projection of a polygon along an axis. 
    /// </summary>
    public struct Interval
    {
        public float min;

        public float max;

        public Interval(float min, float max)
        {
            this.min = min;
            this.max = max;
        }

        /// <summary>
        /// Returns the distance between this and the given interval. 
        /// On overlap, the returned distance will be negative. 
        /// </summary>
        /// <param name="interval"></param>
        /// <returns></returns>
        public float GetIntervalDistance(Interval interval)
        {
            float d1 = interval.min - this.max;
            float d2 = this.min - interval.max;
            float sign = (this.min < interval.min) ? d1 / Math.Abs(d1) : d2 / Math.Abs(d2);

            return sign * Math.Min(Math.Abs(d1), Math.Abs(d2));
        }

        /// <summary>
        /// Returns the distance between the given intervals. 
        /// On overlap, the returned distance will be negative. 
        /// </summary>
        /// <param name="intervalA"></param>
        /// <param name="intervalB"></param>
        /// <returns></returns>
        public static float GetIntervalDistance(Interval intervalA, Interval intervalB)
        {
            return intervalA.GetIntervalDistance(intervalB);
        }
    }
}
