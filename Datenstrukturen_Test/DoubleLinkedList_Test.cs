using NUnit.Framework;
using Common;
using System;
using DataStructures;

namespace DataStructures
{
    [TestFixture]
    public class DoubleLinkedListTest
    {
        private DoubleLinkedList<Person> list;

        [SetUp]
        public void Setup()
        {
            list = new DoubleLinkedList<Person>();
        }

        [Test]
        public void Add_SinglePerson_HeadAndTailAreSet()
        {
            Person person = new Person("Alice");
            list.Add(person);
            Assert.IsNotNull(list.head);
            Assert.AreEqual(person.Name, list.head.Data.Name);
            Assert.IsNull(list.head.Next);
            Assert.IsNull(list.head.Previous);
            Assert.AreSame(list.head, list.tail);
        }

        [Test]
        public void Add_MultiplePersons_CorrectOrder()
        {
            Person person1 = new Person("Alice");
            Person person2 = new Person("Bob");
            Person person3 = new Person("Charlie");
            list.Add(person1);
            list.Add(person2);
            list.Add(person3);
            Assert.IsNotNull(list.head);
            Assert.AreEqual("Alice", list.head.Data.Name);
            Assert.IsNotNull(list.head.Next);
            Assert.AreEqual("Bob", list.head.Next.Data.Name);
            Assert.IsNotNull(list.head.Next.Next);
            Assert.AreEqual("Charlie", list.head.Next.Next.Data.Name);
            Assert.IsNull(list.head.Next.Next.Next);
            Assert.AreEqual("Charlie", list.tail.Data.Name);
            Assert.AreEqual("Bob", list.tail.Previous.Data.Name);
            Assert.AreEqual("Alice", list.tail.Previous.Previous.Data.Name);
            Assert.IsNull(list.head.Previous);
        }

        [Test]
        public void Contains_EmptyList_ReturnsFalse()
        {
            Person person = new Person("Alice");
            bool result = list.Contains(person);
            Assert.IsFalse(result);
        }

        [Test]
        public void Contains_ExistingPerson_ReturnsTrue()
        {
            Person person = new Person("Alice");
            list.Add(person);
            bool result = list.Contains(new Person("Alice"));
            Assert.IsTrue(result);
        }

        [Test]
        public void Contains_NonExistingPerson_ReturnsFalse()
        {
            Person person = new Person("Alice");
            list.Add(person);
            bool result = list.Contains(new Person("Bob"));
            Assert.IsFalse(result);
        }

        [Test]
        public void Contains_MultiplePersons_CheckLastPerson()
        {
            list.Add(new Person("Alice"));
            list.Add(new Person("Bob"));
            list.Add(new Person("Charlie"));
            bool result = list.Contains(new Person("Charlie"));
            Assert.IsTrue(result);
        }

        [Test]
        public void Person_Equals_DifferentObjectsSameName_ReturnsTrue()
        {
            Person person1 = new Person("Alice");
            Person person2 = new Person("Alice");
            Assert.IsTrue(person1.Equals(person2));
        }

        [Test]
        public void Person_Equals_DifferentNames_ReturnsFalse()
        {
            Person person1 = new Person("Alice");
            Person person2 = new Person("Bob");
            Assert.IsFalse(person1.Equals(person2));
        }

        [Test]
        public void InsertBefore_EmptyList_InsertsAsHeadAndTail()
        {
            Person newPerson = new Person("Alice");
            Person afterPerson = new Person("Bob");
            int oldPos = list.PosOfElement(afterPerson);
            list.InsertBefore(afterPerson, newPerson);
            int newPos = list.PosOfElement(afterPerson);
            Assert.AreEqual(oldPos, newPos);
            Assert.IsNotNull(list.head);
            Assert.AreEqual("Alice", list.head.Data.Name);
            Assert.IsNull(list.head.Next);
            Assert.IsNull(list.head.Previous);
            Assert.AreSame(list.head, list.tail);
        }

