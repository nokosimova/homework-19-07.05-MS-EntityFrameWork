using System;
using System.Collections.Generic;

namespace ConsoleApp1
{
    public partial class StudentList
    {
        public StudentList()
        {
            MarkList = new HashSet<MarkList>();
        }

        public int StudentId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MidName { get; set; }
        public DateTime? BirthDate { get; set; }
        public string Telephone { get; set; }

        public virtual ICollection<MarkList> MarkList { get; set; }
    }
}
