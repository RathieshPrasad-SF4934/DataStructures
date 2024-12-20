using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Stack
{
    public class Stack<DataType>
    {
        private int _capacity;
        private int _top;
        private int _count;

        public int Capacity { get{return _capacity;} }

        public int Count { get{return _top+1;} }

        private DataType[] _array;

        public void Push(DataType value)
        {
            if(_top+1==_capacity)
            {
                GrowSize();
            }
            _array[_top+1] = value;
            _top++;
        }

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

        public DataType Peek()
        {
            if(_top==-1)
            {
                return default(DataType);
            }
            return _array[_top];
        }

        public DataType Pop()
        {
            if(_top==-1)
            {
                return default(DataType);
            }
            _top--;
            return _array[_top+1];
        }



        public Stack()
        {
            _capacity=4;

            _top=-1;

            _array = new DataType[_capacity];
        }

        public Stack(int size)
        {
            _capacity=size;

            _top = -1;

            _array = new DataType[size];
        }



        


    }
}