using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PacMan.UI
{
    class menuUI
    {
        public static char menu()
        {
            Console.Clear();
            Console.WriteLine("Press 1 to play new game");
            Console.WriteLine("Press 2 to play Previous game");
            Console.WriteLine("Press 3 to EXIT");
            char option = char.Parse(Console.ReadLine());
            return option;
        }

        public static void score(int score)
        {
            Console.Write("Total score: " + score);
        }
    }
}
