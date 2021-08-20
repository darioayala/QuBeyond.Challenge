using System;
using System.Collections.Generic;
using System.Text;

namespace QuBeyond.Challenge.Business.Exceptions
{
    public class BaseException: Exception
    {
        public BaseException(string message): base(message)
        {

        }
        public int Code { get; set; }

    }
}
