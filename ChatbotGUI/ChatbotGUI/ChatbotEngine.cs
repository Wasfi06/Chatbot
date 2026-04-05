using System;
using System.Collections.Generic;

namespace ChatbotGUI
{
    public class ChatbotEngine
    {
        private string userName = "User";

        private List<string> conversationHistory = new List<string>();
        private string lastTopic = "";
        private string userMood = "";

        public void SetUserName(string name)
        {
            if (!string.IsNullOrWhiteSpace(name))
                userName = name;
        }

        public string GetResponse(string input)
        {
            if (string.IsNullOrWhiteSpace(input))
                return "Please enter something.";

            input = input.ToLower().Trim();

            conversationHistory.Add(input);

            if (input.Contains("worried") || input.Contains("scared"))
                userMood = "worried";
            else if (input.Contains("happy") || input.Contains("good"))
                userMood = "positive";

            if (input.Contains("phishing"))
                lastTopic = "phishing";
            else if (input.Contains("password"))
                lastTopic = "password";
            else if (input.Contains("virus"))
                lastTopic = "virus";

            if (input.Contains("hello") || input.Contains("hi"))
                return $"Hello {userName}! How may I assist you today?";

            if (input.Contains("how are you"))
                return $"I am doing well, {userName}! I'm here to help you stay safe online.";

            if (input.Contains("phishing"))
                return "Phishing is a scam where attackers may trick you into giving your personal information. Always verify your emails.";

            if (input.Contains("password"))
                return "Use strong passwords with a mix of letters, numbers, and symbols and never reuse passwords.";

            if (input.Contains("virus"))
                return "Install antivirus software and avoid downloading unknown files.";

            if (input.Contains("what should i do"))
            {
                if (lastTopic == "phishing")
                    return "Since you're concerned about phishing, try avoiding suspicious emails and never click unknown links.";

                if (lastTopic == "password")
                    return "Since we have discussed passwords, use strong and unique passwords.";

                if (lastTopic == "virus")
                    return "Since you're worried about viruses, always keep your antivirus updated.";

                return "Can you tell me what specifically you're referring to?";
            }

            if (userMood == "worried")
                return "It's okay to feel worried. I'm here to help you stay safe online.";

            if (userMood == "positive")
                return "That's great to hear! Keep learning about cybersecurity.";

            return "I didn’t quite understand that. Could you rephrase?";
        }
    }
}
