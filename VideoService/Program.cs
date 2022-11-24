using System;

namespace VideoService
{
    class Program
    {
        static void Main(string[] args)
        {
            VideoService videoservice = new VideoService();

            Console.WriteLine("Unprocessed videos from database:");
            Console.WriteLine();
            Console.WriteLine(videoservice.GetVideosIDs());
            Console.ReadLine();
        }
    }
}
