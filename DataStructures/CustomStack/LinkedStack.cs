using System;

namespace DataStructures.CustomStack
{
    class Node<T>
    {
        public T Value { get; private set; }
        public Node<T> Next { get; private set; }

        public Node(T value, Node<T> nextNode = null)
        {
            Value = value;
            Next = nextNode;
        }
    }

    class LinkedStack<T>
    {
        private Node<T> start;
        private Node<T> end;
        public int Count { get; private set; }

        public LinkedStack()
        {
            start = null;
            end = null;

            Count = 0;
        }

        public void Print()
        {
            Node<T> current = start;

            while(current != null)
            {
                Console.Write(current.Value + " ");
                current = current.Next;
            }

            Console.WriteLine();
        }

        public void Push(T value)
        {
            start = new Node<T>(value, start);
            Count++;
        }

        public T Pop()
        {
            T temp = start.Value;
            start = start.Next;
            
            Count--;
            return temp;
        }
    }
}
