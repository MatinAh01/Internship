using System.Diagnostics;
using System.Threading.Tasks;

internal class Program
{
    private static readonly HttpClient httpClient = new HttpClient();
    private static readonly SemaphoreSlim semaphoreSlim = new SemaphoreSlim(2);
    private static async Task Main(string[] args)
    {
        var stopwatch = Stopwatch.StartNew();
        await DownloadAsync();
        stopwatch.Stop();
        Console.WriteLine($"Total Execution Time: {stopwatch.ElapsedMilliseconds} ms");
    }
    public static async Task DownloadAsync()
    {
        // HttpClient httpClient = new HttpClient();
        // string url1 = "https://www.githubstatus.com/";
        // string url2 = "https://example.com";
        // string url3 = "https://example.net";

        // var contents = new string[3];
        // contents[0] = await httpClient.GetStringAsync(url1);
        // contents[1] = await httpClient.GetStringAsync(url2);
        // contents[2] = await httpClient.GetStringAsync(url3);

        // await Task.WhenAll();

        // foreach (var item in contents)
        // {
        //     Console.WriteLine(item.Length);
        // }



        var urls = new string[]
        {
            "https://www.githubstatus.com/",
            "https://example.com",
            "https://example.net"
        };

        var Tasks = urls.Select(async url =>
        {
            await semaphoreSlim.WaitAsync();
            try
            {
                return await httpClient.GetStringAsync(url);
            }
            catch (Exception ex)
            {

                Console.WriteLine($"Failed: {url}, Error: {ex.Message}");
                return string.Empty;
            }
            finally
            {
                await Task.Delay(3000);
                semaphoreSlim.Release();
            }
        }).ToArray();

        var contents = await Task.WhenAll(Tasks);

        for (int i = 0; i < contents.Length; i++)
        {
            Console.WriteLine($"URL {i + 1}: {contents[i].Length} bytes");
        }
    }
}