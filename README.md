# GradeManager

Aplicación de consola desarrollada en C# con .NET 10 para gestionar
estudiantes y sus calificaciones.

## Características

-   Registrar estudiantes mediante matrícula y nombre.
-   Evitar el registro de matrículas duplicadas.
-   Agregar calificaciones a un estudiante existente.
-   Validar que las calificaciones sean números entre 0 y 100.
-   Consultar el listado de estudiantes.
-   Calcular el promedio de cada estudiante.
-   Mostrar si el estudiante está **Aprobado** (promedio mayor o igual
    a 70) o **Reprobado** (promedio menor que 70).
-   Validar que la opción del menú sea numérica.

## Requisitos

-   .NET 10 SDK.
-   Un editor o IDE compatible con C#, por ejemplo Visual Studio o
    Visual Studio Code.

Para comprobar que el SDK está instalado, abre una terminal y ejecuta:

``` bash
dotnet --version
```

La versión instalada debe corresponder a .NET 10.

## Cómo ejecutar el proyecto

1.  Descarga o clona el repositorio.

2.  Abre una terminal en la carpeta que contiene el archivo
    `GradeManager.csproj`.

3.  Restaura las dependencias y compila el proyecto:

    ``` bash
    dotnet build
    ```

4.  Ejecuta la aplicación:

    ``` bash
    dotnet run
    ```

También puedes indicar explícitamente el proyecto:

``` bash
dotnet run --project GradeManager.csproj
```

Si abres la solución `GradeManager.slnx` desde un IDE compatible, puedes
ejecutar el proyecto desde las opciones de ejecución del IDE.

## Uso del sistema

Al iniciar, se muestra el siguiente menú:

1.  **Registrar Estudiante:** solicita matrícula y nombre. No permite
    registrar una matrícula que ya exista.
2.  **Agregar Calificación:** solicita la matrícula del estudiante y una
    calificación entre 0 y 100.
3.  **Ver listado de estudiantes:** muestra la matrícula, el nombre, el
    promedio y el estado académico de cada estudiante.
4.  **Salir:** termina la aplicación.

Si un estudiante todavía no tiene calificaciones, el listado muestra
`Promedio: Sin calificaciones`.

## Explicación de las clases

### `Program`

Es el punto de entrada de la aplicación y contiene el menú de consola.
Mantiene la lista de estudiantes durante la ejecución y coordina las
operaciones disponibles.

Sus métodos principales son:

-   `Main`: muestra el menú, lee la opción y dirige el flujo mediante
    `switch`.
-   `AddStudent`: solicita los datos, comprueba que la matrícula no esté
    registrada y crea el estudiante.
-   `AddGrade`: busca al estudiante por matrícula, valida la entrada
    numérica y solicita al objeto estudiante que agregue la
    calificación.
-   `ShowStudentList`: recorre los estudiantes y muestra sus datos,
    promedio y estado académico.

### `Student`

Representa a un estudiante individual.

Sus propiedades son:

-   `studentID`: matrícula del estudiante.
-   `studentName`: nombre del estudiante.
-   `grades`: lista de calificaciones de tipo `double`.

Sus métodos principales son:

-   `Student`: constructor que recibe la matrícula y el nombre e
    inicializa la lista de calificaciones.
-   `AddGrade`: agrega una calificación si está dentro del rango
    permitido de 0 a 100. Devuelve `true` si se agregó y `false` si no
    cumple la validación.
-   `GetAverage`: calcula y devuelve el promedio de las calificaciones.
    Si no hay calificaciones, devuelve `0`; la interfaz evita mostrar
    ese valor como promedio y presenta `Sin calificaciones`.

## Reglas de cálculo

-   Las calificaciones permitidas están en el rango de 0 a 100,
    inclusive.
-   El promedio es la suma de las calificaciones dividida entre la
    cantidad de calificaciones.
-   Un promedio de 70 o más corresponde a **Aprobado**.
-   Un promedio menor que 70 corresponde a **Reprobado**.

## Consideraciones

-   Los estudiantes y sus calificaciones se almacenan en memoria
    mediante listas. Por tanto, los datos se pierden al cerrar la
    aplicación.
-   La aplicación no utiliza actualmente una base de datos ni archivos
    para guardar información de forma permanente.
-   El proyecto utiliza `Average()` de LINQ. Si la configuración del
    proyecto no habilita las importaciones implícitas, será necesario
    importar `System.Linq` en `Student.cs`.
