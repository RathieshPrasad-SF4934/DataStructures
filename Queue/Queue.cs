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
    public partial class CustomQueue<DataType>
    {
        //states the head of the queue
        private int _head;
        //states the position of tail of the queue
        private int _tail;
        //states the number of elements int the queue
        private int _count;
        //states the total capacity of the queue
        private int _capacity;
        //method for returning the Count value
        public int Count
        {
            get
            {
                return _count;
            }
        }
        //Method for returning the capacity
        public int Capacity { get { return _capacity; } }
        private DataType[] _array;
        //Default constructor for the Queue
        public CustomQueue()
        {
            _capacity=4;
            _array = new DataType[4];
            _head = -1;
            _tail = 0;
        }
        //Parameterized constructor for the queue
        public CustomQueue(int size)
        {
            _capacity = size;
            _array = new DataType[size];
            _head = -1;
            _tail = 0;
        }
        //Adding data into the queue
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
        //resizing the queue if capacity is reached
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
        //getting the first element in the queue
        public DataType Peek()
        {
            if(_head==_tail)
            {
                return default(DataType);
            }
            return _array[_head];
        }
        //removing the l
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

    }
}