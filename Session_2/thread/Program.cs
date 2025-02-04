internal class Program
{
    private static void Main(string[] args)
    {
        Thread t = new(WriteT);
        t.Start();

        for (int i = 0; i < 100; i++)
        {
            Console.Write("M ");
        }
    }
    public static void WriteT()
    {
        for (int i = 0; i < 100; i++)
        {
            Console.Write("T ");
        }
    }
}
