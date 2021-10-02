using System;

namespace Exercises.Level2
{
    public class AsciiTextArt
    {
        /// <summary>
        /// You are givven letters in ASCII art format, now you must draw the art of ASCII.
        /// Using ASCII letters you must convert them and create the word using theese letters.
        /// To gain better understanding go to the tests project inside folder AsciiFiles
        /// to see format of letters and expected output of words.
        /// 
        /// </summary>
        /// <param name="letters">ASCII art letters in range ABCDEFGHIJKLMNOPQRSTUVWXYZ?</param>
        /// <param name="word">Word to output in ascii art</param>
        /// <param name="h">Height of letters</param>
        /// <param name="l">Length of letters</param>
        /// <returns></returns>
        public string[] GetArt(string[] letters, string word, int h, int l)
        {
            //word = word.Replace("@", "A");
            char[] wordChars = word.ToCharArray();
            string[] output = new string[h];

            for (int i = 0; i < wordChars.Length; i++)
            {
                int abcIndex = char.ToUpper(wordChars[i]) - 64 - 1;//google
                if (abcIndex < 0 || abcIndex > 26) abcIndex = (letters[0].Length)/4-1;
                for (int j = 0; j < 5; j++)
                {

                    output[j] += letters[j].Substring(abcIndex * 4, 4);
                }

            }






            return output;
        }
    }
}
