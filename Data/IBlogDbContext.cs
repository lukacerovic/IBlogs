
using IBlogs.Models.Domain;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace IBlogs.Data
{
    public class IBlogDbContext : IdentityDbContext<Profile>
    {
        public IBlogDbContext(DbContextOptions options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.HasDefaultSchema("Identity");
            builder.Entity<Profile>(
                entity =>
                {
                    entity.ToTable(name: "User");
                }
                );
        }
        public DbSet<Profile> Profiles { get; set; }
        public DbSet<Posts> BlogPosts { get; set; }
        public DbSet <LikePost> LikePosts { get; set; }
        public DbSet<Comments> CommentPost { get; set; }
    }
}
