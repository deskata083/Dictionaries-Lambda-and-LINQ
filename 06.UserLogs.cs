using System;
using System.Linq;
using System.Collections.Generic;

namespace ConsoleApp1
{
    class Program
    {
        static void Main()
        {
            IDictionary<string, string> users = new SortedDictionary<string, string>();
            int p;
            while (true)
            {
                string msg = Console.ReadLine();
                if (msg == "end") break;
                msg = msg.Remove(0, 3);
                p = msg.IndexOf(" mess");
                string Ip = msg.Remove(p, msg.Length - p);
                p = msg.IndexOf("er=") + 3;
                msg = msg.Remove(0, p);

                if (users.ContainsKey(msg))
                {
                    users[msg] += " " + Ip;
                }
                else
                {
                    users[msg] = Ip;
                }
            }
            foreach (var item in users.Keys)
            {
                Console.WriteLine("{0}: ", item);
                var adr = users[item].Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToList<string>();
                Dictionary<string, int> ips = new Dictionary<string, int>();

                foreach (var itm in adr)
                {
                    if (ips.Keys.Contains(itm))
                    {
                        ips[itm]++;
                    }
                    else
                    {
                        ips[itm] = 1;
                    }
                }
                adr.Clear();

                foreach (var itms in ips.Keys)
                {
                    adr.Add(itms + " => " + ips[itms]);
                }
                Console.WriteLine($"{string.Join(", ", adr)}.");

            }
        }
    }

}


