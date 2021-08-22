using QuBeyond.Challenge.Business.Exceptions;
using QuBeyond.Challenge.Business.Validators;
using System;
using System.Collections.Generic;
using System.Linq;

namespace QuBeyond.Challenge.Business
{
    public class WordFinder : IWordFinder
    {

        private IEnumerable<string> _matrix;

        public WordFinder(IEnumerable<string> matrix)
        {
            _matrix = matrix;
        }

        /// <summary>
        /// Find words in a matrix and returns a list of the top 10 occurrencies
        /// </summary>
        /// <param name="wordStream"></param>
        /// <returns></returns>
        public IEnumerable<string> Find(IEnumerable<string> wordStream)
        {
            var result = new List<string>();
            if (MatrixValidator.Validate(_matrix))
            { 

                var wordsFinded = new SortedDictionary<string, int>();

                foreach (var word in wordStream)
                {
                    //Check for duplicated words
                    if (wordsFinded.ContainsKey(word)) continue;

                    var wordSize = word.Length;
                    var matrixSize = _matrix.First().Length;

                    var searchLimit = matrixSize - wordSize;
                    // This means word is bigger than matrix so, I skip this one for search
                    if (searchLimit < 0) continue;


                    // Iterate rows
                    for (int y = 0; y < matrixSize; y++)
                    {
                        // Iterate columns
                        for (int x = 0; x < matrixSize; x++)
                        {

                            // if word doesn't fit in the remaining search area go to next row
                            if (x > searchLimit && y > searchLimit) break;

                            var foundH = true;
                            var foundV = true;

                            if (x <= searchLimit)
                            {
                                for (int z = 0; z < wordSize; z++)
                                {
                                    //Horizontal search
                                    if (word[z] != _matrix.ElementAt(y)[x + z])
                                    {
                                        foundH = false;
                                        break;
                                    }
                                }
                            }
                            else
                            { 
                                foundH = false;
                            }

                            if (y <= searchLimit)
                            {
                                for (int z = 0; z < wordSize; z++)
                                {
                                    //Vertical search
                                    if (word[z] != _matrix.ElementAt(y + z)[x])
                                    {
                                        foundV = false;
                                        break;
                                    }

                                }
                            }
                            else
                            {
                                foundV = false;
                            }

                            if (foundH)
                            {
                                // Add or increment finded word to results
                                AddFindedWord(wordsFinded, word);

                                // skip word length from search scope
                                x += wordSize;
                            }

                            if (foundV)
                            { 
                                AddFindedWord(wordsFinded, word);
                            }

                        }
                    }

                }

                // I order the words by the most found
                var sortedResult = wordsFinded.OrderByDescending(x => x.Value).Take(10).Select(y => y.Key);
                result = sortedResult.ToList();
            }

            return result;
        }


        private void AddFindedWord(SortedDictionary<string, int> wordsFinded, string word)
        {
            if (wordsFinded.ContainsKey(word))
                wordsFinded[word] += 1;
            else
                wordsFinded.Add(word, 1);

        }


        //private int WordCount(string word)
        

        

    }
}
