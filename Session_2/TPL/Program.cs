using System.Threading.Tasks;
using TPL;

internal class Program
{
    private static async Task Main(string[] args)
    {
        Console.WriteLine("First run (No cache):");
        await CachedWebScraper.DownloadAsync();

        Console.WriteLine("\nSecond run (Uses cache):");
        await CachedWebScraper.DownloadAsync();
    }

    
}