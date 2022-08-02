using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;

namespace DataStructuresLibrary
{
    public class MyArrayList<T> where T : IMyList, IComparable<T>
    {
        private const int DefaultSize = 4;
        private const double Coef = 1.5;
        private int _count;
        private T[] _array;

        public int Capacity => _array.Length;
        public int Length => _count;

        public T this[int index]
        {
            get
            {
                if (index < 0 || index >= Length)
                {
                    throw new IndexOutOfRangeException();
                }

                return _array[index];
            }
            set => throw new NotImplementedException();
        }

        public MyArrayList() : this(DefaultSize)
        {
        }

        public MyArrayList(int size)
        {
            size = size > DefaultSize ? (int)(size * Coef) : DefaultSize;
            _array = new T[size];
        }

        public MyArrayList(T[] array)
        {
            if (array == null)
            {
                throw new ArgumentException();
            }

            int size = array.Length > DefaultSize ? (int)(array.Length * Coef) : DefaultSize;
            _array = new T[size];

            for (int i = 0; i < array.Length; i++)
            {
                _array[i] = array[i];
            }

            _count = array.Length;
        }

        public T[] ToArray()
        {
            T[] result = new T[Length];

            for (int i = 0; i < result.Length; i++)
            {
                result[i] = _array[i];
            }

            return result;
        }

        public void AddBack(T itemToAdd)
        {
            AddByIndex(_count, itemToAdd);
        }

        public void AddFront(T itemToAdd)
        {
            AddByIndex(0, itemToAdd);
        }

        public void AddByIndex(int index, T itemToAdd)
        {
            {
                T[] newArray = new T[_array.Length];

                for (int i = 0; i < index; i++)
                {
                    newArray[i] = _array[i];
                }

                for (int i = index + 1; i < _count + 1; i++)
                {
                    newArray[i] = _array[i - 1];
                }

                newArray[index] = itemToAdd;
                _array = newArray;
                _count++;
            }
        }

        public T RemoveBack()
        {
            return RemoveByIndex(_count - 1);
        }

        public T RemoveFront()
        {
            return RemoveByIndex(0);
        }

        public T RemoveByIndex(int index)
        {
            T[] newArray = new T[_array.Length];

            for (int i = 0; i < index; i++)
            {
                newArray[i] = _array[i];
            }

            for (int i = index; i < _count; i++)
            {
                newArray[i] = _array[i + 1];
            }

            T deletedNumber = _array[index];
            _array = newArray;
            _count--;
            return deletedNumber;
        }

        public T[] RemoveNValuesBack(int n)
        {
            return RemoveNValuesByIndex(_count - n , n);
        }

        public T[] RemoveNValuesFront(int n)
        {
            return RemoveNValuesByIndex(0, n);
        }

        public T[] RemoveNValuesByIndex(int index, int n)
        {
            int localCount = 0;
            T[] newArray = new T[_array.Length];
            T[] deletedNumbers = new T[n];
            do
            {
                if (n > 0)
                {
                    deletedNumbers[localCount] = _array[index];


                    for (int i = 0; i < index; i++)
                    {
                        newArray[i] = _array[i];
                    }

                    for (int i = index; i < _count; i++)
                    {
                        newArray[i] = _array[i + 1];
                    }

                    localCount++;
                    _count--;
                    _array = newArray;
                }

            } while (localCount < n);

            return deletedNumbers;
        }

        public int IndexOf(T element)
        {
            int result = -1;

            for (int i = 0; i < _array.Length; i++)
            {
                if (_array[i].CompareTo(element) == 0)
                {
                    result = i;
                    break;
                }
            }

            return result;
        }

        public void Reverse()
        {
            int count = 1;
            T[] newArray = new T[_array.Length];

            for (int i = 0; i < _count; i++)
            {
                newArray[i] = _array[_count - count];
                count++;
            }
            _array = newArray;
        }

        public T Max()
        {
            int maxIndex = 0;
            T maxElement;

            for (int i = 1; i < _count; i++)
            {
                if (_array[i].CompareTo(_array[maxIndex]) == 1)
                {
                    maxIndex = i;
                }
            }

            maxElement = _array[maxIndex];
            return maxElement;
        }

