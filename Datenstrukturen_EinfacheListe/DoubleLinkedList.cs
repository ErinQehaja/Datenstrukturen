using System;
using Common;

namespace DataStructures
{
    public class DoubleLinkedList<T>
    {
        private Node<T> Head { get; set; }
        private Node<T> Tail { get; set; }

        public DoubleLinkedList()
        {
            Head = null;
            Tail = null;
        }

        public void Add(T data)
        {
            Node<T> newNode = new Node<T>(data);

            if (Head == null)
            {
                Head = newNode;
                Tail = newNode;
            }
            else
            {
                newNode.Previous = Tail;
                Tail.Next = newNode;
                Tail = newNode;
            }
        }

        public bool Contains(T data)
        {
            Node<T> current = Head;
            while (current != null)
            {
                if (current.Data.Equals(data))
                {
                    return true;
                }
                current = current.Next;
            }
            return false;
        }

        public void InsertBefore(T elementAfter, T elementToInsert)
        {
            Node<T> newNode = new Node<T>(elementToInsert);

            if (Head == null)
            {
                Head = newNode;
                Tail = newNode;
                return;
            }

            Node<T> current = Head;
            while (current != null)
            {
                if (current.Data.Equals(elementAfter))
                {
                    newNode.Next = current;
                    newNode.Previous = current.Previous;

                    if (current == Head)
                    {
                        Head = newNode;
                    }
                    else
                    {
                        current.Previous.Next = newNode;
                    }
                    current.Previous = newNode;
                    return;
                }
                current = current.Next;
            }

            newNode.Previous = Tail;
            Tail.Next = newNode;
            Tail = newNode;
        }

        public void InsertAfter(T elementBefore, T elementToInsert)
        {
            Node<T> newNode = new Node<T>(elementToInsert);

            if (Head == null)
            {
                Head = newNode;
                Tail = newNode;
                return;
            }

            Node<T> current = Head;
            while (current != null)
            {
                if (current.Data.Equals(elementBefore))
                {
                    newNode.Next = current.Next;
                    newNode.Previous = current;

                    if (current == Tail)
                    {
                        Tail = newNode;
                    }
                    else
                    {
                        current.Next.Previous = newNode;
                    }
                    current.Next = newNode;
                    return;
                }
                current = current.Next;
            }

            newNode.Previous = Tail;
            Tail.Next = newNode;
            Tail = newNode;
        }

        public int PosOfElement(T element)
        {
            int position = 0;
            Node<T> current = Head;
            while (current != null)
            {
                if (current.Data.Equals(element))
                {
                    return position;
                }
                current = current.Next;
                position++;
            }
            return -1;
        }
    }
}