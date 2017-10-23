using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogsAggregator
{
    public class StartUp
    {
        public static void Main()
        {
            SortedDictionary<string, SortedDictionary<string, int>> users =
                new SortedDictionary<string, SortedDictionary<string, int>>();

            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                string input = Console.ReadLine();
                string[] param = input.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                string ip = param[0];
                string name = param[1];
                int duration = int.Parse(param[2]);

                if (!users.Keys.Contains(name))
                {
                    users.Add(name, new SortedDictionary<string, int>());
                    users[name].Add(ip, duration);
                }
                else
                {
                    if (!users[name].ContainsKey(ip))
                    {
                        users[name].Add(ip, duration);
                    }
                    else
                    {
                        users[name][ip] += duration;
                    }
                }
            }
            var ipAddress = new List<string>();
            foreach (var user in users)
            {
                var totalDurationOfUser = users[user.Key].Values.Sum();
                ipAddress = user.Value.Keys.ToList();
                Console.WriteLine($"{user.Key}: {totalDurationOfUser} [{string.Join(", ", ipAddress)}]");
            }
        }
    }
}
