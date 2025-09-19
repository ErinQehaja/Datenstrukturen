using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common;

namespace DataStructures
{
    public class SingleLinkedList
    {
        public Node Head { get; private set; }

        public SingleLinkedList()
        {
            Head = null;
        }

        public void Add(Person person)
        {
            Node newNode = new Node(person);

            if (Head == null)
            {
                Head = newNode;
            }
            else
            {
                Node current = Head;
                while (current.Next != null)
                {
                    current = current.Next;
                }
                current.Next = newNode;
            }
        }

        public bool Contains(Person person)
        {
            Node current = Head;
            while (current != null)
            {
                if (current.Data.Equals(person))
                {
                    return true;
                }
                current = current.Next;
            }
            return false;
        }
    }
}