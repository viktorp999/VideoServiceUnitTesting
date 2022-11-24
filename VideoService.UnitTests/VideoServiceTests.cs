using NUnit.Framework;
using Moq;
using System.Collections.Generic;
using VideoService.Core;

namespace VideoService.UnitTests
{
    [TestFixture]
    public class VideoServiceTests
    {
        private VideoService _videoservice;
        private Mock<IVideoRepository> _videorepository;

        [SetUp]
        public void SetUp()
        {
            _videorepository = new Mock<IVideoRepository>();
            _videoservice = new VideoService(_videorepository.Object);
        }

        [Test]
        public void GetUnprocessedVideosAsCsv_AllVideosAreProcessed_ReturnEmptyString()
        {
            _videorepository.Setup(r => r.GetUnprocessedVideos()).Returns(new List<Video>());

            var result = _videoservice.GetVideosIDs();

            Assert.That(result, Is.EqualTo(""));
        }

        [Test]
        public void GetUnprocessedVideosAsCsv_FewVideosAreUnProcessed_ReturnStringWithIDsOfUnprocessedVideos()
        {
            _videorepository.Setup(r => r.GetUnprocessedVideos()).Returns(new List<Video>
            {
                new Video {ID = 1},
                new Video {ID = 2},
                new Video {ID = 3}
            });
          
            var result = _videoservice.GetVideosIDs();

            Assert.That(result, Is.EqualTo("1,2,3"));
        }
    }
}
