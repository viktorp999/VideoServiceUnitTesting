using System.Collections.Generic;

namespace VideoService.Core
{
    public interface IVideoRepository
    {
        IEnumerable<Video> GetUnprocessedVideos();
    }
}
