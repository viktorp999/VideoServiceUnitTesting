using System;
using System.Collections.Generic;
using VideoService.Core;
using VideoService.Repository;

namespace VideoService
{
    public class VideoService
    {
        private IVideoRepository _videorepository;

        public VideoService(IVideoRepository videorepository = null)
        {
            _videorepository = videorepository ?? new VideoRepository();
        }

        public string GetVideosIDs()
        {
            List<int> videosID = new List<int>();
            var videos = _videorepository.GetUnprocessedVideos();

            foreach (var v in videos)
            {
                videosID.Add(v.ID);
            }

            return String.Join(",", videosID);
        }
    }
}
