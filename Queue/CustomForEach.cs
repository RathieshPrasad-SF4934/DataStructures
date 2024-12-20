using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Queue
{
    public partial class customQueue<DataType> : IEnumerable, IEnumerator
    {
        int position;
        public IEnumerator GetEnumerator()
        {
            position = _head - 1;
            return (IEnumerator)this;
        }
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
        public void Reset()
        {
            position = _head - 1;
        }
        public Object Current { get { return _array[position]; } }
    }

}