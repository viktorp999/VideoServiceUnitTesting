using System.Data.Entity;

namespace VideoService.VDbContext
{
    public class VideoContext : DbContext
    {
        public DbSet<Video> Videos { get; set; }
    }
}
