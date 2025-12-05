using System;
using NUnit.Framework;

namespace DataStructures
{
    [TestFixture]
    public class StackTests
    {
        private Stack<int> stack;

        [SetUp]
        public void SetUp()
        {
            stack = new Stack<int>();
        }

        [Test]
        public void Push_ElementAdded_IncrementsCountAndSetsTop()
        {
            stack.Push(1);
            stack.Push(2);

            Assert.AreEqual(2, stack.Count);
            Assert.AreEqual(2, stack.Peek());
        }

        [Test]
        public void Pop_ElementRemoved_ReturnsFormerTop()
        {
            stack.Push(10);
            stack.Push(20);

            int popped = stack.Pop();

            Assert.AreEqual(20, popped);
            Assert.AreEqual(1, stack.Count);
            Assert.AreEqual(10, stack.Peek());
        }

        [Test]
        public void Pop_EmptyStack_ThrowsInvalidOperation()
        {
            Assert.Throws<InvalidOperationException>(() => stack.Pop());
        }

        [Test]
        public void Peek_ReturnsTopWithoutRemoving()
        {
            stack.Push(5);

            int value = stack.Peek();

            Assert.AreEqual(5, value);
            Assert.AreEqual(1, stack.Count);
            Assert.IsFalse(stack.IsEmpty());
        }

        [Test]
        public void Clear_AllElementsRemoved_StackEmptyAfterwards()
        {
            stack.Push(1);
            stack.Push(2);

            stack.Clear();

            Assert.AreEqual(0, stack.Count);
            Assert.IsTrue(stack.IsEmpty());
            Assert.Throws<InvalidOperationException>(() => stack.Peek());
        }

        [Test]
        public void Pop_LifoOrder_Maintained()
        {
            stack.Push(1);
            stack.Push(2);
            stack.Push(3);

            Assert.AreEqual(3, stack.Pop());
            Assert.AreEqual(2, stack.Pop());
            Assert.AreEqual(1, stack.Pop());
            Assert.IsTrue(stack.IsEmpty());
        }
    }
}

