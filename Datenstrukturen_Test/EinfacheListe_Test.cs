using NUnit.Framework;
using EinfacheListe;
using System;

namespace EinfacheListe
{
    [TestFixture]
    public class SimpleListTests
    {
        private SimpleList list;

        [SetUp]
        public void Setup()
        {
            list = new SimpleList();
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
    }
}