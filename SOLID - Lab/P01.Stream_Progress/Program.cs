using P01.Stream_Progress.Interefaces;
using System;
using System.Collections.Generic;

namespace P01.Stream_Progress
{
    public class Program
    {
        static void Main()
        {

            List<IStreamable> streams = new List<IStreamable>
            {
                new File("fileStream", 5, 10),
                new Music("musicStream", "current", 10, 10)
            };

            StreamProgressInfo streamProgressInfo;
            
            foreach (var streamInfo in streams)
            {
                streamProgressInfo = new StreamProgressInfo(streamInfo);
                Console.WriteLine(streamProgressInfo.CalculateCurrentPercent());
            }
        }
    }
}
