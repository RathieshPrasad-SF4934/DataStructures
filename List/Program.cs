using System;

namespace List;

class Program 
{
    public static void Main(string[] args)
    {
        CustomList<int> myList = new CustomList<int>(3);
        Console.WriteLine($"{myList.Capacity}");
        myList.Add(1);
         myList.Add(2);
          myList.Add(3);
           myList.Add(4);
        Console.WriteLine($"{myList.Capacity}");
        CustomList<int> myList2 = new CustomList<int>(3);
        myList2.Add(5);
        myList2.Add(6);
        myList2.Add(7);
        myList.AddRange(myList2);
        Console.WriteLine($"{myList.Capacity}");
        foreach(int item in myList)
        {
            System.Console.WriteLine(item);
        }
        myList.Reverse();
        foreach(int item in myList)
        {
            System.Console.WriteLine(item);
        }
    }
}
