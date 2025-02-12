internal class Program
{
    class MyClass
    {
        public int[] LargeArray = new int[1000000]; // Large object in heap
        ~MyClass() // Finalizer (Destructor)
        {
            Console.WriteLine("MyClass object is being finalized!");
        }
    }

    static void Main()
    {
        Console.WriteLine("Creating objects...");
        for (int i = 0; i < 5; i++)
        {
            MyClass obj = new MyClass(); // Creating objects
        }

        Console.WriteLine("Forcing Garbage Collection...");
        GC.Collect(); // Force Garbage Collection
        GC.WaitForPendingFinalizers(); // Ensure finalizers have run

        Console.WriteLine("Garbage Collection completed.");
    }
}
