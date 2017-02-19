using System.Drawing;
using System.Diagnostics;

using Tools.Maths.Matrix;
using Tools.Maths.Vector2;

namespace Tools.Maths
{
    /// <summary>
    /// Represents a transformable shape. 
    /// </summary>
    [DebuggerDisplay("pntOrigin.X: {pntOrigin.X}, pntOrigin.Y: {pntOrigin.Y}")]
    public class csShape
    {
        /*****************************************************************/
        // Declarations
        /*****************************************************************/
        #region Declarations

        /// <summary>
        /// Matrix containing the original vertex positions, in local space. 
        /// </summary>
        public csMatrix mxShape
        {
            get;
            private set;
        }

        /// <summary>
        /// Matrix containing the transformed vertex positions, in local space. 
        /// </summary>
        public csMatrix mxTransformed
        {
            get;
            private set;
        }

        /// <summary>
        /// Origin point of the shape, in world space. 
        /// </summary>
        public PointF pntOrigin;

        private double _dRotation;
        /// <summary>
        /// Current rotation angle, in degrees. 
        /// </summary>
        public double dRotation
        {
            get
            {
                return this._dRotation;
            }
            set
            {
                this._dRotation = csMaths.GetAngleClamped(value);
                
                this.vectFront = this._vectDefault.GetRotated(-this._dRotation);
                this.vectRight = this.vectFront.GetPerpendicular();
                this.mxTransformed = this.mxShape.GetRotated(this.dRotation);
            }
        }

        /// <summary>
        /// A vector facing in the direction of the rotation angle. 
        /// </summary>
        public csVector2 vectFront
        {
            get;
            private set;
        }

        /// <summary>
        /// A vector perpendicular to the front facing vector. 
        /// </summary>
        public csVector2 vectRight
        {
            get;
            private set;
        }

        /// <summary>
        /// A default orientation vector. 
        /// </summary>
        private csVector2 _vectDefault;

        #endregion Declarations
        /*****************************************************************/
        // Constructors
        /*****************************************************************/
        #region Constructors

        public csShape(double[,] matrix, PointF pntOffset)
        {
            this.pntOrigin = pntOffset;
            this.mxShape = new csMatrix(matrix);
            this.mxTransformed = new csMatrix(matrix);
            this._vectDefault = new Vector2.csVector2(0, -10);
            this.dRotation = 0;
        }

        #endregion Constructors
        /*****************************************************************/
        // Methods
        /*****************************************************************/
        #region Methods

        #endregion Methods
        /*****************************************************************/
        // Events
        /*****************************************************************/
        #region Events

        #endregion Events
    }
}
