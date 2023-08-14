using System;
using System.Net;
using System.Text;

class Program
{
    static void Main()
    {
        StartListener();
    }

    static void StartListener()
    {
        using (HttpListener listener = new HttpListener())
        {
            listener.Prefixes.Add("http://localhost:8888/");
            listener.Start();
            Console.WriteLine("Listener started. Waiting for requests...");

            while (true)
            {
                HttpListenerContext context = listener.GetContext();
                HandleRequest(context);
            }
        }
    }

    static void HandleRequest(HttpListenerContext context)
    {
        string resourcePath = context.Request.Url.LocalPath.Trim('/');
        string responseText = "";

        if (resourcePath == "MyName")
        {
            responseText = GetMyName();
        }
        else if (resourcePath == "Information")
        {
            responseText = "Informational response";
            context.Response.StatusCode = 200; // Using a valid status code for demonstration
        }
        else if (resourcePath == "Success")
        {
            responseText = "Success response";
            context.Response.StatusCode = 200;
        }
        else if (resourcePath == "Redirection")
        {
            responseText = "Redirection response";
            context.Response.StatusCode = 302; // Using a valid redirection status code
            context.Response.Headers.Add("Location", "http://example.com");
        }
        else if (resourcePath == "ClientError")
        {
            responseText = "Client error response";
            context.Response.StatusCode = 400;
        }
        else if (resourcePath == "ServerError")
        {
            responseText = "Server error response";
            context.Response.StatusCode = 500;
        }
        else if (resourcePath == "MyNameByHeader")
        {
            responseText = GetMyName();
            context.Response.Headers.Add("X-MyName", "Your Name");
        }
        else if (resourcePath == "MyNameByCookies")
        {
            responseText = GetMyName();
            context.Response.Cookies.Add(new Cookie("MyName", "Your Name"));
        }

        byte[] buffer = Encoding.UTF8.GetBytes(responseText);
        context.Response.OutputStream.Write(buffer, 0, buffer.Length);
        context.Response.Close();
    }

    static string GetMyName()
    {
        return "Your Name";
    }
}
