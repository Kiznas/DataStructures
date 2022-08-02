using DataStructuresLibrary;
using NUnit.Framework;
using System;
using System.Linq;

namespace DataStructures.Tests
{
    public class MyArrayListTests<T> where T : IComparable<T>
    {
        [TestCase(new[] { 1, 2, 3, 4, 5 }, 10, new[] { 1, 2, 3, 4, 5, 10 })]
        [TestCase(new[] { 1, 2, 3, 4, 5 }, 0, new[] { 1, 2, 3, 4, 5, 0 })]
        [TestCase(new[] { 1, 2, 3, 4, 5 }, 23212, new[] { 1, 2, 3, 4, 5, 23212 })]
        [TestCase(new[] { 1, 2, 3, 4, 5 }, -123, new[] { 1, 2, 3, 4, 5, -123 })]
        public void AddBack_WhenValueAdded_ShouldReturnNewArrayWithValueInBack(T[] sourceArray, T valueToAdd, T[] expectedArray)
        {
            MyArrayList<T> myArrayList = new MyArrayList<T>(sourceArray);

            myArrayList.AddBack(valueToAdd);

            CollectionAssert.AreEqual(expectedArray, myArrayList.ToArray());
        }

        [TestCase(new[] { 1, 2, 3, 4, 5 }, 10, new[] { 1, 2, 3, 4, 5, 10, 10 })]
        [TestCase(new[] { 1, 2, 3, 4, 5 }, 0, new[] { 1, 2, 3, 4, 5, 0, 0 })]
        [TestCase(new[] { 1, 2, 3, 4, 5 }, 23212, new[] { 1, 2, 3, 4, 5, 23212, 23212 })]
        [TestCase(new[] { 1, 2, 3, 4, 5 }, -123, new[] { 1, 2, 3, 4, 5, -123, -123 })]
        public void AddBack_WhenValueAdded_ShouldReturnNewArrayWithValueInBack2(int[] sourceArray, int valueToAdd, int[] expectedArray)
        {
            var myArrayList = new MyArrayList(sourceArray);

            myArrayList.AddBack(valueToAdd);
            myArrayList.AddBack(valueToAdd);

            CollectionAssert.AreEqual(expectedArray, myArrayList.ToArray());
        }

        [TestCase(new[] { 1, 2, 3, 4, 5 }, 10, new[] { 10, 1, 2, 3, 4, 5 })]
        [TestCase(new[] { 1, 2, 3, 4, 5 }, 0, new[] { 0, 1, 2, 3, 4, 5 })]
        [TestCase(new[] { 1, 2, 3, 4, 5 }, 78594, new[] { 78594, 1, 2, 3, 4, 5 })]
        [TestCase(new[] { 1, 2, 3, 4, 5 }, -231, new[] { -231, 1, 2, 3, 4, 5 })]
        public void AddFront_WhenValueAdded_ShouldReturnNewArrayWithValueInFront(int[] sourceArray, int valueToAdd, int[] expectedArray)
        {
            var myArrayList = new MyArrayList(sourceArray);

            myArrayList.AddFront(valueToAdd);

            CollectionAssert.AreEqual(expectedArray, myArrayList.ToArray());
        }

        [TestCase(new[] { 1, 2, 3, 4, 5 }, 10, new[] { 10, 10, 1, 2, 3, 4, 5 })]
        [TestCase(new[] { 1, 2, 3, 4, 5 }, 0, new[] { 0, 0, 1, 2, 3, 4, 5 })]
        [TestCase(new[] { 1, 2, 3, 4, 5 }, 666666, new[] { 666666, 666666, 1, 2, 3, 4, 5 })]
        [TestCase(new[] { 1, 2, 3, 4, 5 }, -456, new[] { -456, -456, 1, 2, 3, 4, 5 })]
        public void AddFront_WhenValueAdded_ShouldReturnNewArrayWithValueInFront2(int[] sourceArray, int valueToAdd, int[] expectedArray)
        {
            var myArrayList = new MyArrayList(sourceArray);

            myArrayList.AddFront(valueToAdd);
            myArrayList.AddFront(valueToAdd);

            CollectionAssert.AreEqual(expectedArray, myArrayList.ToArray());
        }

