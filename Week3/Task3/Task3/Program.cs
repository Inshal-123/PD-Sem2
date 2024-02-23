using System;
using System.Collections.Generic;
using System.Linq;

namespace Shiritori
{

    class Program
    {
        static void Main(string[] args)
        {
            Shiritori shiritori = new Shiritori();
            Console.WriteLine("Enter words to play. Type 'exit' to end the game.");

            while (!shiritori.game_over)
            {
                Console.Write("Enter a word: ");
                string word = Console.ReadLine().Trim();

                if (word.ToLower() == "exit")
                {
                    break;
                }

                Console.WriteLine(string.Join(", ", shiritori.Play(word)));
            }
        }
    }
}