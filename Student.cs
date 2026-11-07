using System;
using System.Collections.Generic;
using System.Text;


namespace GradeManager
{
    internal class Student
    {
        public string studentID { get; set; }
        public string studentName { get; set; }

        public List<double> grades { get; set; }

        // Constructor
        public Student(string matricula, string nombre)
        {
            studentID = matricula;
            studentName = nombre;
            grades = new List<double>();
        }

        // Agregar calificación
        public bool AddGrade(double grade)
        {
            if (grade < 0 || grade > 100)
            {
                return false;
            }

            grades.Add(grade);
            return true;
        }

        // Calcular promedio
        public double GetAverage()
        {
            if (grades.Count == 0)
            {
                return 0;
            }

            return grades.Average();
        }
    }
}
