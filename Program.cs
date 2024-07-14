//создать красивый
//паралаксНапишите LINQ-запрос, который отбирает всех студентов с суммарным баллом по всем предметам больше 250. 
//Отсортируйте студентов по убыванию их среднего балла. Для каждого студента создайте новый объект, содержащий его имя, суммарный балл и средний балл.



using System.Diagnostics;
using System.Linq;
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

var grateSudents = StudentList.Where(x => CalcTotalGrades(x) > 250)
    .Select(student => new
    {
        student.Name,
        GradeSum = student.CalcSumGrage(),
        AvarageGrage =student.CalcAvarageGrage()
    }).ToList();


foreach (var st in grateSudents)
{
Console.WriteLine($"Name - {st.Name}, {st.GradeSum}, {st.AvarageGrage} ");
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

    public int CalcSumGrage()
    {
        int sum = 0;
        foreach (var sub in Subjects)
        { 
            foreach ( var gr in sub.Grades)
            {
                sum += gr;
            }
        }
        return sum;
    }
    public double CalcAvarageGrage()
    {
        int totalSum = CalcSumGrage();
        int totalCount = 0;
        foreach (var sb in Subjects)
            totalCount += sb.Grades.Count;
        double Avarage = (double)totalSum / totalCount;
        return Avarage;
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

//var ClientList = new List<Client>
//{
//    new Client("Inna")
//    {
//        Orders = new List<Order>
//        {
//            new Order("Iphone15", 32000,new DateTime(2024,07,15)),
//            new Order("Acum", 12000,new DateTime(2024,07,17)),
//            new Order("Invertor", 6000,new DateTime(2024,07,10))
//        }
//    },
//    new Client("Alex")
//    {
//        Orders = new List<Order>
//        {
//            new Order("Iphone12", 22000,new DateTime(2024,06,10)),
//            new Order("Computer", 62000,new DateTime(2024,05,21)),
//            new Order("MacBook", 80000,new DateTime(2024,01,10))
//        }
//    },
//    new Client("Tom")
//    {
//        Orders = new List<Order>
//        {
//            new Order("TP-LINK ", 450,new DateTime(2024,04,11))

//        }
//    }

//};


//var Clients = ClientList.Where(x => (x.Orders.Any(order => order.Price > 500)))
//    .Select(client => new Client(client.Name)
//    {
//        Orders = client.Orders.OrderBy(x=>x.OrderDate).ToList()
//    });

//foreach (var c in Clients)
//{
//    c.PrintInfo();
//    Console.WriteLine("-------------------------------------------");
//}

//class Client
//{
//    public string Name;

//    public List<Order> Orders;

//    public Client(string name)
//    {
//        Name = name;
//        Orders = new List<Order>();
//    }

//    public void PrintInfo()
//    {
//        Console.WriteLine($"Client name - {Name}");
//        foreach (var ord in Orders)
//            ord.PrintInfo();
//    }

//}

//class Order
//{
//    public string Name;
//    public double Price;
//    public DateTime OrderDate;

//    public Order(string name, double price, DateTime orderDate)
//    {
//        Name = name;
//        Price = price;
//        OrderDate = orderDate;
//    }
//    public void PrintInfo()
//    {

//            Console.WriteLine($"Order name - {Name}, Price - {Price}, date - {OrderDate}");

//    }
//}