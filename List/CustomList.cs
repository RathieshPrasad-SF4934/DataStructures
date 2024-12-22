using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace List
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
        //Adding a List of elements after the given list
        public void AddRange(CustomList<T>element)
        {
            _capacity = _count+element.Count+4;
            T[] temp = new T[_capacity];
            for(int i=0;i<_count;i++)
            {
                temp[i]=_array[i];
            }
            int k =0;
            for(int i=_count;i<_count+element.Count;i++)
            {
                temp[i] = element[k];
                k++;
            }
            _array =  temp;
            _count = _count+element.Count;
        }
        //Checking whether the element is present in the list
        public bool Contains(T data, out int position)
        {
            position = -1;
            for(int i=0;i<Count;i++)
            {
                if(_array[i].Equals(data))
                {
                    position=i;
                    return true;
                }
            }
            return false;
        }
        //Getting the index value of the element given
        public int IndexOf(T data)
        {
            Contains(data,out int position);
            return position;
        }
        //Removing the given data from the list
        public void Remove(T data)
        {
            int position = IndexOf(data);
            RemoveAt(position);
        }
        //Inserting the data at the given position
        public void Insert(int position, T data)
        {
            _capacity = _capacity+1+4;
            T[] temp = new T[_capacity];
            for(int i=0;i<=Count;i++)
            {
                if(i<position)
                {
                    temp[i]=_array[i];
                }
                if(i==position)
                {
                    temp[i]=data;
                }
                else 
                {
                    temp[i]=_array[i-1];
                }
            }
            _array=temp;
        }
        //Inserting a List of data at the given position
        public void InsertRange(int position, CustomList<T>elements)
        {
            _capacity = Count+elements.Count+4;
            T[] temp = new T[_capacity];
            for(int i=0;i<Count+elements.Count;i++)
            {
                if(i<position)
                {
                   temp[i]= _array[i];
                }
                else if(i==position)
                {
                    for(int j=0;j<elements.Count;j++)
                    {
                        temp[i+j]=elements[j];
                    }
                }
                else
                {
                    temp[i+elements.Count]=_array[i];
                }
            }
            _array = temp;
        }
        //Removing the data at the given position
        public void RemoveAt(int position)
        {
            for(int i=0;i<Count;i++)
            {
                if(i<position)
                {
                    continue;
                }
                else 
                {
                    _array[i]=_array[i+1];
                }
            }
            _count-=1;
        }
        //Reversing the given List
        public void Reverse()
        {
            for(int i=0;i<(Count)/2;i++)
            {
                T temp = _array[i];
                _array[i]=_array[Count-1-i];
                _array[Count-1-i] = temp;
            }
        }
        //Sorting the given list
        public void Sort()
        {
            for(int i=0;i<Count;i++)
            {
                for(int j=1;j<Count-i;j++)
                {
                    if(Comparer<T>.Default.Compare(_array[j],_array[j-1])==1)
                    {
                         T temp = _array[j];
                        _array[j] = _array[j-1];
                        _array[j-1]=temp;
                    }
                }
            }
        }


    }
}