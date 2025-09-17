using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using NTierDemoApp.Model;

namespace NTierDemoApp.DAO
{
    public static class StudentDB
    {
        public static void ManageStudent(StudentBO student, ActionType action)
        {
            string spName = "spManageStudent";
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@ActionType", (int)action),
                new SqlParameter("@PKStudentId", student.PKStudentId) { Direction = action == ActionType.Insert ? ParameterDirection.Output : ParameterDirection.Input },
                new SqlParameter("@StuName", student.StuName),
                new SqlParameter("@Marks", student.Marks),
                new SqlParameter("@DateOfBirth", student.DateOfBirth),
                new SqlParameter("@IsActive", student.IsActive)
            };

            SqlHelper.ExecuteNonQuery(Helper.ConnectionString, CommandType.StoredProcedure, spName, parameters);

            if (action == ActionType.Insert)
                student.PKStudentId = Convert.ToInt32(parameters[1].Value);
        }

        public static DataSet GetAllStudents()
        {
            return SqlHelper.ExecuteDataset(Helper.ConnectionString, CommandType.StoredProcedure, "spGetAllStuds");
        }
    }
}
