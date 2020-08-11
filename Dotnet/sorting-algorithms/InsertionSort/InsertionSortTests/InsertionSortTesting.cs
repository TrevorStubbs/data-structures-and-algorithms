using InsertionSortProgram;
using System;
using Xunit;
using static InsertionSortProgram.Program;

namespace InsertionSortTests
{
    public class InsertionSortTesting
    {
        [Fact]
        public void CanSortSampleArray()
        {
            int[] input = { 8, 4, 23, 42, 16, 15 };

            int[] output = InsertionSortMethod(input);

            int[] expected = { 4,8,15,16,23,42 };

            Assert.Equal(expected, output);
        }

        [Fact]
        public void CanSortReverseSortedArray()
        {
            int[] input = { 20, 18, 12, 8, 5, -2 };

            int[] output = InsertionSortMethod(input);

            int[] expected = { -2, 5, 8, 12, 18, 20 };

            Assert.Equal(expected, output);
        }

        [Fact]
        public void CanSortFewUniqueArray()
        {
            int[] input = { 5, 12, 7, 5, 5, 7 };

            int[] output = InsertionSortMethod(input);

            int[] expected = { 5,5,5,7,7,12 };

            Assert.Equal(expected, output);
        }

        [Fact]
        public void CanSortNearlySorted()
        {
            int[] input = { 2, 3, 5, 7, 13, 11 };

            int[] output = InsertionSortMethod(input);

            int[] expected = { 2,3,5,7,11,13 };

            Assert.Equal(expected, output);
        }

        [Fact]
        public void CannotSortAllNegativeNumbers()
        {
            int[] input = { -55,-57,-105,-5,-7 };

            int[] output = InsertionSortMethod(input);

            int[] expected = { -5,-7,-55,-57,-105 };

            Assert.NotEqual(expected, output);
        }
    }
}
