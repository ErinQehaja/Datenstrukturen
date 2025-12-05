using NUnit.Framework;
using Common;
using DataStructures;
using SortingAlgorithms;
using System;
using System.Collections.Generic;

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

        // BUBBLE SORT TESTS
        // Tests für SingleLinkedList + BubbleSort (via Sort-Methode)
        // Tests für DoubleLinkedList + BubbleSort (via Sort-Methode)
        // Tests für DoubleLinkedList.BubbleSort() direkt
        // Tests für BubbleSort<T> direkt (über Interface)

        #region BubbleSort Tests

        [Test]
        public void SingleLinkedList_BubbleSort_EmptyList_NoChange()
        {
            singleList.Sort();
            Assert.IsNull(singleList.head);
        }

        [Test]
        public void SingleLinkedList_BubbleSort_SingleElement_NoChange()
        {
            singleList.Add(new Person("Alice"));
            singleList.Sort();
            Assert.AreEqual("Alice", singleList.head.Data.Name);
            Assert.IsNull(singleList.head.Next);
        }

        [Test]
        public void SingleLinkedList_BubbleSort_TwoElements_OutOfOrder_SwapsCorrectly()
        {
            singleList.Add(new Person("Bob"));
            singleList.Add(new Person("Alice"));
            singleList.Sort();
            Assert.AreEqual("Alice", singleList.head.Data.Name);
            Assert.AreEqual("Bob", singleList.head.Next.Data.Name);
            Assert.IsNull(singleList.head.Next.Next);
        }

        [Test]
        public void SingleLinkedList_BubbleSort_TwoElements_AlreadySorted_NoChange()
        {
            singleList.Add(new Person("Alice"));
            singleList.Add(new Person("Bob"));
            singleList.Sort();
            Assert.AreEqual("Alice", singleList.head.Data.Name);
            Assert.AreEqual("Bob", singleList.head.Next.Data.Name);
            Assert.IsNull(singleList.head.Next.Next);
        }

        [Test]
        public void SingleLinkedList_BubbleSort_MultipleElements_SortsCorrectly()
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

        [Test]
        public void DoubleLinkedList_BubbleSort_EmptyList_NoChange()
        {
            doubleList.Sort();
            Assert.IsNull(doubleList.head);
            Assert.IsNull(doubleList.tail);
        }

        [Test]
        public void DoubleLinkedList_BubbleSort_SingleElement_NoChange()
        {
            doubleList.Add(new Person("Alice"));
            doubleList.Sort();
            Assert.AreEqual("Alice", doubleList.head.Data.Name);
            Assert.AreSame(doubleList.head, doubleList.tail);
            Assert.IsNull(doubleList.head.Next);
            Assert.IsNull(doubleList.head.Previous);
        }

        [Test]
        public void DoubleLinkedList_BubbleSort_TwoElements_OutOfOrder_SwapsCorrectly()
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
        public void DoubleLinkedList_BubbleSort_MultipleElements_SortsCorrectly()
        {
            doubleList.Add(new Person("Eve"));
            doubleList.Add(new Person("Bob"));
            doubleList.Add(new Person("Charlie"));
            doubleList.Add(new Person("Alice"));
            doubleList.Sort();
            var names = GetNames(doubleList.head);
            CollectionAssert.AreEqual(new[] { "Alice", "Bob", "Charlie", "Eve" }, names);
            Assert.AreEqual("Eve", doubleList.tail.Data.Name);
            Assert.AreEqual("Charlie", doubleList.tail.Previous.Data.Name);
            Assert.AreEqual("Bob", doubleList.tail.Previous.Previous.Data.Name);
            Assert.AreEqual("Alice", doubleList.tail.Previous.Previous.Previous.Data.Name);
            Assert.IsNull(doubleList.tail.Next);
            Assert.IsNull(doubleList.head.Previous);
        }

        [Test]
        public void BubbleSortAlgorithm_EmptyList_NoChange()
        {
            Node<Person> head = null;
            var sorter = new BubbleSort<Person>();
            head = sorter.Sort(head);
            Assert.IsNull(head);
        }

        [Test]
        public void BubbleSortAlgorithm_SingleElement_NoChange()
        {
            var node = new Node<Person>(new Person("Alice"));
            var sorter = new BubbleSort<Person>();
            var result = sorter.Sort(node);
            Assert.AreEqual("Alice", result.Data.Name);
            Assert.IsNull(result.Next);
        }

        [Test]
        public void BubbleSortAlgorithm_TwoElements_SwapsIfNeeded()
        {
            var node1 = new Node<Person>(new Person("Bob"));
            var node2 = new Node<Person>(new Person("Alice"));
            node1.Next = node2;
            var sorter = new BubbleSort<Person>();
            var result = sorter.Sort(node1);
            Assert.AreEqual("Alice", result.Data.Name);
            Assert.AreEqual("Bob", result.Next.Data.Name);
            Assert.IsNull(result.Next.Next);
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
                nodes[i].Next = nodes[i + 1];

            var sorter = new BubbleSort<Person>();
            var head = sorter.Sort(nodes[0]);
            var names = GetNames(head);
            CollectionAssert.AreEqual(new[] { "Alpha", "Bravo", "Charlie", "Delta" }, names);
        }

        #endregion

        // INSERTION SORT TESTS
        // Tests für SingleLinkedList + InsertionSort (via Sort-Methode)
        // Tests für DoubleLinkedList + InsertionSort (via Sort-Methode)
        // Tests für DoubleLinkedList.InsertionSort() direkt
        // Tests für InsertionSort<T> direkt (über Interface)

        #region InsertionSort Tests

        [Test]
        public void SingleLinkedList_InsertionSort_EmptyList_NoChange()
        {
            singleList = new SingleLinkedList<Person>(new InsertionSort<Person>());
            singleList.Sort();
            Assert.IsNull(singleList.head);
        }

        [Test]
        public void SingleLinkedList_InsertionSort_SingleElement_NoChange()
        {
            singleList = new SingleLinkedList<Person>(new InsertionSort<Person>());
            singleList.Add(new Person("Alice"));
            singleList.Sort();
            Assert.AreEqual("Alice", singleList.head.Data.Name);
            Assert.IsNull(singleList.head.Next);
        }

        [Test]
        public void SingleLinkedList_InsertionSort_TwoElements_OutOfOrder_InsertsCorrectly()
        {
            singleList = new SingleLinkedList<Person>(new InsertionSort<Person>());
            singleList.Add(new Person("Bob"));
            singleList.Add(new Person("Alice"));
            singleList.Sort();
            Assert.AreEqual("Alice", singleList.head.Data.Name);
            Assert.AreEqual("Bob", singleList.head.Next.Data.Name);
            Assert.IsNull(singleList.head.Next.Next);
        }

        [Test]
        public void SingleLinkedList_InsertionSort_TwoElements_AlreadySorted_NoChange()
        {
            singleList = new SingleLinkedList<Person>(new InsertionSort<Person>());
            singleList.Add(new Person("Alice"));
            singleList.Add(new Person("Bob"));
            singleList.Sort();
            Assert.AreEqual("Alice", singleList.head.Data.Name);
            Assert.AreEqual("Bob", singleList.head.Next.Data.Name);
            Assert.IsNull(singleList.head.Next.Next);
        }

        [Test]
        public void SingleLinkedList_InsertionSort_MultipleElements_SortsCorrectly()
        {
            singleList = new SingleLinkedList<Person>(new InsertionSort<Person>());
            singleList.Add(new Person("Charlie"));
            singleList.Add(new Person("Alice"));
            singleList.Add(new Person("Eve"));
            singleList.Add(new Person("Bob"));
            singleList.Add(new Person("David"));
            singleList.Sort();
            var names = GetNames(singleList.head);
            CollectionAssert.AreEqual(new[] { "Alice", "Bob", "Charlie", "David", "Eve" }, names);
        }

        [Test]
        public void DoubleLinkedList_InsertionSort_EmptyList_NoChange()
        {
            doubleList = new DoubleLinkedList<Person>(new InsertionSort<Person>());
            doubleList.Sort();
            Assert.IsNull(doubleList.head);
            Assert.IsNull(doubleList.tail);
        }

        [Test]
        public void DoubleLinkedList_InsertionSort_SingleElement_NoChange()
        {
            doubleList = new DoubleLinkedList<Person>(new InsertionSort<Person>());
            doubleList.Add(new Person("Alice"));
            doubleList.Sort();
            Assert.AreEqual("Alice", doubleList.head.Data.Name);
            Assert.AreSame(doubleList.head, doubleList.tail);
            Assert.IsNull(doubleList.head.Next);
            Assert.IsNull(doubleList.head.Previous);
        }

        [Test]
        public void DoubleLinkedList_InsertionSort_TwoElements_OutOfOrder_InsertsCorrectly()
        {
            doubleList = new DoubleLinkedList<Person>(new InsertionSort<Person>());
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
        public void DoubleLinkedList_InsertionSort_MultipleElements_SortsCorrectly()
        {
            doubleList = new DoubleLinkedList<Person>(new InsertionSort<Person>());
            doubleList.Add(new Person("Eve"));
            doubleList.Add(new Person("Bob"));
            doubleList.Add(new Person("Charlie"));
            doubleList.Add(new Person("Alice"));
            doubleList.Sort();
            var names = GetNames(doubleList.head);
            CollectionAssert.AreEqual(new[] { "Alice", "Bob", "Charlie", "Eve" }, names);
            Assert.AreEqual("Eve", doubleList.tail.Data.Name);
            Assert.AreEqual("Charlie", doubleList.tail.Previous.Data.Name);
            Assert.AreEqual("Bob", doubleList.tail.Previous.Previous.Data.Name);
            Assert.AreEqual("Alice", doubleList.tail.Previous.Previous.Previous.Data.Name);
            Assert.IsNull(doubleList.tail.Next);
            Assert.IsNull(doubleList.head.Previous);
        }

        [Test]
        public void InsertionSortAlgorithm_EmptyList_NoChange()
        {
            Node<Person> head = null;
            var sorter = new InsertionSort<Person>();
            var result = sorter.Sort(head);
            Assert.IsNull(result);
        }

        [Test]
        public void InsertionSortAlgorithm_SingleElement_NoChange()
        {
            var node = new Node<Person>(new Person("Alice"));
            var sorter = new InsertionSort<Person>();
            var result = sorter.Sort(node);
            Assert.AreEqual("Alice", result.Data.Name);
            Assert.IsNull(result.Next);
        }

        [Test]
        public void InsertionSortAlgorithm_TwoElements_InsertsCorrectly()
        {
            var node1 = new Node<Person>(new Person("Bob"));
            var node2 = new Node<Person>(new Person("Alice"));
            node1.Next = node2;
            var sorter = new InsertionSort<Person>();
            var result = sorter.Sort(node1);
            Assert.AreEqual("Alice", result.Data.Name);
            Assert.AreEqual("Bob", result.Next.Data.Name);
            Assert.IsNull(result.Next.Next);
        }

        [Test]
        public void InsertionSortAlgorithm_MultipleElements_SortsCorrectly()
        {
            var nodes = new[]
            {
                new Node<Person>(new Person("Delta")),
                new Node<Person>(new Person("Bravo")),
                new Node<Person>(new Person("Charlie")),
                new Node<Person>(new Person("Alpha"))
            };
            for (int i = 0; i < nodes.Length - 1; i++)
                nodes[i].Next = nodes[i + 1];

            var sorter = new InsertionSort<Person>();
            var head = sorter.Sort(nodes[0]);
            var names = GetNames(head);
            CollectionAssert.AreEqual(new[] { "Alpha", "Bravo", "Charlie", "Delta" }, names);
        }

        #endregion

        // HILFSMETHODEN

        private string[] GetNames(Node<Person> head)
        {
            var names = new List<string>();
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