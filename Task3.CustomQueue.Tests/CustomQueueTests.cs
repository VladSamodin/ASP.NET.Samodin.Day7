using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Task3.CustomQueue;

namespace Task3.CustomQueue.Tests
{
    [TestClass]
    public class CustomQueueTests
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Constructor_CapacityMinus1_ArgumentOutOfRangeException()
        {
            CustomQueue<int> queue = new CustomQueue<int>(-1);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void Dequeue_EmptyQueue_InvalidOperationException()
        {
            CustomQueue<int> queue = new CustomQueue<int>();
            queue.Dequeue();
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void Peek_EmptyQueue_InvalidOperationException()
        {
            CustomQueue<int> queue = new CustomQueue<int>();
            queue.Peek();
        }

        [TestMethod]
        public void GrowArray_200Elements_Capacity320()
        {
            CustomQueue<int> queue = new CustomQueue<int>();
            int expected = 320;
            for (int i = 0; i < 200; i++)
            {
                queue.Enqueue(i);
            }
            int actual = queue.Capacity;
            Assert.AreEqual(expected, actual);

        }

        [TestMethod]
        public void EnqueueDequeue_ArrayElements_ElementsOrderedByEnterTime()
        {
            CustomQueue<int> queue = new CustomQueue<int>();
            for (int i = 0; i < 200; i++)
            {
                queue.Enqueue(i);
            }
            bool isRightOrder = true;
            for (int i = 0; i < 200; i++)
            {
                isRightOrder &= queue.Dequeue() == i;
            }
            Assert.IsTrue(isRightOrder);

        }

        [TestMethod]
        public void TestCircularBuffer_Enqueue20ElementsDequeue10ElementsEnqueue10Elements_Capacity20()
        {
            CustomQueue<int> queue = new CustomQueue<int>();
            for (int i = 0; i < 20; i++)
            {
                queue.Enqueue(i);
            }
            System.Diagnostics.Debug.WriteLine("\n\n\tCount = {0}\n\n", queue.Count);
            for (int i = 0; i < 10; i++)
            {
                queue.Dequeue();
            }
            System.Diagnostics.Debug.WriteLine("\n\n\tCount = {0}\n\n", queue.Count);
            for (int i = 0; i < 10; i++)
            {
                queue.Enqueue(i);
            }
            System.Diagnostics.Debug.WriteLine("\n\n\tCount = {0}\n\n", queue.Count);
            bool isRightOrder = true;
            for (int i = 10; i < 30; i++)
            {
                isRightOrder &= queue.Dequeue() == i % 20;
            }
            Assert.IsTrue(isRightOrder && queue.Capacity == 20);
        }

        [TestMethod]
        public void TestEnumerator_Enqueue20ElementsDequeue10ElementsEnqueue10Elements_Capacity20()
        {
            CustomQueue<int> queue = new CustomQueue<int>();
            for (int i = 0; i < 20; i++)
            {
                queue.Enqueue(i);
            }
            for (int i = 0; i < 9; i++)
            {
                queue.Dequeue();
            }
            for (int i = 0; i < 8; i++)
            {
                queue.Enqueue(i);
            }
            bool isRightOrder = true;
            int expectedValue = 9;
            foreach (var item in queue)
            {
                isRightOrder &= item == expectedValue % 20;
                expectedValue++;
            }
            Assert.IsTrue(isRightOrder);
        }
    }
}
