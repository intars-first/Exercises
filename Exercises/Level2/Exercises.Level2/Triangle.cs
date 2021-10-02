using System;

namespace Exercises.Level2
{
    public class Triangle
    {
        /// <summary>
        /// Note: compleete half trangle first
        /// 
        /// The program:
        ///  You must create a triangle. 
        ///  n is the number of lines a triangle will have.
        ///  Triangle body has to be made out of "*",
        ///  so result should for 3 be like:
        ///  * 
        /// ***
        ///*****
        /// 
        /// Example of 5:
        /// 
        ///    *
        ///   ***
        ///  *****
        /// *******
        ///*********
        ///
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public string[] GetTRiangle(int n)
        {
            string[] allLines = new string[n];
            string line = "*";

            for (int i = 0; i < n; i++)
            {
                string spaces = "";
                for (int j = i+1; j < n; j++) { spaces += " "; }
                
                allLines[i] = spaces + line;
                line += "**";
                
            }

            return allLines;
        }
    }
}
