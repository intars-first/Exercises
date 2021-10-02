using System;

namespace Exercises.Level2
{
    public class Triforce
    {
        /// <summary>
        /// !!! COMPLETE TRIANGLE BEFORE ATTEMPTING THIS !!!
        /// 
        /// 
        /// The program:
        ///  You must create a program that echoes a Triforce of a given size N.       
        /// - A triforce is made of 3 identical triangles
        /// - A triangle of size N should be made of N lines
        /// - A triangle's line starts from 1 star, and earns 2 stars each line
        /// 
        /// For example, a Triforce of size 3 will look like:
        ///        
        ///     *
        ///    ***
        ///   *****
        ///  *     *
        /// ***   ***
        ///***** *****
        ///
        /// Another example, a Triforce of size 5 will look like:
        ///
        ///         *
        ///        ***
        ///       *****
        ///      *******
        ///     *********
        ///    *         *
        ///   ***       ***
        ///  *****     *****
        /// *******   *******
        ///********* *********
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>


        public string[] GetTriforce(int n)
        {
            string[] allLines = new string[n * 2];

            string fullEmpty = "";
            for (int i = 0; i < n; i++) { fullEmpty += " "; }

            //5;4;3;2;1 - between triangles
            string halfEmtyBuilder = " ";
            string[] halfEmpty = new string[n];
            for (int i = n - 1; i >= 0; i--)
            {
                halfEmpty[i] = halfEmtyBuilder;
                halfEmtyBuilder += " ";
            }

            Triangle triangleCreator = new Triangle();
            string[] triangle = triangleCreator.GetTRiangle(n);

            for (int i = 0; i < n; i++)
            {
                allLines[i] = fullEmpty + triangle[i];
                allLines[i + n] = triangle[i] + halfEmpty[i] + triangle[i];
            }


            return allLines;
        }
    }
}
