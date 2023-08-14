using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NimGame
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "Nim Game";

            int totalMatches = 7; // Total number of matches on the table

            while (totalMatches > 0)
            {
                // Display the current state
                Console.WriteLine($"Remaining matches: {totalMatches}");

                // Human player's turn
                int humanChoice = GetValidInput(1, 3, "How many matches do you want to pick?");
                totalMatches -= humanChoice;

                if (totalMatches <= 0)
                {
                    Console.WriteLine("You picked the last match. Computer wins!");
                    break;
                }

                // Display the current state
                Console.WriteLine($"Remaining matches: {totalMatches}");

                // Computer player's turn
                int computerChoice = Math.Min(3, totalMatches);
                totalMatches -= computerChoice;

                if (totalMatches <= 0)
                {
                    Console.WriteLine("Computer picked the last match. You win!");
                    break;
                }
            }

            Console.WriteLine("\nPress any key to exit...");
            Console.ReadKey();
        }

        static int GetValidInput(int min, int max, string prompt)
        {
            int choice;
            while (true)
            {
                Console.Write($"{prompt} ({min}-{max}): ");
                if (int.TryParse(Console.ReadLine(), out choice) && choice >= min && choice <= max)
                {
                    return choice;
                }
                Console.WriteLine($"Invalid input. Please enter a number between {min} and {max}.");
            }
        }
    }
}
