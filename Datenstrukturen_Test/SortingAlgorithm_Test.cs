using NUnit.Framework;
using Common;
using DataStructures;
using SortingAlgorithms;
using System;

namespace SortingAlgorithms.Tests
{
    [TestFixture]
    public class SortingAlgorithm_Test
    {
        private SingleLinkedList<Person> singleList;
        private DoubleLinkedList<Person> doubleList;

        [SetUp]
        public void Setup()
        {
            singleList = new SingleLinkedList<Person>();
            doubleList = new DoubleLinkedList<Person>();
        }

        // Tests für SingleLinkedList + BubbleSort

        [Test]
        public void SingleLinkedList_Sort_EmptyList_NoChange()
        {
            singleList.Sort();
            Assert.IsNull(singleList.head);
        }

        [Test]
        public void SingleLinkedList_Sort_SingleElement_NoChange()
        {
            singleList.Add(new Person("Alice"));
            singleList.Sort();

            Assert.AreEqual("Alice", singleList.head.Data.Name);
            Assert.IsNull(singleList.head.Next);
        }

        [Test]
        public void SingleLinkedList_Sort_TwoElements_OutOfOrder_SwapsCorrectly()
        {
            singleList.Add(new Person("Bob"));
            singleList.Add(new Person("Alice"));
            singleList.Sort();

            Assert.AreEqual("Alice", singleList.head.Data.Name);
            Assert.AreEqual("Bob", singleList.head.Next.Data.Name);
            Assert.IsNull(singleList.head.Next.Next);
        }

        [Test]
        public void SingleLinkedList_Sort_TwoElements_AlreadySorted_NoChange()
        {
            singleList.Add(new Person("Alice"));
            singleList.Add(new Person("Bob"));
            singleList.Sort();

            Assert.AreEqual("Alice", singleList.head.Data.Name);
            Assert.AreEqual("Bob", singleList.head.Next.Data.Name);
            Assert.IsNull(singleList.head.Next.Next);
        }

        [Test]
        public void SingleLinkedList_Sort_MultipleElements_SortsCorrectly()
        {
            singleList.Add(new Person("Charlie"));
            singleList.Add(new Person("Alice"));
            singleList.Add(new Person("Eve"));
            singleList.Add(new Person("Bob"));
            singleList.Add(new Person("David"));

            singleList.Sort();

            var names = GetNames(singleList.head);
            CollectionAssert.AreEqual(new[] { "Alice", "Bob", "Charlie", "David", "Eve" }, names);
        }

        // Tests für DoubleLinkedList + BubbleSort (via Sort())

        [Test]
        public void DoubleLinkedList_Sort_EmptyList_NoChange()
        {
            doubleList.Sort();
            Assert.IsNull(doubleList.head);
            Assert.IsNull(doubleList.tail);
        }

        [Test]
        public void DoubleLinkedList_Sort_SingleElement_NoChange()
        {
            doubleList.Add(new Person("Alice"));
            doubleList.Sort();

            Assert.AreEqual("Alice", doubleList.head.Data.Name);
            Assert.AreSame(doubleList.head, doubleList.tail);
            Assert.IsNull(doubleList.head.Next);
            Assert.IsNull(doubleList.head.Previous);
        }

        [Test]
        public void DoubleLinkedList_Sort_TwoElements_OutOfOrder_SwapsCorrectly()
        {
            doubleList.Add(new Person("Bob"));
            doubleList.Add(new Person("Alice"));
            doubleList.Sort();

            Assert.AreEqual("Alice", doubleList.head.Data.Name);
            Assert.AreEqual("Bob", doubleList.head.Next.Data.Name);
            Assert.IsNull(doubleList.head.Next.Next);

            Assert.AreSame(doubleList.head.Next, doubleList.tail);
            Assert.AreSame(doubleList.head, doubleList.tail.Previous);
            Assert.IsNull(doubleList.head.Previous);
            Assert.IsNull(doubleList.tail.Next);
        }

        [Test]
        public void DoubleLinkedList_Sort_MultipleElements_SortsCorrectly()
        {
            doubleList.Add(new Person("Eve"));
            doubleList.Add(new Person("Bob"));
            doubleList.Add(new Person("Charlie"));
            doubleList.Add(new Person("Alice"));

            doubleList.Sort();

            var names = GetNames(doubleList.head);
            CollectionAssert.AreEqual(new[] { "Alice", "Bob", "Charlie", "Eve" }, names);

            // Prüfe bidirektionale Verweise
            Assert.AreEqual("Eve", doubleList.tail.Data.Name);
            Assert.AreEqual("Charlie", doubleList.tail.Previous.Data.Name);
            Assert.AreEqual("Bob", doubleList.tail.Previous.Previous.Data.Name);
            Assert.AreEqual("Alice", doubleList.tail.Previous.Previous.Previous.Data.Name);
            Assert.IsNull(doubleList.tail.Next);
            Assert.IsNull(doubleList.head.Previous);
        }

