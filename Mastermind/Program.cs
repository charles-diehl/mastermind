using System;
using System.Linq;

namespace Mastermind
{
    class Program
    {
        static void Main(string[] args)
        {
            bool correctAnswer = false;
            int triesRemaining = 10;

            char[] answer = GenerateAnswer();

            Console.WriteLine("Please enter a guess. Valid guesses are 4 digits, where each digit is between 1 and 6.\nInvalid guesses will be treated as an incorrect guess.\n\n");

            while (!correctAnswer && triesRemaining > 0)
            {
                Console.WriteLine($"Please enter a guess. You have {triesRemaining} tries remaining");
                var guess = Console.ReadLine();
                correctAnswer = CheckAnswer(guess, answer);
                if (!correctAnswer)
                {
                    Console.WriteLine();//writing a line to make it look less junky
                    triesRemaining--;
                }
                    
            }
            if (correctAnswer)
            {
                if (triesRemaining == 10)
                {
                    Console.WriteLine("You did well, so well you completed the task with 0 incorrect guesses.\nI'm pretty sure you cheated, and I'm not even mad.");
                }
                else
                {
                    Console.WriteLine($"You did well, you completed the task with {triesRemaining} tries remaining. Excellent work!");
                }
            }
            else
            {
                Console.WriteLine($"Better luck next time. The correct answer was {new string(answer)}\n\n\n");
            }
        }

        static char[] GenerateAnswer()
        {
            char[] answer = new char[4];
            Random rnd = new Random();
            for (int i = 0; i < 4; i++)
            {
                answer[i] = rnd.Next(1, 6).ToString()[0];
                Console.Write(answer[i]);
            }
                
            Console.WriteLine();
            return answer;
        }

        static bool CheckAnswer(string guess, char[] answer)
        {
            bool match = true;
            //all guesses should be 4 digits, no extra minus characters for putting in 6 characters on turn one
            if (guess.Length != 4)
            {
                Console.WriteLine("Invalid Guess, please input a 4 digit number");
                return false;
            }
            
            //I don't know why, but if they put in letters, they deserve to lose a guess.
            try
            {
                int.Parse(guess);
            }
            catch
            {
                Console.WriteLine("Invalid Guess, please input a 4 digit number");
                return false;
            }

            char[] charGuess = guess.ToCharArray();
            for( int i = 0; i < 4; i++)
            {
                //got a match
                if (charGuess[i] == answer[i])
                {
                    Console.Write("+");
                }
                else
                {
                    //it's not a match, but we have to figure out how bad a guess it was
                    match = false;

                    //matches somewhere, just not where they guessed
                    if (answer.Contains(charGuess[i]))
                    {
                        Console.Write("-");
                    }

                    //no dice
                    else
                    {
                        Console.Write(" ");
                    }
                }
            }
            Console.WriteLine();
            return match;
        }
    }
}
