using System;

namespace P01.Stream_Progress
{
    public class Program
    {
        public static void Main()
        {
            //Music(string artist, string album, int length, int bytesSent)

            Music music = new Music("Sancak", "Yagmur", 4, 133);

            StreamProgressInfo streamProgress = new StreamProgressInfo(music);


        }
    }
}
