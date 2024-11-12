using System;

namespace GuessNumber
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("The game Guess the number that the computer has guessed");
            Console.WriteLine("MENU");
            Console.WriteLine("1. PLAY\n2. DIFFICULT\n");

            int maxNumber = 100; 

            while (true)
            {
                Console.Write("Choose an option: ");
                bool isValidInput = Int32.TryParse(Console.ReadLine(), out int menuChoice);

                if (isValidInput && menuChoice == 1)
                {
                    PlayGame(maxNumber);
                }
                else if (isValidInput && menuChoice == 2)
                {
                    maxNumber = SetDifficulty();
                }
                else
                {
                    Console.WriteLine("Invalid choice. Please select 1 or 2.");
                }
            }
        }

        static void PlayGame(int maxNumber)
        {
            Random random = new Random();
            int targetNumber = random.Next(1, maxNumber + 1); 
            int attempts = 0;

            Console.WriteLine($"I have chosen a number between 1 and {maxNumber}. Try to guess it!");

            while (true)
            {
                Console.Write("Enter your guess: ");
                bool isNumber = Int32.TryParse(Console.ReadLine(), out int playerGuess);

                if (!isNumber)
                {
                    Console.WriteLine("Please enter a valid number.");
                    continue;
                }

                attempts++;

                if (playerGuess < targetNumber)
                {
                    Console.WriteLine("Too low!");
                }
                else if (playerGuess > targetNumber)
                {
                    Console.WriteLine("Too high!");
                }
                else
                {
                    Console.WriteLine($"Congratulations! You guessed the number in {attempts} attempts.");
                    break;
                }
            }
        }

        static int SetDifficulty()
        {
            Console.WriteLine("Choose difficulty level:");
            Console.WriteLine("1. Easy (1-50)");
            Console.WriteLine("2. Medium (1-100)");
            Console.WriteLine("3. Hard (1-200)");

            while (true)
            {
                Console.Write("Enter the difficulty level: ");
                bool isValidDifficulty = Int32.TryParse(Console.ReadLine(), out int difficulty);

                switch (difficulty)
                {
                    case 1:
                        Console.WriteLine("Easy mode selected.");
                        return 50;
                    case 2:
                        Console.WriteLine("Medium mode selected.");
                        return 100;
                    case 3:
                        Console.WriteLine("Hard mode selected.");
                        return 200;
                    default:
                        Console.WriteLine("Invalid choice. Please choose 1, 2, or 3.");
                        break;
                }
            }
        }
    }
}
    