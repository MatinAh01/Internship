using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace TPL
{
    public class CachedWebScraper
    {
        private static readonly HttpClient _httpClient = new(); // avoid socket exhaustion and allows connection pooling
        private static readonly ConcurrentDictionary<string, string> _cache = new(); // thread safe catching

        public static async Task DownloadAsync()
        {
            var urls = new string[]
            {
                "https://www.githubstatus.com/",
                "https://example.com",
                "https://example.net",
            };

            var stopwatch = Stopwatch.StartNew();

            await Parallel.ForEachAsync(urls, async (url, CancellationToken) =>
                {
                    string content = await GetContentAsync(url);
                    Console.WriteLine($"Content Length ({url}): {content.Length}");
                }
            );

            stopwatch.Stop();
            Console.WriteLine($"Execution Time: {stopwatch.ElapsedMilliseconds} ms");
        }
        public static async Task<string> GetContentAsync(string url)
        {
            if (_cache.TryGetValue(url, out var cachedContent))
            {
                Console.WriteLine($"Cache hit: {url}");
                return cachedContent;
            }

            Console.WriteLine($"Downloading: {url}");
            var content = await _httpClient.GetStringAsync(url);
            _cache.TryAdd(url, content);
            return content;
        }
    }
}