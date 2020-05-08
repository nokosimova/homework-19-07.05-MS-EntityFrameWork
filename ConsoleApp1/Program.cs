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
        {
            try
            {
                using (var context = new NewDBContext())
                {
                    var markList = context.MarkList.ToList();
                    var studList = context.StudentList.ToList();
                    var courseList = context.CourseList.ToList();
                    Console.WriteLine(" id |             FIO               | Subject  |  Mark |");
                    Console.WriteLine("--------------------------------------------------------");
                    studList.ForEach(s =>
                    {
                        markList.ForEach(m =>
                        {                            
                            if (s.StudentId == m.StudentId)
                            {
                                var coursename = context.CourseList.Find(m.CourseId).CourseName;
                                Console.WriteLine($"{m.MarkId}  |{s.FirstName} {s.LastName}           |{coursename}   | {m.Point}  |");
                            }
                        });
                    });
                }
            }
            catch(Exception x)
            {
                Console.WriteLine($"Fail:{x.Message}");
            }
            finally
            { }
        }
        /*
                    companyList.ForEach(p =>

                    {

                        Console.WriteLine($"ID:{p.Id}\tCompanyName:{p.CompanyName}");

                    });

                }

            }

            catch (Exception ex)

            {

                FailMessage(ex.Message);

            }

            finally

            {

                if (type != "update")

                {

                    ConsoleReadWithPressKeyMessage();

                }*/
        public static void AddData()
        { }
        public static void UpdateData()
        { }
        public static void DeleteData()
        { }

    }
}
