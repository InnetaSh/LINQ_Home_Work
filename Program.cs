//создать красивый
//паралаксНапишите LINQ-запрос, который отбирает всех студентов с суммарным баллом по всем предметам больше 250. 
//Отсортируйте студентов по убыванию их среднего балла. Для каждого студента создайте новый объект, содержащий его имя, суммарный балл и средний балл.



using System.Xml.Linq;

var StudentList = new List<Student>
{
    new Student("Alex")
    { 
        Subjects = new List<Subject>
        {
            new Subject("Math"){ Grades = new List<int>{ 10,9,8,12,12, 12, 6, 8, 10, 12 } },
            new Subject("English"){ Grades = new List<int>{ 12,6,8,10,12, 10, 10, 8, 11, 12, 8, 10, 10} },
            new Subject("Geology"){ Grades = new List<int>{ 8,12,10,12,11,10,10, 9, 10, 10, 12, 12, 11, 10 } },
        } 
    },
    new Student("Tom")
    {
         Subjects = new List<Subject>
        {
           new Subject("Math"){ Grades = new List<int>{ 10,10,8,11,12,8, 10, 12, 10, 12, 11, 12, 12 } },
            new Subject("English"){ Grades = new List<int>{ 12,11,10,11,12,10,12, 9, 10, 10, 12, 12, 11, 10} },
            new Subject("Geology"){ Grades = new List<int>{ 9,10,10,12,12,11,10} },
        }
    },
    new Student("Sam")
    {
         Subjects = new List<Subject>
        {
            new Subject("Math"){ Grades = new List<int>{ 10,9,8} },
            new Subject("English"){ Grades = new List<int>{ 6,8,10,8} },
            new Subject("Geology"){ Grades = new List<int>{ 8,10,10} },
        }
    },
    new Student("Bob")
    {
         Subjects = new List<Subject>
        {
            new Subject("Math"){ Grades = new List<int>{ 7,9,6} },
            new Subject("English"){ Grades = new List<int>{ 5,6,8} },
            new Subject("Geology"){ Grades = new List<int>{ 8,12,10,10,10} },
        }
    },
    new Student("Anna")
    {
         Subjects = new List<Subject>
        {
            new Subject("Math"){ Grades = new List<int>{ 10,9,12,12,10,12,12, 10, 12, 10, 12, 11, 12, 12 } },
            new Subject("English"){ Grades = new List<int>{ 12,10,11,11,10,10,12, 10, 9, 12, 12, 10, 12, 12 } },
            new Subject("Geology"){ Grades = new List<int>{ 10,12,10,12,11,12,12} },
        }
    },
};

var grateSudents = StudentList.Where(x => CalcTotalGrades(x) > 250).ToList();
foreach (var st in grateSudents)
{
    Console.WriteLine($"{st.Name}");
    st.PrintGrade();
    Console.WriteLine("----------------------------------------------");
}

int CalcTotalGrades(Student student)
{
    var result = 0;
    foreach (var subject in student.Subjects)
        foreach (var grade in subject.Grades)
            result += grade;
    return result;
}

class Student
{
    public string Name;

    public List<Subject> Subjects;

    public Student(string name)
    {
        Name = name;
        Subjects = new List<Subject>();
    }

    public void PrintGrade()
    {
        foreach (var sb in Subjects)
        {
            string subStr = String.Join(",", sb.Grades);
            Console.WriteLine($"{sb.Name}: {subStr}");
        }
    }
}

class Subject
{
    public string Name;
    public List<int> Grades;

    public Subject(string name)
    {
        Name = name;
        Grades = new List<int>();
    }
}

//Напишите LINQ-запрос, который отбирает всех клиентов, у которых есть хотя бы один заказ с суммой больше 500. 
//Создайте новый список объектов, содержащих имя клиента и список всех его заказов, отсортированных по дате заказа.
