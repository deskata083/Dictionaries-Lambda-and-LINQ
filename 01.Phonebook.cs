using System;
using System.Collections.Generic;
using System.Linq;

namespace Phonebook
{
    public class StartUp
    {
        public static void Main()
        {
            Dictionary<string, string> phonebook = new Dictionary<string, string>();
            string input = Console.ReadLine();

            while (input != "END")
            {
                string[] phonePar = input.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                string command = phonePar[0];
                if (command == "A")
                {
                    string key = phonePar[1];
                    string number = phonePar[2];
                    //phonebook.Add(key, number);
                    phonebook[key] = number;
                }
                else
                {
                    string key = phonePar[1];
                    if (phonebook.ContainsKey(key))
                    {
                        Console.WriteLine($"{key} -> {phonebook[key]}");
                    }
                    else
                    {
                        Console.WriteLine($"Contact {key} does not exist.");
                    }
                }
                input = Console.ReadLine();
            }
        }
    }
}
