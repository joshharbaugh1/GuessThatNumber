using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuessThatNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            //call the guess number function
            GuessNumber();
            Console.ReadKey();
        }
        
        static void GuessNumber()
        {
            //create random number generator and variables
            Random rng = new Random();
            int magicNumber = rng.Next(1,101);
            int totalGuesses = 0;
            Console.WriteLine("Guess a number between 1-100");
            int numberGuess = Convert.ToInt32(Console.ReadLine());
            

            //int lastNumberGuessed = 0;
            
            //while the number you guess doesnt equal the computers random generated number,
            //run the loop
            while (numberGuess != magicNumber)
            {
                
                if (magicNumber<numberGuess)
                {
                    Console.WriteLine("You need to guess lower!");
                    totalGuesses++;
                    Console.WriteLine("Keep guessing!");
                    numberGuess = Convert.ToInt32(Console.ReadLine());
                    
                }
                else
                {
                    Console.WriteLine("You need to guess higher!"); 
                    
                    //increment the total guesses and tell you to keep guessing if you dont get it
                    totalGuesses++;
                    Console.WriteLine("Keep guessing!");
                    numberGuess = Convert.ToInt32(Console.ReadLine());
                    
                }

            }
            //if you guess the number you got it!
            Console.WriteLine("You got it!");
            Console.WriteLine(totalGuesses);
            Console.WriteLine("It took you " + totalGuesses + " tries.");
        }
    }
}
