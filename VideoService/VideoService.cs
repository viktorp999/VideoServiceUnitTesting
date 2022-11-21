using System;
using System.Collections.Generic;
using VideoService.Core;
using VideoService.Repository;
using VideoService.FileReader;

namespace VideoService
{
    public class VideoService
    {
        private IVideoFileReader _videoreader;
        private IVideoRepository _videorepository;

        public VideoService(IVideoFileReader videoreader = null, IVideoRepository videorepository = null)
        {
            _videoreader = videoreader ?? new VideoFileReader();
            _videorepository = videorepository ?? new VideoRepository();
        }

        public string ReadVideoTitle()
        {
            var title = _videoreader.ReadVideoFile("video.txt");
            Video video = null;

            if (video == null)
            {
                return "Error";
            }

            return video.Title;
        }

        public string GetUnprocessedVideosAsCsv()
        {
            List<int> videosID = new List<int>();
            var videos = _videorepository.GetUnprocessedVideos();

            foreach(var v in videos)
            {
                videosID.Add(v.ID);
            }

            return String.Join(",", videosID);
        }
    }
}
