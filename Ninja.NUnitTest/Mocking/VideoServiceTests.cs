using Moq;
using Ninja.Mocking;
using Ninja.Mocking.Models;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ninja.NUnitTest
{
    public class VideoServiceTests
    {
        private Mock<IFileReader> _fileReader;
        private VideoService _videoService;
        private Mock<IVideoRepository> _videoRepository;

        [SetUp]
        public void SetUp()
        {
            _fileReader = new Mock<IFileReader>();
            _videoRepository = new Mock<IVideoRepository>();
            _videoService = new VideoService(_fileReader.Object, _videoRepository.Object);
        }


        [Test]
        public void ReadVideoTitle_EmptyFile_ReturnError()
        {
            //Arrange
            _fileReader.Setup(fr => fr.Read("video.txt")).Returns("");//in this step, we should setup a method


            //Act
            var result = _videoService.ReadVideoTitle();

            //Assert
            Assert.That(result, Does.Contain("error").IgnoreCase);

        }

        [Test]
        public void GetUnprocessedVideoAsCsv_AllVideosAreProcessed_ReturnEmptyString()
        {
            //Arrange
            _videoRepository.Setup(vr => vr.GetUnprocessedVideos()).Returns(new List<Video>());

            //Act
            var result = _videoService.GetUnprocessedVideoAsCsv();

            //Assert
            Assert.That(result, Is.EqualTo(""));
        }


        [Test]
        public void GetUnprocessedVideoAsCsv_FewUnProcessedVideos_ReturnStringOfUnProcessedVideoIds()
        {
            //Arrange
            _videoRepository.Setup(vr => vr.GetUnprocessedVideos()).Returns(new List<Video>() {
             new Video(){Id=1},
             new Video(){Id=2}
            });

            //Act
            var result = _videoService.GetUnprocessedVideoAsCsv();

            //Assert
            Assert.That(result, Is.EqualTo("1,2"));
        }
    }
}
