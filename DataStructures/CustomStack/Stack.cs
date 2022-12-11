using System;

namespace DataStructures.CustomStack
{
    class Stack<T>
    {
        private static readonly int CAPACITY = 4;

        private T[] stack;
        public int Count { get; private set; }

        public Stack()
        {
            stack = new T[CAPACITY];
            Count = 0;
        }

        public void Print()
        {
            for (int i = 0; i < Count; i++)
            {
                Console.Write(stack[i] + " ");
            }

            Console.WriteLine();
        }

        public void Push(T value)
        {
            if (Count + 1 == stack.Length)
            {
                stack = extendStack();
            }

            stack[Count] = value;
            Count++;
        }

        public T Pop()
        {
            T temp = stack[Count - 1];

            stack[Count - 1] = default(T);
            Count--;

            return temp;
        }

        private T[] extendStack()
        {
            T[] temp = new T[Count + CAPACITY];

            for (int i = 0; i < Count; i++)
            {
                temp[i] = stack[i];
            }

            return temp;
        }
    }
}
