using System;

public class Program
{

    public static void Main()
    {
        // Lista de datos de la familia Perez
        List<Person> people = new List<Person>
        {
            new Person("John","Perez" , 30),
            new Person("Jane","Perez" , 17 ),
            new Person("Jack","Perez" , 11 ),
            new Person("Jill","Perez" , 28 ),
            new Person("Joe","Perez" , 22 )
        };
        const int AdultAge = 18;

        //filtra las personas mientras su edad sea mayor que la variable AdultAge, osea mayor de edad
        List<Person> adults = people.Where(x => x.Age >= AdultAge).ToList<Person>();
        //filtra las personas mientras su edad sea menor que la variable AdultAge, osea menor de edad
        List<Person> children = people.Where(x => x.Age < AdultAge).ToList<Person>();
        //escribe el nombre de todos los adultos
        adults.ForEach(t => { Console.WriteLine($"My Name is: {t.FullName} and I'm an adult, my age is {t.Age} years old"); });
        Console.WriteLine();
        //escribe el nombre de todos los menores de edad
        children.ForEach(t => { Console.WriteLine($"My Name is: {t.FullName} and I'm a children, my age is {t.Age} years old"); });

        var oldestOne = adults.FirstOrDefault(x => x.Age == adults.Max(t => t.Age));
        List<Person> youngerOne = people.Where(x => x.Age == people.OrderBy(t => t.Age).FirstOrDefault().Age).Select(t=>t).ToList();

        Console.WriteLine();
        Console.WriteLine($"My Name is: {oldestOne.FullName} and I'm the oldest person in this group, my age is {oldestOne.Age} years old");
        youngerOne.ForEach(t =>
        {
            Console.WriteLine($"My Name is: {t.FullName} and I'm the younger person in this group, my age is {t.Age} years old");
        });
        Console.Read();
    }
    public class Person
    {
        private string _firstName { get; set; }
        private string _lastName { get; set; }
        public int Age { get; set; }
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="name"></param>
        /// <param name="lastname"></param>
        /// <param name="age"></param>
        public Person(string name, string lastname, int age)
        {
            _firstName = name;
            _lastName = lastname;
            Age = age;
        }
        /// <summary>
        /// Retorna el nombre completo de la persona
        /// </summary>
        public string FullName => _firstName + " " + _lastName;

    }
}


