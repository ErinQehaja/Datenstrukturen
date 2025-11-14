using Common;
using Datenstrukturen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortingAlgorithms
{
    public class BubbleSort<T> : ISortAlgorithm<T> where T : IComparable<T>
    {
        public void Sort(Node<T> head)
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
    }
}