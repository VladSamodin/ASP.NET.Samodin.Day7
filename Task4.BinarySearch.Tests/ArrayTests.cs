using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace Task4.BinarySearch.Tests
{
    [TestClass]
    public class ArrayTests
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void BinarySearchInt_NullArray_ArgumentNullException()
        {
            Task4.BinarySearch.Array.BinarySearch<int>(null, 3);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void BinarySearchInt_NullComparer_ArgumentNullException()
        {
            IComparer<int> comparer = null;
            Task4.BinarySearch.Array.BinarySearch<int>(new int[] { 1 }, 3, comparer);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void BinarySearchInt_NullComparison_ArgumentNullException()
        {
            Comparison<int> comparison = null;
            Task4.BinarySearch.Array.BinarySearch<int>(new int[] { 1 }, 3, comparison);
        }

        [TestMethod]
        public void BinarySearchInt_EmptyArrayAnd2_Minus1()
        {
            int[] array = { };
            int expected = -1;
            int actual = Task4.BinarySearch.Array.BinarySearch<int>(array, 2);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void BinarySearchInt_ArrayWith2And3_2()
        {
            int[] array = { 0, 1, 3, 5, 11, 12 };
            int expected = 2;
            int actual = Task4.BinarySearch.Array.BinarySearch<int>(array, 3);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void BinarySearchInt_ArraySortedByDescAnd15AndComparison_Minus1()
        {
            int[] array = { 21, 15, 14, 13, 9, 5, 4, -1, -6 };
            int expected = 1;
            int actual = Task4.BinarySearch.Array.BinarySearch<int>(array, 15, (x, y) => y - x);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void BinarySearchInt_ArrayWithSearchingElementOnLeftBoundAndMinus1_5()
        {
            int[] array = { -1, 1, 3, 5, 11, 12 };
            int expected = 0;
            int actual = Task4.BinarySearch.Array.BinarySearch<int>(array, -1);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void BinarySearchInt_ArrayWithSearchingElementOnRightBoundAnd12_5()
        {
            int[] array = { 0, 1, 3, 5, 11, 12 };
            int expected = 5;
            int actual = Task4.BinarySearch.Array.BinarySearch<int>(array, 12);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void BinarySearchInt_ArrayWithoutSearchingElementAnd2_Minus1()
        {
            int[] array = { 0, 1, 3, 5, 11, 12 };
            int expected = -1;
            int actual = Task4.BinarySearch.Array.BinarySearch<int>(array, 2);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void BinarySearchDouble_ArrayWithElementNearZero_1()
        {
            double[] array = { -1, 0.0003 * 10000 - 3, 1, 3, 5, 11, 12 };
            int expected = 1;
            int actual = Task4.BinarySearch.Array.BinarySearch<double>(array, 0, DoubleCompasion);
            Assert.AreEqual(expected, actual);
        }

        private static bool DoubleEquals(double a, double b,
                double maxRelativeError, double maxAbsoluteError)
        {
            if (Math.Abs(a - b) < maxAbsoluteError)
                return true;
            double relativeError;
            if (Math.Abs(b) > Math.Abs(a))
                relativeError = Math.Abs((a - b) / b);
            else
                relativeError = Math.Abs((a - b) / a);
            if (relativeError <= maxRelativeError)
                return true;
            return false;
        }

        private static int DoubleCompasion(double a, double b)
        {
            if (DoubleEquals(a, b, 0.00001, 0.000001))
            {
                return 0;
            }
            else if(a < b)
            {
                return -1;
            }
            else
            {
                return 1;
            }
        }


    }
}
