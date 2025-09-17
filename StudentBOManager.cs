using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using NTierDemoApp.Model;
using NTierDemoApp.DAO;


namespace NTierDemoApp.BO
{
    public class StudentBOManager
    {
        public void InsertStudent(StudentBO student)
        {
            student.Validate();
            StudentDB.ManageStudent(student, ActionType.Insert);
        }

        public void UpdateStudent(StudentBO student)
        {
            student.Validate();
            StudentDB.ManageStudent(student, ActionType.Update);
        }

        public void DeleteStudent(int studentId)
        {
            // Pass dummy values to avoid SqlDateTime overflow
            StudentBO student = new StudentBO
            {
                PKStudentId = studentId,
                StuName = "", // dummy
                Marks = 0, // dummy
                DateOfBirth = DateTime.Now, // valid date
                IsActive = false // dummy
            };

            StudentDB.ManageStudent(student, ActionType.Delete);
        }

        public DataSet GetAllStudents()
        {
            return StudentDB.GetAllStudents();
        }
    }
}
