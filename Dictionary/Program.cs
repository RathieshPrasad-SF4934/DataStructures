using System;
using System.Runtime.InteropServices;

namespace Dictionary;

class Program
{
    public static void Main(string[] args)
    {
        CustomDictionary<string,string> dictionary = new CustomDictionary<string, string>();
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

        // for(int i=0;i<dictionary.Count;i++)
        // {
        //     Console.WriteLine($"{dictionary[i]}");
            
        // }

        // Dictionary<string,string>dict = new Dictionary<string, string>();
        // dict.Add("one","rathiesh");
        // dict.Add("two","sairam");
        // for(int i=0;i<dict.Count;i++)
        // {
        //     Console.WriteLine($"{dict[i]}");
            
        // }
        

        
        
        

    }
}
