using System;

namespace DataStructures.CustomList
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

        public Node(T value, Node<T> prevNode)
        {
            Value = value;

            Prev = prevNode;
            Next = prevNode.Next;

            Prev.Next = this;
            Next.Prev = this;
        }
    }
    class LinkedList<T>
    {
        private Node<T> start;
        private Node<T> end;
        public int Count { get; private set; }

        public LinkedList()
        {
            start = null;
            end = null;
            Count = 0;
        }

        public void Print()
        {
            Node<T> current = start;

            while (current != null)
            {
                T prevValue = (current.Prev == null) ? default(T) : current.Prev.Value;
                T nextValue = (current.Next == null) ? default(T) : current.Next.Value;

                Console.Write($"{current.Value} ({prevValue}::{nextValue})");
                current = current.Next;
            }

            Console.WriteLine();
        }

        public void Insert(int index, T value)
        {
            BorderCheckExclusive(index);

            Node<T> current = start;
            int i = 0;

            do
            {
                if (i == index)
                {
                    if (index == 0)
                    {
                        start = new Node<T>(value);
                        start.Next = current;

                        if (Count != 0)
                        {
                            current.Prev = start;
                        }
                        end = (Count == 0) ? start : end;
                    }

                    else if (index == Count)
                    {
                        Node<T> node = new Node<T>(value);
                        node.Prev = end;

                        end.Next = node;
                        end = node;
                    }

                    else
                    {
                        new Node<T>(value, current.Prev);
                    }

                    Count++;
                    break;
                }

                current = current.Next;
                i++;

            } while (i != index + 1);
        }

        public void Add(T value)
        {
            if (Count == 0)
            {
                Node<T> node = new Node<T>(value);
                start = end = node;
            }

            else
            {
                Node<T> node = new Node<T>(value);
                node.Prev = end;

                end.Next = node;
                end = node;
            }

            Count++;
        }

        public T RemoveAt(int index)
        {
            BorderCheckInclusive(index);

            T value = default(T);
            Node<T> current = start;
            int i = 0;

            while (current != null)
            {
                if (i == index)
                {
                    if (index == 0)
                    {
                        start = (Count == 0) ? null : current.Next;

                        if (Count != 0)
                        {
                            start.Prev = null;
                        }
                    }

                    else if (index + 1 == Count)
                    {
                        current.Prev.Next = null;
                        end = current.Prev;
                    }

                    else
                    {
                        current.Prev.Next = current.Next;
                        current.Next.Prev = current.Prev;
                    }

                    value = current.Value;
                    Count--;
                }

                current = current.Next;
                i++;
            }

            return value;
        }

        public int Remove(T value)
        {
            Node<T> current = start;
            int i = 0;

            while (current != null)
            {
                if (current.Value.Equals(value))
                {
                    if (i == 0)
                    {
                        start = (Count == 0) ? null : current.Next;

                        if (Count != 0)
                        {
                            start.Prev = null ;
                        }
                    }

                    else if (i + 1 == Count)
                    {
                        current.Prev.Next = null;
                        end = current.Prev;
                    }

                    else
                    {
                        current.Prev.Next = current.Next;
                        current.Next.Prev = current.Prev;
                    }

                    Count--;
                    return i;
                }

                i++;
                current = current.Next;
            }

            return -1;
        }

        public bool Contains(T value)
        {
            Node<T> current = start;

            while (current != null)
            {
                if (current.Value.Equals(value))
                {
                    return true;
                }
            }

            return false;
        }

        public int IndexOf(T value)
        {
            Node<T> current = start;
            int i = 0;

            while (current != null)
            {
                if (current.Value.Equals(value))
                {
                    return i;
                }

                i++;
            }

            return -1;
        }

        private void BorderCheckExclusive(int index)
        {
            if (index > Count || index < 0)
                throw new IndexOutOfRangeException("Invalid index");
        }

        private void BorderCheckInclusive(int index)
        {
            if (index >= Count || index < 0)
                throw new IndexOutOfRangeException("Invalid index");
        }
    }
}
