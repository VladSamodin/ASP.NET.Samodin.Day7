using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3.CustomQueue
{
    public class CustomQueue<T>: IEnumerable<T>
    {
        private const int MinCapacity = 10;
        private T[] items;
        private int head;
        private int tail;

        public int Count
        {
            get
            {
                if (this.Empty)
                    return 0;
                if (head <= tail)
                    return tail - head + 1;
                else
                    return items.Length - (head - tail - 1);
            }
        }

        public int Capacity
        {
            get
            {
                return items.Length;
            }
        }

        public bool Empty
        {
            get
            {
                return head == -1;
            }
        }

        public CustomQueue(int initialCapacity = 10)
        {
            if (initialCapacity <= 0)
            {
                throw new ArgumentOutOfRangeException("initialCapacity", "Capacity must be > 0");
            }
            if (initialCapacity < MinCapacity)
            {
                initialCapacity = MinCapacity;
            }
            items = new T[initialCapacity];
            head = -1;
            tail = -1;
        }


        public void Enqueue(T toAdd)
        {
            if (this.Empty)
            {
                head = 0;
            }
            if ((tail + 1) % items.Length == head)
            {
                GrowArray();
            }
            tail = (tail + 1) % items.Length;
            items[tail] = toAdd;
        }

        public T Dequeue()
        {
            if (this.Empty)
            {
                throw new InvalidOperationException("Queue is empty");
            }
            T dequeueValue = items[head];
            if (head == tail)
            {
                head = -1;
                tail = -1;
            }
            else
            {
                head = (head + 1) % items.Length;
            }
            return dequeueValue;
        }

        public T Peek()
        {
            if (this.Empty)
            {
                throw new InvalidOperationException("Queue is empty");
            }
            return items[head];
        }

        public void Clear()
        {
            head = -1;
        }

        public IEnumerator<T> GetEnumerator()
        {
            return new CustomIterator(this);
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }

        private void GrowArray()
        {
            Array.Resize<T>(ref items, items.Length * 2);
        }

        private class CustomIterator : IEnumerator<T>
        {
            private readonly CustomQueue<T> queue;
            private int currentShift;

            public CustomIterator(CustomQueue<T> queue)
            {
                currentShift = -1;
                this.queue = queue;
            }

            public T Current
            {
                get
                {
                    if (currentShift == -1)
                    {
                        throw new InvalidOperationException();
                    }
                    return queue.items[(queue.head + currentShift) % queue.items.Length];
                }
            }

            public void Dispose() { }

            object System.Collections.IEnumerator.Current
            {
                get { throw new NotImplementedException(); }
            }

            public bool MoveNext()
            {
                if (currentShift + 1 == queue.Count)
                {
                    return false;
                }
                currentShift++;
                return true;
            }

            public void Reset()
            {
                currentShift = -1;
            }
        }
    }
}
