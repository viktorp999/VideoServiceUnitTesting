using System.IO;
using VideoService.Core;

namespace VideoService.FileReader
{
    public class VideoFileReader : IVideoFileReader
    {
        public string ReadVideoFile(string path)
        {
            return File.ReadAllText(path);
        }
    }
}
