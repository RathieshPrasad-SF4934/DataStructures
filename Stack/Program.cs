using System;

namespace Stack;

class Program 
{
    public static void Main(string[] args)
    {
        Stack<int> myStack = new Stack<int>();

        Stack<int> newStack = new Stack<int>(5);

        System.Console.WriteLine(myStack.Capacity);
        System.Console.WriteLine(newStack.Capacity);

        myStack.Push(1);
        myStack.Push(2);
        myStack.Push(3);
        myStack.Push(4);
        myStack.Push(5);
        myStack.Push(6);
        System.Console.WriteLine(myStack.Peek());
        System.Console.WriteLine(myStack.Pop());
        System.Console.WriteLine(myStack.Peek());
        System.Console.WriteLine(myStack.Pop());
        System.Console.WriteLine(myStack.Peek());
        System.Console.WriteLine(myStack.Pop());
    }
}