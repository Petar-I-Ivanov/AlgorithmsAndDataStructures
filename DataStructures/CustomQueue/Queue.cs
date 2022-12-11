using System;

namespace DataStructures.CustomQueue
{
    class Queue<T>
    {
        private static readonly int CAPACITY = 4;

        private T[] queue;
        public int Count { get; private set; }

        public Queue()
        {
            queue = new T[CAPACITY];
            Count = 0;
        }

        public void Print()
        {
            for (int i = 0; i < Count; i++)
            {
                Console.Write(queue[i] + " ");
            }

            Console.WriteLine();
        }

        public void Enqueue(T value)
        {
            if (Count + 1 == queue.Length)
            {
                queue = extendArray();
            }

            queue[Count] = value;
            Count++;
        }

        public T Dequeue()
        {
            if (Count == 0)
            {
                throw new InvalidOperationException();
            }

            T value = queue[0];

            queue = removeFirst();
            Count--;

            return value;
        }

        private T[] extendArray()
        {
            T[] temp = new T[Count + CAPACITY];

            for (int i = 0; i < Count; i++)
            {
                temp[i] = queue[i];
            }

            return temp;
        }

        private T[] removeFirst()
        {
            T[] temp = new T[Count];

            for (int i = 1; i < Count; i++)
            {
                temp[i - 1] = queue[i];
            }

            return temp;
        }
    }
}
