using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Reflection.Metadata.Ecma335;
using System.Threading.Tasks;

namespace Queue
{
    public partial class customQueue<DataType>
    {
        private int _head;

        private int _tail;

        private int _count;

        private int _capacity;

        public int Count
        {
            get
            {
                return _count;
            }
        }

        public int Capacity { get { return _capacity; } }
        private DataType[] _array;
        public void Enqueue(DataType value)
        {
            if(_head==-1)
            {
                _head+=1;
            }
            if(_tail==_capacity)
            {
                GrowSize();
            }
            _array[_tail] = value;
            _tail++;
            _count++;

        }
        void GrowSize()
        {
            _capacity*=2;
            DataType[] temp = new DataType[_capacity];

            for(int i=_head;i<_tail;i++)
            {
                temp[i]=_array[i];
            }

            _array = temp;
        }
        public DataType Peek()
        {
            if(_head==_tail)
            {
                return default(DataType);
            }
            return _array[_head];
        }
        public DataType Dequeue()
        {
            if(_head==_tail)
            {
                return default(DataType);
            }
            else
            {
                _head++;
                _count--;
                return _array[_head-1];
            }
        }

        public customQueue()
        {
            _capacity=4;
            _array = new DataType[4];
            _head = -1;
            _tail = 0;
        }

        public customQueue(int size)
        {
            _capacity = size;
            _array = new DataType[size];
            _head = -1;
            _tail = 0;
        }
        
    
    }
}