        [TestCase(new[] { 1, 2, 3, 4, 5 }, 1, 10, new[] { 1, 10, 2, 3, 4, 5 })]
        [TestCase(new[] { 1, 2, 3, 4, 5 }, 2, 0, new[] { 1, 2, 0, 3, 4, 5 })]
        [TestCase(new[] { 1, 2, 3, 4, 5 }, 1, 78594, new[] { 1, 78594, 2, 3, 4, 5 })]
        [TestCase(new[] { 1, 2, 3, 4, 5 }, 0, -231, new[] { -231, 1, 2, 3, 4, 5 })]
        [TestCase(new int[0], 0, 12, new[] { 12 })]
        public void AddByIndex_WhenValueAdded_ShouldReturnNewArrayWithValueOnIndex(int[] sourceArray, int index, int valueToAdd, int[] expectedArray)
        {
            var myArrayList = new MyArrayList(sourceArray);

            myArrayList.AddByIndex(index, valueToAdd);

            CollectionAssert.AreEqual(expectedArray, myArrayList);
        }

        [TestCase(new[] { 1, 2, 3, 4, 5 }, new[] { 1, 2, 3, 4 })]
        [TestCase(new[] { 3, 2, 1, 55, 5 }, new[] { 3, 2, 1, 55 })]
        [TestCase(new[] { 5, 1, 3, 0, 0 }, new[] { 5, 1, 3, 0 })]
        [TestCase(new[] { 10, 222, 331, 412, 1000 }, new[] { 10, 222, 331, 412 })]
        [TestCase(new[] { 0 }, new int[0])]
        public void RemoveBack_WhenBackDeleted_ShouldReturnArrayWithoutLastNumber(int[] sourceArray, int[] expectedArray)
        {
            var myArrayList = new MyArrayList(sourceArray);

            myArrayList.RemoveBack();

            CollectionAssert.AreEqual(expectedArray, myArrayList.ToArray());
        }

        [TestCase(new[] { 1, 2, 3, 4, 5 }, 5)]
        [TestCase(new[] { 3, 2, 1, 55, 5 }, 5)]
        [TestCase(new[] { 5, 1, 3, 0, 0 }, 0)]
        [TestCase(new[] { 10, 222, 331, 412, 1000 }, 1000)]
        [TestCase(new[] { 0 }, 0)]
        public void RemoveBack_WhenBackDeleted_ShouldReturnDeletedNumber(int[] sourceArray, int deletedNumber)
        {
            var myArrayList = new MyArrayList(sourceArray);

            Assert.AreEqual(deletedNumber, myArrayList.RemoveBack());
        }

        [TestCase(new[] { 1, 2, 3, 4, 5 }, new[] { 2, 3, 4, 5 })]
        [TestCase(new[] { 3, 2, 1, 55, 5 }, new[] { 2, 1, 55, 5 })]
        [TestCase(new[] { 5, 1, 3, 0, 5 }, new[] { 1, 3, 0, 5 })]
        [TestCase(new[] { 0, 222, 331, 412, 5 }, new[] { 222, 331, 412, 5 })]
        [TestCase(new[] { 0 }, new int[0])]
        public void RemoveFront_WhenFrontDeleted_ShouldReturnArrayWithoutFirstNumber(int[] sourceArray, int[] expectedArray)
        {
            var myArrayList = new MyArrayList(sourceArray);

            myArrayList.RemoveFront();

            CollectionAssert.AreEqual(expectedArray, myArrayList.ToArray());
        }

