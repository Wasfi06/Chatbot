using System;

namespace CSAI.Chatbot
{
    public class ChatbotEngine
    {
        private string userName;

        public void StartChat()
        {
            Console.Write("\nEnter your name: ");
            userName = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(userName))
            {
                userName = "User";
            }

            Console.WriteLine($"\nWelcome, {userName}! I'm your Cybersecurity Awareness Assistant.\n");

            while (true)
                //as long as the user enters something other than "exit" the system will respond
            {
                Console.Write("You: ");
                string input = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(input))
                {
                    Console.WriteLine("Bot: Please enter something.\n");
                    continue;
                }

                string response = GetResponse(input.ToLower());
                Console.WriteLine("Bot: " + response + "\n");
            }
        }

        private string GetResponse(string input)
        {
            //these are the chatbots series if responses
            if (input.Contains("how are you"))
                return "I'm just a bot, but I'm here to help you stay safe online!";

            else if (input.Contains("purpose"))
                return "My purpose is to educate you about cybersecurity and keep you safe online.";

            else if (input.Contains("password"))
                return "Use strong passwords with a mix of letters, numbers, and symbols.";

            else if (input.Contains("phishing"))
                return "Be cautious of emails asking for personal information. Always verify the sender.";

            else if (input.Contains("safe browsing"))
                return "Only visit secure websites (https) and avoid clicking suspicious links.";

            else if (input.Contains("exit"))
            {
                Environment.Exit(0);
                return string.Empty;
            }

            else
                return "I didn’t quite understand that. Could you rephrase?";
        }
    }
}