        public T Min()
        {
            int minIndex = 0;
            T minElement;

            for (int i = 1; i < _count; i++)
            {
                if (_array[i].CompareTo(_array[minIndex]) == -1)
                {
                    minIndex = i;
                }
            }
            minElement = _array[minIndex];
            return minElement;
        }

        public int MaxIndex()
        {
            int maxIndex = 0;

            for (int i = 1; i < _count; i++)
            {
                if (_array[i].CompareTo(_array[maxIndex]) == 1)
                {
                    maxIndex = i;
                }
            }

            return maxIndex;
        }

        public int MinIndex()
        {
            int minIndex = 0;

            for (int i = 1; i < _count; i++)
            {
                if (_array[i].CompareTo(_array[minIndex]) == -1)
                {
                    minIndex = i;
                }
            }

            return minIndex;
        }

        public void Sort(bool ascending = true)
        {
            if (ascending == true)
            {
                for (int i = 0; i < _count - 1; i++)
                {
                    int minIndex = i;

                    for (int j = i + 1; j < _count; j++)
                    {
                        if (_array[i].CompareTo(_array[minIndex]) == -1)
                        {
                            minIndex = j;
                        }
                    }

                    if (minIndex != i)
                    {
                        Swap(ref _array[i], ref _array[minIndex]);
                    }
                }
            }
            else
            {
                for (int i = 0; i < _count - 1; i++)
                {
                    int maxIndex = i;

                    for (int j = i + 1; j < _count; j++)
                    {
                        if (_array[i].CompareTo(_array[maxIndex]) == 1)
                        {
                            maxIndex = j;
                        }
                    }

                    if (maxIndex != i)
                    {
                        Swap(ref _array[i], ref _array[maxIndex]);
                    }
                }
            }
        }

        public int RemoveByValue(T value)
        {
            T[] newArray = new T[_array.Length];
            int indexOfElement = 0;
            for (int i = 0; i < _count; i++)
            {
                if (_array[i].CompareTo(value) == 0)
                {
                    indexOfElement = i;

                    for (int j = 0; j < indexOfElement; j++)
                    {
                        newArray[j] = _array[j];
                    }

                    for (int j = indexOfElement; j < _count; j++)
                    {
                        newArray[j] = _array[j + 1];
                    }

                    _array = newArray;
                    _count--;
                    break;
                }
                else
                {
                    indexOfElement = -1;
                }
            }
            return indexOfElement;
        }

        public int RemoveByValueAll(T value)
        {
            T[] newArray = new T[_array.Length];
            int indexOfElement;
            int countOfElements = 0;
            for (int i = 0; i < _count; i++)
            {
                if (_array[i].CompareTo(value) == 0)
                {
                    indexOfElement = i;

                    for (int j = 0; j < indexOfElement; j++)
                    {
                        newArray[j] = _array[j];
                    }

                    for (int j = indexOfElement; j < _count; j++)
                    {
                        newArray[j] = _array[j + 1];
                    }

                    _array = newArray;
                    _count--;
                    i--;
                    countOfElements++;
                }
                else if (_array[0].CompareTo(value) == 0)
                {
                    countOfElements++;
                    break;
                }
            }
            if (countOfElements == 0)
            {
                countOfElements = -1;
            }
            return countOfElements;
        }

        public void AddFront(IEnumerable<T> items)
        {
            AddByIndex(0, items);
        }

        public void AddBack(IEnumerable<T> items)
        {
            AddByIndex(_count, items);
            
        }

        public void AddByIndex(int index, IEnumerable<T> items)
        {
            int localCount = 0;

            foreach (T item in items)
            {
                localCount++;
            }

            T[] newArray2 = new T[_array.Length + localCount];
            int i = 0;

            for (int j = 0; j < index; j++)
            {
                newArray2[j] = _array[j];
                i++;
            }

            foreach (T item in items)
            {
                newArray2[i++] = item;
                _count++;
            }

            for (int j = i; j < _count; j++)
            {
                newArray2[j] = _array[index];
                index++;
            }

            _array = newArray2;
        }

        private static (T, T) Swap(ref T a, ref T b)
        {
            T temp = a;
            a = b;
            b = temp;
            return (a, b);
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Length; i++)
            {
                yield return _array[i];
            }
        }

        //IEnumerator IEnumerable.GetEnumerator()
        //{
        //    return GetEnumerator();
        //}
    }
}