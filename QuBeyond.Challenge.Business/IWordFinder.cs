using System;
using System.Collections.Generic;
using System.Text;

namespace QuBeyond.Challenge.Business
{
    public interface IWordFinder
    {
        public IEnumerable<string> Find(IEnumerable<string> wordStream);
    }
}
