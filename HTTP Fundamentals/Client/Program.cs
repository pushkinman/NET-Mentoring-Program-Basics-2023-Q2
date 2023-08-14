using System;
using System.Net.Http;
using System.Threading.Tasks;

class Program
{
    static async Task Main()
    {
        using (HttpClient client = new HttpClient())
        {
            // Task 1: URL
            string myNameResponse = await client.GetStringAsync("http://localhost:8888/MyName/");
            Console.WriteLine(myNameResponse);

            // Task 2: HTTP status messages
            await MakeRequestAndPrintStatus(client, "http://localhost:8888/Information/");
            await MakeRequestAndPrintStatus(client, "http://localhost:8888/Success/");
            await MakeRequestAndPrintStatus(client, "http://localhost:8888/Redirection/");
            await MakeRequestAndPrintStatus(client, "http://localhost:8888/ClientError/");
            await MakeRequestAndPrintStatus(client, "http://localhost:8888/ServerError/");

            // Task 3: Header
            HttpResponseMessage myNameByHeaderResponse = await client.GetAsync("http://localhost:8888/MyNameByHeader/");
            if (myNameByHeaderResponse.Headers.TryGetValues("X-MyName", out var headerValues))
            {
                foreach (var value in headerValues)
                {
                    Console.WriteLine("X-MyName Header Value: " + value);
                }
            }

            // Task 4: Cookies
            HttpResponseMessage myNameByCookiesResponse = await client.GetAsync("http://localhost:8888/MyNameByCookies/");
            if (myNameByCookiesResponse.Headers.TryGetValues("Set-Cookie", out var cookieValues))
            {
                foreach (var value in cookieValues)
                {
                    if (value.StartsWith("MyName="))
                    {
                        Console.WriteLine("MyName Cookie Value: " + value);
                    }
                }
            }
        }
    }

    static async Task MakeRequestAndPrintStatus(HttpClient client, string url)
    {
        HttpResponseMessage response = await client.GetAsync(url);
        Console.WriteLine($"{url} - Status Code: {(int)response.StatusCode} {response.ReasonPhrase}");
    }
}