        // Tests für DoubleLinkedList.BubbleSort() direkt

        [Test]
        public void DoubleLinkedList_BubbleSort_EmptyList_NoChange()
        {
            doubleList.BubbleSort();
            Assert.IsNull(doubleList.head);
            Assert.IsNull(doubleList.tail);
        }

        [Test]
        public void DoubleLinkedList_BubbleSort_SingleElement_NoChange()
        {
            doubleList.Add(new Person("Alice"));
            doubleList.BubbleSort();

            Assert.AreEqual("Alice", doubleList.head.Data.Name);
            Assert.AreSame(doubleList.head, doubleList.tail);
        }

        [Test]
        public void DoubleLinkedList_BubbleSort_TwoElements_SortsCorrectly()
        {
            doubleList.Add(new Person("Bob"));
            doubleList.Add(new Person("Alice"));
            doubleList.BubbleSort();

            Assert.AreEqual("Alice", doubleList.head.Data.Name);
            Assert.AreEqual("Bob", doubleList.head.Next.Data.Name);
            Assert.AreSame(doubleList.head.Next, doubleList.tail);
            Assert.AreSame(doubleList.head, doubleList.tail.Previous);
        }

        [Test]
        public void DoubleLinkedList_BubbleSort_MultipleElements_SortsCorrectly()
        {
            doubleList.Add(new Person("Charlie"));
            doubleList.Add(new Person("Alice"));
            doubleList.Add(new Person("Bob"));
            doubleList.BubbleSort();

            var names = GetNames(doubleList.head);
            CollectionAssert.AreEqual(new[] { "Alice", "Bob", "Charlie" }, names);

            Assert.AreEqual("Charlie", doubleList.tail.Data.Name);
            Assert.AreEqual("Bob", doubleList.tail.Previous.Data.Name);
            Assert.AreEqual("Alice", doubleList.tail.Previous.Previous.Data.Name);
        }

        // Tests für BubbleSort<T> direkt (über Interface)

        [Test]
        public void BubbleSortAlgorithm_EmptyList_NoChange()
        {
            Node<Person> head = null;
            var sorter = new BubbleSort<Person>();
            sorter.Sort(head);

            Assert.IsNull(head);
        }

        [Test]
        public void BubbleSortAlgorithm_SingleElement_NoChange()
        {
            var node = new Node<Person>(new Person("Alice"));
            var sorter = new BubbleSort<Person>();
            sorter.Sort(node);

            Assert.AreEqual("Alice", node.Data.Name);
            Assert.IsNull(node.Next);
        }

        [Test]
        public void BubbleSortAlgorithm_TwoElements_SwapsIfNeeded()
        {
            var node1 = new Node<Person>(new Person("Bob"));
            var node2 = new Node<Person>(new Person("Alice"));
            node1.Next = node2;

            var sorter = new BubbleSort<Person>();
            sorter.Sort(node1);

            Assert.AreEqual("Alice", node1.Data.Name);
            Assert.AreEqual("Bob", node1.Next.Data.Name);
            Assert.IsNull(node1.Next.Next);
        }

        [Test]
        public void BubbleSortAlgorithm_MultipleElements_SortsCorrectly()
        {
            var nodes = new[]
            {
                new Node<Person>(new Person("Delta")),
                new Node<Person>(new Person("Bravo")),
                new Node<Person>(new Person("Charlie")),
                new Node<Person>(new Person("Alpha"))
            };

            for (int i = 0; i < nodes.Length - 1; i++)
            {
                nodes[i].Next = nodes[i + 1];
            }

            var sorter = new BubbleSort<Person>();
            sorter.Sort(nodes[0]);

            var names = new List<string>();
            var current = nodes[0];
            while (current != null)
            {
                names.Add(current.Data.Name);
                current = current.Next;
            }

            CollectionAssert.AreEqual(new[] { "Alpha", "Bravo", "Charlie", "Delta" }, names);
        }

        // Hilfsmethode: Namen aus verketteter Liste extrahieren

        private string[] GetNames(Node<Person> head)
        {
            var names = new System.Collections.Generic.List<string>();
            var current = head;
            while (current != null)
            {
                names.Add(current.Data.Name);
                current = current.Next;
            }
            return names.ToArray();
        }
    }
}