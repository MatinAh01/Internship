using thread;

internal class Program
{
    public static ThreadService _threadService { get; set; } = new ThreadService();
    public static void Main(string[] args)
    {
       // _threadService.PtintNumber();

       _threadService.ThreadSynchronization();
    }
}
