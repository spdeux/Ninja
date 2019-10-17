using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Ninja.Mocking.Models;

namespace Ninja.Mocking
{
    public class VideoRepository : IVideoRepository
    {
        public IEnumerable<Video> GetUnprocessedVideos()
        {
            IList<Video> videos;
            using (var context = new VideoContext())
            {
                videos = (from video in context.Videos
                          where !video.IsProcessed
                          select video).ToList();

            }

            return videos;
        }
    }
}
