using System;
using System.Collections.Generic;

namespace ConsoleApp1
{
    public partial class MarkList
    {
        public int? StudentId { get; set; }
        public int? CourseId { get; set; }
        public int MarkId { get; set; }
        public int? Point { get; set; }

        public virtual CourseList Course { get; set; }
        public virtual StudentList Student { get; set; }
    }
}
