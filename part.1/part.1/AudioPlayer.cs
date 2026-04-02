using System.Media;
using System.IO;

namespace CSAI.Audio
{
    public static class AudioPlayer
    {
        public static void PlayGreeting()
        {
            string path = "C:\\Users\\inert\\source\\repos\\part.1\\part.1\\Assets\\ChatWasfi.wav";

            if (File.Exists(path))
            {
                SoundPlayer player = new SoundPlayer(path);
                player.PlaySync();
            }
        }
    }
}
