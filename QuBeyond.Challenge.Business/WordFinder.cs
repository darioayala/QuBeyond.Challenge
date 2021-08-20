using QuBeyond.Challenge.Business.Exceptions;
using System;
using System.Collections.Generic;

namespace QuBeyond.Challenge.Business
{
    public class WordFinder : IWordFinder
    {

        private IEnumerable<string> _matrix;

        public WordFinder(IEnumerable<string> matrix)
        {
            _matrix = matrix;
        }
        public IEnumerable<string> Find(IEnumerable<string> wordStream)
        {
            Validate(wordStream);




            //TODO: temporary
            return null;


        }

        private bool Validate(IEnumerable<string> matrix)
        {
            if (matrix == null)
                throw new MatrixEmptyException();


            return true;
        }
    }
}
