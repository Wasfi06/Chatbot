using CyberChatbotGUI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ChatbotGUI
{
    public partial class Form1 : Form
    {
        ChatbotEngine bot = new ChatbotEngine();
        bool nameCaptured = false;

        public Form1()
        {
            InitializeComponent();
            chatBox.ReadOnly = true;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            AudioPlayer.PlayGreeting();

            chatBox.AppendText("Bot: Welcome to the Cybersecurity Awareness Bot!\n");
            chatBox.AppendText("Bot: Please enter your name:\n\n");
        }

        private void sendButton_Click(object sender, EventArgs e)
        {
            string input = inputBox.Text.Trim();

            if (string.IsNullOrWhiteSpace(input))
            {
                MessageBox.Show("Please enter a message.");
                return;
            }

            chatBox.AppendText("You: " + input + "\n");

            if (!nameCaptured)
            {
                bot.SetUserName(input);
                chatBox.AppendText($"Bot: Welcome, {input}! Ask me anything about cybersecurity.\n\n");
                nameCaptured = true;
                inputBox.Clear();
                return;
            }

            // this is the chatbots noraml response
            string response = bot.GetResponse(input);
            chatBox.AppendText("Bot: " + response + "\n\n");

            inputBox.Clear();
        }
    }
}
 