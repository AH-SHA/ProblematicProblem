using System;
using System.Collections.Generic;
using System.Threading;
using System.Linq;


namespace ProblematicProblem
{
    class Program
    {
        static bool cont = true;
        static List<string> activities = new List<string>() { "Movies", "Paintball", "Bowling", "Lazer Tag", "LAN Party", "Hiking", "Axe Throwing", "Wine Tasting" };
        static void Main(string[] args)
        {
            Random rng = new Random();

            Console.Write("Hello, welcome to the Random Activity Generator! \nWould you like to generate a random activity? true/false: ");
            bool cont = bool.Parse(Console.ReadLine().ToLower());

            if (cont != true)
            {
                Console.WriteLine();
                Console.WriteLine("GAME OVER");
               
            }
            Console.WriteLine();

            while(cont == true)
            {
                Console.Write("We are going to need your information first! What is your name? ");
                string userName = Console.ReadLine();
                Console.WriteLine();

                Console.Write("What is your age? ");
                int userAge = int.Parse(Console.ReadLine());

                Console.WriteLine();
                Console.Write("Would you like to see the current list of activities? true/false: ");

                bool seeList = bool.Parse(Console.ReadLine().ToLower());

                if (seeList == true)                       
                {
                    foreach (string activity in activities)
                    {
                        Console.Write($"{activity} ");
                        Thread.Sleep(250);
                    }

                    Console.WriteLine();
                    Console.Write("Would you like to add any activities before we generate one? true/false: ");
                    bool addToList = bool.Parse(Console.ReadLine());
                    Console.WriteLine();

                    while (addToList == true)                
                    {
                        Console.Write("What would you like to add? ");
                        string userAddition = Console.ReadLine();
                        activities.Add(userAddition);

                        foreach (string activity in activities)
                        {
                            Console.Write($"{activity} ");
                            Thread.Sleep(250);
                        }

                        Console.WriteLine();
                        Console.WriteLine("Would you like to add more? true/false: ");
                        addToList = bool.Parse(Console.ReadLine().ToLower());
                    }

                    
                }

                while (cont)
                {
                    Console.Write("Connecting to the database");

                    for (int i = 0; i < 10; i++)
                    {
                        Console.Write(". ");
                        Thread.Sleep(500);
                    }
                    Console.WriteLine();
                    Console.Write("Choosing your random activity");

                    for (int i = 0; i < 9; i++)
                    {
                        Console.Write(". ");
                        Thread.Sleep(500);
                    }

                    Console.WriteLine();
                    int randomNumber = rng.Next(activities.Count);
                    string randomActivity = activities[randomNumber];

                    if (userAge < 21 && randomActivity == "Wine Tasting")
                    {
                        Console.WriteLine($"Oh no! Looks like you are too young to do {randomActivity}");
                        Console.WriteLine("Pick something else!");

                        activities.Remove(randomActivity);

                        randomNumber = rng.Next(activities.Count);
                        randomActivity = activities[randomNumber];
                    }
                    Console.Write($"Ah got it! {userName}, your random activity is: {randomActivity}! Is this ok or do you want to grab another activity? true/false: ");
                    Console.WriteLine();
                    cont = bool.Parse(Console.ReadLine().ToLower());
                    if (cont == false)
                    {
                        Console.WriteLine("GAME OVER");
                    }
                }

            }
        }
    }
}