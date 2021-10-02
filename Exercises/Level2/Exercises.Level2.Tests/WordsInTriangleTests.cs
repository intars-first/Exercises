using Xunit;

namespace Exercises.Level2.Tests
{
    public class WordsInTriangleTests
    {
        private readonly WordsInTriangle _wordsInTriangle = new WordsInTriangle();

        [Fact]
        public void Hello()
        {
            string[] expected = new string[]
            {
                "     *",
                "    * *",
                "   *   *",
                "  *     *",
                " * home  *",
                "***********",
            };

            string[] words = new string[] { "home" };

            Assert.Equal(expected, _wordsInTriangle.GetWordInTriangle(words));
        }

        [Fact]
        public void ABeautifulHome()
        {
            string[] expected = new string[]
            {
                "        *",
                "       * *",
                "      *   *",
                "     *     *",
                "    *       *",
                "   * a       *",
                "  * beautiful *",
                " * home        *",
                "*****************",
            };

            string[] words = new string[] { "a", "beautiful", "home" };

            Assert.Equal(expected, _wordsInTriangle.GetWordInTriangle(words));
        }

        [Fact]
        public void SunshineiSgREAT()
        {
            string[] expected = new string[]
            {
                "         *",
                "        * *",
                "       *   *",
                "      *     *",
                "     *       *",
                "    *         *",
                "   * sunshine  *",
                "  * is          *",
                " * great         *",
                "*******************",
            };

            string[] words = new string[] { "sunshine", "is", "great" };

            Assert.Equal(expected, _wordsInTriangle.GetWordInTriangle(words));
        }

        [Fact]
        public void A()
        {
            string[] expected = new string[]
            {
                "   *",
                "  * *",
                " * A *",
                "*******",
            };

            string[] words = new string[] { "A" };

            Assert.Equal(expected, _wordsInTriangle.GetWordInTriangle(words));
        }

        [Fact]
        public void Empty()
        {
            string[] expected = new string[]
            {
                "  *",
                " * *",
                "*****",
            };

            string[] words = new string[] { };

            Assert.Equal(expected, _wordsInTriangle.GetWordInTriangle(words));
        }
    }
}
