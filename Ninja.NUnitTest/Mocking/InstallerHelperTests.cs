using Moq;
using Ninja.Mocking;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace Ninja.NUnitTest
{

    public class InstallerHelperTests
    {
        private Mock<IFileDownloader> _fileDownloader;
        private InstallerHelper _installHelper;

        [SetUp]
        public void SetUp()
        {
            _fileDownloader = new Mock<IFileDownloader>();
            _installHelper = new InstallerHelper(_fileDownloader.Object);
        }


        [Test]
        public void DownloadInstaller_DownloadCompletes_ReturnTrue()
        {
            //Act
            var result = _installHelper.DownloadInstaller("customer", "installer");

            //Assert
            Assert.That(result, Is.True);
        }

        [Test]
        public void DownloadInstaller_DownloadFails_ReturnFalse()
        {
            //Arrange
            //First Solution:this way is correct but we don't actually access to arguments in real Enterprise applicaion
            //_fileDownloader.Setup(fd => fd.DownloadFile("http://example.com/customer/installer", null)).Throws<WebException>();

            //Second Solution
            _fileDownloader.Setup(fd => fd.DownloadFile(It.IsAny<string>(), It.IsAny<string>())).Throws<WebException>();

            //Act
            var result = _installHelper.DownloadInstaller("customer", "installer");

            //Assert
            Assert.That(result, Is.False);
        }
    }
}
