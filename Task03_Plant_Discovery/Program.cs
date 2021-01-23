using System;
using System.Linq;
using System.Collections.Generic;

namespace Task03_Plant_Discovery
{
    class Program
    {
        static void Main(string[] args)
        {
            int numbers = int.Parse(Console.ReadLine());

            Dictionary<string, List<double>> plantsInfo = new Dictionary<string, List<double>>();

            for (int i = 1; i <= numbers; i++)
            {
                string[] nextInfoLine = Console.ReadLine().Split("<->", StringSplitOptions.RemoveEmptyEntries).ToArray();

                string plant = nextInfoLine[0];
                double rarity = double.Parse(nextInfoLine[1]);
                
                if(plantsInfo.ContainsKey(plant))
                {
                    plantsInfo[plant][0] = rarity;
                }
                else
                {
                    plantsInfo.Add(plant, new List<double> { rarity, 0 });
                }
            }

            while (true)
            {
                string[] comand = Console.ReadLine().Split(new string[] { ": ", " - " }, StringSplitOptions.RemoveEmptyEntries).ToArray();

                if(comand[0].ToUpper() == "EXHIBITION")
                {
                    break;
                }

                string typeComand = comand[0].ToUpper();
                string plant = comand[1];

                switch (typeComand)
                {
                    case "RATE":
                        
                        double rating = double.Parse(comand[2]);
                        
                        if(plantsInfo.ContainsKey(plant))
                        {
                            plantsInfo[plant].Add(rating);

                            int helpVarNumberOfRates = plantsInfo[plant].Count;
                            double averigeRate = 0;
                            double sumRate = 0;

                            for (int i = 2; i <= helpVarNumberOfRates - 1; i++)
                            {
                                sumRate += plantsInfo[plant][i]; 
                            }

                            averigeRate = sumRate / (helpVarNumberOfRates - 2);

                            plantsInfo[plant][1] = averigeRate;
                        }
                        else
                        {
                            Console.WriteLine("error");
                        }

                        break;

                    case "UPDATE":

                        double newParity = double.Parse(comand[2]);

                        if (plantsInfo.ContainsKey(plant))
                        {
                            plantsInfo[plant][0] = newParity;
                        }
                        else
                        {
                            Console.WriteLine("error");
                        }

                        break;

                    case "RESET":

                        if (plantsInfo.ContainsKey(plant))
                        {
                            int helpVarLenghOfListWithOutRarity = plantsInfo[plant].Count();

                            for (int i = 2; i <= helpVarLenghOfListWithOutRarity - 1; i++)
                            {
                                plantsInfo[plant].Remove(i);
                            }

                            plantsInfo[plant][1] = 0;
                        }
                        else
                        {
                            Console.WriteLine("error");
                        }

                        break;
                    
                    default:
                        break;
                }

            }

            Console.WriteLine("Plants for the exhibition:");
            foreach (var element in plantsInfo.OrderByDescending(x => x.Value[0]).ThenByDescending(y => y.Value[1]))
            {
                Console.WriteLine($"- {element.Key}; Rarity: {element.Value[0]}; Rating: {element.Value[1]:f2}");

            }
        }
    }
}
