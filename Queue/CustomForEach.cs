using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Queue
{
    //Enumerator for using ForEach
    public partial class CustomQueue<DataType> : IEnumerable, IEnumerator
    {
        int position;
        //Getting the position for the loop
        public IEnumerator GetEnumerator()
        {
            position = _head - 1;
            return (IEnumerator)this;
        }
        //Moving to the next position
        public bool MoveNext()
        {
            if (position < _tail - 1)
            {
                position++;
                return true;
            }
            Reset();
            return false;
        }
        //Resetting the position 
        public void Reset()
        {
            position = _head - 1;
        }
        public Object Current { get { return _array[position]; } }
    }

}