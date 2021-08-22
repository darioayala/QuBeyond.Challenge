# Word Finder

This solution contains 2 projects

* QuBeyond.Challenge.Business 
* QuBeyond.Challenge.Test


## QuBeyond.Challenge.Business

This is the main library, it contains a Find method. at first, it validates that matrix is well formed, if it´s not an exception is throwed.
Then, for each word in the wordstream there is a loop that checks every character of the matrix and compares with first character of the word that is searching for. 
If the fist character of the word is equal to the character in the matrix it compares the second character of the word with the next character to the right of the matrix.
If are equal continues with the next word character, if not, it starts to compare characters vertically.

If word was found for first time it is added to a sortedDictionary list of type <string, int>, string field contains the word and int field is an integer that indicated how many times this word was finded.
After searching for every word in wordstream, sortedDictionario is ordered by most finded words and top 10 is returned as a word list.

## QuBeyond.Challenge.Test
This is where the unit test are defined, 7 test were created to check different conditions on WordFinder library

### WordFinder_ExceptionMatrixNotSquare 
Checks an exception is thrown if matrix is not square (n x n) 

### WordFinder_ExceptionOnMatrixElementSize 
An exception is thrown if there is elements in the matrix with different length

### WordFinder_ExceptionOnMatrixTooLong
Check matrix don't exceed 64x64 size.

### WordFinder_ExceptionOnNullMatrix
Checks exception when matrix is null.

### WordFinder_FindMediumMatrix
Checks a 12x12 matrix with several words with more than one ocurrence

### WordFinder_FindSmallMatrix
Test using matrix and words provided in the challenge document

### WordFinder_NoWordsWereFind
Test that a empty string list is returned if none of the words in wordstream were found
