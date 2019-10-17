using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ninja.NUnitTest
{
    public class StackTests
    {
        private Stack<string> _stack;

        [SetUp]
        public void Setup()
        {
            _stack = new Stack<string>();
        }

        [Test]
        public void Push_ArgumentIsNull_ReturnArgumentException()
        {
            Assert.Throws<ArgumentException>(() => _stack.Push(null));
        }

        [Test]
        public void Push_ValidArgument_CountShouldBeGreaterThanZero()
        {
            var stack = new Stack<string>();
            stack.Push("a");

            Assert.Greater(stack.Count, 0);
            Assert.That(stack.Count, Is.EqualTo(1));
        }

        [Test]
        public void Count_EmptyStack_ReturnZero() //write this test to avoid wrong things happen in prev method when user set Count manually to 1 
        {
            var stack = new Stack<string>();
            Assert.That(stack.Count, Is.EqualTo(0));
        }


        [Test]
        public void Pop_EmptyStack_ReturnInvalidOperationException()
        {
            Assert.Throws<InvalidOperationException>(() => _stack.Pop());
        }

        [Test]
        public void Pop_StackWithFewObjects_ReturnObjectOnTheTop()
        {
            //Arrange
            var stack = new Stack<string>();
            stack.Push("a");
            stack.Push("b");
            stack.Push("c");

            //Act
            var result = stack.Pop();

            //Assert
            Assert.That(result, Is.EqualTo("c"));

        }

        [Test]
        public void Pop_StackWithFewObjects_RemoveObjectOnTheTop()
        {
            //Arrange
            var stack = new Stack<string>();
            stack.Push("a");
            stack.Push("b");
            stack.Push("c");

            //Act
            stack.Pop();

            //Assert
            Assert.That(stack.Count, Is.EqualTo(2));
        }

        [Test]
        public void Peek_EmptyStack_ReturnInvalidOperationException()
        {
            Assert.Throws<InvalidOperationException>(() => _stack.Peek());
        }

        [Test]
        public void Peek_StackWithFewObjects_ReturnObjectOnTheTop()
        {
            //Arrange
            var stack = new Stack<string>();
            stack.Push("a");
            stack.Push("b");
            stack.Push("c");

            //Act
            var result = stack.Peek();

            //Assert
            Assert.That(result, Is.EqualTo("c"));

        }

        [Test]
        public void Peek_StackWithFewObjects_DoesNotRemoveObjectOnTheTop()
        {
            //Arrange
            var stack = new Stack<string>();
            stack.Push("a");
            stack.Push("b");
            stack.Push("c");

            //Act
            stack.Peek();

            //Assert
            Assert.That(stack.Count, Is.EqualTo(3));
        }


    }
}
