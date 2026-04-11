using System;
using System.IO;

namespace CSAI.UI
{
    public static class ConsoleUI
    {
        public static void DisplayAsciiArt()
        {
            Console.ForegroundColor = ConsoleColor.Cyan; //changes the colour of the cover page

            Console.WriteLine("=====================================");
            Console.WriteLine("   CYBERSECURITY AWARENESS BOT");
            Console.WriteLine("=====================================");

            Console.ResetColor();
        }
    }
}
