using System;
using System.Collections.Generic;
using System.Reflection;
namespace SynCart
{
    public class Grid<DataType>
    {
        public void ShowTable(CustomList<DataType> list)
        {
            if(list!=null && list.Count>0)
            {
                PropertyInfo[] properties = typeof(DataType).GetProperties();
                //Line
                System.Console.WriteLine(new string('-',properties.Length*25));

                //Property Name
                Console.Write("|");
                foreach(var property in properties)
                {
                    Console.Write($" {property.Name,-20} | ");
                }
                System.Console.WriteLine();

                foreach(var data in list)
                {
                    Console.Write("|");
                    foreach(var property in properties)
                    {
                        if(property.CanRead)
                        {
                            if(property.PropertyType == typeof(DateTime))
                            {
                                var value = ((DateTime)property.GetValue(data)).ToString("dd/MM/yyyy");
                                Console.Write($" {value,-20} | ");
                            }
                            else
                            {
                                var value = property.GetValue(data);
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