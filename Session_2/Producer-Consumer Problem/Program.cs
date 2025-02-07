internal class Program
{
    private static Queue<int> buffer = new Queue<int>();
    private static int bufferCapacity = 10;
    private static object lockObject = new object();
    private static SemaphoreSlim emptySlots = new SemaphoreSlim(bufferCapacity, bufferCapacity);
    private static SemaphoreSlim filledSlots = new SemaphoreSlim(0, bufferCapacity);
    private static int itemCount = 0;
    private static int maxItem = 20;
    private static void Main(string[] args)
    {
        Task[] producers = new Task[3];
        Task[] consumers = new Task[3];

        for (int i = 0; i < producers.Length; i++)
        {
            int producerId = i + 1;
            producers[i] = Task.Run(() => Producer(producerId));
        }

        for (int i = 0; i < consumers.Length; i++)
        {
            int consumerId = i + 1;
            producers[i] = Task.Run(() => Consumer(consumerId));
        }

        Task.WaitAll(producers);
        Task.WaitAll(consumers);
    }
    static void Producer(int producerId)
    {
        while (true)
        {
            int item = Interlocked.Increment(ref itemCount);

            if (item > maxItem)
                break;

            emptySlots.Wait();

            lock (lockObject)
            {
                buffer.Enqueue(item);
                Console.WriteLine($"Producer {producerId} produced item {item}");
            }

            filledSlots.Release();
        }
    }
    static void Consumer(int consumerId)
    {
        while (true)
        {
            filledSlots.Wait();

            int item;

            lock (lockObject)
            {
                if (buffer.Count == 0 && itemCount >= maxItem)
                    break;

                item = buffer.Dequeue();

                Console.WriteLine($"Consumer {consumerId} consumed item {item}");
            }

            emptySlots.Release();
        }
    }
}