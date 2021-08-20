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
        public IEnumerable<string> Find(IEnumerable<string> wordStream)
        {
            if (MatrixValidator.Validate(wordStream))
            { 

                var wordsFinded = new SortedDictionary<string, int>();

                foreach (var word in wordStream)
                {
                    //Check for duplicated words
                    if (wordsFinded.ContainsKey(word)) continue;

                    //Horizontal search
                    




                    //Vertical search
                }            
            
            }




            //TODO: temporary
            return null;


        }




        private int WordCount(string word)
        

        

    }
}
