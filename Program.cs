using System;
using System.Text;
using static System.Console;
using System.IO;
using System.Collections.Generic;
namespace Hangman
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool run = true;
            string input, answer;
            char guessedChar;
            int i,j,numberOfGuesses=10;
            List<string> guessedList = new List<string>();

            //read words from file and put in array
            //StreamReader wordlistTxt = new StreamReader("wordlist.txt");
            //string[] wordlist= ReadAllLines("wordlist.txt");

            string[] wordlist = new string[] { "car", "boat", "fly", "heat", "cat","ratatat" };

            
            //select random word.

            var random = new Random();
            int maxValue = wordlist.Length + 1;
            int rnd = random.Next(0,maxValue);
            answer = wordlist[rnd];

            //make a string of * to show number of letters in answer

            char[] answerAsCharArray = answer.ToCharArray();
            char[] answerDisplay = new char[answerAsCharArray.Length];

            for( i=0;i<answerAsCharArray.Length;i++)
            {
                answerDisplay[i] = '_';
            }

            //Stringbuilder, use it to collect every guess and display

            StringBuilder guessedLetters = new StringBuilder(11);
            do
            {
                while (numberOfGuesses>0)
                {
                    //Check if the puzzle have been solved, if it has
                    string checkAnswer = new string(answerDisplay);
                    if (checkAnswer == answer)
                    {
                        WriteLine("You Win!");
                        run = false;
                        numberOfGuesses = 0;
                        break;
                    }
                    else
                    {
                        Clear();
                        WriteLine("Guess the word!");

                        //Display number of letters in word
                        WriteLine(answerDisplay);

                        //Display previously guessed letters
                        WriteLine(guessedLetters);

                        WriteLine($"Guesses left:{ numberOfGuesses.ToString() }\n1. Guess a letter.\n2. Solve word");
                        input = ReadLine();
                        switch (input)
                        {
                            ///////////////////////////////
                            case "1":
                                numberOfGuesses--;
                                WriteLine("Guess a letter: ");
                                input = ReadLine();
                                guessedChar = ConvertToChar(input);
                                for (j = 0; j < answerAsCharArray.Length; j++)
                                {
                                    if (guessedChar == answerAsCharArray[j])
                                    {
                                        answerDisplay[j] = guessedChar;
                                    }
                                    else { }
                                }
                                if (guessedList.Contains(input) == true)
                                {
                                    numberOfGuesses++;
                                }
                                else
                                {
                                    guessedList.Add(input);
                                }
                                guessedLetters.Append(guessedChar);
                                break;

                            ///////////////////////////////
                            
                            case "2":
                                input = ReadLine();
                                if (input == answer)
                                {
                                    WriteLine("You Win!");
                                    run = false;
                                    numberOfGuesses = 0;
                                    break;
                                }
                                else
                                {
                                    numberOfGuesses--;
                                }
                                break;
                            ///////////////////////////////
                            default:
                                WriteLine("Invalid choice, try again...");
                                ReadLine();
                                break;
                        }
                    }
                }
                //game is over, end loop.
               // run = false;
            
            } while (run == true);

            WriteLine("Thank you for playing.");
            ReadLine();
        }
        public static char ConvertToChar(string input)
        {
            char result;
           // Not sure how this conversion would fail, but I didn't realize that until after I wrote it. 
            while(char.TryParse(input, out result) == false)
            {
                WriteLine("Invalid input. Try again!");
                input=ReadLine();
            }
            return result;
        }
    }
}