using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMinerTask
{
    public class StartUp
    {
        public static void Main()
        {
            Dictionary<string, int> resourse = new Dictionary<string, int>();
            string material = Console.ReadLine();
            while (material != "stop")
            {
                int kg = int.Parse(Console.ReadLine());
                if (resourse.ContainsKey(material))
                {
                    resourse[material] += kg;
                }
                else
                {
                    resourse.Add(material, kg);
                }
                material = Console.ReadLine();
            }
            foreach (var item in resourse.Keys)
            {
                Console.WriteLine("{0} -> {1}", item, resourse[item]);
            }
        }
    }
}
