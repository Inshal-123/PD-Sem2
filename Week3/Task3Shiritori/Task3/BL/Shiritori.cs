using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shiritori
{
    class Shiritori
    {
        public List<string> words;
        public bool game_over;

        public Shiritori()
        {
            words = new List<string>();
            game_over = false;
        }

        public List<string> Play(string word)
        {
            if (game_over)
            {
                Console.WriteLine("Game over.");
                return words;
            }

            if (words.Contains(word))
            {
                game_over = true;
                Console.WriteLine("Game over. Word has already been said.");
                return words;
            }

            if (words.Count > 0 && words.Last().Last() != word.First())
            {
                game_over = true;
                Console.WriteLine("Game over. Word does not match the rule.");
                return words;
            }

            words.Add(word);
            return words;
        }

        public string Restart()
        {
            words.Clear();
            game_over = false;
            return "Game restarted.";
        }
    }
}