using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Part_I
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //================== Question 1 =======================


            DataSet TeacherCourseDS = new DataSet("TeacherCourseDS");

            Console.WriteLine("\nThe name of the DataSer is : " + TeacherCourseDS.DataSetName);
            Console.WriteLine("=====================================================================");

            //Teachers table
            DataTable dtTeachers = new DataTable("Teachers");
            TeacherCourseDS.Tables.Add(dtTeachers);

            dtTeachers.Columns.Add("TeacherId", typeof(Int32));
            dtTeachers.Columns.Add("FirstName", typeof(string));
            dtTeachers.Columns.Add("LastName", typeof(string));

            dtTeachers.PrimaryKey = new DataColumn[] { dtTeachers.Columns["TeacherId"] };
            Console.WriteLine("\n\t DataTable Name : " + dtTeachers.TableName);
            Console.WriteLine("=====================================================================");

            foreach (DataColumn dc in dtTeachers.Columns)
            {
                Console.WriteLine("\t\t Column Name : " + dc.ColumnName + "\t\t" + "DataType : " + dc.DataType);
            }


            //courses table
            DataTable dtCourses = new DataTable("Courses");
            TeacherCourseDS.Tables.Add(dtCourses);

            dtCourses.Columns.Add("CourseId", typeof(string));
            dtCourses.Columns.Add("CourseTitle", typeof(string));
            dtCourses.Columns.Add("Duration", typeof(Int32));
            dtCourses.PrimaryKey = new DataColumn[] { dtCourses.Columns["CourseId"] };
            Console.WriteLine("\n\t DataTable Name : " + dtCourses.TableName);
            Console.WriteLine("=====================================================================");

            foreach (DataColumn dc in dtCourses.Columns)
            {
                Console.WriteLine("\t\t Column Name : " + dc.ColumnName + "\t\t" + "DataType : " + dc.DataType);
            }


            //Course assignments table
            DataTable dtCoursesAssignments = new DataTable("CoursesAssignments");
            TeacherCourseDS.Tables.Add(dtCoursesAssignments);

            dtCoursesAssignments.Columns.Add("TeacherId", typeof(Int32));
            dtCoursesAssignments.Columns.Add("CourseId", typeof(string));
            dtCoursesAssignments.Columns.Add("AssignmentDate", typeof(DateTime));
            dtCoursesAssignments.Columns.Add("StartingDate", typeof(DateTime));
            dtCoursesAssignments.Columns.Add("EndingDate", typeof(DateTime));
            dtCoursesAssignments.PrimaryKey = new DataColumn[] { dtCoursesAssignments.Columns["TeacherId"], dtCoursesAssignments.Columns["CourseId"] };

            DataRelation TeacherToCourseAssignments = new DataRelation("TeacherToCourseAssignments", dtTeachers.Columns["TeacherId"], dtCoursesAssignments.Columns["TeacherId"]);
            DataRelation CourseToCourseAssignments = new DataRelation("CourseToCourseAssignments", dtCourses.Columns["CourseId"], dtCoursesAssignments.Columns["CourseId"]);
            TeacherCourseDS.Relations.Add(TeacherToCourseAssignments);
            TeacherCourseDS.Relations.Add(CourseToCourseAssignments);

            Console.WriteLine("\n\t DataTable Name : " + dtCoursesAssignments.TableName);
            Console.WriteLine("=====================================================================");

            foreach (DataColumn dc in dtCoursesAssignments.Columns)
            {
                Console.WriteLine("\t\t" + dc.ColumnName + "\t\t" + dc.DataType);
            }



            //================== Question 2 =======================

            // Teacher table
            dtTeachers.Rows.Add(11111, "Mary", "Brown");
            dtTeachers.Rows.Add(22222, "John", "Abbott");
            dtTeachers.Rows.Add(33333, "Thomas", "Moore");

            //Courses table
            dtCourses.Rows.Add("COMP101", "Object-Oriented Programming Concepts", 90);
            dtCourses.Rows.Add("COMP102", "Algorithms and Programming", 75);
            dtCourses.Rows.Add("COMP103", "Multi-tier Applications Development", 90);


            //CoursesAssignments table
            dtCoursesAssignments.Rows.Add(22222, "COMP101", new DateTime(2024, 1, 22), new DateTime(2024, 1, 25), new DateTime(2024, 5, 25));
            dtCoursesAssignments.Rows.Add(22222, "COMP102", new DateTime(2024, 1, 22), new DateTime(2024, 1, 25), new DateTime(2024, 5, 25));
            dtCoursesAssignments.Rows.Add(22222, "COMP103", new DateTime(2024, 1, 22), new DateTime(2024, 1, 25), new DateTime(2024, 5, 25));
            dtCoursesAssignments.Rows.Add(11111, "COMP101", new DateTime(2024, 1, 22), new DateTime(2024, 1, 25), new DateTime(2024, 5, 25));


            //================== Question 3 =======================

            var searchProjects = dtCoursesAssignments.Select("TeacherId = 22222");
            Console.WriteLine("\n\tthe courses assigned to the teacher John Abbott are: ");
            Console.WriteLine("=====================================================================");
            foreach (DataRow dr in searchProjects)
            {
                Console.WriteLine( "\t CourseId : "+ dr["CourseId"] + "\t Assignment Date : " +  dr["AssignmentDate"] + "\t Starting Date : " + dr["StartingDate"] + "\t Ending Date : "+ dr["EndingDate"]);
            }

            var searchEmployee = dtCoursesAssignments.Select("CourseId = 'COMP101'");
            Console.WriteLine("\n\tAll the teachers who have been assigned to the course COMP101, are: ");
            Console.WriteLine("=====================================================================");
            foreach (DataRow dr in searchEmployee)
            {
                Console.WriteLine("\t TeacherID : " + dr["TeacherId"] + "\t Assignment Date : " + dr["AssignmentDate"] + "\t Starting Date : " + dr["StartingDate"] + "\t Ending Date : " + dr["EndingDate"]);
            }

        }
    }
}
