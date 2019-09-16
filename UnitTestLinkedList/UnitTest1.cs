using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ARLinkedList;

namespace UnitTestLinkedList
{
    /// <summary>
    /// Unit Testing class for implementation of LList class and it's methods
    /// </summary>
    [TestClass]
    public class UnitTest1
    {
        /// <summary>
        /// This method will test getting the length of the list
        /// </summary>
        [TestMethod]
        public void TestCount()
        {
            //create a primative type of int list
            LList<int> numbers = new LList<int>();

            //add data
            for (int i = 0; i < 10; i++)
            {
                numbers.AddBack(i);
            }

            //check length of list..should be 10
            int length = 10;

            Assert.AreEqual(length, numbers.Count);
        }

        /// <summary>
        /// This method will test adding to the front of the list
        /// </summary>
        [TestMethod]
        public void TestAdd()
        {
            //create a primative type of int list
            LList<int> numbers = new LList<int>();

            //add initial data
            for (int i = 0; i < 10; i++)
            {
                numbers.AddBack(i);
            }

            numbers.AddFirst(42);

            int expectedFirst = 42;

            
        }

        /// <summary>
        /// This will test the function of finding the minimum number in the list
        /// </summary>
        [TestMethod]
        public void TestMin()
        {
            //create a primative type of int list
            LList<int> numbers = new LList<int>();

            //add initial data
            for (int i = 0; i < 10; i++)
            {
                numbers.AddBack(i);
            }

            int minimum = 0;

            Assert.AreEqual(minimum, numbers.Min());

        }
    }
}
