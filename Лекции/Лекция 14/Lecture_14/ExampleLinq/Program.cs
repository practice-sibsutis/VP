// See https://aka.ms/new-console-template for more information
using ExampleLinq;
//Получение источника данных
//from переменная in набор_объектов
//select переменная;
string[] people = { "Tom", "Bob", "Sam", "Tim", "Tomas", "Bill" };
var queryAllPeople = from p in people select p;

Console.WriteLine("All people:");
foreach(var item in queryAllPeople)
{
    Console.Write(item);
    Console.Write(' ');
}
Console.WriteLine("\n\n");

//Фильтрация
//from переменная in набор_объектов
//where условие фильтрации
//select переменная;
queryAllPeople = from p in people
                 where p.StartsWith("T")
                 select p;

Console.WriteLine(@"Starts whith 'T':");
foreach (var item in queryAllPeople)
{
    Console.Write(item);
    Console.Write(' ');
}
Console.WriteLine("\n\n");


//Упорядочение
//from переменная in набор_объектов
//orderby переменная {ascending | descending}
//select переменная;
queryAllPeople = from p in people
                 where p.StartsWith("T")
                 orderby p.Length descending
                 select p;


Console.WriteLine(@"Starts whith 'T' and sort by length:");
foreach (var item in queryAllPeople)
{
    Console.Write(item);
    Console.Write(' ');
}
Console.WriteLine("\n\n");

//Группирование
//from переменная in набор_объектов
//group переменная by ключ/условие по которому происходит группирование [into переменная]
//select переменная;
List<Student> students = new List<Student>
        {
           new Student {First="Svetlana", Last="Omelchenko", ID=111, Scores= new List<int> {97, 72, 81, 60}},
           new Student {First="Claire", Last="O'Donnell", ID=112, Scores= new List<int> {75, 84, 91, 39}},
           new Student {First="Sven", Last="Mortensen", ID=113, Scores= new List<int> {99, 89, 91, 95}},
           new Student {First="Cesar", Last="Garcia", ID=114, Scores= new List<int> {72, 81, 65, 84}},
           new Student {First="Debra", Last="Garcia", ID=115, Scores= new List<int> {97, 89, 85, 82}},
           new Student {First="Kristina", Last="Omelchenko", ID=111, Scores= new List<int> {97, 72, 81, 60}},
           new Student {First="Sven", Last="O'Donnell", ID=113, Scores= new List<int> {99, 89, 91, 95}}
        };

var studentQuery2 =
    from student in students
    group student by student.Last[0] into g
    orderby g.Key
    select g;

Console.WriteLine(@"Group by last:");
foreach (var group in studentQuery2)
{
    foreach(var item in group)
    {
        Console.Write($"{item.First} {item.Last},");
        Console.Write(' ');
    }
    Console.WriteLine();
}
Console.WriteLine("\n");

//Соединение
//from переменная in набор_объектов
//join переменная in набор_объектов on условие соединения
//select объект соединения;
List<Student> students2 = new List<Student>
        {
           new Student {First="Svetlana", Last="Omelchenko", ID=111, Scores= new List<int> {97, 72, 81, 60}},
           new Student {First="Claire", Last="O'Donnell", ID=112, Scores= new List<int> {75, 84, 91, 39}},
           new Student {First="Anna", Last="Mortensen", ID=113, Scores= new List<int> {99, 89, 91, 95}},
           new Student {First="Charles", Last="Garcia", ID=114, Scores= new List<int> {72, 81, 65, 84}},
           new Student {First="Carlos", Last="Garcia", ID=115, Scores= new List<int> {97, 89, 85, 82}}
        };

var studentQuery3 =
    from student in students
    join student2 in students2 on student.First equals student2.First
    select new {FirstStudent = student.ID, SecondStudent = student2.ID};

Console.WriteLine(@"Join by first:");
foreach (var item in studentQuery3)
{

    Console.WriteLine($"{item}");
}
Console.WriteLine("\n\n");


//  Select: определяет проекцию выбранных значений
foreach(var item in students.Select(student => student.First.ToUpper())){
    Console.WriteLine(item);
}
Console.WriteLine();

//  Where: определяет фильтр выборки
foreach (var item in students.Where(student => student.First.StartsWith("C"))){
    Console.WriteLine(item);
}
Console.WriteLine();

//  OrderBy: упорядочивает элементы по возрастанию
foreach (var item in students.OrderBy(student => student.First)) 
{
    Console.WriteLine(item);
}
Console.WriteLine();

