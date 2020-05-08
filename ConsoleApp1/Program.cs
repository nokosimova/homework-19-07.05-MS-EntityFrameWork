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
            while (act)
            {
                Thread.Sleep(1000);
                Console.WriteLine("Choose command to table MarkList:");
                Console.WriteLine("1 - Show table");
                Console.WriteLine("2 - Add data");
                Console.WriteLine("3 - Update data");
                Console.WriteLine("4 - Delete data");
                Console.WriteLine("5 - Exit");
                var command = int.Parse(Console.ReadLine());

                switch (command)
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
        public static void Show(object mess = null)
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
            catch (Exception x)
            {
                Console.WriteLine($"Fail:{x.Message}");
            }
            finally
            {
                if (mess == null)
                {
                    Console.WriteLine("Press any key to continue...");
                    Console.ReadKey();
                }
            }
        }
        public static void ShowStudentIdAndName()
        {
            using (var context = new NewDBContext())
            {
                var studList = context.StudentList.ToList();
                Console.WriteLine("id  |               FIO            |");
                studList.ForEach(s => { Console.WriteLine($"{s.StudentId} |{s.FirstName} {s.LastName}    "); });
            }
        }

        public static void ShowCourseIdAndName()
        {
            using (var context = new NewDBContext())
            {
                var courseList = context.CourseList.ToList();
                Console.WriteLine("id  |  Course name  |");
                courseList.ForEach(c => { Console.WriteLine($"{c.CourseId} |{c.CourseName}      "); });
            }
        }
        public static void AddData()
        {
            try
            {
                using (var context = new NewDBContext())
                {
                    Console.WriteLine("Choose Student id: ");
                    ShowStudentIdAndName();
                    var studId = int.Parse(Console.ReadLine());

                    Console.WriteLine("Choose Course id: ");
                    ShowCourseIdAndName();
                    var courseId = int.Parse(Console.ReadLine());

                    Console.WriteLine("Choose mark from 2-4:");
                    var point = int.Parse(Console.ReadLine());

                    MarkList newMark = new MarkList()
                    {
                        StudentId = studId,
                        CourseId = courseId,
                        Point = point
                    };
                    context.MarkList.Add(newMark);
                    var result = context.SaveChanges();
                    if (result > 0) Console.WriteLine("New data was successfully added!");
                }
            }
            catch(Exception x)
            {
                Console.WriteLine($"Fail:{x.Message}");
            }
            finally
            {
                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
            }
        }
        public static void UpdateData()
        {
            try
            {
                using (var context = new NewDBContext())
                {
                    Show("tochange");
                    Console.WriteLine("Choose ID to update");
                    var markId = int.Parse(Console.ReadLine());
                    var row = context.MarkList.Find(markId);
                    if (row != null)
                    {                        
                        Console.WriteLine("Would you like to change student name? (Y(yes)/N(no))");
                        if ((Console.ReadLine()).ToUpper() == "Y")
                        {
                            ShowStudentIdAndName();
                            Console.Write("new ID: ");
                            var studId = int.Parse(Console.ReadLine());
                            row.StudentId = studId;
                        }                        
                        Console.WriteLine("Would you like to change course? (Y(yes)/N(no))");
                        if ((Console.ReadLine()).ToUpper() == "Y")
                        {
                            ShowCourseIdAndName();
                            Console.Write("new course ID: ");
                            var courseId = int.Parse(Console.ReadLine());
                            row.CourseId = courseId;
                        }
                        Console.WriteLine("Would you like to change mark? (Y(yes)/N(no))");                        
                        if ((Console.ReadLine()).ToUpper() == "Y")
                        {
                            Console.Write("new mark from 2-4: ");
                            var point = int.Parse(Console.ReadLine());
                            row.Point = point;
                        }                        
                        if (context.SaveChanges() > 0)
                            Console.WriteLine("Data was successfully updated!");
                        else
                            Console.WriteLine("Fail! Data wasn't updated!");
                    }
                    else
                        Console.WriteLine("Wrong mark ID!");
                }
            }
            catch (Exception x)
            {
                Console.WriteLine($"Fail:{x.Message}");
            }
            finally
            {
                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
            }
        }
        public static void DeleteData()
        {
            try
            {
                using (var context = new NewDBContext())
                {
                    Show("tochange");
                    Console.Write("Choose ID to delete:");
                    var markId = int.Parse(Console.ReadLine());
                    var row = context.MarkList.Find(markId);
                    if (row != null)
                    {
                        Console.Write("Are you sure? Y(yes)/N(no):");
                        var confirm = Console.ReadLine();
                        if (confirm.ToUpper() == "Y") context.MarkList.Remove(row);
                        if (context.SaveChanges() > 0)
                            Console.WriteLine("Data was successfully deleted!");
                        else
                            Console.WriteLine("Fail! Data wasn't deleted!");
                    }
                    else
                        Console.WriteLine("Wrong mark ID!");                    
                }
            }
            catch (Exception x)
            {
                Console.WriteLine($"Fail:{x.Message}");
            }
            finally
            {
                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
            }

        }

    }
}
