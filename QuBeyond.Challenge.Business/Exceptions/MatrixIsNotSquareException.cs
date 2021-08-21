using System;
using System.Collections.Generic;
using System.Text;

namespace QuBeyond.Challenge.Business.Exceptions
{
    public class MatrixIsNotSquareException: BaseException
    {
        public MatrixIsNotSquareException() : base("Matrix must be square")
        {
            Code = 1003;
        }
    }
}
