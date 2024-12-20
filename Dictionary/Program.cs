using System;
using System.Runtime.InteropServices;

namespace Dictionary;

class Program
{
    public static void Main(string[] args)
    {
        customDictionary<string,string> dictionary = new customDictionary<string, string>();
        dictionary.Add("SF1001","Rathiesh");
        dictionary.Add("SF1002","Rathiesh");
        dictionary.Add("SF1001","Rathiesh");
        dictionary.Add("SF1001","Rathiesh");
        dictionary.Add("SF1001","Rathiesh");
        dictionary.Add("SF1001","Rathiesh");
        dictionary.Add("SF1001","Rathiesh");
        foreach(KeyValue<string,string> item in dictionary)
        {
            System.Console.WriteLine(item.Key);
            System.Console.WriteLine(item.Value);
        }
        System.Console.WriteLine();
        System.Console.WriteLine();
        // Console.WriteLine($"{dictionary["SF1004"]}");
        dictionary["SF1001"] = "Sairam";
        Console.WriteLine($"{dictionary["SF1001"]}");
        

        
        
        

    }
}