//  OrderByDescending: упорядочивает элементы по убыванию
foreach (var item in students.OrderByDescending(student => student.First))
{
    Console.WriteLine(item);
}
Console.WriteLine();

//  ThenBy: задает дополнительные критерии для упорядочивания элементов возрастанию
foreach (var item in students.OrderBy(student => student.Last).ThenBy(student => student.First))
{
    Console.WriteLine(item);
}
Console.WriteLine();

//  ThenByDescending: задает дополнительные критерии для упорядочивания элементов по убыванию
foreach (var item in students.OrderBy(student => student.Last).ThenByDescending(student => student.First))
{
    Console.WriteLine(item);
}
Console.WriteLine();

//  Join: соединяет две коллекции по определенному признаку
foreach (var item in students.Join(students2,
    s1 => s1.Last,
    s2 => s2.Last,
    (s1, s2) => new { FirstStudent = s1.First, SecondStudent = s2.First }))
{
    Console.WriteLine($"{item.FirstStudent} {item.SecondStudent}");
}
Console.WriteLine();

//  Aggregate: применяет к элементам последовательности агрегатную функцию, которая сводит их к одному объекту
var aggregateQuery = students.Aggregate((s1, s2) => new Student
{
    First = "Claire",
    Last = "O'Donnell",
    ID = s1.ID + s2.ID,
    Scores = new List<int> { 75, 84, 91, 39 }
});
Console.WriteLine($"{aggregateQuery}\n");

//  GroupBy: группирует элементы по ключу
foreach (var group in students.GroupBy(student => student.Last))
{
    foreach(var item in group)
    {
        Console.WriteLine(item);
    }
}
Console.WriteLine();

//  ToLookup: группирует элементы по ключу, при этом все элементы добавляются в словарь
foreach (var group in students.ToLookup(student => student.Last))
{
    foreach (var item in group)
    {
        Console.WriteLine(item);
    }
}
Console.WriteLine();

//  GroupJoin: выполняет одновременно соединение коллекций и группировку элементов по ключу
Person magnus = new Person { Name = "Hedlund, Magnus" };
Person terry = new Person { Name = "Adams, Terry" };
Person charlotte = new Person { Name = "Weiss, Charlotte" };

Pet barley = new Pet { Name = "Barley", Owner = terry };
Pet boots = new Pet { Name = "Boots", Owner = terry };
Pet whiskers = new Pet { Name = "Whiskers", Owner = charlotte };
Pet daisy = new Pet { Name = "Daisy", Owner = magnus };

List<Person> persons = new List<Person> { magnus, terry, charlotte };
List<Pet> pets = new List<Pet> { barley, boots, whiskers, daisy };

var query =
    persons.GroupJoin(pets,
                     person => person,
                     pet => pet.Owner,
                     (person, petCollection) =>
                         new
                         {
                             OwnerName = person.Name,
                             Pets = petCollection.Select(pet => pet.Name)
                         });

foreach (var obj in query)
{
    // Output the owner's name.
    Console.WriteLine("{0}:", obj.OwnerName);
    // Output each of the owner's pet's names.
    foreach (string pet in obj.Pets)
    {
        Console.WriteLine("  {0}", pet);
    }
}
Console.WriteLine();


//    Reverse: располагает элементы в обратном порядке
foreach (var p in persons.Reverse<Person>())
{
    Console.WriteLine(p.Name);
}
Console.WriteLine();

//    All: определяет, все ли элементы коллекции удовлятворяют определенному условию
Console.WriteLine($"All:{students.All(student => student.Scores.Average() > 70)}");
Console.WriteLine();

//    Any: определяет, удовлетворяет хотя бы один элемент коллекции определенному условию
Console.WriteLine($"Any:{students.Any(student => student.Scores.Average() > 90)}");
Console.WriteLine();

//    Contains: определяет, содержит ли коллекция определенный элемент
Console.WriteLine($"Contains:{persons.Contains<Person>(new Person { Name = "Weiss, Charlotte" })}");
Console.WriteLine();

//    Distinct: удаляет дублирующиеся элементы из коллекции
persons.Add(new Person { Name = "Hedlund, Magnus" });
persons.Add(new Person { Name = "Hedlund, Magnus" });
persons.Add(new Person { Name = "Hedlund, Magnus" });

foreach(var p in persons)
{
    Console.WriteLine(p.Name);
}
Console.WriteLine();
foreach (var p in persons.Distinct())
{
    Console.WriteLine(p.Name);
}
Console.WriteLine();

