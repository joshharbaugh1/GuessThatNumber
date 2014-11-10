using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HangManV2._0
{
    class Program
    {
        static void Main(string[] args)
        {
            Hangman();
            Console.ReadKey();
        }

        static void Hangman()
        {
            //declare the variable that we need to keep
            //track of
            int numberOfGuessesLeft = 7;
            List<string> wordBank = new List<string>() { "carrot", "nickleback" };
            Random rng = new Random();
            string wordToGuess = wordBank[rng.Next(0, wordBank.Count())];
            string lettersGuessed = string.Empty;
            bool playing = true;

            //this is the loop that drives the game
            while (playing)
            {
                DisplayRoundInfo(lettersGuessed, wordToGuess, numberOfGuessesLeft);
                string input = GetUserInput(lettersGuessed);
                if (input.Length == 1)
                {
                    //its a letter guess, add it to the lettersGuessed string
                    lettersGuessed += input;
                    //see if the guess is in the word
                    if (wordToGuess.ToLower().Contains(input.ToLower()))
                    {
                        //its a correct guess!
                        //check to see if they've guessed all letters
                        if (!GetMaskedWord(lettersGuessed, wordToGuess).Contains("_"))
                        {
                            //they've guessed all the letters, way to go
                            playing = false;
                        }
                    }
                    else
                    {
                        //incorrect guess, subtract a guess
                        numberOfGuessesLeft--;
                        playing = (numberOfGuessesLeft > 0);
                    }

                }
                else
                {
                    //its a word guess
                    if (input.ToLower() == wordToGuess.ToLower())
                    {
                        //its a match!
                        playing = false;
                    }
                    else
                    {
                        numberOfGuessesLeft--;
                        playing = (numberOfGuessesLeft > 0);    
                    }
                }
            }
            //game ended, decide if they won or lost
            if(numberOfGuessesLeft > 0)
            {
                Console.WriteLine("You won, way to go boss");
            }
            else
            {
                Console.WriteLine("You really suck at this game...");
            }

        }

        static void DisplayRoundInfo(string lettersGuessed, string wordToGuess, int numberOfGuessesLeft)
        {
            //before any output; clear the screen
            Console.Clear();
            Console.WriteLine(GetMaskedWord(lettersGuessed, wordToGuess));
            Console.WriteLine("# of guesses left: " + numberOfGuessesLeft);
            Console.WriteLine("Letters guessed: " + lettersGuessed.ToUpper());

        }
        static string GetMaskedWord(string lettersGuessed, string wordToGuess)
        {
            string returnString = string.Empty;
            //loop over every letter of the word
            //they need to guess
            for(int i = 0; i < wordToGuess.Length; i++)
            {
                //get the current letter from the word they
                //need to guess, lowercase style
                string currentLetter = wordToGuess[i].ToString().ToLower();
                if(lettersGuessed.ToLower().Contains(currentLetter))
                {
                    returnString += currentLetter + " ";
                }
                else
                {
                    //not guessed the letter
                    returnString += "_ ";
                }
            }
            //loop complete
            return returnString;
        }

        static string GetUserInput(string lettersGuessed)
        {
            //delcare a variable to hold our input
            string returnString;
            bool isValid = true;
            do
            {
                Console.WriteLine("Enter a guess: ");
                returnString = Console.ReadLine();
                if (returnString.Length == 0)
                {
                    Console.WriteLine("You need to enter a guess");
                    isValid = false;
                }
                else if (returnString.Length == 1)
                {
                    isValid = char.IsLetter(returnString[0]);
                    if (isValid)
                    {
                        //make sure that letter has not
                        //been guessed
                        isValid = !(lettersGuessed.ToLower().Contains(returnString.ToLower()));
                    }
                }

            } while (isValid == false);
            return returnString;
        }
    }
}
