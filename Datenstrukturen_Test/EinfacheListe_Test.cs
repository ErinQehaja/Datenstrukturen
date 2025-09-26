using NUnit.Framework;
using Common;
using System;

namespace DataStructures
{
    [TestFixture]
    public class SingleLinkedTest
    {
        private SingleLinkedList<Person> list;

        [SetUp]
        public void Setup()
        {
            list = new SingleLinkedList<Person>();
        }

        [Test]
        public void Add_SinglePerson_HeadIsSet()
        {
            Person person = new Person("Alice");
            list.Add(person);
            Assert.IsNotNull(list.Head);
            Assert.AreEqual(person.Name, list.Head.Data.Name);
            Assert.IsNull(list.Head.Next);
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
            Assert.IsNotNull(list.Head);
            Assert.AreEqual("Alice", list.Head.Data.Name);
            Assert.IsNotNull(list.Head.Next);
            Assert.AreEqual("Bob", list.Head.Next.Data.Name);
            Assert.IsNotNull(list.Head.Next.Next);
            Assert.AreEqual("Charlie", list.Head.Next.Next.Data.Name);
            Assert.IsNull(list.Head.Next.Next.Next);
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
        public void InsertBefore_EmptyList_InsertsAsHead()
        {
            Person newPerson = new Person("Alice");
            Person afterPerson = new Person("Bob");
            list.InsertBefore(afterPerson, newPerson);
            Assert.IsNotNull(list.Head);
            Assert.AreEqual("Alice", list.Head.Data.Name);
            Assert.IsNull(list.Head.Next);
        }

        [Test]
        public void InsertBefore_BeforeFirstElement_InsertsAtHead()
        {
            list.Add(new Person("Bob"));
            Person newPerson = new Person("Alice");
            list.InsertBefore(new Person("Bob"), newPerson);
            Assert.IsNotNull(list.Head);
            Assert.AreEqual("Alice", list.Head.Data.Name);
            Assert.IsNotNull(list.Head.Next);
            Assert.AreEqual("Bob", list.Head.Next.Data.Name);
            Assert.IsNull(list.Head.Next.Next);
        }

        [Test]
        public void InsertBefore_BeforeMiddleElement_InsertsCorrectly()
        {
            list.Add(new Person("Alice"));
            list.Add(new Person("Charlie"));
            Person newPerson = new Person("Bob");
            list.InsertBefore(new Person("Charlie"), newPerson);
            Assert.IsNotNull(list.Head);
            Assert.AreEqual("Alice", list.Head.Data.Name);
            Assert.IsNotNull(list.Head.Next);
            Assert.AreEqual("Bob", list.Head.Next.Data.Name);
            Assert.IsNotNull(list.Head.Next.Next);
            Assert.AreEqual("Charlie", list.Head.Next.Next.Data.Name);
            Assert.IsNull(list.Head.Next.Next.Next);
        }

        [Test]
        public void InsertBefore_NonExistingElement_InsertsAtEnd()
        {
            list.Add(new Person("Alice"));
            Person newPerson = new Person("Bob");
            list.InsertBefore(new Person("Charlie"), newPerson);
            Assert.IsNotNull(list.Head);
            Assert.AreEqual("Alice", list.Head.Data.Name);
            Assert.IsNotNull(list.Head.Next);
            Assert.AreEqual("Bob", list.Head.Next.Data.Name);
            Assert.IsNull(list.Head.Next.Next);
        }

        [Test]
        public void InsertAfter_EmptyList_InsertsAsHead()
        {
            Person newPerson = new Person("Alice");
            Person beforePerson = new Person("Bob");
            list.InsertAfter(beforePerson, newPerson);
            Assert.IsNotNull(list.Head);
            Assert.AreEqual("Alice", list.Head.Data.Name);
            Assert.IsNull(list.Head.Next);
        }

        [Test]
        public void InsertAfter_AfterFirstElement_InsertsCorrectly()
        {
            list.Add(new Person("Alice"));
            Person newPerson = new Person("Bob");
            list.InsertAfter(new Person("Alice"), newPerson);
            Assert.IsNotNull(list.Head);
            Assert.AreEqual("Alice", list.Head.Data.Name);
            Assert.IsNotNull(list.Head.Next);
            Assert.AreEqual("Bob", list.Head.Next.Data.Name);
            Assert.IsNull(list.Head.Next.Next);
        }

        [Test]
        public void InsertAfter_AfterMiddleElement_InsertsCorrectly()
        {
            list.Add(new Person("Alice"));
            list.Add(new Person("Charlie"));
            Person newPerson = new Person("Bob");
            list.InsertAfter(new Person("Alice"), newPerson);
            Assert.IsNotNull(list.Head);
            Assert.AreEqual("Alice", list.Head.Data.Name);
            Assert.IsNotNull(list.Head.Next);
            Assert.AreEqual("Bob", list.Head.Next.Data.Name);
            Assert.IsNotNull(list.Head.Next.Next);
            Assert.AreEqual("Charlie", list.Head.Next.Next.Data.Name);
            Assert.IsNull(list.Head.Next.Next.Next);
        }

        [Test]
        public void InsertAfter_NonExistingElement_InsertsAtEnd()
        {
            list.Add(new Person("Alice"));
            Person newPerson = new Person("Bob");
            list.InsertAfter(new Person("Charlie"), newPerson);
            Assert.IsNotNull(list.Head);
            Assert.AreEqual("Alice", list.Head.Data.Name);
            Assert.IsNotNull(list.Head.Next);
            Assert.AreEqual("Bob", list.Head.Next.Data.Name);
            Assert.IsNull(list.Head.Next.Next);
        }
    }
}