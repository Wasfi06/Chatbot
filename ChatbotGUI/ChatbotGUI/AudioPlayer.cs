using System.Media;
using System.IO;

namespace CyberChatbotGUI
{
    public static class AudioPlayer
    {
        public static void PlayGreeting()
        {
            string path = "C:\\Users\\inert\\source\\repos\\ChatbotGUI\\ChatbotGUI\\Assets\\ChatWasfi.wav";

            if (File.Exists(path))
            {
                SoundPlayer player = new SoundPlayer(path);
                player.PlaySync();
            }
        }
    }
}
