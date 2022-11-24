using System.Collections.Generic;
using System.Linq;
using VideoService.VDbContext;
using VideoService.Core;

namespace VideoService.Repository
{
    public class VideoRepository : IVideoRepository
    {
        public IEnumerable<Video> GetUnprocessedVideos()
        {
            using (VideoContext context = new VideoContext())
            {
                var videos = (from video 
                              in context.Videos 
                              where !video.IsProcessed 
                              select video).ToList();

                return videos;
            }
        }
    }
}
