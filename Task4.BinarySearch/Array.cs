using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task4.BinarySearch
{
    public static class Array
    {
        public static int BinarySearch<T>(T[] array, T value)
        {
            IComparer<T> comparer = Comparer<T>.Default;
            return BinarySearchWithValidationArray<T>(array, value, comparer.Compare);
        }

        public static int BinarySearch<T>(T[] array, T value, Comparison<T> comparison)
        {
            if (comparison == null)
            {
                throw new ArgumentNullException("comparison");
            }
            return BinarySearchWithValidationArray<T>(array, value, comparison);
        }

        public static int BinarySearch<T>(T[] array, T value, IComparer<T> comparer)
        {
            if (comparer == null)
            {
                throw new ArgumentNullException("comparer");
            }
            return BinarySearchWithValidationArray<T>(array, value, comparer.Compare);
        }

        private static int BinarySearchWithValidationArray<T>(T[] array, T value, Comparison<T> comparison)
        {
            if (array == null)
            {
                throw new ArgumentNullException("array");
            }
            if (array.Length == 0)
            {
                return -1;
            }
            return BinarySearchAlgorithm<T>(array, value, comparison, 0, array.Length - 1);
        }

        private static int BinarySearchAlgorithm<T>(T[] array, T value, Comparison<T> comparison, int left, int right)
        {
            int middle = left + (right - left) / 2;
            int resultCompare = comparison(value, array[middle]);
            if (resultCompare == 0)
            {
                return middle;
            }
            if (left == right)
            {
                return -1;
            }
            if (resultCompare < 0)
            {
                return BinarySearchAlgorithm<T>(array, value, comparison, left, middle);
            }
            else
            {
                return BinarySearchAlgorithm<T>(array, value, comparison, middle + 1, right);
            }
        }
    }
}
