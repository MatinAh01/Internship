using System.Collections.Concurrent;

internal class Program
{
    private static void Main(string[] args)
    {
        ConcurrentDictionary();
    }
    public static void ConcurrentDictionary()
    {
        ConcurrentDictionary<int, string> concurrentDict = new ConcurrentDictionary<int, string>();

        Parallel.For(0, 10, i =>
        {
            concurrentDict.TryAdd(i, $"Value {i}");
        });

        foreach (var kvp in concurrentDict)
        {
            Console.WriteLine($"Key: {kvp.Key}, Value: {kvp.Value}");
        }
    }
    public static void ConcurrentQueue()
    {
        ConcurrentQueue<int> concurrentQueue = new ConcurrentQueue<int>();

        Parallel.For(0, 10, i =>
        {
            concurrentQueue.Enqueue(i);
        });

        Parallel.ForEach(concurrentQueue, item =>
        {
            Console.WriteLine($"Dequeued: {item}");
        });
    }
    public static void ConcurrentBag()
    {
         ConcurrentBag<int> concurrentBag = new ConcurrentBag<int>();

        Parallel.For(0, 10, i =>
        {
            concurrentBag.Add(i);
        });

        Parallel.ForEach(concurrentBag, item =>
        {
            Console.WriteLine($"Processed: {item}");
        });
    }
}