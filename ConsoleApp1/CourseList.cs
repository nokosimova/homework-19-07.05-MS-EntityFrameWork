using System;
using System.Collections.Generic;

namespace ConsoleApp1
{
    public partial class CourseList
    {
        public CourseList()
        {
            MarkList = new HashSet<MarkList>();
        }

        public int CourseId { get; set; }
        public string CourseName { get; set; }

        public virtual ICollection<MarkList> MarkList { get; set; }
    }
}
