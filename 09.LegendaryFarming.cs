using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LegendaryFarming
{
    public class StartUp
    {
        public static void Main()
        {
            Dictionary<string, int> materials = new Dictionary<string, int>();
            materials["shards"] = 0;
            materials["fragments"] = 0;
            materials["motes"] = 0;
            string legendaryItem = "";
            bool fl = true;
            while (fl)
            {
                string[] input = Console.ReadLine()
                    .ToLower()
                    .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();
                for (int i = 1; i < input.Length; i += 2)
                {
                    int quantity = int.Parse(input[i - 1]);
                    string material = input[i];
                    if (!materials.ContainsKey(material))
                    {
                        materials.Add(material, quantity);
                    }
                    else
                    {
                        materials[material] += quantity;
                    }
                    if (materials.ContainsKey("shards") && materials["shards"] >= 250)
                    {
                        legendaryItem = "Shadowmourne";
                        materials["shards"] -= 250;
                        fl = false;
                        break;
                    }
                    if (materials.ContainsKey("fragments") && materials["fragments"] >= 250)
                    {
                        legendaryItem = "Valanyr";
                        materials["fragments"] -= 250;
                        fl = false;
                        break;
                    }
                    if (materials.ContainsKey("motes") && materials["motes"] >= 250)
                    {
                        legendaryItem = "Dragonwrath";
                        materials["motes"] -= 250;
                        fl = false;
                        break;
                    }
                }
            }
            Console.WriteLine($"{legendaryItem} obtained!");

            var specialMat = new Dictionary<string, int>();
            var andereMat = new Dictionary<string, int>();
            foreach (var item in materials.Keys)
            {
                if (item == "shards" || item == "fragments" || item == "motes")
                {
                    specialMat.Add(item, materials[item]);
                    // materials.Remove(item);
                }
                else andereMat.Add(item, materials[item]);

            }
            foreach (var item in specialMat.OrderByDescending(x => x.Value).ThenBy(x=>x.Key))
            {
                Console.WriteLine($"{item.Key}: {item.Value}");
            }
           foreach (var item in andereMat.OrderBy(x => x.Key))
           {
               Console.WriteLine($"{item.Key}: {item.Value}");
           }
        }
    }
}
