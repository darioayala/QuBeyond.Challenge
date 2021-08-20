using System;
using System.Collections.Generic;
using System.Text;

namespace QuBeyond.Challenge.Business.Exceptions
{
    public class MatrixTooLongException: BaseException
    {
        public MatrixTooLongException(): base("Matrix size cannot exceed 64x64 size")
        {
            Code = 1002;
        }
    }
}
