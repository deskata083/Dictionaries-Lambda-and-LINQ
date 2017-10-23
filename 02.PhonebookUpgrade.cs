using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhonebookUpgrade
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
                string key;
                string number;
                if (command == "A")
                {
                     key = phonePar[1];
                     number = phonePar[2];
                    //phonebook.Add(key, number);
                    phonebook[key] = number;
                }
                else if(command == "S")
                {
                     key = phonePar[1];
                    if (phonebook.ContainsKey(key))
                    {
                        Console.WriteLine($"{key} -> {phonebook[key]}");
                    }
                    else
                    {
                        Console.WriteLine($"Contact {key} does not exist.");
                    }
                }
                else if (command == "ListAll")
                {
                   
                    foreach (var item in phonebook.Keys.OrderBy(k => k))
                    {
                        Console.WriteLine($"{item} -> {phonebook[item]}");
                    }
                    
                }
                input = Console.ReadLine();
            }
        }
    }
}
