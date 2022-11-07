using System.Collections.Generic;

namespace VideoService
{
    public interface IVideoRepository
    {
        IEnumerable<Video> GetUnprocessedVideos();
    }
}
