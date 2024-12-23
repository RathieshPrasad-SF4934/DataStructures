using System;

namespace SynCartFileManagement;

class Program 
{
    public static void Main(string[] args)
    {
        FileManagement.Create();
        Operations.DefaultData();
        Operations.MainMenu();
        FileManagement.WriteToCSV();
    }
}

