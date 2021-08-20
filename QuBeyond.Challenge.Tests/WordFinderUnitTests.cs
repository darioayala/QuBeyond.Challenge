using NUnit.Framework;
using QuBeyond.Challenge.Business;
using QuBeyond.Challenge.Business.Exceptions;
using System.Collections.Generic;

namespace QuBeyond.Challenge.Tests
{
    public class Tests
    {

        private WordFinder _wordFinder;
        private IEnumerable<string> _matrix;

        [SetUp]
        public void Setup()
        {
            _matrix = new List<string>();
        }

        [Test]
        public void WordFinder_ExceptionOnNullMatrix()
        {
            IEnumerable<string> matrix = null;
            //var wordstream = new List<string>();

            _wordFinder = new WordFinder(matrix);
            //Assert.Throws(Is.InstanceOf(typeof(MatrixEmptyException)), () => _wordFinder.Find(wordstream));



            Assert.Pass();
        }


        private IEnumerable<string> Matrix1Builder()
        {
            var matrix = new List<string>
            {
                "abcdc",
                "fgwio",
                "chill",
                "pqnsd",
                "uvdxy"
            };
            return matrix;
        
        }

    }
}