        [Test]
        public void InsertBefore_BeforeFirstElement_InsertsAtHead()
        {
            Person afterPerson = new Person("Bob");
            list.Add(afterPerson);
            int oldPos = list.PosOfElement(afterPerson);
            Person newPerson = new Person("Alice");
            list.InsertBefore(afterPerson, newPerson);
            int newPos = list.PosOfElement(afterPerson);
            Assert.AreNotEqual(oldPos, newPos);
            Assert.AreEqual(1, newPos);
            Assert.IsNotNull(list.head);
            Assert.AreEqual("Alice", list.head.Data.Name);
            Assert.IsNotNull(list.head.Next);
            Assert.AreEqual("Bob", list.head.Next.Data.Name);
            Assert.IsNull(list.head.Next.Next);
            Assert.AreEqual("Bob", list.tail.Data.Name);
            Assert.AreEqual("Alice", list.tail.Previous.Data.Name);
            Assert.IsNull(list.head.Previous);
        }

        [Test]
        public void InsertBefore_BeforeMiddleElement_InsertsCorrectly()
        {
            Person afterPerson = new Person("Charlie");
            list.Add(new Person("Alice"));
            list.Add(afterPerson);
            int oldPos = list.PosOfElement(afterPerson);
            Person newPerson = new Person("Bob");
            list.InsertBefore(afterPerson, newPerson);
            int newPos = list.PosOfElement(afterPerson);
            Assert.AreNotEqual(oldPos, newPos);
            Assert.AreEqual(2, newPos);
            Assert.IsNotNull(list.head);
            Assert.AreEqual("Alice", list.head.Data.Name);
            Assert.IsNotNull(list.head.Next);
            Assert.AreEqual("Bob", list.head.Next.Data.Name);
            Assert.IsNotNull(list.head.Next.Next);
            Assert.AreEqual("Charlie", list.head.Next.Next.Data.Name);
            Assert.IsNull(list.head.Next.Next.Next);
            Assert.AreEqual("Charlie", list.tail.Data.Name);
            Assert.AreEqual("Bob", list.tail.Previous.Data.Name);
            Assert.AreEqual("Alice", list.tail.Previous.Previous.Data.Name);
        }

        [Test]
        public void InsertBefore_NonExistingElement_InsertsAtEnd()
        {
            Person afterPerson = new Person("Charlie");
            list.Add(new Person("Alice"));
            int oldPos = list.PosOfElement(afterPerson);
            Person newPerson = new Person("Bob");
            list.InsertBefore(afterPerson, newPerson);
            int newPos = list.PosOfElement(afterPerson);
            Assert.AreEqual(oldPos, newPos);
            Assert.IsNotNull(list.head);
            Assert.AreEqual("Alice", list.head.Data.Name);
            Assert.IsNotNull(list.head.Next);
            Assert.AreEqual("Bob", list.head.Next.Data.Name);
            Assert.IsNull(list.head.Next.Next);
            Assert.AreEqual("Bob", list.tail.Data.Name);
            Assert.AreEqual("Alice", list.tail.Previous.Data.Name);
        }

        [Test]
        public void InsertAfter_EmptyList_InsertsAsHeadAndTail()
        {
            Person newPerson = new Person("Alice");
            Person beforePerson = new Person("Bob");
            int oldPos = list.PosOfElement(beforePerson);
            list.InsertAfter(beforePerson, newPerson);
            int newPos = list.PosOfElement(beforePerson);
            Assert.AreEqual(oldPos, newPos);
            Assert.IsNotNull(list.head);
            Assert.AreEqual("Alice", list.head.Data.Name);
            Assert.IsNull(list.head.Next);
            Assert.IsNull(list.head.Previous);
            Assert.AreSame(list.head, list.tail);
        }

        [Test]
        public void InsertAfter_AfterFirstElement_InsertsCorrectly()
        {
            Person beforePerson = new Person("Alice");
            list.Add(beforePerson);
            int oldPos = list.PosOfElement(beforePerson);
            Person newPerson = new Person("Bob");
            list.InsertAfter(beforePerson, newPerson);
            int newPos = list.PosOfElement(beforePerson);
            Assert.AreEqual(oldPos, newPos);
            Assert.AreEqual(0, newPos);
            Assert.IsNotNull(list.head);
            Assert.AreEqual("Alice", list.head.Data.Name);
            Assert.IsNotNull(list.head.Next);
            Assert.AreEqual("Bob", list.head.Next.Data.Name);
            Assert.IsNull(list.head.Next.Next);
            Assert.AreEqual("Bob", list.tail.Data.Name);
            Assert.AreEqual("Alice", list.tail.Previous.Data.Name);
        }

