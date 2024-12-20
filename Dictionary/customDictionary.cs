using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace Dictionary
{
    public class customDictionary<TKey, TValue>:IEnumerable,IEnumerator
    {
        private int _count;
        private int _capacity;
        public int Count { get { return _count; } }

        private KeyValue<TKey, TValue>[] _array;

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
        public customDictionary()
        {
            _count = 0;
            _capacity = 4;
            _array = new KeyValue<TKey, TValue>[_capacity];
        }

        public customDictionary(int size)
        {
            _count = 0;
            _capacity = size;
            _array = new KeyValue<TKey, TValue>[_capacity];
        }

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
        bool ContainsKey(TKey key)
        {
            if(LinearSearch(key,out TValue value)>-1)
            {
                return true;
            }
            return false;
        }
        bool ContainsValue(TValue value)
        {
            if(LinearSearchValue(value)>-1)
            {
                return true;
            }
            return false;
        }
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
        int position;
        public IEnumerator GetEnumerator()
        {
            position = -1;

            return (IEnumerator) this;
        }

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

        public void Reset()
        {
            position=-1;
        }

        public Object Current { get{return _array[position];}}


    }
}