        [TestCase(new[] { 1, 2, 3, 4, 5 }, 1)]
        [TestCase(new[] { 3, 2, 1, 55, 5 }, 3)]
        [TestCase(new[] { 5, 1, 3, 0, 5 }, 5)]
        [TestCase(new[] { 10, 0, 331, 412, 5 }, 10)]
        [TestCase(new[] { 0 }, 0)]
        public void RemoveFront_WhenFrontDeleted_ShouldReturnDeletedNumber(int[] sourceArray, int deletedNumber)
        {
            var myArrayList = new MyArrayList(sourceArray);

            Assert.AreEqual(deletedNumber, myArrayList.RemoveFront());
        }

        [TestCase(new[] { 1, 2, 3, 4, 5 }, 1, new[] { 1, 3, 4, 5 })]
        [TestCase(new[] { 3, 2, 1, 55, 5 }, 3, new[] { 3, 2, 1, 5 })]
        [TestCase(new[] { 5, 1, 3, 0, 5 }, 3, new[] { 5, 1, 3, 5 })]
        [TestCase(new[] { 0, 222, 331, 412, 5 }, 1, new[] { 0, 331, 412, 5 })]
        public void RemoveByIndex_WhenIndexDeleted_ShouldReturnArrayWithoutIndexNumber(int[] sourceArray, int index, int[] expectedArray)
        {
            var myArrayList = new MyArrayList(sourceArray);

            myArrayList.RemoveByIndex(index);

            CollectionAssert.AreEqual(expectedArray, myArrayList.ToArray());
        }

        [TestCase(new[] { 1, 2, 3, 4, 5 }, 1, 2)]
        [TestCase(new[] { 3, 2, 1, 55, 5 }, 3, 55)]
        [TestCase(new[] { 5, 1, 3, 0, 5 }, 3, 0)]
        [TestCase(new[] { 0, 222, 331, 412, 5 }, 1, 222)]
        public void RemoveByIndex_WhenIndexDeleted_ShouldReturnDeletedNumber(int[] sourceArray, int index, int deletedNumber)
        {
            var myArrayList = new MyArrayList(sourceArray);

            Assert.AreEqual(deletedNumber, myArrayList.RemoveByIndex(index));
        }

        [TestCase(new[] { 1, 2, 3, 4, 5 }, 2, new[] { 1, 2, 3 })]
        [TestCase(new[] { 1, 2, 3, 4, 5 }, 1, new[] { 1, 2, 3, 4 })]
        [TestCase(new[] { 1, 2, 3, 4, 5 }, 3, new[] { 1, 2 })]
        [TestCase(new[] { 1, 2, 3, 4, 5 }, 0, new[] { 1, 2, 3, 4, 5 })]
        [TestCase(new[] { 1, 2, 3, 4, 5 }, 4, new[] { 1 })]
        [TestCase(new[] { 1, 2, 3, 4, 5 }, 5, new int[0])]
        public void RemoveBackNValues_WhenNValuesIBackDeleted_ShouldReturnArrayWithoutLastNNumbers(int[] sourceArray, int n, int[] expectedArray)
        {
            var myArrayList = new MyArrayList(sourceArray);

            myArrayList.RemoveNValuesBack(n);

            CollectionAssert.AreEqual(expectedArray, myArrayList.ToArray());
        }

        [TestCase(new[] { 1, 2, 3, 4, 5 }, 2, new[] { 4, 5 })]
        [TestCase(new[] { 1, 2, 3, 4, 5 }, 1, new[] { 5 })]
        [TestCase(new[] { 1, 2, 3, 4, 5 }, 3, new[] { 3, 4, 5 })]
        [TestCase(new[] { 1, 2, 3, 4, 5 }, 0, new int[0])]
        [TestCase(new[] { 1, 2, 3, 4, 5 }, 4, new[] { 2, 3, 4, 5 })]
        [TestCase(new[] { 1, 2, 3, 4, 5 }, 5, new[] { 1, 2, 3, 4, 5 })]
        public void RemoveBackNValues_WhenNValuesInBackDeleted_ShouldReturnArrayDeletedNumbers(int[] sourceArray, int n, int[] deletedNumber)
        {
            var myArrayList = new MyArrayList(sourceArray);

            Assert.AreEqual(deletedNumber, myArrayList.RemoveNValuesBack(n));
        }

