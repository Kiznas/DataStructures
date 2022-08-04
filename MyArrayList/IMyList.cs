using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace DataStructuresLibrary
{
    public interface IMyList<T> : IEnumerable<T>
    {
        void AddBack(T itemToAdd);
        void AddFront(T itemToAdd);
        void AddByIndex(int index, T itemToAdd);
        T RemoveBack();
        T RemoveFront();
        T RemoveByIndex(int index);
        T[] RemoveNValuesBack(int n);
        T[] RemoveNValuesFront(int n);
        T[] RemoveNValuesByIndex(int index, int n);
        int Length { get; }
        T this[int index] { get; set; }
        int IndexOf(T element);
        void Reverse();
        T Max();
        T Min();
        int MaxIndex();
        int MinIndex();
        void Sort(bool ascending = true);
        int RemoveByValue(T value);
        int RemoveByValueAll(T value);
        void AddFront(IEnumerable<T> items);//foreach(var item in items){}
        void AddBack(IEnumerable<T> items);//items.Count()
        void AddByIndex(int index, IEnumerable<T> items);

    }
}

