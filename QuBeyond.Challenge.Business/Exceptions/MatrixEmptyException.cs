using System;
using System.Collections.Generic;
using System.Text;

namespace QuBeyond.Challenge.Business.Exceptions
{
    public class MatrixEmptyException: BaseException
    {
        public MatrixEmptyException(): base("Matrix cannot be null")
        {
            Code = 1000;
        }
    }
}