        [TestCase(new[] { 1, 2, 3, 4, 5 }, 2, new[] { 3, 4, 5 })]
        [TestCase(new[] { 1, 2, 3, 4, 5 }, 1, new[] { 2, 3, 4, 5 })]
        [TestCase(new[] { 1, 2, 3, 4, 5 }, 3, new[] { 4, 5 })]
        [TestCase(new[] { 1, 2, 3, 4, 5 }, 0, new[] { 1, 2, 3, 4 , 5 })]
        [TestCase(new[] { 1, 2, 3, 4, 5 }, 4, new[] { 5 })]
        [TestCase(new[] { 1, 2, 3, 4, 5 }, 5, new int[0])]
        public void RemoveFrontNValues_WhenNValuesInFrontDeleted_ShouldReturnArrayWithoutFirstNNumbers(int[] sourceArray, int n, int[] expectedArray)
        {
            var myArrayList = new MyArrayList(sourceArray);

            myArrayList.RemoveNValuesFront(n);

            CollectionAssert.AreEqual(expectedArray, myArrayList.ToArray());
        }

        [TestCase(new[] { -1, 2, 3, 4, 5 }, 2, new[] { -1, 2 })]
        [TestCase(new[] { 1, 2, 3, 4, 5 }, 1, new[] { 1 })]
        [TestCase(new[] { 1, 2, 3, 4, 5 }, 3, new[] { 1, 2, 3 })]
        [TestCase(new[] { 1, 2, 3, 4, 5 }, 0, new int[0])]
        [TestCase(new[] { 1, 2, 3, 4, 5 }, 4, new[] { 1, 2, 3, 4 })]
        [TestCase(new[] { 1, 2, 3, 4, 5 }, 5, new[] { 1, 2, 3, 4, 5 })]
        public void RemoveFrontNValues_WhenNValuesInFrontDeleted_ShouldReturnDeletedNumbers(int[] sourceArray, int n, int[] deletedNumber)
        {
            var myArrayList = new MyArrayList(sourceArray);

            Assert.AreEqual(deletedNumber, myArrayList.RemoveNValuesFront(n));
        }

        [TestCase(new[] { 1, 2, 3, 4, 5 }, 2, 3, new[] { 1, 2 })]
        [TestCase(new[] { 1, 2, 3, 4, 5 }, 1, 4, new[] { 1 })]
        [TestCase(new[] { 1, 2, 3, 4, 5 }, 3, 2, new[] { 1, 2, 3 })]
        [TestCase(new[] { 1, 2, 3, 4, 5 }, 0, 0, new[] { 1, 2, 3, 4, 5 })]
        [TestCase(new[] { 1, 2, 3, 4, 5 }, 0, 3, new[] { 4, 5 })]
        [TestCase(new[] { 1, 2, 3, 4, 5 }, 0, 5, new int[0])]
        public void RemoveByIndexNValues_WhenNValuesByIndexDeleted_ShouldReturnArrayWithoutIndexNNumbers(int[] sourceArray, int index, int n, int[] expectedArray)
        {
            var myArrayList = new MyArrayList(sourceArray);

            myArrayList.RemoveNValuesByIndex(index, n);

            CollectionAssert.AreEqual(expectedArray, myArrayList.ToArray());
        }

        [TestCase(new[] { 1, 2, 3, 4, 5 }, 2, 3, new[] { 3, 4, 5 })]
        [TestCase(new[] { 1, 2, 3, 4, 5 }, 1, 4, new[] { 2, 3, 4, 5 })]
        [TestCase(new[] { 1, 2, 3, 4, 5 }, 3, 2, new[] { 4, 5 })]
        [TestCase(new[] { 1, 2, 3, 4, 5 }, 0, 0, new int[0])]
        [TestCase(new[] { 1, 2, 3, 4, 5 }, 0, 3, new[] { 1, 2, 3 })]
        [TestCase(new[] { 1, 2, 3, 4, 5 }, 0, 5, new[] { 1, 2, 3, 4, 5 })]
        public void RemoveByIndexNValues_WhenNValuesByIndexDeleted_ShouldReturnDeletedNumbers(int[] sourceArray, int index, int n, int[] deletedNumber)
        {
            var myArrayList = new MyArrayList(sourceArray);

            Assert.AreEqual(deletedNumber, myArrayList.RemoveNValuesByIndex(index, n));
        }

