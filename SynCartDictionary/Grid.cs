using System;
using System.Collections.Generic;
using System.Reflection;
namespace SynCartDictionary
{
    public class Grid<Type1,Type2>
    {
        public void ShowTable(CustomDictionary<Type1,Type2> list)
        {
            // List<Type2> list = new List<Type2>();
            // list.Add(Type2);
            if(list!=null && list.Count>0)
            {
                PropertyInfo[] properties = typeof(Type2).GetProperties();
                
                //Line
                System.Console.WriteLine(new string('-',properties.Length*25));

                //Property Name
                Console.Write("|");
                foreach(var property in properties)
                {
                    Console.Write($" {property.Name,-20} | ");
                }
                System.Console.WriteLine();

                foreach(KeyValue<Type1,Type2> data in list)
                {
                    Console.Write("|");
                    foreach(var property in properties)
                    {
                        if(property.CanRead)
                        {
                            if(property.PropertyType == typeof(DateTime))
                            {
                                var value = ((DateTime)property.GetValue(data.Value)).ToString("dd/MM/yyyy");
                                Console.Write($" {value,-20} | ");
                            }
                            else
                            {

                                var value = property.GetValue(data.Value);
                                Console.Write($" {value,-20} | ");
                            }
                        }
                    }
                    System.Console.WriteLine();
                }

                //End Line
                System.Console.WriteLine(new string('-',properties.Length*25));

            }
        }
    }
}