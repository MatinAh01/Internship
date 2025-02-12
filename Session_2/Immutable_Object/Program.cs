internal class Program
{
    private static void Main(string[] args)
    {
        var person = new Person() { Name = "Matin", Age = 23 };
        // person.Age = 25; Compilation error (immutable)



        var car = new Car("Tesla", 2022);
        // car.Model = "BMW"; Compilation error (readonly)



        var emp1 = new Employee("John", 35);
        // emp1.Age = 39; Compilation error (immutable)
    }
    public class Person
    {
        public string Name { get; init; } = string.Empty;
        public int Age { get; init; }
    }
    public class Car
    {
        public readonly string Model;
        public readonly int Year;

        public Car(string model, int year)
        {
            Model = model;
            Year = year;
        }
    }
    public record Employee(string Name, int Age);
}
