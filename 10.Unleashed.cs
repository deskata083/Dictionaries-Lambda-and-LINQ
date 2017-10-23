using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Unleash
{
    public class SatrUp
    {
        public static void Main()
        {
            string pattern = @"(.*?) @(.*?) (\d+) (\d+)";

            Dictionary<string, Dictionary<string, long>> singers
                   = new Dictionary<string, Dictionary<string, long>>();
            string input = Console.ReadLine();

            while (input != "End")
            {
                if (!Regex.IsMatch(input, pattern))
                {
                    input = Console.ReadLine();
                    continue;
                }


                string[] singerPar = input.Split(new char[] { '@' }, StringSplitOptions.RemoveEmptyEntries);
                if (singerPar.Length == 2)
                {
                    string[] singerArr = singerPar[0].Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                    if (singerArr.Length > 0 && singerArr.Length < 4)
                    {
                        string singerName = "";
                        for (long i = 0; i < singerArr.Length; i++)
                        {
                            singerName += singerArr[i] + " ";
                        }
                        string[] parameter = singerPar[1].Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                        if (parameter.Length > 2 && parameter.Length < 6)
                        {
                            long ticketPrice;
                            long ticketCount;
                            if (long.TryParse(parameter[parameter.Length - 2], out ticketPrice) &&
                                long.TryParse(parameter[parameter.Length - 1], out ticketCount))
                            {
                                string place = "";
                                for (long i = 0; i < parameter.Length - 2; i++)
                                {
                                    place += parameter[i] + " ";
                                }
                                long money = ticketCount * ticketPrice;

                                if (!singers.ContainsKey(place))
                                {
                                    singers.Add(place, new Dictionary<string, long>());
                                    singers[place].Add(singerName, money);
                                }
                                else
                                {
                                    if (!singers[place].ContainsKey(singerName))
                                    {
                                        singers[place].Add(singerName, money);
                                    }
                                    else
                                    {
                                        singers[place][singerName] += money;
                                    }
                                }
                            }
                        }
                    }

                }
                input = Console.ReadLine();
            }
            foreach (var item in singers.Keys)
            {
                Console.WriteLine(item);
                foreach (var itm in singers[item].OrderByDescending(x => x.Value))
                {
                    Console.WriteLine($"#  {itm.Key}-> {itm.Value}");
                }
            }
        }
    }
}

