using System.Data.Entity;

namespace VideoService.VDbContext
{
    public class VideoContext : DbContext
    {
        public VideoContext()
            :base("name=VideoConnection")
        {

        }

        public DbSet<Video> Videos { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Video>()
                .HasKey(c => c.ID);

            modelBuilder.Entity<Video>()
                .Property(c => c.Title)
                .IsRequired()
                .HasMaxLength(255);

            modelBuilder.Entity<Video>()
                .Property(c => c.IsProcessed)
                .IsRequired();
                
            base.OnModelCreating(modelBuilder);
        }
    }
}
