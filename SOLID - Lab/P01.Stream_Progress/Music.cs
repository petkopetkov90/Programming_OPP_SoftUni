using P01.Stream_Progress.Interefaces;

namespace P01.Stream_Progress
{
    public class Music : IStreamable
    {

        public Music(string artist, string album, int length, int bytesSent)
        {
            Artist = artist;
            Album = album;
            Length = length;
            BytesSent = bytesSent;
        }
        public string Artist { get; private set; }

        public string Album { get; private set; }

        public int Length { get; private set; }

        public int BytesSent { get; private set; }
    }
}
