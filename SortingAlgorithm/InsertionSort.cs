using Common;
using Datenstrukturen;
using System;

namespace SortingAlgorithms
{
    public class InsertionSort<T> : ISortAlgorithm<T> where T : IComparable<T>
    {
        public Node<T> Sort(Node<T> head)
        {
            if (head == null || head.Next == null) return head;

            Node<T> sorted = null;
            Node<T> current = head;

            while (current != null)
            {
                Node<T> next = current.Next;
                sorted = InsertIntoSortedList(sorted, current);
                current = next;
            }

            return sorted;
        }

        private Node<T> InsertIntoSortedList(Node<T> sortedHead, Node<T> newNode)
        {
            if (sortedHead == null || sortedHead.Data.CompareTo(newNode.Data) >= 0)
            {
                newNode.Next = sortedHead;
                if (sortedHead != null)
                    sortedHead.Previous = newNode;
                newNode.Previous = null;
                return newNode;
            }

            Node<T> current = sortedHead;
            while (current.Next != null && current.Next.Data.CompareTo(newNode.Data) < 0)
            {
                current = current.Next;
            }

            newNode.Next = current.Next;
            if (current.Next != null)
                current.Next.Previous = newNode;
            current.Next = newNode;
            newNode.Previous = current;

            return sortedHead;
        }
    }
}