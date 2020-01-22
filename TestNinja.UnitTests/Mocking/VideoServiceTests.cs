using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestNinja.Mocking;

namespace TestNinja.UnitTests.Mocking
{
    [TestFixture]
    class VideoServiceTests
    {
        private Mock<IFileReader> _fileReader;
        private VideoService _videoService;
        private Mock<IVideoRepository> _repository;

        [SetUp]
        public void SetUp()
        {
            //fake fileReader object
            _fileReader = new Mock<IFileReader>();
            //fake videoRepository object
            _repository = new Mock<IVideoRepository>();
            //new instance of videoservice with fake fr and vr object
            _videoService = new VideoService(_fileReader.Object, _repository.Object);

        }

        [Test]
        public void ReadVideoTitle_EmptyFile_ReturnError()
        {

            _fileReader.Setup(fr => fr.Read("video.txt")).Returns("");

            var result = _videoService.ReadVideoTitle();

            Assert.That(result, Does.Contain("error").IgnoreCase);
        }

        // [] => ""
        // [{} {} {}] => "1,2,3"
        [Test]
        public void GetUnprocessedVideosAsCsv_AllprocessedVideos_ReturnsEmptyString()
        {
            _repository.Setup(vr => vr.GetUnprocessedVideos()).Returns(new List<Video>());

            var result = _videoService.GetUnprocessedVideosAsCsv();

            Assert.That(result, Is.EqualTo(""));

        }

        [Test]
        public void GetUnprocessedVideosAsCsv_AtLeastOneUnprocessedVideo_ReturnsNotEmptyString()
        {
            var videos = new List<Video>();
            videos.Add(new Video { Id = 1 });
            videos.Add(new Video { Id = 2 });
            videos.Add(new Video { Id = 3 });
            _repository.Setup(vr => vr.GetUnprocessedVideos()).Returns(videos);

            var result = _videoService.GetUnprocessedVideosAsCsv();

            Assert.That(result, Is.EqualTo("1,2,3"));

        }


    }
}
