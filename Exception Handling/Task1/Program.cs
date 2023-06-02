using System;

namespace Task1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            PrintFirstCharacterOfLines();
        }

        static void PrintFirstCharacterOfLines()
        {
            try
            {
                Console.WriteLine("Enter input lines:");
                string inputLine;
                while (true)
                {
                    inputLine = Console.ReadLine();
                    if (string.IsNullOrEmpty(inputLine))
                    {
                        throw new Exception("Input cannot be empty.");
                    }

                    char firstCharacter = inputLine[0];
                    Console.WriteLine("First character: " + firstCharacter);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}