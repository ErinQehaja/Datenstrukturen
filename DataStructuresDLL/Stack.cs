using System;
using Common;

namespace DataStructures
{
    public class Stack<T>
    {
        private Node<T> top;

        public int Count { get; private set; }

        public Stack()
        {
            top = null;
            Count = 0;
        }

        public void Push(T item)
        {
            Node<T> newNode = new Node<T>(item)
            {
                Next = top
            };

            top = newNode;
            Count++;
        }

        public T Pop()
        {
            if (IsEmpty())
            {
                throw new InvalidOperationException("Stack is empty.");
            }

            T value = top.Data;
            top = top.Next;
            Count--;
            return value;
        }

        public T Peek()
        {
            if (IsEmpty())
            {
                throw new InvalidOperationException("Stack is empty.");
            }

            return top.Data;
        }

        public bool IsEmpty()
        {
            return Count == 0;
        }

        public void Clear()
        {
            top = null;
            Count = 0;
        }
    }
}

