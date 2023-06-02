using System;

namespace GreetingLibrary
{
    public static class Greeting
    {
        public static string SayHello(string username)
        {
            string currentTime = DateTime.Now.ToString("HH:mm:ss");
            return $"{currentTime} Hello, {username}!";
        }
    }
}
