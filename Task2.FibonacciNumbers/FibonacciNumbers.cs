using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2.FibonacciNumbers
{
    public class FibonacciNumbers
    {
        private int n;

        public int[] GetFirstNumbers(int n)
        {
            if (n < 1)
            {
                throw new ArgumentOutOfRangeException("n");
            }
            this.n = n;
            int [] result = new int[n];
            IEnumerator<int> enumerator = GetEnumerator();
            int i = 0;
            while(enumerator.MoveNext())
            {
                result[i++] = enumerator.Current;
            }
            return result;
        }

        private IEnumerator<int> GetEnumerator()
        {
            int previousValue = 0;
            int currentValue = 1;
            yield return currentValue;
            for (int i = 2; i <= n; i++)
            {
                int temp = previousValue;
                previousValue = currentValue;
                currentValue += temp;
                yield return currentValue;
            }
        }    
    }
}
