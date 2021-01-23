using System;
using System.Text;
using System.Linq;

namespace Task01_World_Tour
{
    class Program
    {
        static void Main(string[] args)
        {
            string worldTourStops = Console.ReadLine();

            while (true)
            {
                string[] comand = Console.ReadLine().Split(':', StringSplitOptions.RemoveEmptyEntries).ToArray();

                if(comand[0].ToUpper() == "TRAVEL")
                {
                    break;
                }

                string typeComand = comand[0];

                switch (typeComand.ToUpper())
                {
                    case "ADD STOP":

                        int index = int.Parse(comand[1]);
                        string insertString = comand[2];

                        if(index >= 0 && index < worldTourStops.Length)
                        {
                            worldTourStops = worldTourStops.Insert(index, insertString);
                        }

                        Console.WriteLine(worldTourStops);

                        break;

                    case "REMOVE STOP":

                        int startIndex = int.Parse(comand[1]);
                        int endIndex = int.Parse(comand[2]);
                        
                        if (startIndex >=0 && startIndex <= endIndex && endIndex < worldTourStops.Length)
                        {
                            worldTourStops = worldTourStops.Remove(startIndex, endIndex - startIndex + 1);
                        }

                        Console.WriteLine(worldTourStops);

                        break;

                    case "SWITCH":

                        string oldString = comand[1];
                        string newString = comand[2];

                        if (worldTourStops.Contains(oldString))
                        {
                            int helpIndex = worldTourStops.IndexOf(oldString);
                            worldTourStops = worldTourStops.Remove(helpIndex, oldString.Length);
                            worldTourStops = worldTourStops.Insert(helpIndex, newString);
                            Console.WriteLine(worldTourStops);
                        }

                        //Console.WriteLine(worldTourStops);

                        break;


                    default:
                        break;
                }


            }
            
            Console.WriteLine($"Ready for world tour! Planned stops: {worldTourStops}");
        }
    }
}
