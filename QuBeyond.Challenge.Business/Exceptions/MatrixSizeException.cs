using System;
using System.Collections.Generic;
using System.Text;

namespace QuBeyond.Challenge.Business.Exceptions
{
    public class MatrixSizeException: BaseException
    {
        public MatrixSizeException() : base("Matrix elements cannot have different sizes") 
        {
            Code = 1001;
        }
    }
}
