namespace GradeManager
{
    internal class Program
    {
        static List<Student> studentList = new List<Student>();
        static void Main(string[] args)
        {
            int opcion;

            do
            {
                Console.Clear();
                Console.WriteLine("Gestor de estudiantes.");
                Console.WriteLine("-------------------------");
                Console.WriteLine("");
                Console.WriteLine("1. Registrar Estudiante");
                Console.WriteLine("2. Agregar Calificación");
                Console.WriteLine("3. Ver listado de estudiantes");
                Console.WriteLine("4. Salir");
                Console.WriteLine("");
                Console.Write("Elige una opción: ");

                if (!int.TryParse(Console.ReadLine(), out opcion))
                {
                    Console.WriteLine("Debe introducir un número válido.");
                    Console.ReadKey();
                    continue;
                }

                switch (opcion)
                {
                    case 1:
                        AddStudent();
                        break;

                    case 2:
                        AddGrade();
                        break;

                    case 3:
                        ShowStudentList();
                        break;

                    case 4:
                        Console.WriteLine("Saliendo del sistema...");
                        Console.ReadKey();
                        break;

                    default:
                        Console.WriteLine("Opción no válida.");
                        Console.ReadKey();
                        break;
                }

            }
            while (opcion != 4);
        }

        static void AddStudent()
        {
            Console.Clear();
            Console.WriteLine("Registro de estudiantes");
            Console.WriteLine("");

            Console.Write("Matricula: ");
            string? matricula = Console.ReadLine();

            bool exists = studentList.Any(s => s.studentID == matricula);

            if (exists)
            {
                Console.WriteLine("ya existe este estudiante");
                Console.ReadKey();
                return;
            }

            Console.Write("Nombre: ");
            string? nombre = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(nombre) || string.IsNullOrWhiteSpace(matricula))
            {
                Console.WriteLine("Datos incompletos.");
                return;
            }

            Student student = new Student(matricula, nombre);

            studentList.Add(student);
            Console.WriteLine("Estudiante registrado exitosamente");

            Console.ReadKey();
        }

        static void AddGrade()
        {
                Console.Clear();
                Console.WriteLine("Agregar calificación");

                Console.Write("Matrícula: ");
                string? id = Console.ReadLine();

                var studentFound = studentList.FirstOrDefault(
                    s => s.studentID == id
                );

                if (studentFound == null)
                {
                    Console.WriteLine("Estudiante no encontrado.");
                    Console.ReadKey();
                    return;
                }

                Console.Write("Calificación: ");

                if (!double.TryParse(Console.ReadLine(), out double grade))
                {
                    Console.WriteLine("Debe introducir un número válido.");
                    Console.ReadKey();
                    return;
                }

                if (studentFound.AddGrade(grade))
                {
                    Console.WriteLine("Calificación agregada correctamente.");
                }
                else
                {
                    Console.WriteLine("La calificación debe estar entre 0 y 100.");
                }

                Console.ReadKey();
                return;
            }

        static void ShowStudentList()
        {
            
                Console.Clear();
                Console.WriteLine("Listado de estudiantes");
                Console.WriteLine("-------------------------");

                if (studentList.Count == 0)
                {
                    Console.WriteLine("No hay estudiantes registrados.");
                    Console.ReadKey();
                    return;
                }

                foreach (var stu in studentList)
                {
                    Console.WriteLine($"Matrícula: {stu.studentID}");
                    Console.WriteLine($"Nombre: {stu.studentName}");

                    if (stu.grades.Count == 0)
                    {
                        Console.WriteLine("Promedio: Sin calificaciones");
                    }
                    else
                    {
                        double average = stu.GetAverage();

                        Console.WriteLine($"Promedio: {average:F2}");

                        string status = average >= 70 ? "Aprobado" : "Reprobado";

                        Console.WriteLine($"Estado: {status}");
                    }

                    Console.WriteLine("-------------------------");
                }

                Console.ReadKey();
                return;
            }

    }

}
