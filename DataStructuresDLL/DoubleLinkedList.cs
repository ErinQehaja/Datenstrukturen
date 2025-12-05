using System;
using Datenstrukturen;
using Common;
using SortingAlgorithms;

namespace DataStructures
{
    public class DoubleLinkedList<T> where T : IComparable<T>
    {
        public Node<T> head { get; private set; }
        public Node<T> tail { get; private set; }
        private ISortAlgorithm<T> sortAlgorithm;

        public DoubleLinkedList(ISortAlgorithm<T> algorithm = null)
        {
            head = null;
            tail = null;
            sortAlgorithm = algorithm ?? new BubbleSort<T>();
        }

        public void Add(T data)
        {
            Node<T> newNode = new Node<T>(data);

            if (head == null)
            {
                head = newNode;
                tail = newNode;
            }
            else
            {
                newNode.Previous = tail;
                tail.Next = newNode;
                tail = newNode;
            }
        }

        public void BubbleSort()
        {
            if (head == null || head.Next == null) return;

            bool swapped;
            Node<T> current;
            Node<T> next;

            do
            {
                swapped = false;
                current = head;

                while (current.Next != null)
                {
                    next = current.Next;
                    if (current.Data.CompareTo(next.Data) > 0)
                    {
                        T temp = current.Data;
                        current.Data = next.Data;
                        next.Data = temp;
                        swapped = true;
                    }
                    current = current.Next;
                }
            } while (swapped);
        }

        public bool Contains(T data)
        {
            Node<T> current = head;
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

            if (head == null)
            {
                head = newNode;
                tail = newNode;
                return;
            }

            Node<T> current = head;
            while (current != null)
            {
                if (current.Data.Equals(elementAfter))
                {
                    newNode.Next = current;
                    newNode.Previous = current.Previous;

                    if (current == head)
                    {
                        head = newNode;
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

            newNode.Previous = tail;
            tail.Next = newNode;
            tail = newNode;
        }

        public void InsertAfter(T elementBefore, T elementToInsert)
        {
            Node<T> newNode = new Node<T>(elementToInsert);

            if (head == null)
            {
                head = newNode;
                tail = newNode;
                return;
            }

            Node<T> current = head;
            while (current != null)
            {
                if (current.Data.Equals(elementBefore))
                {
                    newNode.Next = current.Next;
                    newNode.Previous = current;

                    if (current == tail)
                    {
                        tail = newNode;
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

            newNode.Previous = tail;
            tail.Next = newNode;
            tail = newNode;
        }

        public int PosOfElement(T element)
        {
            int position = 0;
            Node<T> current = head;
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

        public void Sort()
        {
            head = sortAlgorithm.Sort(head);

            if (head == null)
            {
                tail = null;
                return;
            }

            tail = head;
            while (tail.Next != null)
                tail = tail.Next;

            Node<T> current = head;
            Node<T> prev = null;
            while (current != null)
            {
                current.Previous = prev;
                prev = current;
                current = current.Next;
            }
        }
    }
}