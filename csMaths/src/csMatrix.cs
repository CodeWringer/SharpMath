using System;
using System.Diagnostics;
using System.Drawing;

namespace Tools.Maths.Matrix
{
    /// <summary>
    /// Represents a matrix (two dimensional array) and offers matrix transformation methods. 
    /// </summary>
    [DebuggerDisplay("Rows: {Rows}, Columns: {Columns}, matrix: {matrix}")]
    public class csMatrix
    {
        /*****************************************************************/
        // Declarations
        /*****************************************************************/
        #region Declarations

        /// <summary>
        /// Count of rows in the matrix. 
        /// </summary>
        public int Rows { get; private set; }

        /// <summary>
        /// Count of columns in the matrix. 
        /// </summary>
        public int Columns { get; private set; }

        /// <summary>
        /// The two dimensional array serving as a matrix. 
        /// </summary>
        public double[,] matrix;
        
        /// <summary>
        /// Getter / Setter for values of underlying two dimensional array. 
        /// </summary>
        /// <param name="row"></param>
        /// <param name="column"></param>
        /// <returns></returns>
        public double this[int row, int column]
        {
            get
            {
                return this.matrix[row, column];
            }
            set
            {
                this.matrix[row, column] = value;
            }
        }

        #endregion Declarations
        /*****************************************************************/
        // Constructors
        /*****************************************************************/
        #region Constructors

        public csMatrix(int Rows, int Columns)
        {
            this.Rows = Rows;
            this.Columns = Columns;
            this.matrix = new double[Rows, Columns];
        }

        public csMatrix(double[,] matrix)
        {
            this.Rows = matrix.GetLength(0);
            this.Columns = matrix.GetLength(1);
            this.matrix = matrix;
        }

        #endregion Constructors
        /*****************************************************************/
        // Methods
        /*****************************************************************/
        #region Methods