        [TestCase(new[] { 5, 12, 32, 4, 25 }, 32, 2)]
        [TestCase(new[] { 1, 2, 0, 4, 5 }, 0, 2)]
        [TestCase(new[] { 1, 2, 123123, 4, 5 }, 123123, 2)]
        [TestCase(new[] { 1, 2, -55, 4, 5 }, -55, 2)]
        [TestCase(new[] { 1, 2, -55, 4, 5 }, 5, 4)]
        [TestCase(new[] { 1, 2, -55, 4, 5 }, 1, 0)]
        public void IndexOf_WhenFoundElementIndex_ShouldReturnIndexOfElement(int[] sourceArray, int element, int expectedIndex)
        {
            var myArrayList = new MyArrayList(sourceArray);

            myArrayList.IndexOf(element);

            Assert.AreEqual(expectedIndex, myArrayList.IndexOf(element));
        }
        [TestCase(new[] { 1, 2, 3, 4, 5 }, new[] { 5, 4, 3, 2, 1 })]
        [TestCase(new[] { 5, 4, 3, 2, 1 }, new[] { 1, 2, 3, 4, 5 })]
        [TestCase(new[] { -1230, 15, 555, 12, 44 }, new[] { 44, 12, 555, 15, -1230 })]
        [TestCase(new[] { 123, 421, 3333, 2, 112, 32 }, new[] { 32, 112, 2, 3333, 421, 123 })]
        [TestCase(new[] { 203, 2, 4, 123, 32, -22 }, new[] { -22, 32, 123, 4, 2, 203 })]
        [TestCase(new[] { 24, 43, -666, 123, -323, 222 }, new[] { 222, -323, 123, -666, 43, 24 })]
        public void Reverse_WhenReverseArray_ShouldReturnRevesedArray(int[] sourceArray, int[] expectedArray)
        {
            var myArrayList = new MyArrayList(sourceArray);

            myArrayList.Reverse();

            CollectionAssert.AreEqual(expectedArray, myArrayList.ToArray());
        }

        [TestCase(new[] { 5, 12, 32, 4, 25 }, 32)]
        [TestCase(new[] { -10, -20, -321, -100, -5 }, -5)]
        [TestCase(new[] { -10, -20, -321, -100, 0 }, 0)]
        [TestCase(new[] { 1, 2, 0, 4, 512 }, 512)]
        [TestCase(new[] { 10, -20, -321, -100, -10 }, 10)]
        public void Max_WhenFoundMaxElementOfArray_ShouldReturnMaxElementOfArray(int[] sourceArray, int expectedElement)
        {
            var myArrayList = new MyArrayList(sourceArray);

            myArrayList.Max();

            Assert.AreEqual(expectedElement, myArrayList.Max());
        }

        [TestCase(new[] { 5, 12, 32, 4, 25 }, 4)]
        [TestCase(new[] { -10, -20, -321, -100, -5 }, -321)]
        [TestCase(new[] { 311, 21, 12, 4, 512 }, 4)]
        [TestCase(new[] { -1210, -20, -321, -100, -10 }, -1210)]
        [TestCase(new[] { 12, -20, 321, 3100, 22 }, -20)]
        [TestCase(new[] { 2, 40, 132, 123, 0 }, 0)]
        public void Min_WhenFoundMinElementOfArray_ShouldReturnMinElementOfArray(int[] sourceArray, int expectedElement)
        {
            var myArrayList = new MyArrayList(sourceArray);

            myArrayList.Min();

            Assert.AreEqual(expectedElement, myArrayList.Min());
        }

