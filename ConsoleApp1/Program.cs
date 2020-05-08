using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection.PortableExecutable;
using System.Runtime.CompilerServices;
using System.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Threading;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            bool act = true;
            while(act)
            {
                Thread.Sleep(1000); 
                Console.WriteLine("Choose command to table MarkList:");
                Console.WriteLine("1 - Show table");
                Console.WriteLine("2 - Add data");
                Console.WriteLine("3 - Update data");
                Console.WriteLine("4 - Delete data");
                Console.WriteLine("5 - Exit");
                var command = int.Parse(Console.ReadLine());

                switch(command)
                {
                    case 1:
                        Show();
                        break;
                    case 2:
                        AddData();
                        break;
                    case 3:
                        UpdateData();
                        break;
                    case 4:
                        DeleteData();
                        break;
                    case 5:
                        act = false;
                        break;
                    default:
                        break;
                }

            }
        }
        public static void Show()
        { }
        public static void AddData()
        { }
        public static void UpdateData()
        { }
        public static void DeleteData()
        { }
    }
}
