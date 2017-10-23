using System;
using System.Linq;
using System.Collections.Generic;

namespace ConsoleApp1
{
    class Program
    {
        static void Main()
        {
            Dictionary<string, string> igrachi = new Dictionary<string, string>();
            string[] person;
            while (true)
            {
                person = Console.ReadLine().Split(new char[] { ':' }, StringSplitOptions.RemoveEmptyEntries).ToArray<string>();
                if (person[0] == "JOKER") break;
                if (igrachi.ContainsKey(person[0]))
                {
                    igrachi[person[0]] = igrachi[person[0]] + ",  " + person[1];
                }
                else
                {
                    igrachi.Add(person[0], person[1]);
                }
            }
            foreach (var item in igrachi.Keys)
            {
                Console.WriteLine("{0}: {1}", item, val(igrachi[item]));
            }
            //-----------------------------------------------------------
            int val(string s)
            {
                string kart = "234567891JQKA";
                string vid = "CDHS";
                var arr = s.Split(new char[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries).ToList<string>();
                int i = 0; while (i < arr.Count - 1)
                {
                    int j = i + 1; while (j < arr.Count)
                    {
                        if (arr[i] == arr[j]) arr.RemoveAt(j); else j++;
                    }
                    i++;
                }
                int sum = 0;
                foreach (var item in arr)
                {
                    char type = item[item.Length - 1];
                    item.Remove(item.Length - 1, 1);
                    int k = kart.IndexOf(item[0]) + 2;
                    int m = vid.IndexOf(type) + 1;
                    sum = sum + k * m;
                }
                return sum;
            }
        }

    }
}

