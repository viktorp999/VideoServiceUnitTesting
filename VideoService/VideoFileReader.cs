using System.IO;

namespace VideoService
{
    public class VideoFileReader : IVideoFileReader
    {
        public string ReadVideoFile(string path)
        {
            return File.ReadAllText(path);
        }
    }
}
