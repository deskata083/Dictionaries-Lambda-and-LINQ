using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FixEmails
{
    public class StartUp
    {
        public static void Main()
        {
            Dictionary<string, string> persons = new Dictionary<string, string>();
            string name = Console.ReadLine();
            string email;

            while (name != "stop" && name != "Stop")
            {
                email = Console.ReadLine();
                string emailDomain = email.Substring(email.Length - 2).ToLower();
                persons.Add(name, email);
                if (emailDomain.EndsWith("us") || email.EndsWith("uk"))
                {
                    persons.Remove(name);
                }
                name = Console.ReadLine();
            }
            foreach (string person in persons.Keys)
            {
                Console.WriteLine($"{person} -> {persons[person]}");
            }
        }
    }
}