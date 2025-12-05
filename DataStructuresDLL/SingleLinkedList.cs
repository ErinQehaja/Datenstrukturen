using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common;
using Datenstrukturen;
using SortingAlgorithms;

namespace DataStructures
{
    public class SingleLinkedList<T> where T : IComparable<T>
    {
        public Node<T> head { get; private set; }
        private ISortAlgorithm<T> sortAlgorithm;

        public SingleLinkedList(ISortAlgorithm<T> algorithm = null)
        {
            head = null;
            sortAlgorithm = algorithm ?? new BubbleSort<T>();
        }

        public void Add(T data)
        {
            Node<T> newNode = new Node<T>(data);

            if (head == null)
            {
                head = newNode;
            }
            else
            {
                Node<T> current = head;
                while (current.Next != null)
                {
                    current = current.Next;
                }
                current.Next = newNode;
            }
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
                return;
            }

            if (head.Data.Equals(elementAfter))
            {
                newNode.Next = head;
                head = newNode;
                return;
            }

            Node<T> current = head;
            while (current.Next != null)
            {
                if (current.Next.Data.Equals(elementAfter))
                {
                    newNode.Next = current.Next;
                    current.Next = newNode;
                    return;
                }
                current = current.Next;
            }

            current.Next = newNode;
        }

        public void InsertAfter(T elementBefore, T elementToInsert)
        {
            Node<T> newNode = new Node<T>(elementToInsert);

            if (head == null)
            {
                head = newNode;
                return;
            }

            Node<T> current = head;
            while (current != null)
            {
                if (current.Data.Equals(elementBefore))
                {
                    newNode.Next = current.Next;
                    current.Next = newNode;
                    return;
                }
                current = current.Next;
            }

            if (current == null && head != null)
            {
                current = head;
                while (current.Next != null)
                {
                    current = current.Next;
                }
                current.Next = newNode;
            }
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
        }
    }
}