using QuBeyond.Challenge.Business.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QuBeyond.Challenge.Business.Validators
{
    public class MatrixValidator
    {

        public static bool Validate(IEnumerable<string> matrix)
        {
            if (matrix == null)
                throw new MatrixEmptyException();

            if (matrix != null && matrix.Count() == 0)
                throw new MatrixEmptyException();

            if (!ValidateMatrixElementsSize(matrix))
                throw new MatrixSizeException();

            if (!ValidateMatrixSize(matrix))
                throw new MatrixTooLongException();

            if (!ValidateMatrixIsSquare(matrix))
                throw new MatrixIsNotSquareException();

            return true;
        }

        /// <summary>
        /// Validates if all element of the matrix have the same size
        /// </summary>
        /// <param name="matrix"></param>
        /// <returns></returns>
        private static bool ValidateMatrixElementsSize(IEnumerable<string> matrix)
        {
            var sizeFirstElement = matrix.First().Length;

            foreach (var element in matrix)
            {
                if (element.Length != sizeFirstElement) return false;
            }

            return true;

        }

        /// <summary>
        /// Validates that matrix size cannot exceed 64x64 size
        /// </summary>
        /// <param name="matrix"></param>
        /// <returns></returns>
        private static bool ValidateMatrixSize(IEnumerable<string> matrix)
        {
            return (matrix.First().Length > 64 || matrix.Count() > 64)?false:true;
        }

        private static bool ValidateMatrixIsSquare(IEnumerable<string> matrix)
        { 
            var x = matrix.First().Length;
            var y = matrix.Count();

            return x == y;
        
        }

    }
}