        /// <summary>
        /// Returns a matrix, based on this matrix with its vertices rotated by the given angle. 
        /// </summary>
        /// <param name="angle">An angle in degrees. </param>
        /// <returns></returns>
        public csMatrix GetRotated(double angle)
        {
            angle = angle % CSharpMaths.DEG_CIRCLE;

            if (angle < 0)
                angle = CSharpMaths.DEG_CIRCLE + angle;

            angle = angle * CSharpMaths.DEG_TO_RAD;

            double cos = Math.Cos(angle);
            double sin = Math.Sin(angle);

            double[,] mxResult = new double[this.Rows, this.Columns];
            double[,] mxVertex = new double[3, 1];
            double[,] mxRotate = new double[,]
            {
                { cos, -sin, 0 },
                { sin, cos, 0 },
                { 0, 0, 1 }
            };

            csMatrix oVertex = new csMatrix(mxVertex);
            csMatrix oRotate = new csMatrix(mxRotate);
            csMatrix oMultiply;

            for (int column = 0; column < this.Columns; column++)
            {
                oVertex.matrix[0, 0] = this.matrix[0, column];
                oVertex.matrix[1, 0] = this.matrix[1, column];
                oVertex.matrix[2, 0] = 1;

                oMultiply = oRotate.GetMultiplied(oVertex);
                mxResult[0, column] = oMultiply.matrix[0, 0];
                mxResult[1, column] = oMultiply.matrix[1, 0];
            }

            return new csMatrix(mxResult);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pntScaling"></param>
        /// <returns></returns>
        public csMatrix GetScaled(PointF pntScaling)
        {
            double[,] matrix = new double[this.Rows, this.Columns];

            throw new NotImplementedException();

            return new csMatrix(matrix);
        }

        /// <summary>
        /// Returns a reflection matrix, based on this matrix. 
        /// </summary>
        /// <param name="X">If true, the matrix will be reflected along the x axis. </param>
        /// <param name="Y">If true, the matrix will be reflected along the y axis. </param>
        /// <returns></returns>
        public csMatrix GetReflected(bool X, bool Y)
        {
            double[,] matrix = new double[this.Rows, this.Columns];

            for (int column = 0; column < this.Columns; column++)
            {
                if (X)
                    matrix[0, column] = -this.matrix[0, column];
                if (Y)
                    matrix[1, column] = -this.matrix[1, column];
            }

            return new csMatrix(matrix);
        }

        #region GetMultiplied

        /// <summary>
        /// Returns a matrix with the elemednts of the given matrix multiplied with the elements of this matrix. 
        /// </summary>
        /// <param name="matrix">A matrix to multiply with. </param>
        /// <returns></returns>
        public csMatrix GetMultiplied(csMatrix matrix)
        {
            double[,] matrixA = this.matrix;
            double[,] matrixB = matrix.matrix;

            if (this.Columns != matrix.Rows)
            {
                throw new ArgumentException("The number of columns in the first matrix must be the same as the number of rows in the second matrix!");
            }

            int rowsA = this.Rows;
            int columnsA = this.Columns;
            int columnsB = matrix.Columns;

            double[,] matrixCombined = new double[rowsA, columnsB];

            for (int rowA = 0; rowA < rowsA; rowA++)
            {
                for (int columnB = 0; columnB < columnsB; columnB++)
                {
                    for (int columnA = 0; columnA < columnsA; columnA++)
                    {
                        matrixCombined[rowA, columnB] += matrixA[rowA, columnA] * matrixB[columnA, columnB];
                    }
                }
            }

            return new csMatrix(matrixCombined);
        }

        /// <summary>
        /// Returns a matrix with the elemednts of the given matrix multiplied with the elements of this matrix. 
        /// Unsafe method. 
        /// </summary>
        /// <param name="matrix">A matrix to multiply with. </param>
        /// <returns></returns>
        public unsafe csMatrix GetMultipliedUnsafe(csMatrix matrix)
        {
            double[,] matrixA = this.matrix;
            double[,] matrixB = matrix.matrix;

            int h = this.Rows;
            int w = matrix.Columns;
            int l = this.Columns;
            double[,] result = new double[h, w];

            unsafe
            {
                fixed (double* pm = result, pm1 = matrixA, pm2 = matrixB)
                {
                    int i1;
                    int i2;

                    for (int i = 0; i < h; i++)
                    {
                        i1 = i * l;

                        for (int j = 0; j < w; j++)
                        {
                            i2 = j;
                            double res = 0.0D;

                            for (int k = 0; k < l; k++, i2 += w)
                            {
                                res += pm1[i1 + k] * pm2[i2];
                            }
                            pm[i * w + j] = res;
                        }
                    }
                }
            }

            return new csMatrix(result);
        }

        #endregion GetMultiplied

        /// <summary>
        /// Returns a matrix with the elements of the given matrix added to the elements of this matrix. 
        /// </summary>
        /// <param name="matrixB">A matrix to add to this matrix. </param>
        /// <returns></returns>
        public csMatrix GetAdded(csMatrix matrixB)
        {
            double[,] matrix = new double[this.Rows, this.Columns];

            for (int columnA = 0; columnA < this.Columns; columnA++)
            {
                for (int columnB = 0; columnB < matrixB.Columns; columnB++)
                {
                    for (int rowA = 0; rowA < this.Rows; rowA++)
                    {
                        matrix[rowA, columnA] += this.matrix[rowA, columnA] + matrixB.matrix[rowA, columnB];
                    }
                }
            }

            return new csMatrix(matrix);
        }

        /// <summary>
        /// Returns a matrix with the elements of the given matrix subtracted from the elements of this matrix. 
        /// </summary>
        /// <param name="matrixB">A matrix to subtract from this matrix. </param>
        /// <returns></returns>
        public csMatrix GetSubtracted(csMatrix matrixB)
        {
            if (this.Rows != matrixB.Rows || this.Columns != matrixB.Columns)
            {
                throw new ArgumentException("The given matrix must have the same number of columns and rows!");
            }

            double[,] matrix = new double[this.Rows, this.Columns];

            for (int columnA = 0; columnA < this.Columns; columnA++)
            {
                for (int columnB = 0; columnB < matrixB.Columns; columnB++)
                {
                    for (int rowA = 0; rowA < this.Rows; rowA++)
                    {
                        matrix[rowA, columnA] += this.matrix[rowA, columnA] - matrixB.matrix[rowA, columnB];
                    }
                }
            }

            return new csMatrix(matrix);
        }

        #endregion Methods
        /*****************************************************************/
        // Events
        /*****************************************************************/
        #region Events

        #endregion Events
    }
}
