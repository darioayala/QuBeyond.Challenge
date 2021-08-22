using NUnit.Framework;
using QuBeyond.Challenge.Business;
using QuBeyond.Challenge.Business.Exceptions;
using System.Collections.Generic;
using System.Linq;

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

        #region Tests
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
            IEnumerable<string> matrix = MatrixWithDifferentSizeElementsBuilder();
            var wordstream = new List<string>();

            _wordFinder = new WordFinder(matrix);

            Assert.Throws(Is.InstanceOf(typeof(MatrixSizeException)), delegate { _wordFinder.Find(wordstream); });
        }

        [Test]
        public void WordFinder_ExceptionOnMatrixTooLong()
        {
            IEnumerable<string> matrix = MatrixWithExceedingSizeBuilder();
            var wordstream = new List<string>();

            _wordFinder = new WordFinder(matrix);

            Assert.Throws(Is.InstanceOf(typeof(MatrixTooLongException)), delegate { _wordFinder.Find(wordstream); });
        }

        [Test]
        public void WordFinder_ExceptionMatrixNotSquare()
        {
            IEnumerable<string> matrix = MatrixNotSquareBuilder();
            var wordstream = new List<string>();

            _wordFinder = new WordFinder(matrix);

            Assert.Throws(Is.InstanceOf(typeof(MatrixIsNotSquareException)), delegate { _wordFinder.Find(wordstream); });
        }

        [Test]
        public void WordFinder_FindSmallMatrix()
        {
            IEnumerable<string> matrix = MatrixSmallBuilder(); 
            var wordstream = new List<string>()
            { 
                "wind",
                "cold",
                "chill",
                "tree"
            };

            _wordFinder = new WordFinder(matrix);
            var result = _wordFinder.Find(wordstream);

            Assert.That(result.Any(p => p == "wind"));
            Assert.That(result.Any(p => p == "cold"));
            Assert.That(result.Any(p => p == "chill"));
            Assert.That(!result.Any(p => p == "tree"));
        }

        [Test]
        public void WordFinder_FindMediumMatrix()
        {
            IEnumerable<string> matrix = MatrixMediumBuilder();
            var wordstream = new List<string>()
            {
                "airplane",
                "ship",
                "truck",
                "boat",
                "road",
                "car",
                "sick",
                "van",
                "bus",
                "earth",
                "child",
                "nice",
                "place"
            };

            _wordFinder = new WordFinder(matrix);
            var result = _wordFinder.Find(wordstream);

            // I check for words with more that 1 occurrence
            Assert.AreEqual(result.Count(), 10);
            Assert.That(result.Any(p => p == "airplane"));
            Assert.That(result.Any(p => p == "ship"));
            Assert.That(result.Any(p => p == "truck"));
            Assert.That(result.Any(p => p == "road"));
            Assert.That(result.Any(p => p == "car"));
            Assert.That(result.Any(p => p == "van"));
            Assert.That(result.Any(p => p == "bus"));
            Assert.That(result.Any(p => p == "child"));

        }

        [Test]
        public void WordFinder_NoWordWereFind()
        {
            IEnumerable<string> matrix = MatrixSmallBuilder();
            var wordstream = new List<string>()
            {
                "storm",
                "river",
                "tree"
            };

            _wordFinder = new WordFinder(matrix);
            var result = _wordFinder.Find(wordstream);

            Assert.IsInstanceOf(typeof(IEnumerable<string>),result);
            Assert.AreEqual(result.Count(), 0);
        }

        #endregion

        #region Builders

        private IEnumerable<string> MatrixSmallBuilder()
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

        private IEnumerable<string> MatrixWithExceedingSizeBuilder()
        {
            var text = "Vestibulum ante ipsum primis in faucibus orci luctus et ultrices.";
            var matrix = new List<string>();

            for (int i = 0; i <= 64; i++)
            { 
                matrix.Add(text);
            }
            return matrix;
        }

        private IEnumerable<string> MatrixNotSquareBuilder()
        {
            return new List<string>
            {
                "abcdc",
                "chill",
                "uvdxg"
            };
        }


        private IEnumerable<string> MatrixMediumBuilder()
        {
            return new List<string>
            { 
                "airplanertbc",
                "inicexroadua",
                "roadplacersr",
                "pwbdcboattnt",
                "lzvkoshipcar",
                "aqaktmnroxlu",
                "nbnsshiplbac",
                "eachildliuok",
                "hfsecncarswm",
                "truckixnzbts",
                "aaletqwearth",
                "vanchildxvan"
            };
        }
        #endregion

    }
}