//  Except: возвращает разность двух коллекций, то есть те элементы, которые создаются только в одной коллекции
List<Person> persons2 = new List<Person> { magnus };

foreach (var p in persons.Except(persons2))
{
    Console.WriteLine(p.Name);
}
Console.WriteLine();

//    Union: объединяет две однородные коллекции
foreach (var p in persons.Union(persons2))
{
    Console.WriteLine(p.Name);
}
Console.WriteLine();

//    Intersect: возвращает пересечение двух коллекций, то есть те элементы, которые встречаются в обоих коллекциях
foreach (var p in persons.Intersect(persons2))
{
    Console.WriteLine(p.Name);
}
Console.WriteLine();

//    Count: подсчитывает количество элементов коллекции, которые удовлетворяют определенному условию
Console.WriteLine($"Count:{students.Count(student => student.Scores.Average() > 80)}");
Console.WriteLine();

//    Sum: подсчитывает сумму числовых значений в коллекции
Console.WriteLine($"Sum:{students.Sum(student => 1)}");
Console.WriteLine();

//    Average: подсчитывает cреднее значение числовых значений в коллекции
Console.WriteLine($"Average:{students.Average(student => student.Scores.Average())}");
Console.WriteLine();

//    Min: находит минимальное значение
Console.WriteLine($"Min:{students.Min(student => student.Scores.Min())}");
Console.WriteLine();

//    Max: находит максимальное значение
Console.WriteLine($"Max:{students.Max(student => student.Scores.Max())}");
Console.WriteLine();

//Take: выбирает определенное количество элементов
foreach (var p in persons.Take(2))
{
    Console.WriteLine(p.Name);
}
Console.WriteLine();

//    Skip: пропускает определенное количество элементов
foreach (var p in persons.Skip(1))
{
    Console.WriteLine(p.Name);
}
Console.WriteLine();

//    TakeWhile: возвращает цепочку элементов последовательности, до тех пор, пока условие истинно
foreach (var p in students.TakeWhile(student => student.Scores.Average() < 85))
{
    Console.WriteLine($"{p.First} {p.Last}");
}
Console.WriteLine();

//    SkipWhile: пропускает элементы в последовательности, пока они удовлетворяют заданному условию, и затем возвращает оставшиеся элементы
foreach (var p in students.SkipWhile(student => student.Scores.Average() < 85))
{
    Console.WriteLine($"{p.First} {p.Last}");
}
Console.WriteLine();

//    Concat: объединяет две коллекции
foreach (var p in students.Concat(students2))
{
    Console.WriteLine($"{p.First} {p.Last}");
}
Console.WriteLine();

//    Zip: объединяет две коллекции в соответствии с определенным условием
int[] numbers = { 1, 2, 3, 4 };
string[] words = { "one", "two", "three" };

var numbersAndWords = numbers.Zip(words, (first, second) => first + " " + second);

foreach (var item in numbersAndWords)
    Console.WriteLine(item);

//    First: выбирает первый элемент коллекции
Console.WriteLine(words.First(word => word.StartsWith("t")));
Console.WriteLine();

//    FirstOrDefault: выбирает первый элемент коллекции или возвращает значение по умолчанию
Console.WriteLine(words.FirstOrDefault(word => word.StartsWith("z")));
Console.WriteLine();

//    Single: выбирает единственный элемент коллекции, если коллекция содержит больше или меньше одного элемента, то генерируется исключение
Console.WriteLine(words.Single(word => word.StartsWith("o")));
Console.WriteLine();

//    SingleOrDefault: выбирает единственный элемент коллекции. Если коллекция пуста, возвращает значение по умолчанию.
//    Если в коллекции больше одного элемента, генерирует исключение
Console.WriteLine(words.SingleOrDefault(word => word.StartsWith("o")));
Console.WriteLine();

//  ElementAt: выбирает элемент последовательности по определенному индексу
Console.WriteLine(words.ElementAt(1));
Console.WriteLine();

//    ElementAtOrDefault: выбирает элемент коллекции по определенному индексу или возвращает значение по умолчанию, если индекс вне допустимого диапазона
Console.WriteLine(words.ElementAtOrDefault(1));
Console.WriteLine();

//    Last: выбирает последний элемент коллекции
Console.WriteLine(words.Last(word => word.StartsWith("t")));
Console.WriteLine();

//    LastOrDefault: выбирает последний элемент коллекции или возвращает значение по умолчанию
Console.WriteLine(words.LastOrDefault(word => word.StartsWith("t")));
Console.WriteLine();
