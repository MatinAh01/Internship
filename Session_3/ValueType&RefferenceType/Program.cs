internal class Program
{
    private static void Main(string[] args)
    {
        // value type behavior
        int a = 10;
        int b = a; // Copy of 'a' is assigned to 'b'
        b = 20;

        Console.WriteLine(a); // 10 (unchanged)
        Console.WriteLine(b); // 20




        // refference type behavior
        Person person1 = new Person { Name = "Matin" };
        Person person2 = person1; // person2 now points to the same memory location as person1

        person2.Name = "Amirhossein";

        Console.WriteLine(person1.Name); // Amirhossein (Both point to the same memory location)
        Console.WriteLine(person2.Name); // Amirhossein




        // Value Type in Methods
        void ChangeValue(int x)
        {
            x = 20; // Only modifies the local copy
        }

        int num = 10;
        ChangeValue(num);
        Console.WriteLine(num); // 10 (unchanged)





        // Reference Type in Methods
        void ChangeReference(Person p)
        {
            p.Name = "Updated";
        }

        Person person = new Person { Name = "main" };
        ChangeReference(person);
        Console.WriteLine(person.Name); // Updated (Changed!)

    }
    public class Person
    {
        public string Name { get; set; } = string.Empty;
    }


}