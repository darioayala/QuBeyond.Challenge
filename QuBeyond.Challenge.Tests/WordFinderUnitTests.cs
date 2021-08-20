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
            var wordstream = new List<string>();

            _wordFinder = new WordFinder(matrix);

            Assert.Throws(Is.InstanceOf(typeof(MatrixEmptyException)), delegate { _wordFinder.Find(wordstream); });

        }

        [Test]
        public void WordFinder_ExceptionOnMatrixElementsSize()
        {
            IEnumerable<string> matrix = null;
            var wordstream = MatrixWithDifferentSizeElementsBuilder();

            _wordFinder = new WordFinder(matrix);

            Assert.Throws(Is.InstanceOf(typeof(MatrixSizeException)), delegate { _wordFinder.Find(wordstream); });
        }

        [Test]
        public void WordFinder_ExceptionOnMatrixTooLong()
        {
            IEnumerable<string> matrix = null;
            var wordstream = MatrixWithExceedingSize();

            _wordFinder = new WordFinder(matrix);

            Assert.Throws(Is.InstanceOf(typeof(MatrixTooLongException)), delegate { _wordFinder.Find(wordstream); });
        }

        private IEnumerable<string> Matrix1Builder()
        {
            return new List<string>
            {
                "abcdc",
                "fgwio",
                "chill",
                "pqnsd",
                "uvdxy"
            };
        }

        private IEnumerable<string> MatrixWithDifferentSizeElementsBuilder()
        {
            return new List<string>
            {
                "abcdc",
                "fgwio",
                "chill",
                "pqnsd",
                "uvdx"
            };

        }

        private IEnumerable<string> MatrixWithExceedingSize()
        {
            var text = "Vestibulum ante ipsum primis in faucibus orci luctus et ultrices.";
            var matrix = new List<string>();

            for (int i = 0; i <= 64; i++)
            { 
                matrix.Add(text);
            }
            return matrix;
        }
    }
}