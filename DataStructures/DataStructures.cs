using System;
using DataStructures.CustomList;
using DataStructures.CustomQueue;
using DataStructures.CustomStack;

namespace DataStructures
{
    class Program
    {
        static void Main(string[] args)
        {
            LinkedStack<int> lstack = new LinkedStack<int>();

            lstack.Push(1);
            lstack.Push(2);
            lstack.Push(3);
            lstack.Push(4);
            lstack.Push(5);

            lstack.Print();

            lstack.Pop();
            lstack.Print();

            lstack.Pop();
            lstack.Print();

            lstack.Pop();
            lstack.Print();

            Stack<int> stack = new Stack<int>();

            stack.Push(1);
            stack.Push(2);
            stack.Push(3);
            stack.Push(4);
            stack.Push(5);

            stack.Print();

            stack.Pop();
            stack.Print();

            stack.Pop();
            stack.Print();

            stack.Pop();
            stack.Print();
        }
    }
}
