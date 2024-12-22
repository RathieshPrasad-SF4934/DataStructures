using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace SynCart
{
    public partial class CustomList<T>
    {
        //defines the capacity of the list
        private int _capacity;
        //defines the number of elements present in the list
        private int _count;
        private T[] _array;
        //Get Method for Capactity
        public int Capacity { get{return _capacity;} }
        //Get Method for Coung
        public int Count { get{return _count;} }

        
        //Indexor for the List
        public T this[int index]
        {
            get{return _array[index];}
            set{_array[index] = value;}
        }
        //Default Constructor for the list
        public CustomList()
        {
            _capacity = 4;
            _count = 0;
            _array = new T[_capacity];
        }
        //Parameterized Constructor for the List
        public CustomList(int size)
        {
            _capacity = size;
            _count = 0;
            _array = new T[_capacity];
        }
        //Adding Elements into the list
        public void Add(T element)
        {
            if(_count==_capacity)
            {
                GrowSize();
            }
            _array[Count] = element;
            _count++;
        }
        //Resizing the List if the capacity is full
        void GrowSize()
        {
            _capacity*=2;
            T[] temp = new T[_capacity];
            for(int i=0;i<_count;i++)
            {
                temp[i]=_array[i];
            }
            _array = temp;
        }
        
        // public  int BinarySearch<Type>(CustomList<T> list, string key)
        // {
        //     int start = 0;
        //     int end = list.Count-1;

        //     while(start<=end)
        //     {
        //         int mid = start + (end-start)/2;
        //         T midElement = list[mid];
        //         PropertyInfo[] properties = typeof(T).GetProperties();

        //         string idToCompare = properties[0].GetValue(midElement).ToString();

        //         if(key.Equals(idToCompare))
        //         {
        //             return mid;
        //         }
        //         else if(idToCompare.CompareTo(key)<0)
        //         {
        //             start = mid+1;
        //         }else
        //         {
        //             end = mid-1;
        //         }
                
        //     }
        //     return -1;
        // }

        
    }
}