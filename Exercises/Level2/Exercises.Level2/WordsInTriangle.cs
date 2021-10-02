using System;

namespace Exercises.Level2
{
    public class WordsInTriangle
    {
        /// <summary>
        /// Given array of words draw them inside a smallest possible triangle, compleeting rules. 
        /// !. Every word has to be drawn in a new line.
        /// 2. No word can touch wall of the triangle, meaning there has to a " " between a wall and word.
        /// 
        /// For example word Home:
        /// 
        ///      *
        ///     * *
        ///    *   *
        ///   *     *
        ///  * home  *
        /// ***********
        /// 
        /// a beautiful home:
        /// 
        ///         *
        ///        * *
        ///       *   *
        ///      *     *
        ///     *       *
        ///    * a       *
        ///   * beautiful *
        ///  * home        *
        /// *****************
        /// 
        /// </summary>
        /// <param name="words">Words to put in triangle</param>
        /// <returns></returns>
        public string[] GetWordInTriangle(string[] words)
        {
            //platums +2 tukšumi ja pāra tad 3
            //vieta palielinas pa divi
            //minimums 3 rindas
            //7 =>11 =>6 (5) līnijas

            //empty special case;
            if (words.Length == 0) return new string[3] { "  *", " * *", "*****" };

            //base is needed wider if word is higher up
            int baseFilling = 0;
            for (int i = 0; i < words.Length; i++)
            {
                int baseForLine = words[i].Length + 2;
                if (baseForLine % 2 == 0) baseForLine++;
                baseForLine += (words.Length - 1 - i) * 2;

                baseFilling = Math.Max(baseFilling, baseForLine);
            }

            //create triangle
            int fillingLineCount = baseFilling / 2 + 1;
            string[] triangle = new string[fillingLineCount + 2];

            string firstStar = "";
            string FirstLeadingSpaces = "";
            for (int j = 1; j < triangle.Length; j++) { FirstLeadingSpaces += " "; }
            triangle[0] = $"{FirstLeadingSpaces }*";


            for (int i = 1; i < triangle.Length - 1; i++)
            {
                string leadingSpaces = "";
                for (int j = i + 1; j < triangle.Length; j++) { leadingSpaces += " "; }

                string filling = " ";
                if (i >= triangle.Length - 1 - words.Length)//words input neccessary
                {
                    filling += words[i - (triangle.Length - 1 - words.Length)];
                }
                for (int j = filling.Length; j <= (i - 1) * 2; j++)
                {
                    filling += " ";
                }

                triangle[i] = $"{leadingSpaces }*{filling }*";
            }

            string baseStars = "";
            for (int i = 0; i < baseFilling + 4; i++) { baseStars += "*"; }
            triangle[triangle.Length - 1] = baseStars;



            return triangle;
        }
    }
}