        [TestCase(new[] { 5, 12, 32, 4, 25 }, 2)]
        [TestCase(new[] { -10, -20, -321, -100, -5 }, 4)]
        [TestCase(new[] { -10, -20, -321, -100, 0 }, 4)]
        [TestCase(new[] { 1, 2, 0, 4, 512 }, 4)]
        [TestCase(new[] { 10, -20, -321, -100, -10 }, 0)]
        public void MaxIndex_WhenFoundMaxElementOfArrayIndex_ShouldReturnMaxElementOfArrayIndex(int[] sourceArray, int expectedIndex)
        {
            var myArrayList = new MyArrayList(sourceArray);

            myArrayList.MaxIndex();

            Assert.AreEqual(expectedIndex, myArrayList.MaxIndex());
        }

        [TestCase(new[] { 5, 12, 32, 4, 25 }, 3)]
        [TestCase(new[] { -10, -20, -321, -100, -5 }, 2)]
        [TestCase(new[] { -10, -20, -321, -100, 0 }, 2)]
        [TestCase(new[] { 311, 21, 12, 4, 512 }, 3)]
        [TestCase(new[] { -1210, -20, -321, -100, -10 }, 0)]
        [TestCase(new[] { 12, -20, 321, 3100, 22 }, 1)]
        [TestCase(new[] { 2, 40, 132, 123, 1 }, 4)]
        public void MinIndex_WhenFoundMinElementOfArrayIndex_ShouldReturnMinElementOfArrayIndex(int[] sourceArray, int expectedIndex)
        {
            var myArrayList = new MyArrayList(sourceArray);

            myArrayList.MinIndex();

            Assert.AreEqual(expectedIndex, myArrayList.MinIndex());
        }

        [TestCase(new[] { 32, 123, 3, 21, 1 }, new[] { 1, 3, 21, 32, 123 })]
        [TestCase(new[] { 5, 4, 3, 2, 1 }, new[] { 1, 2, 3, 4, 5 })]
        [TestCase(new[] { -120, 3, 123, 32, -1001 }, new[] { -1001, -120, 3, 32, 123 })]
        [TestCase(new[] { 0, 0, 0, 2, 1 }, new[] { 0, 0, 0, 1, 2 })]
        public void SortAscending_WhenArrayIn_ShouldReturnSortedInAscendingOrder(int[] sourceArray, int[] expectedArray)
        {
            var myArrayList = new MyArrayList(sourceArray);

            myArrayList.Sort(true);

            CollectionAssert.AreEqual(expectedArray, myArrayList.ToArray());
        }

        [TestCase(new[] { 32, 123, 3, 21, 1 }, new[] { 123, 32, 21, 3, 1 })]
        [TestCase(new[] { 5, 4, 3, 2, 1 }, new[] { 5, 4, 3, 2, 1 })]
        [TestCase(new[] { -120, 3, 123, 32, -1001 }, new[] { 123, 32, 3, -120, -1001 })]
        [TestCase(new[] { 0, 0, 0, 2, 1 }, new[] { 2, 1, 0, 0, 0 })]
        public void SortDescending_WhenArrayIn_ShouldReturnSortedInDescendingOrder(int[] sourceArray, int[] expectedArray)
        {
            var myArrayList = new MyArrayList(sourceArray);

            myArrayList.Sort(false);

            CollectionAssert.AreEqual(expectedArray, myArrayList.ToArray());
        }

        [TestCase(new[] { 42, 123, 445, 44, 445 }, 445, new[] { 42, 123, 44, 445 })]
        [TestCase(new[] { 521, 123, -33, 0, 5 }, -33, new[] { 521, 123, 0, 5 })]
        [TestCase(new[] { 13, 0, 5 }, 0, new[] { 13, 5 })]
        [TestCase(new[] { -1, 2 }, -12, new[] { -1, 2 })]
        public void RemoveByValue_WhenValueRemoved_ShouldReturnArrayWithoutValue(int[] sourceArray, int value, int[] expectedArray)
        {
            var myArrayList = new MyArrayList(sourceArray);

            myArrayList.RemoveByValue(value);

            CollectionAssert.AreEqual(expectedArray, myArrayList.ToArray());
        }

