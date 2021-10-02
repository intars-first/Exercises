using System;

namespace Exercises.Level2
{
    public class WordsInBox
    {
        /// <summary>
        /// Draw a box made out of stars (*) and put the word inide of them.
        /// So that a word Home makes:
        /// 
        /// ********
        /// * Home *
        /// ********
        /// 
        /// If you need more examples go to the tests project.
        /// </summary>
        /// <param name="word">Word to put in a box</param>
        /// <returns></returns>
        public string[] GetBox(string word)
        {
            
            string starLine = "****";
            for (int i = 0; i < word.Length; i++) { starLine += "*"; }

            string[] allLines = new string[3];
            allLines[0] = starLine;
            allLines[1] = $"* {word} *";
            allLines[2] = starLine;

            return allLines;
        }
    }
}
