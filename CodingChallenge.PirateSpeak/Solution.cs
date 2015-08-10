using System;
using System.Linq;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace CodingChallenge.PirateSpeak
{
    public class Solution
    {
        public string[] GetPossibleWords(string jumble, string[] dictionary)
        {
            List<string> found_results = new List<string>();

            foreach(string word in dictionary)
            {
                // create temp word for comparison 
                string temp_word = word;
                // only look at words with the same length
                if (jumble.Length == word.Length)
                {
                    // split the jumbled wored into an array to parse
                    char[] word_chars = jumble.ToCharArray();
                    int found = 0;
                    // check each letter of the word
                    foreach(char cur_letter in word_chars)
                    {
                        if (temp_word.Contains(cur_letter))
                        {
                            found++;
                            // remove "validated" letter, handles duplications ex. oob
                            temp_word = temp_word.Remove(temp_word.IndexOf(cur_letter), 1); 
                        }
                    }
                    // if all letters match add the word the the list to be returned
                    if (found == jumble.Length)
                        found_results.Add(word);
                }
            }
            // return list as an array
            return found_results.ToArray();
        }
    }
}