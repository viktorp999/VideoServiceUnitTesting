using System.Collections.Generic;
using System.Linq;

namespace VideoService
{
    public class VideoRepository : IVideoRepository
    {
        public IEnumerable<Video> GetUnprocessedVideos()
        {
            using (VideoContext context = new VideoContext())
            {
                var videos = (from video in context.Videos where !video.IsProcessed select video).ToList();

                return videos;
            }
        }
    }
}
