namespace GradeManager
{

    
        internal class Program
        {
        static void Main(string[] args)
        {

            var studentList= new List<Student>();

            int opcion;

            do
            {
                //Menu
                Console.Clear();
                Console.WriteLine("1. Registrar Estudiante");
                Console.WriteLine("2. Opción 2");
                Console.WriteLine("3. Ver listado de es");
                Console.WriteLine("4. Salir");
                Console.Write("Elige una opción: ");
                opcion = int.Parse(Console.ReadLine());

                switch (opcion)
                {
                    case 1:
                        Console.Clear();
                        Console.WriteLine("Registro de estudiantes");
                        Console.WriteLine("");

                        Console.Write("Matricula: ");
                        string matricula = Console.ReadLine();

                        bool exists = studentList.Any(s => s.studentID == matricula);

                        if (exists)
                        {
                            Console.WriteLine("ya existe este estudiante");
                            Console.ReadKey();
                            break;
                        }

                        Console.Write("Nombre: ");
                        string nombre = Console.ReadLine();

                        if (string.IsNullOrWhiteSpace(nombre) || string.IsNullOrWhiteSpace(matricula))
                        {
                            Console.WriteLine("Datos incompletos.");
                            break;

                        }

                       //Save Student
                        Student student = new Student(matricula, nombre);
                        
                        studentList.Add(student);
                        Console.WriteLine("Estudiante registrado exitosamente");

                        Console.ReadKey();
                        break;

                    case 3:
                        Console.WriteLine("Ver");
                        foreach (var stu in studentList)
                        {
                            Console.WriteLine($"Matrícula: {stu.studentID} | Nombre: {stu.studentName}");
                            Console.ReadKey();
                        }
                        Console.ReadKey();
                        break;
                    case 4:
                        Console.WriteLine("Saliendo del sistema...");
                        Console.ReadKey();
                        break;
                    default:
                        Console.WriteLine("Opcion no valida. Intente de nuevo.");
                        break;
                }
                //
            }
            while (opcion != 4);
            return;



           
                            
        }
       

        }

}
