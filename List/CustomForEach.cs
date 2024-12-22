using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace List
{
    //Creating and Defining Enumerator for using ForEach Loop
    public partial class CustomList<T>:IEnumerable,IEnumerator
    {
        int position;
        //Getting the tracking position
        public  IEnumerator GetEnumerator()
        {
            position=-1;
            return (IEnumerator) this;
        }
        //Finding whether there is element to loop
        public bool MoveNext()
        {
            if(position<Count-1)
            {
                position++;
                return true;
            }
            Reset();
            return false;
        }
        //Resetting the value of position after loop completes
        public void Reset()
        {
            position=-1;
        }
        public Object Current { get{return _array[position];} }
    }
}