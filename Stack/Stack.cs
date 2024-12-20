using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Stack
{
    public class Stack<DataType>
    {
        //states the total capacity of the stack
        private int _capacity;
        //states the position of the top element of the stack
        private int _top;
        private DataType[] _array;
        //Method for returning the Capacity of the stack
        public int Capacity { get{return _capacity;} }
        //Method for returning the Count of elements in the list
        public int Count { get{return _top+1;} }
        //Default constructor of the stack
        public Stack()
        {
            _capacity=4;

            _top=-1;

            _array = new DataType[_capacity];
        }
        //parameterized constructor of the stack
        public Stack(int size)
        {
            _capacity=size;

            _top = -1;

            _array = new DataType[size];
        }
        //Adding elements int the stack
        public void Push(DataType value)
        {
            if(_top+1==_capacity)
            {
                GrowSize();
            }
            _array[_top+1] = value;
            _top++;
        }
        //Resizing the stack after the capacity has been reached
        void GrowSize()
        {
            _capacity*=2;

            DataType[] temp = new DataType[_capacity];

            for(int i=0;i<_top+1;i++)
            {
                temp[i]=_array[i];
            }

            _array = temp;
        }
        //Returning the fist element of the stack
        public DataType Peek()
        {
            if(_top==-1)
            {
                return default(DataType);
            }
            return _array[_top];
        }
        //Removing the first element of the stack
        public DataType Pop()
        {
            if(_top==-1)
            {
                return default(DataType);
            }
            _top--;
            return _array[_top+1];
        }

    }
}