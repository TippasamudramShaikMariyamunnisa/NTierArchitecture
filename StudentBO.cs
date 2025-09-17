using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NTierDemoApp.Model
{
    public class StudentBO
    {
        public int PKStudentId { get; set; }
        public string StuName { get; set; }
        public int Marks { get; set; }
        public DateTime DateOfBirth { get; set; }
        public bool IsActive { get; set; }

        public void Validate()
        {
            if (string.IsNullOrWhiteSpace(StuName))
                throw new ApplicationException("Student name is required.");

            if (Marks < 0 || Marks > 100)
                throw new ApplicationException("Marks must be between 0 and 100.");

            if ((DateTime.Now - DateOfBirth).TotalDays < 365 * 5)
                throw new ApplicationException("Student must be at least 5 years old.");
        }

    }
}
