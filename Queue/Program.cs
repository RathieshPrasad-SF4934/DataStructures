
using System;

namespace Queue;

class Program
{
    public static void Main(string[] args)
    {
        customQueue<int> customQueue = new customQueue<int>(3);
        customQueue.Enqueue(1);
        customQueue.Enqueue(2);
        customQueue.Enqueue(3);
        // System.Console.WriteLine(customQueue.Capacity);
        customQueue.Enqueue(1);
        customQueue.Enqueue(1);
        customQueue.Enqueue(1);
        // System.Console.WriteLine(customQueue.Capacity);
        foreach(int item in customQueue)
        {
            System.Console.WriteLine();

        }
    }
}