        [TestCase(new[] { 42, 123, 32, 44, 445 }, 445, 4)]
        [TestCase(new[] { 521, 123, -33, 0, 5 }, -33, 2)]
        [TestCase(new[] { 13, 0, 5 }, 0, 1)]
        [TestCase(new[] { -1, 2 }, -12, -1)]
        public void RemoveByValue_WhenValueRemoved_ShouldReturnIndexOfValue(int[] sourceArray, int value, int indexOfElement)
        {
            var myArrayList = new MyArrayList(sourceArray);

            Assert.AreEqual(indexOfElement, myArrayList.RemoveByValue(value));
        }

        [TestCase(new[] { 42, 123, 445, 44, 445 }, 445, new[] { 42, 123, 44 })]
        [TestCase(new[] { 521, 123, -33, -33, -33, 5 }, -33, new[] { 521, 123, 5 })]
        [TestCase(new[] { 13, 0, 5 }, 0, new[] { 13, 5 })]
        [TestCase(new[] { -1, 2 }, -12, new[] { -1, 2 })]
        public void RemoveByValueAll_WhenValueRemoved_ShouldReturnArrayWithoutValue(int[] sourceArray, int value, int[] expectedArray)
        {
            var myArrayList = new MyArrayList(sourceArray);

            myArrayList.RemoveByValueAll(value);

            CollectionAssert.AreEqual(expectedArray, myArrayList.ToArray());
        }

        [TestCase(new[] { 42, 123, 445, 44, 445 }, 445, 2)]
        [TestCase(new[] { 521, 123, -33, 0, 5 }, -33, 1)]
        [TestCase(new[] { 13, 13, 13 }, 13, 3)]
        [TestCase(new[] { -1, 2 }, -12, -1)]
        public void RemoveByValueAll_WhenAllValueRemoved_ShouldReturnNumberOfValues(int[] sourceArray, int value, int countOfElments)
        {
            var myArrayList = new MyArrayList(sourceArray);

            Assert.AreEqual(countOfElments, myArrayList.RemoveByValueAll(value));
        }

        [TestCase(new[] { 1, 2, 3, 4, 5 }, new[] { 5, 4, 3, 2, 1 }, new[] { 5, 4, 3, 2, 1, 1, 2, 3, 4, 5 })]
        [TestCase(new[] { 1 }, new[] { 222 }, new[] { 222, 1 })]
        [TestCase(new[] { 0, 0, 0, 0, 0 }, new[] { 1, 3, 521, 32, 1231 }, new[] { 1, 3, 521, 32, 1231, 0, 0, 0, 0, 0 })]
        [TestCase(new int[0], new[] { 5, 4, 3, 2, 1 }, new[] { 5, 4, 3, 2, 1 })]
        [TestCase(new[] { 5, 4, 3, 2, 1 }, new int[0], new[] { 5, 4, 3, 2, 1 })]
        [TestCase(new[] { -121, 123 }, new[] { 222 }, new[] { 222, -121, 123 })]
        public void AddFrontIEnumarble_WhenAdded_ShouldReturnArrayWithAllNumbers(int[] sourceArray, int [] items, int [] expectedArray)
        {
            var myArrayList = new MyArrayList(sourceArray);

            myArrayList.AddFront(items);

            CollectionAssert.AreEqual(expectedArray, myArrayList.ToArray());
        }

