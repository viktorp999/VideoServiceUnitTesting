using NUnit.Framework;
using System;
using Moq;
using System.Collections.Generic;
using VideoService.Core;

namespace VideoService.UnitTests
{
    [TestFixture]
    public class VideoServiceTests
    {
        private VideoService _videoservice;
        private Mock<IVideoFileReader> _videoreader;
        private Mock<IVideoRepository> _videorepository;

        [SetUp]
        public void SetUp()
        {
            _videoreader = new Mock<IVideoFileReader>();
            _videorepository = new Mock<IVideoRepository>();
            _videoservice = new VideoService(_videoreader.Object, _videorepository.Object);
        }

        [Test]
        public void ReadVideoTitle_EmptyFile_ReturnError()
        {
            _videoreader.Setup(vr => vr.ReadVideoFile("viteo.txt")).Returns("");

            var result = _videoservice.ReadVideoTitle();

            Assert.That(result, Does.Contain("error").IgnoreCase);
        }

        [Test]
        public void GetUnprocessedVideosAsCsv_AllVideosAreProcessed_ReturnEmptyString()
        {
            _videorepository.Setup(r => r.GetUnprocessedVideos()).Returns(new List<Video>());

            var result = _videoservice.GetUnprocessedVideosAsCsv();

            Assert.That(result, Is.EqualTo(""));
        }

        [Test]
        public void GetUnprocessedVideosAsCsv_FewVideosAreUnProcessed_ReturnStringWithIDOfUnprocessedVideos()
        {
            _videorepository.Setup(r => r.GetUnprocessedVideos()).Returns(new List<Video>
            {
                new Video {ID = 1},
                new Video {ID = 2},
                new Video {ID = 3}
            }
            );
          
            var result = _videoservice.GetUnprocessedVideosAsCsv();

            Assert.That(result, Is.EqualTo("1,2,3"));
        }
    }
}
