using System;

namespace DataStructures.CustomQueue
{
    class Node<T>
    {
        public T Value { get; private set; }
        public Node<T> Next { get; set; }
        public Node<T> Prev { get; set; }

        public Node(T value)
        {
            Value = value;
            Next = null;
            Prev = null;
        }
    }

    class LinkedQueue<T>
    {
        private Node<T> start;
        private Node<T> end;

        public int Count { get; private set; }

        public LinkedQueue()
        {
            start = null;
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

        public void Enqueue(T value)
        {
            if (start == null)
            {
                start = end = new Node<T>(value);
            }

            else
            {
                Node<T> temp = new Node<T>(value);
                
                temp.Prev = end;
                end.Next = temp;
                end = temp;
            }

            Count++;
        }

        public T Dequeue()
        {
            Node<T> temp = start;

            start = start.Next;
            start.Prev = null;

            Count--;
            return temp.Value;
        }
    }
}
