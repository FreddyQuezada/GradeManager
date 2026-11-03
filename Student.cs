using System;
using System.Collections.Generic;
using System.Text;

namespace GradeManager
{
    internal class Student
    {
        public string studentID;
        public string studentName;

        public Student(string studentID, string studentName)
        {
            this.studentID = studentID;
            this.studentName = studentName;
        }



        public void ValidStudent()
        {

        }

        

        public void ShowGrades(){
            Console.WriteLine("Showing grades");
        }

    }




}
