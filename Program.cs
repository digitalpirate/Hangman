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
            int i,j;
            //StreamReader wordlistTxt = new StreamReader("wordlist.txt");
            //string[] wordlist= ReadAllLines("wordlist.txt");

            string[] wordlist = new string[] { "car", "boat", "fly", "heat", "cat","ratatat" };
            
            //read words from file and put in array

            //select random word.
            var random = new Random();
            int rnd = random.Next(0,wordlist.Length);
            answer = wordlist[rnd];
            char[] answerAsCharArray = answer.ToCharArray();
            char[] answerDisplay = new char[answerAsCharArray.Length];
            for( i=0;i<answerAsCharArray.Length;i++)
            {
                answerDisplay[i] = '*';
            }
            
            StringBuilder guessedLetters = new StringBuilder(11);

                //Stringbuilder, use it to collect every guess and display

            //Stringbuilder, make a string of - to show number of letters in answer

            do
            {
                for ( i = 10; i > 0; i--)
                {

                    WriteLine("Guess the word!");
                    //Display number of letters in word

                    //Display previously guessed letters
                    WriteLine(answerDisplay);
                    WriteLine(guessedLetters);
                    WriteLine($"Guesses left:{ i.ToString() }\n1. Guess a letter.\n2.Solve word");
                    input = ReadLine();
                    switch (input)
                    {
                        case "1":
                            WriteLine("Guess a letter: ");
                            
                            input = ReadLine();
                            guessedChar = ConvertToChar(input);
                            for (j = 0; j < answerAsCharArray.Length; j++)
                            {
                                if(guessedChar == answerAsCharArray[j])
                                {
                                    answerDisplay[j] = guessedChar;
                                }
                            }

                            if (answerDisplay.ToString() == answer)
                            {
                                WriteLine("You Win!");
                                run = false;
                                i = 0;
                                break;
                            }

                            guessedLetters.Append(guessedChar);


                            break;
                        case "2":
                            input = ReadLine();
                            if(input == answer)
                            {
                                WriteLine("You Win!");
                                run = false;
                                i = 0;
                                break;
                            }
                            break;
                        default:
                            WriteLine("invalid");
                            break;
                    }
                }
                run = false;
            } while (run == true);
            WriteLine("Thank you for playing.");
        }
        public static char ConvertToChar(string input)
        {
            char result;
            while(char.TryParse(input, out result) == false)
            {
                WriteLine("Invalid input. Try again!");
                input=ReadLine();
            }

            return result;
        }
        
    }
}
