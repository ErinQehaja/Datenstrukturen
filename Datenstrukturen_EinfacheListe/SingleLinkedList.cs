using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common;

namespace DataStructures
{
    public class SingleLinkedList<T>
    {
        public Node<T> Head { get; private set; }

        public SingleLinkedList()
        {
            Head = null;
        }

        public void Add(T data)
        {
            Node<T> newNode = new Node<T>(data);

            if (Head == null)
            {
                Head = newNode;
            }
            else
            {
                Node<T> current = Head;
                while (current.Next != null)
                {
                    current = current.Next;
                }
                current.Next = newNode;
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
    }
}