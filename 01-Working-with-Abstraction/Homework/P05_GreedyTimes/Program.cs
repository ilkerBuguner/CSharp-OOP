using System;
using System.Collections.Generic;
using System.Linq;

namespace P05_GreedyTimes
{

    public class Potato
    {
        static void Main(string[] args)
        {
            long input = long.Parse(Console.ReadLine());
            string[] safe = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            var bag = new Dictionary<string, Dictionary<string, long>>();
            long gold = 0;
            long gems = 0;
            long money = 0;

            for (int i = 0; i < safe.Length; i += 2)
            {
                string name = safe[i];
                long amount = long.Parse(safe[i + 1]);

                string treasure = string.Empty;

                if (name.Length == 3)
                {
                    treasure = "Cash";
                    money += amount;
                    if (!bag.ContainsKey(treasure))
                    {
                        if (bag.ContainsKey("Gem"))
                        {
                            if (amount > bag["Gem"].Values.Sum())
                            {
                                continue;
                            }
                        }
                        else
                        {
                            continue;
                        }
                    }
                    else if (bag[treasure].Values.Sum() + amount > bag["Gem"].Values.Sum())
                    {
                        continue;
                    }
                }
                else if (name.ToLower().EndsWith("gem"))
                {
                    treasure = "Gem";
                    gems += amount;
                    if (!bag.ContainsKey(treasure))
                    {
                        if (bag.ContainsKey("Gold"))
                        {
                            if (amount > bag["Gold"].Values.Sum())
                            {
                                continue;
                            }
                        }
                        else
                        {
                            continue;
                        }
                    }
                    else if (bag[treasure].Values.Sum() + amount > bag["Gold"].Values.Sum())
                    {
                        continue;
                    }
                }
                else if (name.ToLower() == "gold")
                {
                    treasure = "Gold";
                    gold += amount;
                }

                if (treasure == "")
                {
                    continue;
                }
                else if (input < bag.Values.Select(x => x.Values.Sum()).Sum() + amount)
                {
                    continue;
                }

                

                if (!bag.ContainsKey(treasure))
                {
                    bag[treasure] = new Dictionary<string, long>();
                }

                if (!bag[treasure].ContainsKey(name))
                {
                    bag[treasure][name] = 0;
                }

                bag[treasure][name] += amount;
            }

            foreach (var x in bag)
            {
                Console.WriteLine($"<{x.Key}> ${x.Value.Values.Sum()}");
                foreach (var item2 in x.Value.OrderByDescending(y => y.Key).ThenBy(y => y.Value))
                {
                    Console.WriteLine($"##{item2.Key} - {item2.Value}");
                }
            }
        }
    }
}