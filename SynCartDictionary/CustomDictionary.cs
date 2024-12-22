using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;

using System.Linq;
using System.Threading.Tasks;

namespace SynCartDictionary
{
    public class CustomDictionary<TKey, TValue>:IEnumerable,IEnumerator
    {
        //States the element present in the dictionary
        private int _count;
        //states the capacity of the dictionary
        private int _capacity;
        //Get method for Count
        public int Count { get { return _count; } }

        private KeyValue<TKey, TValue>[] _array;
        //Indexor for the dictionary
        public TValue this[TKey key]
        {
            get
            {
                LinearSearch(key,out TValue value);
                return value;
            }
            set
            {
                int position = LinearSearch(key,out TValue value2);
                _array[position].Value = value;
            }
        }
        //Default constructor for dictionary
        public CustomDictionary()
        {
            _count = 0;
            _capacity = 4;
            _array = new KeyValue<TKey, TValue>[_capacity];
        }
        //Parameterized constructor for the dictionary
        public CustomDictionary(int size)
        {
            _count = 0;
            _capacity = size;
            _array = new KeyValue<TKey, TValue>[_capacity];
        }
        //Method for adding elements into the dictionary
        public void Add(TKey key, TValue value)
        {
            if (LinearSearch(key, out TValue value2) == -1)
            {
                if (_count == _capacity)
                {
                    GrowSize();
                }
                KeyValue<TKey, TValue> data = new KeyValue<TKey, TValue>();
                data.Key = key;
                data.Value = value;
                _array[_count] = data;
                _count++;
            }

        }
        
        //Resizing the dictionary if the capacity is reached
        void GrowSize()
        {
            _capacity *= 2;
            KeyValue<TKey, TValue>[] temp = new KeyValue<TKey, TValue>[_capacity];
            for (int i = 0; i < _count; i++)
            {
                temp[i] = _array[i];

            }
            _array = temp;


        }
        //Checking if the given key is present in the dictionary
        bool ContainsKey(TKey key)
        {
            if(LinearSearch(key,out TValue value)>-1)
            {
                return true;
            }
            return false;
        }
        //Checking if the given value is present in the dictionary
        bool ContainsValue(TValue value)
        {
            if(LinearSearchValue(value)>-1)
            {
                return true;
            }
            return false;
        }
        //Searching for a given value in the dictionary
        int LinearSearchValue(TValue value)
        {
            for(int i=0; i<_count; i++)
            {
                if(_array[i].Value.Equals(value))
                {
                    return i;
                }
            }
            return -1;
        }
        //searching for a given key in the dictionary
        int LinearSearch(TKey key, out TValue value)
        {
            value = default(TValue);
            for (int i = 0; i < _count; i++)
            {
                if (_array[i].Key.Equals(key))
                {
                    value = _array[i].Value;
                    return i;
                }
            }
            return -1;
        }
        //Defining the enumerator for Foreach loop 
        int position;
        //getting the tracking position
        public IEnumerator GetEnumerator()
        {
            position = -1;

            return (IEnumerator) this;
        }
        //looping through the dictionary
        public bool MoveNext()
        {
            if(position<_count-1)
            {
                position++;
                return true;
            }
            Reset();
            return false;
        }
        //stopping the loop and resetting the tracking position
        public void Reset()
        {
            position=-1;
        }
        //creating the current object
        public Object Current { get{return _array[position];}}


    }
}