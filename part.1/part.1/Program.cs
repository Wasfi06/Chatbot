using System;
using CSAI.Chatbot;
using CSAI.UI;
using CSAI.Audio;

namespace CSAI
{
    class Program
    {
        static void Main(string[] args)
        {
            //calling the other methods to the main method
            AudioPlayer.PlayGreeting();

            ConsoleUI.DisplayAsciiArt();

            ChatbotEngine chatbot = new ChatbotEngine();
            chatbot.StartChat();

            Console.ReadLine();
        }
    }
}