        [Test]
        public void InsertAfter_AfterMiddleElement_InsertsCorrectly()
        {
            Person beforePerson = new Person("Alice");
            list.Add(beforePerson);
            list.Add(new Person("Charlie"));
            int oldPos = list.PosOfElement(beforePerson);
            Person newPerson = new Person("Bob");
            list.InsertAfter(beforePerson, newPerson);
            int newPos = list.PosOfElement(beforePerson);
            Assert.AreEqual(oldPos, newPos);
            Assert.AreEqual(0, newPos);
            Assert.IsNotNull(list.head);
            Assert.AreEqual("Alice", list.head.Data.Name);
            Assert.IsNotNull(list.head.Next);
            Assert.AreEqual("Bob", list.head.Next.Data.Name);
            Assert.IsNotNull(list.head.Next.Next);
            Assert.AreEqual("Charlie", list.head.Next.Next.Data.Name);
            Assert.IsNull(list.head.Next.Next.Next);
            Assert.AreEqual("Charlie", list.tail.Data.Name);
            Assert.AreEqual("Bob", list.tail.Previous.Data.Name);
            Assert.AreEqual("Alice", list.tail.Previous.Previous.Data.Name);
        }

        [Test]
        public void InsertAfter_NonExistingElement_InsertsAtEnd()
        {
            Person beforePerson = new Person("Charlie");
            list.Add(new Person("Alice"));
            int oldPos = list.PosOfElement(beforePerson);
            Person newPerson = new Person("Bob");
            list.InsertAfter(beforePerson, newPerson);
            int newPos = list.PosOfElement(beforePerson);
            Assert.AreEqual(oldPos, newPos);
            Assert.IsNotNull(list.head);
            Assert.AreEqual("Alice", list.head.Data.Name);
            Assert.IsNotNull(list.head.Next);
            Assert.AreEqual("Bob", list.head.Next.Data.Name);
            Assert.IsNull(list.head.Next.Next);
            Assert.AreEqual("Bob", list.tail.Data.Name);
            Assert.AreEqual("Alice", list.tail.Previous.Data.Name);
        }

        [Test]
        public void BubbleSort_EmptyList_NoChange()
        {
            list.BubbleSort();
            Assert.IsNull(list.head);
            Assert.IsNull(list.tail);
        }

        [Test]
        public void BubbleSort_SingleElement_NoChange()
        {
            list.Add(new Person("Alice"));
            list.BubbleSort();
            Assert.AreEqual("Alice", list.head.Data.Name);
            Assert.IsNull(list.head.Next);
            Assert.AreSame(list.head, list.tail);
        }

        [Test]
        public void BubbleSort_TwoElements_SortsCorrectly()
        {
            list.Add(new Person("Bob"));
            list.Add(new Person("Alice"));
            list.BubbleSort();
            Assert.AreEqual("Alice", list.head.Data.Name);
            Assert.AreEqual("Bob", list.head.Next.Data.Name);
            Assert.IsNull(list.head.Next.Next);
            Assert.AreSame(list.tail, list.head.Next);
        }

        [Test]
        public void BubbleSort_MultipleElements_SortsCorrectly()
        {
            list.Add(new Person("Charlie"));
            list.Add(new Person("Alice"));
            list.Add(new Person("Bob"));
            list.BubbleSort();
            Assert.AreEqual("Alice", list.head.Data.Name);
            Assert.AreEqual("Bob", list.head.Next.Data.Name);
            Assert.AreEqual("Charlie", list.head.Next.Next.Data.Name);
            Assert.IsNull(list.head.Next.Next.Next);
            Assert.AreEqual("Charlie", list.tail.Data.Name);
            Assert.AreEqual("Bob", list.tail.Previous.Data.Name);
            Assert.AreEqual("Alice", list.tail.Previous.Previous.Data.Name);
        }
    }
}