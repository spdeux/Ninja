using Ninja.Mocking.Models;
using System.Collections.Generic;

namespace Ninja.Mocking
{
    public interface IVideoRepository
    {
        IEnumerable<Video> GetUnprocessedVideos();
    }
}