        [TestCase(new[] { 1, 2, 3, 4, 5 }, new[] { 5, 4, 3, 2, 1 }, new[] { 1, 2, 3, 4, 5, 5, 4, 3, 2, 1 })]
        [TestCase(new[] { 1 }, new[] { 222 }, new[] { 1, 222 })]
        [TestCase(new[] { 0, 0, 0, 0, 0 }, new[] { 1, 3, 521, 32, 1231 }, new[] { 0, 0, 0, 0, 0, 1, 3, 521, 32, 1231 })]
        [TestCase(new int[0], new[] { 5, 4, 3, 2, 1 }, new[] { 5, 4, 3, 2, 1 })]
        [TestCase(new[] { 5, 4, 3, 2, 1 }, new int[0], new[] { 5, 4, 3, 2, 1 })]
        [TestCase(new[] { -121, 123 }, new[] { -222 }, new[] { -121, 123, -222 })]
        public void AddBackIEnumarble_WhenAdded_ShouldReturnArrayWithAllNumbers(int[] sourceArray, int[] items, int[] expectedArray)
        {
            var myArrayList = new MyArrayList(sourceArray);

            myArrayList.AddBack(items);

            CollectionAssert.AreEqual(expectedArray, myArrayList.ToArray());
        }

        [TestCase(new[] { 1, 2, 3, 4, 5 }, 1, new[] { 5, 4, 3, 2, 1 }, new[] { 1, 5, 4, 3, 2, 1, 2, 3, 4, 5,  })]
        [TestCase(new[] { 1 }, 0, new[] { 222 }, new[] { 222, 1 })]
        [TestCase(new[] { 0, 0, 0, 0, 0 }, 2, new[] { 1, 3, 521, 32, 1231 }, new[] { 0, 0, 1, 3, 521, 32, 1231, 0, 0, 0,  })]
        [TestCase(new int[0], 0, new[] { 5, 4, 3, 2, 1 }, new[] { 5, 4, 3, 2, 1 })]
        [TestCase(new[] { 5, 4, 3, 2, 1 }, 0, new int[0], new[] { 5, 4, 3, 2, 1 })]
        [TestCase(new[] { -121, 123 }, 1, new[] { -222 }, new[] { -121, -222, 123 })]
        public void AddByIndexIEnumarble_WhenAdded_ShouldReturnArrayWithAllNumbers(int[] sourceArray, int index, int[] items, int[] expectedArray)
        {
            var myArrayList = new MyArrayList(sourceArray);

            myArrayList.AddByIndex(index, items);

            CollectionAssert.AreEqual(expectedArray, myArrayList.ToArray());
        }

        [TestCase(new[] { 65 }, 0, 65)]
        [TestCase(new[] { 5, 21 }, 1, 21)]
        [TestCase(new[] { 5, 3, 10, -90, 5, 0 }, 3, -90)]
        [TestCase(new[] { 5, 3, 10, -90, 5, 0 }, 0, 5)]
        [TestCase(new[] { 5, 3, 10, -90, 5, 0 }, 5, 0)]
        public void IndexerGet_WhenValidIndexAndArrayFilled_ShouldReturnValueByIndex
            (int[] sourceArray, int index, int expected)
        {
            IMyList myList = new MyArrayList(sourceArray);

            int actual = myList[index];

            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[0])]
        public void IndexerGet_WhenEmptyArray_ShouldThrowIndexOutOfRange
            (int[] sourceArray)
        {
            IMyList myList = new MyArrayList(sourceArray);

            Assert.Throws<IndexOutOfRangeException>(() =>
            {
                var item = myList[0];
            });
        }

        [TestCase(new[] { 1 }, 2)]
        [TestCase(new[] { 1 }, -1)]
        [TestCase(new[] { 1, 6, 3, 4, 1 }, 5)]
        [TestCase(new[] { 1, 6, 3, 4, 1 }, -10)]
        public void IndexerGet_WhenInvalidIndex_ShouldThrowIndexOutOfRange
            (T[] sourceArray, int index)
        {
            IMyList myList = new MyArrayList(sourceArray);

            Assert.Throws<IndexOutOfRangeException>(() =>
            {
                var item = myList[index];
            });
        }

        [Test]
        public void ArrayConstructor_WhenNullPassed_ShouldThrowArgumentException()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                IMyList myList = new MyArrayList(null);
            });
        }

    }
}