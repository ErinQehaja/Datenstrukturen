using System;

namespace EinfacheListe
{
    public class Person
    {
        public string Name { get; set; }

        public Person(string name)
        {
            Name = name;
        }

        public override bool Equals(object obj)
        {
            if (obj is Person other)
            {
                return Name == other.Name;
            }
            return false;
        }

        public override int GetHashCode()
        {
            return Name.GetHashCode();
        }
    }

    public class Node
    {
        public Person Data { get; set; }
        public Node Next { get; set; }

        public Node(Person data)
        {
            Data = data;
            Next = null;
        }
    }

    public class SimpleList
    {
        public Node Head { get; private set; }

        public SimpleList()
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

    class Program
    {
        static void Main()
        {
            SimpleList list = new SimpleList();

            list.Add(new Person("Alice"));
            list.Add(new Person("Bob"));
            list.Add(new Person("Charlie"));

            Console.WriteLine(list.Contains(new Person("Bob")));
            Console.WriteLine(list.Contains(new Person("David")));
        }
    }
}