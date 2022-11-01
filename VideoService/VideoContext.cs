using System.Data.Entity;

namespace VideoService
{
    public class VideoContext : DbContext
    {
        public DbSet<Video> Videos { get; set; }
    }
}
