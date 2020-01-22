using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestNinja.Fundamentals;

namespace TestNinja.UnitTests
{
    [TestFixture]
    class StackTests
    {
        [Test]
        public void Count_WhenCalledPushMethod_ReturnsCountOdItemsInList()
        {
            var stack = new Fundamentals.Stack<string>();

            var obj = "string";

            stack.Push(obj);

            var result = stack.Count;

            Assert.That(result, Is.EqualTo(1));
        }

        [Test]
        public void Push_WhenCalledOnEmptyStack_StackIsNotEmpty()
        {
            var stack = new Fundamentals.Stack<string>();

            var obj = "string";
                        
            stack.Push(obj);

            Assert.That(stack.Count, Is.EqualTo(1));
            
        }

        [Test]
        public void Push_WhenCalledWithNullParam_ReturnsArgumentNullException()
        {
            var stack = new Fundamentals.Stack<string>();
                    
            Assert.That(() => stack.Push(null), Throws.ArgumentNullException);

        }

        [Test]
        public void Pop_WhenCalledOnList_ReturnsLastItem()
        {
            var stack = new Fundamentals.Stack<string>();

            var obj1 = "string";
            var obj2 = "secondstring";

            stack.Push(obj1);
            stack.Push(obj2);

            var lastItem = stack.Pop();

            Assert.That(lastItem, Is.EqualTo(obj2));

        }

        [Test]
        public void Pop_WhenCalledOnList_RemovesLastItem()
        {
            var stack = new Fundamentals.Stack<string>();

            var obj1 = "string"; //first item
            var obj2 = "secondstring"; //second item

            stack.Push(obj1);
            stack.Push(obj2);

            stack.Pop();

            var result = stack.Pop();

            Assert.That(result, Is.EqualTo(obj1));
        }

        [Test]
        public void Pop_WhenCalledOnZeroCountStack_ReturnsInvalidOperationException()
        {
            var stack = new Fundamentals.Stack<string>();

            Assert.That(()=>stack.Pop(), Throws.InvalidOperationException);

        }

        [Test]
        public void Peek_WhenCalledOnList_ReturnsLastItem()
        {
            var stack = new Fundamentals.Stack<string>();

            var obj1 = "string";
            var obj2 = "secondstring";

            stack.Push(obj1);
            stack.Push(obj2);

            var lastItem = stack.Pop();

            Assert.That(lastItem, Is.EqualTo(obj2));

        }

        [Test]
        public void Peek_WhenCalledOnZeroCountStack_ReturnsInvalidOperationException()
        {
            var stack = new Fundamentals.Stack<string>();

            Assert.That(() => stack.Peek(), Throws.InvalidOperationException);

        }

    }
}
