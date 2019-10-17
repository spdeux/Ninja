using Microsoft.EntityFrameworkCore;
using Ninja.Mocking.Models;
using System;

namespace Ninja
{
    public class VideoContext : DbContext
    {
        public DbSet<Video> Videos { get; set; }
        public VideoContext()
        {

        }
    }


}