using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Question1
{
    public class Course
    {
        public int CourseID { get; set; }
        public string CourseTitle { get; set; }
        private Dictionary<Student, double> students;

        public delegate void NumberOfStudentChangeHandler(int oldNumber, int newNumber);
        public event NumberOfStudentChangeHandler OnNumberOfStudentChange;

        public Course(int courseID, string courseTitle)
        {
            CourseID = courseID;
            CourseTitle = courseTitle;
            students = new Dictionary<Student, double>();
        }

        public void AddStudent(Student p, double g)
        {
            int oldNumber = students.Count;
            students[p] = g;
            int newNumber = students.Count;
            OnNumberOfStudentChange?.Invoke(oldNumber, newNumber);
        }

        public void RemoveStudent(int studentID)
        {
            int oldNumber = students.Count;
            foreach (var student in students.Keys)
            {
                if (student.StudentID == studentID)
                {
                    students.Remove(student);
                    break;
                }
            }
            int newNumber = students.Count;
            OnNumberOfStudentChange?.Invoke(oldNumber, newNumber);
        }

        public override string ToString()
        {
            string result = $"CourseID: {CourseID} - CourseTitle: {CourseTitle} \n";
            foreach (var kvp in students)
            {
                result += $"StudentID: {kvp.Key.StudentID} - {kvp.Key.StudentName} - Mark: {kvp.Value}\n";
            }
            return result;
        }
    }
}
