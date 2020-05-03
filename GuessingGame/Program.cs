using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace GuessingGame
{
    class Program
    {
        static void Main(string[] args)
        {
            const int MAXGUESS = 100;
            const int MINGUESS = 1;


            int randomNumber = 0;
            int totalGuesses = 0;
            int currentGuess = 0;
            string userInput = "";
            bool newGame     = true;
            string replay    = "";
            bool validInput  = true;

            while (newGame == true)
            {
                Random rnd = new Random();
                randomNumber = rnd.Next(1, 101);
                WriteLine("\nA random number has been generated!");

                /*WriteLine("For testing, the random number is " + randomNumber +
                          ". Remember to comment this out before exiting.");*/

                Write("\nGuess a number between 1 and 100   "  );
                userInput = ReadLine();
                validInput = isNumeric(userInput);
                if (validInput)
                {
                    currentGuess = Convert.ToInt32(userInput);
                }

                while (currentGuess != randomNumber)
                {

                    if(validInput == false)
                    {
                        Write("\n\nYour guess must be a number between 1 and 100. Try again.  ");
                    }
                    else if((currentGuess < MINGUESS) || (currentGuess > MAXGUESS)){
                        Write("\n\nYour guess must be a number between 1 and 100. Try again.  ");
                    }

                    else if ( currentGuess < randomNumber)
                    {
                        Write("\nToo low. Try another number!   ");
                        totalGuesses++;
                    }
                    else
                    {
                        Write("\nToo high. Try another number!   ");
                        totalGuesses++;
                    }
                    userInput = ReadLine();
                    validInput = isNumeric(userInput);
                    if (validInput)
                    {
                        currentGuess = Convert.ToInt32(userInput);
                    }
                }

                Write("\n\n" + currentGuess + " was correct! You made " + totalGuesses + " guesses." + 
                      "\nWould you like to try again (Y/N)?   ");
                replay = ReadLine();
                while ((replay != "Y") && (replay != "y") && (replay != "n") && (replay != "N"))
                {
                    Write("\n\nInvalid input please enter Y or N   ");
                    replay = ReadLine();
                }

                if((replay == "Y") || (replay == "y"))
                {
                    WriteLine("\n\n\nRestarting Game\n\n\n");
                    newGame = true;
                    totalGuesses = 0;
                }
                else
                {
                    WriteLine("\n\n\nThank you for playing\n\n\n");
                    newGame = false;
                    ReadLine();
                }
            }

        }

        private static bool isNumeric(String input)
        {
            double test;
            return double.TryParse(input, out test);  //Return true if the input can converted to a double
        }
    }
}
