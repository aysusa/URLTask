using System.Diagnostics;

namespace URLTask
{
    internal class Program
    {
   
           

            static async Task Main(string[] args)
            {
                List<string> urls = new List<string>
            {
                  "https://www.google.com",
                  "https://www.microsoft.com",
                  "https://www.github.com",
                  "https://www.stackoverflow.com",
                  "https://www.bing.com",
                  "https://www.reddit.com"
            };


                await GetData(urls);
            }

            static async Task GetData(List<string> urls)
            {
                using (HttpClient client = new HttpClient())
                {
                    Stopwatch stopwatch = new Stopwatch();
                    stopwatch.Start();

                    foreach (var url in urls)
                    {
                        try
                        {
                            HttpResponseMessage response = await client.GetAsync(url);
                            if (response.IsSuccessStatusCode)
                            {
                                Console.WriteLine($"Request to {url} successful");
                            }
                            else
                            {
                                Console.WriteLine($"Request to {url} failed with status code: {response.StatusCode}");
                            }
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine($"Error while requesting {url}: {e.Message}");
                        }
                    }

                    stopwatch.Stop();
                    Console.WriteLine($"\nTotal time taken: {stopwatch.Elapsed.TotalSeconds:F2} seconds");
                }
            }
        
    }
}

