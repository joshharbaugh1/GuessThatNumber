using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HangMan
{
    class Program
    {
        static List<string> wordsToPickFrom = new List<string> { "apple", "waffle", "coding", "seedpaths" };
        static int numberOfGuesses = 7;

        static void Main(string[] args)
        {
            //ask user to enter their name in order to start playing

            //gives instructions
            Console.WriteLine("Let's play HANGMAN! Enter your name to play!");
            Console.ReadLine();
            Console.WriteLine("Keep guessing letters in order to solve the puzzle, you have 6 guesses.");
            Console.WriteLine("You may also solve the puzzle by typing in the entire word.");
            Random rng = new Random();
            HangMan(wordsToPickFrom[rng.Next(0,wordsToPickFrom.Count())]);
            Console.ReadKey();
        }

        static void HangMan(string thisWord)
        {
            int correctLetterCounter = 0;
            string currentGuess = "";
            string wrongLetters = "";
            bool playing = true;
            string magicWord = "";
            string lettersGuessed = ""; 
            foreach (char thischar in thisWord)
            {
                magicWord += "_";
                
            }
            while (playing)
            {
                PrintThatStuff(unMask(lettersGuessed, thisWord), numberOfGuesses);
                string thisGuess = getInput(currentGuess);
                if (thisGuess.Length > 1)
                {
                    // Word Guess
                    if (thisGuess == magicWord)
                    {
                        Console.WriteLine("You Win!");
                        playing = false;
                    }
                    else
                    {
                        numberOfGuesses--;
                        if (numberOfGuesses == 0)
                        {
                            Console.WriteLine("God...your stupid");
                            Console.ReadKey();
                            playing = false;
                        }
                    
                
                    //loop through the magic word
                  
                    }   
                }
                else
                {
                    // Single character guess
                    lettersGuessed += thisGuess;
                    if(thisWord.Contains(thisGuess))
                    {
                        // Correct Guess
                        correctLetterCounter++;

                        // Check if last letter was guessed
                        bool winner = true;
                        for (int i = 0; i < thisWord.Length; i++)
                        {
                            if (!(thisWord[i].ToString().ToLower().Contains(lettersGuessed))) { winner = false; }
                        }

                        // Check for the win condition
                        if(winner) {
                            playing=false;
                            Console.Write("You win! You still had " + numberOfGuesses + " left");
                            Console.ReadKey();
                            Console.WriteLine("Good Job!");
			
                            winner=false;
                        }
                        else
                        {

                        }

                    }
                    else
                    {
                        // Incorrect Guess
                        numberOfGuesses--;
                        wrongLetters += thisGuess;
                        if(numberOfGuesses == 0)
                        {
                            Console.WriteLine("You Lost");
                            Console.ReadKey();
                            playing = false;
                        }
                    }
                }

            }
            Console.ReadKey();
        }
        static string getInput(string letterGuessed)
        {
            string alphabet = "abcdefghijklmnopqrstuvwxyz";
            Console.WriteLine("Take a guess");
            while (true)
            {
                string userInput = Console.ReadLine();
                if (!(userInput.Length > 1))
                {
                    // One letter guess
                    if (alphabet.Contains(userInput.ToLower()) && !letterGuessed.Contains(userInput))
                    {
                        return userInput;
                    }
                    else if (alphabet.Contains(userInput.ToLower()))
                    {
                        if (letterGuessed.Contains(userInput))
                        {
                            Console.WriteLine("You already guessed that letter.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Invalid input.");
                    }
                    

                }
                else
                {
                    // More than one character guess

                    // Check if the word guess contains an invalid character
                    if (alphabet.Contains(userInput.ToLower()))
                    {
                        // valid characters in the word
                        return userInput;
                    }
                    else
                    {
                        // invalid input again
                        Console.WriteLine("Invalid input.");
                    }
                }
               
            }
        }
        static void PrintThatStuff(string maskedword, int numberofguesses)
        {
            Console.Clear();
            Console.WriteLine("You have {0} guesses remaining", numberofguesses);
            Console.WriteLine(maskedword);
        }
        static string unMask(string letter, string wordToMask)
        {
            string maskedString = "";
            for (int i = 0; i < wordToMask.Length; i++ )
            {
                if(letter.Contains(wordToMask[i]))
                {
                    maskedString += wordToMask[i];
                }

                else
                {
                    maskedString += "_ ";
                }
            }
                return maskedString;
        }
    }
}
